// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/openapi/get-filtered-routes.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
/* eslint-disable */
import type { Route, OpenAPISchema } from '../types.js'

export function getFilteredRoutes(openapi: OpenAPISchema): Route[] {
  return Object.entries(openapi.paths)
    .filter(([, pathSchema]) => {
      const post = pathSchema.post
      const summary = post.summary

      const isDocumented = post?.['x-undocumented'] == null
      const isSeamInternalRoute = summary.startsWith('/seam/')

      return isDocumented && !isSeamInternalRoute
    })
    .map(([path, route]) => ({ path, ...route }))
}
