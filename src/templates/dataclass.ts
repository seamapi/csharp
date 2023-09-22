import { camelCase, snakeCase, pascalCase } from 'change-case'
import * as cs from '../codegen.js'
import {
  deepFlattenAllOfSchema,
  type AllOfSchema,
  type ObjSchema,
  type OneOfSchema,
  type PropertySchema,
  type RefSchema,
} from '@seamapi/nextlove-sdk-generator'
import assert from 'assert'
import { GLOBAL_NAMESPACE } from '../constants.js'

const FALLBACK_TYPE = new cs.TypeNode(cs.TokenNode.TYPE_OBJECT, true)

export type RouteInfo = {
  method_name: string
  path: string
  parameter_schema: ObjSchema
  response_obj_type: string | undefined
  response_arr_type: string | undefined
  nullable: boolean
  return_path: string
  namespace: string[]
}

export const DATA_CLASS_IMPORT_BLOCKS = new cs.StatementBlock([
  new cs.UsingStatement(['System', 'Runtime', 'Serialization']),
  new cs.UsingStatement(['Newtonsoft', 'Json']),
  new cs.UsingStatement(['Newtonsoft', 'Json', 'Converters']),
  new cs.UsingStatement(['Newtonsoft', 'Json', 'Linq']),
  new cs.UsingStatement(['JsonSubTypes']),
])

export const API_IMPORT_BLOCKS = new cs.StatementBlock([
  ...DATA_CLASS_IMPORT_BLOCKS.statements,
  new cs.UsingStatement([...GLOBAL_NAMESPACE, 'Client']),
  new cs.UsingStatement([...GLOBAL_NAMESPACE, 'Model']),
])

const wrapNamespace = (statements: cs.Statement[], namespace?: string[]) => {
  if (!namespace || namespace.length === 0) {
    return new cs.StatementBlock(statements)
  }

  return new cs.NamespaceBlock(
    new cs.NamespaceNode(namespace),
    statements.map((s) => new cs.StatementBlock([s])),
  )
}

export const generateDataclassFileForSchema = (
  name: string,
  schema: SupportedPropertySchema,
  resource_type: 'response' | 'request' | 'model',
  namespace?: string[],
) => {
  const className = pascalCase(name)

  const classes = generateDataclassesForSchema(
    className,
    schema,
    resource_type,
    namespace,
  )

  return {
    classFile: new cs.CSharpFile(
      [
        DATA_CLASS_IMPORT_BLOCKS,
        wrapNamespace(classes.classDefs, namespace),
      ].map((s) => new cs.StatementBlock([s])),
    ),
    name: className,
  }
}

