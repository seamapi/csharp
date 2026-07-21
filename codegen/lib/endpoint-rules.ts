// TEMPORARY: Verbatim port of @seamapi/nextlove-sdk-generator lib/endpoint-rules.ts.
// This is a frozen output-parity workaround: it exists only so the
// generated output stays byte-identical to the previous generator.
// Do not review, refactor, or improve it.
// TODO: Delete this file and drive generation from @seamapi/blueprint once
// the generated output is allowed to change.
// @ts-nocheck
/* eslint-disable */
export const endpoints_returning_deprecated_action_attempt = [
  '/access_codes/delete',
  '/access_codes/unmanaged/delete',
  '/access_codes/update',
  '/noise_sensors/noise_thresholds/delete',
  '/noise_sensors/noise_thresholds/update',
  '/thermostats/climate_setting_schedules/update',
]

export const ignored_endpoint_paths = [
  '/health',
  '/health/get_health',
  '/health/get_service_health',
  '/health/service/[service_name]',
]
