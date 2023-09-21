import os from 'os'

export type CSharpNamespace = string[]

class CompilerCtx {
  public tabSize = 4
  public eol = os.EOL

  indent() {
    return ' '.repeat(this.tabSize)
  }

  withIndent(serialized: string) {
    return serialized
      .split(this.eol)
      .map((l) => (l.trim() ? this.indent() + l : ''))
      .join(this.eol)
  }

  combineWords(...words: (string | undefined)[]) {
    return words.filter((x) => Boolean(x)).join(' ')
  }

  combineStatements(...statements: (string | undefined)[]) {
    return statements.filter((x) => Boolean(x)).join(this.eol)
  }

  combineNodes(...nodes: (CSharpNode | undefined)[]) {
    return this.combineWords(...nodes.map((n) => n?.serialize(this)))
  }

  combineAdjacent(...nodes: (CSharpNode | undefined)[]) {
    return nodes
      .filter((x) => Boolean(x))
      .map((n) => n?.serialize(this))
      .join('')
  }

  serializeNamespace(namespace: CSharpNamespace) {
    return namespace.join('.')
  }
}

abstract class CSharpNode {
  abstract serialize(ctx: CompilerCtx): string
}

abstract class Statement extends CSharpNode {
  constructor(private includeSemicolon: boolean) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return this.serializeStatement(ctx) + (this.includeSemicolon ? ';' : '')
  }

  abstract serializeStatement(ctx: CompilerCtx): string
}

class StatementBlock extends Statement {
  constructor(public statements: Statement[]) {
    super(false)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return this.statements.map((s) => s.serialize(ctx)).join(ctx.eol)
  }
}

class CSharpFile extends Statement {
  constructor(public statements: StatementBlock[]) {
    super(false)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return this.statements.map((n) => n.serialize(ctx)).join(ctx.eol.repeat(2))
  }
}

class CurlyBlock extends Statement {
  constructor(
    public statements: StatementBlock[],
    public separator?: string,
  ) {
    super(false)
  }

  serializeStatement(ctx: CompilerCtx): string {
    const { eol } = ctx

    return `{${eol}${ctx.withIndent(
      this.statements
        .map((s) => s.serialize(ctx))
        .join((this.separator ?? '') + eol.repeat(2)),
    )}${eol}}`
  }
}

class CurlyBlockWithNode<T extends CSharpNode> extends CurlyBlock {
  constructor(
    public declaration: T,
    statements: StatementBlock[],
    separator?: string,
  ) {
    super(statements, separator)
  }

  override serialize(ctx: CompilerCtx): string {
    return [this.declaration.serialize(ctx), super.serialize(ctx)].join(ctx.eol)
  }
}

class UsingStatement extends Statement {
  constructor(public namespace: CSharpNamespace) {
    super(true)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return ctx.combineWords('using', ctx.serializeNamespace(this.namespace))
  }
}

class NamespaceNode extends CSharpNode {
  constructor(public namespace: CSharpNamespace) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineNodes(
      new SyntaxNode('namespace'),
      new AccessChain(this.namespace.map((n) => new TokenNode(n))),
    )
  }
}

class VisibilityModifiers extends CSharpNode {
  constructor(
    public visibility: (
      | 'public'
      | 'private'
      | 'protected'
      | 'internal'
      | 'async'
      | 'partial'
      | 'virtual'
      | 'override'
      | 'abstract'
    )[],
  ) {
    super()
  }

  serialize(_ctx: CompilerCtx): string {
    return this.visibility.join(' ')
  }
}

class ClassDeclarationSpecifier extends CSharpNode {
  constructor(
    public name: TokenNode,
    public base?: string,
    public modifiers?: VisibilityModifiers,
    public classToken: TokenNode = new TokenNode('class'),
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    const base = this.base ? ` : ${this.base}` : ''

    return ctx.combineWords(
      this.modifiers?.serialize(ctx),
      `${this.classToken.serialize(ctx)} ${this.name.serialize(ctx)}${base}`,
    )
  }
}

class EnumDeclarationSpecifier extends CSharpNode {
  constructor(
    public name: TokenNode,
    public modifiers?: VisibilityModifiers,
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineNodes(this.modifiers, new TokenNode('enum'), this.name)
  }
}

class Class extends CurlyBlockWithNode<ClassDeclarationSpecifier> {}

class Enum extends CurlyBlockWithNode<EnumDeclarationSpecifier> {
  constructor(
    public override declaration: EnumDeclarationSpecifier,
    statements: StatementBlock[],
  ) {
    super(declaration, statements, ',')
  }
}

class RawNode extends CSharpNode {
  constructor(public raw: string) {
    super()
  }

  serialize(): string {
    return this.raw
  }
}

class CompositeNode extends CSharpNode {
  constructor(public nodes: CSharpNode[]) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineNodes(...this.nodes)
  }
}