export const generateDataclassFileForRoutes = (
  class_name: string,
  routes: RouteInfo[],
  namespace?: string[],
) => {
  const classStatements: cs.Statement[] = []

  const seamInterfaceType = new cs.TypeNode(new cs.TokenNode('ISeam'), false)
  const seamInterfaceName = new cs.TokenNode('_seam')

  const seamClient = new cs.FieldDeclaration(
    seamInterfaceType,
    seamInterfaceName,
    undefined,
    new cs.VisibilityModifiers(['private']),
  )

  const constructor = new cs.MethodDeclaration(
    undefined,
    new cs.MethodNode(new cs.TokenNode(class_name), [
      new cs.ParameterNode(
        new cs.TypeNode(new cs.TokenNode('ISeam')),
        new cs.TokenNode('seam'),
      ),
    ]),
    new cs.CurlyBlock([
      new cs.StatementBlock([
        new cs.AssignStatement(seamInterfaceName, new cs.TokenNode('seam')),
      ]),
    ]),
    new cs.VisibilityModifiers(['public']),
  )

  classStatements.push(seamClient, constructor)

  for (const route of routes) {
    const {
      method_name,
      path,
      response_obj_type,
      response_arr_type,
      parameter_schema,
      return_path,
      nullable,
    } = route

    const request = generateDataclassesForObjectOrRefSchema(
      pascalCase([method_name, 'request'].join('_')),
      parameter_schema,
      'request',
    )

    if (!response_obj_type && !response_arr_type) {
      // TODO: support non-named response types
      throw new Error('Invalid response type')
    }

    const responseType = new cs.TypeNode(
      response_arr_type
        ? new cs.TokenNodeGeneric('List', [
            new cs.TypeNode(
              new cs.TokenNode(pascalCase(response_arr_type)),
              nullable,
            ),
          ])
        : new cs.TokenNode(pascalCase(response_obj_type!), nullable),
    )

    const response = generateDataclassesForSchema(
      pascalCase([method_name, 'response'].join('_')),
      {
        type: 'object',
        required: [],
        properties: {
          [pascalCase(return_path)]: {
            $ref: responseType.serialize(new cs.CompilerCtx()),
            nullable,
          },
        },
      },
      'response',
    )

    const requestOptions = new cs.TokenNode('requestOptions')
    const requestObj = new cs.TokenNode('request')

    const getMethod = (isAsync: boolean) => {
      const asyncPostfix = isAsync ? 'Async' : ''

      const methodName = new cs.TokenNode(
        pascalCase(method_name) + asyncPostfix,
      )

      const wrapTypeTask = (type: cs.TypeNode) =>
        isAsync
          ? new cs.TypeNode(
              new cs.TokenNode('Task'),
              undefined,
              new cs.TypeArgumentsNode([type]),
            )
          : type

      const wrapAwait = (node: cs.CSharpNode) =>
        isAsync ? new cs.ParanthesisNode(new cs.AwaitNode(node)) : node

      const call = new cs.TokenNodeApplyFunction(
        new cs.AccessChain([
          seamInterfaceName,
          new cs.TokenNode('Post' + asyncPostfix),
        ]),
        [new cs.Literal(path), requestOptions],
        new cs.TypeArgumentsNode([
          new cs.TypeNode(new cs.TokenNode(response.className)),
        ]),
      )

      const result = new cs.AccessChain([
        wrapAwait(call),
        new cs.TokenNode('Data'),
        new cs.TokenNode(pascalCase(return_path)),
      ])

      const methodSimple = new cs.MethodDeclaration(
        wrapTypeTask(responseType),
        new cs.MethodNode(methodName, [
          new cs.ParameterNode(
            new cs.TypeNode(new cs.TokenNode(request.className)),
            requestObj,
          ),
        ]),
        new cs.CurlyBlock([
          new cs.StatementBlock([
            // var requestOptions = new RequestOptions();
            new cs.AssignStatement(
              new cs.CompositeNode([new cs.TokenNode('var'), requestOptions]),
              new cs.ApplyConstructorNode(
                new cs.TokenNode('RequestOptions'),
                [],
              ),
            ),
            // requestOptions.Data = request
            new cs.AssignStatement(
              new cs.AccessChain([requestOptions, new cs.TokenNode('Data')]),
              requestObj,
            ),
            // return seam.Post<responseType>(route, requestOptions).Data;
            new cs.ReturnStatement(result),
          ]),
        ]),
        new cs.VisibilityModifiers([
          'public',
          ...(isAsync ? ['async' as const] : []),
        ]),
      )

      const methodWithProperties = new cs.MethodDeclaration(
        wrapTypeTask(responseType),
        new cs.MethodNode(methodName, request.parameterDefs),
        new cs.CurlyBlock(
          [
            new cs.ReturnStatement(
              wrapAwait(
                new cs.TokenNodeApplyFunction(methodName, [
                  new cs.ApplyConstructorNode(
                    new cs.TokenNode(request.className),
                    request.parameterDefs.map(
                      (pd) =>
                        new cs.RawNode(`${pd.name.token}: ${pd.name.token}`),
                    ),
                  ),
                ]),
              ),
            ),
          ].map((s) => new cs.StatementBlock([s])),
        ),
        new cs.VisibilityModifiers([
          'public',
          ...(isAsync ? ['async' as const] : []),
        ]),
      )

      return [methodSimple, methodWithProperties]
    }

    classStatements.push(
      ...[
        ...request.classDefs,
        ...response.classDefs,
        ...getMethod(false),
        ...getMethod(true),
      ],
    )
  }

  const cl = new cs.Class(
    new cs.ClassDeclarationSpecifier(
      new cs.TokenNode(pascalCase(class_name)),
      undefined,
      new cs.VisibilityModifiers(['public']),
    ),
    classStatements.map((s) => new cs.StatementBlock([s])),
  )

  const extendedClass = new cs.Class(
    new cs.ClassDeclarationSpecifier(
      new cs.TokenNode('Seam'),
      undefined,
      new cs.VisibilityModifiers(['public', 'partial']),
    ),
    [
      new cs.StatementBlock([
        new cs.NodeStatement(
          new cs.CompositeNode([
            new cs.TokenNode('public'),
            new cs.AccessChain([
              new cs.TokenNode('Api'),
              new cs.TokenNode(pascalCase(class_name)),
            ]),
            new cs.TokenNode(pascalCase(class_name)),
            new cs.TokenNode('=>'),
            new cs.TokenNodeApplyFunction(new cs.TokenNode('new'), [
              new cs.TokenNode('this'),
            ]),
          ]),
        ),
      ]),
    ],
  )

  const extendedInterface = new cs.Class(
    new cs.ClassDeclarationSpecifier(
      new cs.TokenNode('ISeam'),
      undefined,
      new cs.VisibilityModifiers(['public', 'partial']),
      new cs.TokenNode('interface'),
    ),
    [
      new cs.StatementBlock([
        new cs.NodeStatement(
          new cs.CompositeNode([
            new cs.TokenNode('public'),
            new cs.AccessChain([
              new cs.TokenNode('Api'),
              new cs.TokenNode(pascalCase(class_name)),
            ]),
            new cs.TokenNode(pascalCase(class_name)),
            new cs.CurlyBlock(
              [new cs.NodeStatement(new cs.TokenNode('get'))].map(
                (s) => new cs.StatementBlock([s]),
              ),
            ),
          ]),
          false,
        ),
      ]),
    ],
  )

  return {
    classFile: new cs.CSharpFile(
      [
        API_IMPORT_BLOCKS,
        wrapNamespace([cl], namespace),
        wrapNamespace(
          [extendedClass, extendedInterface],
          [...GLOBAL_NAMESPACE, 'Client'],
        ),
      ].map((s) => new cs.StatementBlock([s])),
    ),
    className: class_name,
  }
}

type SupportedPropertySchema = Exclude<PropertySchema, AllOfSchema>

type GeneratedDataclassResult = {
  className: string
  classDefs: cs.Statement[]
  parameterDefs?: cs.ParameterNode[]
  propertyDefs?: cs.Statement[]
}

const generateDataclassesForSchema = (
  name: string,
  schema: SupportedPropertySchema,
  resource_type: 'response' | 'request' | 'model',
  namespace?: string[],
) => {
  if ('oneOf' in schema) {
    return generateDataclassesForOneOfSchema(
      name,
      schema,
      resource_type,
      namespace,
    )
  }

  if ('$ref' in schema || schema.type === 'object') {
    return generateDataclassesForObjectOrRefSchema(
      name,
      schema,
      resource_type,
      namespace,
    )
  }

  throw new Error(
    'Unsupported schema: ' +
      JSON.stringify(
        {
          schema,
          name,
        },
        null,
        2,
      ),
  )
}

const generateEnumDefs = (
  property_name: string,
  nullable: boolean,
  enumValues: (string | number)[],
  ty: 'number' | 'string',
  root_name: string,
) => {
  const enumName = pascalCase(property_name + 'Enum')

  const enumNode = new cs.Enum(
    new cs.EnumDeclarationSpecifier(
      new cs.TokenNode(enumName),
      new cs.VisibilityModifiers(['public']),
    ),
    enumValues
      .map(
        (enumValue, i) =>
          new cs.AnnotatedStatement(
            'EnumMember',
            new cs.AssignStatement(
              new cs.TokenNode(
                typeof enumValue === 'string'
                  ? pascalCase(enumValue)
                  : enumName + i.toString(),
              ),
              new cs.Literal(i),
              false,
            ),
            cs.AnnotatedStatement.getPropertyList({
              Value: new cs.Literal(enumValue),
            }),
          ),
      )
      .map((s) => new cs.StatementBlock([s])),
  )

  const enumDef =
    ty === 'string'
      ? new cs.AnnotatedStatement('JsonConverter', enumNode, [
          new cs.TokenNodeApplyFunction(new cs.TokenNode('typeof'), [
            new cs.TokenNode('StringEnumConverter'),
          ]),
        ])
      : enumNode

  const typeNode = new cs.TypeNode(
    root_name
      ? new cs.AccessChain([
          new cs.TokenNode(root_name),
          new cs.TokenNode(enumName),
        ])
      : new cs.TokenNode(enumName),
    nullable,
  )

  return {
    enumDef,
    typeNode,
    enumName,
  }
}