class NodeStatement extends Statement {
  constructor(
    public node: CSharpNode,
    includeSemicolon = true,
  ) {
    super(includeSemicolon)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return this.node.serialize(ctx)
  }
}

class RawStatement extends Statement {
  constructor(
    public raw: string,
    includeSemicolon = true,
  ) {
    super(includeSemicolon)
  }

  serializeStatement(): string {
    return this.raw
  }
}

class AnnotatedStatement<T extends Statement> extends Statement {
  static getPropertyList(properties: Record<string, CSharpNode | undefined>) {
    return Object.entries(properties).map(([property_name, value]) =>
      value
        ? new AssignNode(new TokenNode(property_name), value)
        : new TokenNode(property_name),
    )
  }

  constructor(
    public annotation: string,
    public annotated: T,
    public properties?: CSharpNode[],
  ) {
    super(false)
  }

  serializeStatement(ctx: CompilerCtx): string {
    const props = this.properties
      ? `(${this.properties.map((p) => p.serialize(ctx)).join(', ')})`
      : ''

    return [`[${this.annotation}${props}]`, this.annotated.serialize(ctx)].join(
      ctx.eol,
    )
  }
}

class Literal extends CSharpNode {
  constructor(public value: any) {
    super()
  }

  serialize(): string {
    switch (typeof this.value) {
      case 'string':
        return `"${this.value}"`
      case 'number':
        return this.value.toString()
      case 'boolean':
        return this.value ? 'true' : 'false'
      default:
        if (typeof this.value === 'object' && this.value === null) return 'null'

        throw new Error(`Unknown literal type: ${typeof this.value}`)
    }
  }
}

const RESERVED_TOKENS = ['event']

class TokenNode extends CSharpNode {
  static readonly TYPE_STRING = new TokenNode('string')
  static readonly TYPE_INT = new TokenNode('int')
  static readonly TYPE_FLOAT = new TokenNode('float')
  static readonly TYPE_BOOLEAN = new TokenNode('bool')
  static readonly TYPE_OBJECT = new TokenNode('object')
  static readonly TYPE_OBJECT_CLASS = new TokenNode('Object')
  static readonly TYPE_JOBJECT = new TokenNode('JObject')

  constructor(
    public token: string,
    isReserved = false,
  ) {
    if (!isReserved && RESERVED_TOKENS.includes(token)) {
      token += '_'
    }

    super()
  }

  serialize(_: CompilerCtx): string {
    return this.token
  }
}

class TokenNodeGeneric extends TokenNode {
  constructor(
    public override token: string,
    public generics: TypeNode[],
  ) {
    super(token)
  }

  override serialize(ctx: CompilerCtx): string {
    return `${super.serialize(ctx)}<${this.generics
      .map((g) => g.serialize(ctx))
      .join(', ')}>`
  }
}

class TypeArgumentsNode extends CSharpNode {
  constructor(public generics: TypeNode[]) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return `<${this.generics.map((g) => g.serialize(ctx)).join(', ')}>`
  }
}

class FunctionArgumentsNode extends CSharpNode {
  constructor(public args: CSharpNode[]) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return `(${this.args.map((a) => a.serialize(ctx)).join(', ')})`
  }
}

class TokenNodeApplyFunction extends CSharpNode {
  constructor(
    public token: CSharpNode,
    public args: CSharpNode[],
    public typeArguments?: TypeArgumentsNode,
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineAdjacent(
      this.token,
      this.typeArguments,
      new FunctionArgumentsNode(this.args),
    )
  }
}

class ApplyConstructorNode extends TokenNodeApplyFunction {
  constructor(
    public override token: TokenNode,
    public override args: CSharpNode[],
    public override typeArguments?: TypeArgumentsNode,
  ) {
    super(token, args, typeArguments)
  }

  override serialize(ctx: CompilerCtx): string {
    return `new ${super.serialize(ctx)}`
  }
}

class ReturnStatement extends Statement {
  constructor(public value: CSharpNode) {
    super(true)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return ctx.combineWords('return', this.value.serialize(ctx))
  }
}

class SyntaxNode extends CSharpNode {
  constructor(public syntax: string) {
    super()
  }

  serialize(_: CompilerCtx): string {
    return this.syntax
  }
}

class TypeNode extends CSharpNode {
  constructor(
    public type: CSharpNode,
    public nullable = false,
    public generics?: TypeArgumentsNode,
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineAdjacent(
      this.type,
      this.nullable ? new SyntaxNode('?') : undefined,
      this.generics,
    )
  }
}

class AccessChain extends CSharpNode {
  constructor(public nodes: CSharpNode[]) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return this.nodes.map((n) => n.serialize(ctx)).join('.')
  }
}

abstract class AbstractFieldDeclaration<
  Token extends CSharpNode,
  Body extends Statement | undefined,
  Rhs extends CSharpNode = CSharpNode,