const generateDataclassesForObjectOrRefSchema = (
  name: string,
  schema: ObjSchema | RefSchema,
  resource_type: 'response' | 'request' | 'model',
  namespace?: string[],
  topLevelOptions: {
    enumOverrides?: Record<string, cs.CSharpNode>
    base?: cs.TokenNode
  } = {},
) => {
  const { enumOverrides: topLevelEnumOverrides, base } = topLevelOptions

  const extraFields = new Map<string, cs.Statement>()
  const extraClasses: cs.AnnotatedStatement<cs.Class>[] = []

  const required = 'required' in schema ? new Set(schema.required) : new Set()
  const properties =
    'properties' in schema ? Object.entries(schema.properties) : []

  const isSchemaObjectRecursive = (schema: PropertySchema[]): boolean => {
    return schema.every(
      (s) =>
        ('type' in s && s.type === 'object') ||
        ('allOf' in s && isSchemaObjectRecursive(s.allOf)) ||
        ('oneOf' in s && isSchemaObjectRecursive(s.oneOf)),
    )
  }

  const mapSchemaEnum = (
    property_name: string,
    nullable: boolean,
    enumValues: (string | number)[],
    ty: 'number' | 'string',
  ) => {
    const { enumDef, enumName, typeNode } = generateEnumDefs(
      property_name,
      nullable,
      enumValues,
      ty,
      name,
    )

    extraFields.set(enumName, enumDef)

    return typeNode
  }

  const mapOneOfType = (
    schema: OneOfSchema,
    property_name: string,
    nullable: boolean,
  ): cs.TypeNode => {
    if (!schema.discriminator) {
      if (schema.oneOf.every((s) => 'type' in s && s.type === 'string')) {
        // TODO: support union over date-time, uri, uuid
        return new cs.TypeNode(cs.TokenNode.TYPE_STRING, nullable)
      }

      console.warn(`OneOf not supported for ${name}, ${property_name}`)

      if (isSchemaObjectRecursive(schema.oneOf)) {
        return new cs.TypeNode(cs.TokenNode.TYPE_JOBJECT, nullable)
      }

      return FALLBACK_TYPE
    }

    const { classDefs, className } = generateDataclassesForOneOfSchema(
      property_name,
      schema,
      resource_type,
      namespace,
    )

    extraFields.set(className, new cs.StatementBlock(classDefs))

    return new cs.TypeNode(new cs.TokenNode(className), nullable)
  }

  const mapAllOfType = (
    schema: AllOfSchema,
    property_name: string,
    nullable: boolean,
  ): cs.TypeNode => {
    const flattened = deepFlattenAllOfSchema(schema)
    if (flattened != null) {
      return mapSchemaType(flattened, property_name, nullable)
    }

    console.warn(`AllOf not supported for ${name}, ${property_name}`)

    if (isSchemaObjectRecursive(schema.allOf)) {
      return new cs.TypeNode(cs.TokenNode.TYPE_JOBJECT, nullable)
    }

    return FALLBACK_TYPE
  }

  const mapSchemaType = (
    schema: PropertySchema,
    property_name: string,
    nullable: boolean,
  ): cs.TypeNode => {
    if ('$ref' in schema) {
      return new cs.TypeNode(new cs.TokenNode(schema.$ref), nullable)
    }

    if ('oneOf' in schema) {
      if (
        schema.oneOf.every((s) => 'type' in s && s.type === 'string' && s.enum)
      ) {
        schema = {
          type: 'string',
          enum: schema.oneOf.flatMap((s) => {
            assert('type' in s)

            if (s.type !== 'string') return []
            return s.enum ?? []
          }),
          ...schema,
        }
      } else {
        return mapOneOfType(schema, property_name, nullable)
      }
    }

    if ('allOf' in schema) {
      return mapAllOfType(schema, property_name, nullable)
    }

    switch (schema.type) {
      case 'string': {
        if (schema.enum && !topLevelEnumOverrides?.[property_name]) {
          return mapSchemaEnum(property_name, nullable, schema.enum, 'string')
        }

        return new cs.TypeNode(cs.TokenNode.TYPE_STRING, nullable)
      }
      case 'integer':
        if (schema.enum) {
          return mapSchemaEnum(property_name, nullable, schema.enum, 'number')
        }

        return new cs.TypeNode(cs.TokenNode.TYPE_INT, nullable)
      case 'boolean':
        return new cs.TypeNode(cs.TokenNode.TYPE_BOOLEAN, nullable)
      case 'object':
        if ('additionalProperties' in schema) {
          // TODO: support enums
          return FALLBACK_TYPE
        }

        const newClassName = pascalCase(name + pascalCase(property_name))

        const newClasses = generateDataclassesForObjectOrRefSchema(
          newClassName,
          schema,
          'model',
          namespace,
        )

        extraClasses.push(...newClasses.classDefs)

        return new cs.TypeNode(new cs.TokenNode(newClassName), nullable)
      case 'array':
        return new cs.TypeNode(
          new cs.TokenNodeGeneric('List', [
            mapSchemaType(
              schema.items,
              property_name,
              'nullable' in schema.items ? !!schema.items.nullable : false,
            ),
          ]),
          nullable,
        )
      case 'number':
        return new cs.TypeNode(cs.TokenNode.TYPE_FLOAT)
      default:
        console.warn(
          `Unknown type for class ${name}, property ${property_name} ${JSON.stringify(
            schema,
            null,
            2,
          )}`,
        )

        return new cs.TypeNode(cs.TokenNode.TYPE_OBJECT_CLASS)
    }
  }

  const mapTypeToProperty = ([property_name, schema]: [
    property_name: string,
    schema: PropertySchema,
  ]) => {
    const isRequired =
      required.has(property_name) && !('nullable' in schema && schema.nullable)

    const enumOverride = topLevelEnumOverrides?.[property_name]

    return new cs.AnnotatedStatement(
      'DataMember',
      new cs.PropertyDeclaration(
        mapSchemaType(
          schema,
          property_name,
          'nullable' in schema ? !!schema.nullable : !isRequired,
        ),
        new cs.TokenNode(pascalCase(property_name)),
        new cs.PropertyMethods({}, enumOverride ? undefined : {}),
        new cs.VisibilityModifiers([
          'public',
          ...(enumOverride ? ['override' as const] : []),
        ]),
        enumOverride,
      ),
      cs.AnnotatedStatement.getPropertyList({
        Name: new cs.Literal(snakeCase(property_name)),
        IsRequired: new cs.Literal(isRequired),
        EmitDefaultValue: new cs.Literal(false),
      }),
    )
  }

  const classNameToken = new cs.TokenNode(pascalCase(name))

  const jsonConstructor = new cs.AnnotatedStatement(
    'JsonConstructorAttribute',
    new cs.MethodDeclaration(
      undefined,
      new cs.MethodNode(classNameToken, []),
      new cs.CurlyBlock([]),
      new cs.VisibilityModifiers([
        properties.length > 0 ? 'protected' : 'public',
      ]),
    ),
  )

  if (pascalCase(name) === 'ActionAttempt') {
    console.log('action_attempt', { status_properties: properties[0]?.[1] })
  }

  const propertyDefs = properties.map(mapTypeToProperty)

  const parameterDefs = propertyDefs.map((pd) => {
    if (!pd.annotated.type)
      throw new Error(`No type for property def ${pd.annotated.token.token}`)

    return new cs.ParameterNode(
      pd.annotated.type,
      new cs.TokenNode(camelCase(pd.annotated.token.token)),
      new cs.TokenNode('default'),
    )
  })

  const constructors: cs.Statement[] = [jsonConstructor]

  if (propertyDefs.length > 0) {
    const publicConstructor = new cs.MethodDeclaration(
      undefined,
      new cs.MethodNode(classNameToken, parameterDefs),
      new cs.CurlyBlock([
        new cs.StatementBlock(
          propertyDefs.map(
            (pd) =>
              // FIXME: do non-null assertions here
              new cs.AssignStatement(
                new cs.TokenNode(pascalCase(pd.annotated.token.token)),
                new cs.TokenNode(camelCase(pd.annotated.token.token)),
              ),
          ),
        ),
      ]),
      new cs.VisibilityModifiers(['public']),
    )

    constructors.push(publicConstructor)
  }

  const data_contract_name = [
    ...(namespace && namespace.length > 0
      ? [camelCase(namespace.join('_'))]
      : []),
    camelCase(name),
    resource_type,
  ].join('_')

  const classDefs = [
    new cs.AnnotatedStatement(
      'DataContract',
      new cs.Class(
        new cs.ClassDeclarationSpecifier(
          classNameToken,
          base?.token,
          new cs.VisibilityModifiers(['public']),
        ),

        [...constructors, ...extraFields.values(), ...propertyDefs].map(
          (pd) => new cs.StatementBlock([pd]),
        ),
      ),
      cs.AnnotatedStatement.getPropertyList({
        Name: new cs.Literal(data_contract_name),
      }),
    ),
    ...extraClasses,
  ]

  return {
    className: name,
    classDefs,
    parameterDefs,
    propertyDefs,
  } satisfies GeneratedDataclassResult
}

const generateDataclassesForOneOfSchema = (
  name: string,
  schema: OneOfSchema,
  resource_type: 'response' | 'request' | 'model',
  namespace?: string[],
): GeneratedDataclassResult => {
  if (!schema.discriminator) {
    throw new Error(
      'OneOfSchema must have discriminator: ' + JSON.stringify(schema, null, 2),
    )
  }

  const { propertyName: discriminatedPropertyName } = schema.discriminator

  const objSchemas = schema.oneOf.map((s) => {
    if (!('type' in s && s.type === 'object')) {
      throw new Error('OneOfSchema must have object types')
    }

    const prop = s.properties[discriminatedPropertyName]

    if (
      !(
        prop &&
        'type' in prop &&
        prop.type === 'string' &&
        prop.enum &&
        prop.enum.length === 1
      )
    ) {
      throw new Error(
        'OneOfSchema must have string discriminator: ' +
          JSON.stringify(schema, null, 2),
      )
    }

    const specificName = prop.enum[0]!

    return [specificName, s] as const
  })

  const defs: cs.Statement[] = []

  const specifiedClassDefs: cs.Statement[] = []
  const specifiedClassNames: [string, string][] = []

  const propertyDeclaration = new cs.PropertyDeclaration(
    new cs.TypeNode(cs.TokenNode.TYPE_STRING),
    new cs.TokenNode(pascalCase(discriminatedPropertyName)),
    new cs.PropertyMethods({}, undefined),
    new cs.VisibilityModifiers(['public', 'abstract']),
  )

  defs.push(propertyDeclaration)

  const classNameToken = new cs.TokenNode(pascalCase(name))

  for (const [specifiedName, subschema] of objSchemas) {
    const specifiedClassName = pascalCase(name) + pascalCase(specifiedName)

    const { classDefs } = generateDataclassesForObjectOrRefSchema(
      specifiedClassName,
      subschema,
      resource_type,
      namespace,
      {
        enumOverrides: {
          [discriminatedPropertyName]: new cs.Literal(specifiedName),
        },
        base: classNameToken,
      },
    )

    specifiedClassDefs.push(...classDefs)
    specifiedClassNames.push([specifiedClassName, specifiedName])
  }

  const classDef = new cs.Class(
    new cs.ClassDeclarationSpecifier(
      classNameToken,
      undefined,
      new cs.VisibilityModifiers(['public', 'abstract']),
    ),
    defs.map((d) => new cs.StatementBlock([d])),
  )

  let wrappedClassDef: cs.Statement = classDef

  for (const [specifiedClassName, specifiedName] of specifiedClassNames) {
    wrappedClassDef = new cs.AnnotatedStatement(
      'JsonSubtypes.KnownSubType',
      wrappedClassDef,
      [
        new cs.TokenNodeApplyFunction(new cs.TokenNode('typeof'), [
          new cs.TokenNode(specifiedClassName),
        ]),
        new cs.Literal(snakeCase(specifiedName)),
      ],
    )
  }

  const withJsonConverter = new cs.AnnotatedStatement(
    'JsonConverter',
    wrappedClassDef,
    [
      new cs.TokenNodeApplyFunction(new cs.TokenNode('typeof'), [
        new cs.TokenNode('JsonSubtypes'),
      ]),
      new cs.Literal(pascalCase(discriminatedPropertyName)),
    ],
  )

  return {
    className: classNameToken.token,
    classDefs: [withJsonConverter, ...specifiedClassDefs],
  }
}