> extends Statement {
  constructor(
    public type: TypeNode | undefined,
    public token: Token,
    public body: Body,
    public visibility?: VisibilityModifiers,
    public rhs?: Rhs,
  ) {
    super(!body || !!rhs)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return ctx.combineWords(
      this.visibility?.serialize(ctx),
      this.type?.serialize(ctx),
      this.token.serialize(ctx),
      this.body?.serialize(ctx),
      ...(this.rhs ? ['=', this.rhs.serialize(ctx)] : []),
    )
  }
}

class FieldDeclaration extends AbstractFieldDeclaration<TokenNode, undefined> {}

class ParameterNode extends CSharpNode {
  constructor(
    public type: TypeNode,
    public name: TokenNode,
    public defaultValue?: CSharpNode,
  ) {
    if (!type) {
      throw new Error('wut?')
    }

    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineWords(
      this.type.serialize(ctx),
      this.name.serialize(ctx),
      ...(this.defaultValue ? ['=', this.defaultValue.serialize(ctx)] : []),
    )
  }
}

class MethodNode extends CSharpNode {
  // TODO: generics
  constructor(
    public name: TokenNode,
    public parameters?: ParameterNode[],
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    const parametersSerialized = this.parameters
      ? `(${this.parameters.map((p) => p.serialize(ctx)).join(', ')})`
      : ''
    return `${this.name.serialize(ctx)}${parametersSerialized}`
  }
}

class MethodDeclaration extends AbstractFieldDeclaration<
  MethodNode,
  CurlyBlock | undefined
> {}

class PropertyMethods extends Statement {
  constructor(
    public get?: {
      statements?: StatementBlock[]
      visibility?: VisibilityModifiers
    },
    public set?: {
      statements?: StatementBlock[]
      visibility?: VisibilityModifiers
    },
  ) {
    super(false)
  }

  serializeStatement(ctx: CompilerCtx): string {
    const statements: Statement[] = []

    if (this.get) {
      const getMethod = new MethodDeclaration(
        undefined,
        new MethodNode(new TokenNode('get')),
        this.get.statements ? new CurlyBlock(this.get.statements) : undefined,
        this.get.visibility,
      )

      statements.push(getMethod)
    }

    if (this.set) {
      const setMethod = new MethodDeclaration(
        undefined,
        new MethodNode(new TokenNode('set')),
        this.set.statements ? new CurlyBlock(this.set.statements) : undefined,
        this.set.visibility,
      )

      statements.push(setMethod)
    }

    return new CurlyBlock([new StatementBlock(statements)]).serialize(ctx)
  }
}

class PropertyDeclaration extends AbstractFieldDeclaration<
  TokenNode,
  PropertyMethods
> {}

class AssignNode<
  LHS extends CSharpNode,
  RHS extends CSharpNode,
> extends CSharpNode {
  constructor(
    public lhs: LHS,
    public rhs: RHS,
    public operation: '=' = '=',
  ) {
    super()
  }

  serialize(ctx: CompilerCtx): string {
    return ctx.combineNodes(this.lhs, new SyntaxNode(this.operation), this.rhs)
  }
}

class AssignStatement<
  LHS extends CSharpNode,
  RHS extends CSharpNode,
> extends Statement {
  constructor(
    public lhs: LHS,
    public rhs: RHS,
    includeSemicolon = true,
    public operation: '=' = '=',
  ) {
    super(includeSemicolon)
  }

  serializeStatement(ctx: CompilerCtx): string {
    return new AssignNode(this.lhs, this.rhs, this.operation).serialize(ctx)
  }
}

class AwaitNode extends CompositeNode {
  constructor(public node: CSharpNode) {
    super([new TokenNode('await'), node])
  }
}

class ParanthesisNode extends CompositeNode {
  constructor(public node: CSharpNode) {
    super([new TokenNode('('), node, new TokenNode(')')])
  }
}

class NamespaceBlock extends CurlyBlockWithNode<NamespaceNode> {}

export {
  RawNode,
  RawStatement,
  CSharpFile,
  CurlyBlock,
  CurlyBlockWithNode,
  UsingStatement,
  ClassDeclarationSpecifier,
  Class,
  StatementBlock,
  AnnotatedStatement,
  Literal,
  VisibilityModifiers,
  CompilerCtx,
  FieldDeclaration,
  TokenNode,
  PropertyDeclaration,
  MethodDeclaration,
  MethodNode,
  TypeNode,
  PropertyMethods,
  TokenNodeGeneric,
  ParameterNode,
  AssignStatement,
  Statement,
  EnumDeclarationSpecifier,
  AssignNode,
  Enum,
  TokenNodeApplyFunction,
  TypeArgumentsNode,
  ReturnStatement,
  ApplyConstructorNode,
  AccessChain,
  CompositeNode,
  NamespaceBlock,
  NamespaceNode,
  AwaitNode,
  ParanthesisNode,
  CSharpNode,
  NodeStatement,
}
