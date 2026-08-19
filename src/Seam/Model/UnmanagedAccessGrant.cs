using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents an unmanaged Access Grant. Unmanaged Access Grants do not have client sessions, instant keys, customization profiles, or keys.
    /// </summary>
    [DataContract(Name = "seamModel_unmanagedAccessGrant_model")]
    public class UnmanagedAccessGrant
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessGrant() { }

        public UnmanagedAccessGrant(
            string accessGrantId = default,
            List<string> accessMethodIds = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<UnmanagedAccessGrantErrors> errors = default,
            List<string> locationIds = default,
            string? name = default,
            List<UnmanagedAccessGrantPendingMutations> pendingMutations = default,
            List<UnmanagedAccessGrantRequestedAccessMethods> requestedAccessMethods = default,
            string? reservationKey = default,
            List<string> spaceIds = default,
            string startsAt = default,
            string? userIdentityId = default,
            List<UnmanagedAccessGrantWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AccessMethodIds = accessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            LocationIds = locationIds;
            Name = name;
            PendingMutations = pendingMutations;
            RequestedAccessMethods = requestedAccessMethods;
            ReservationKey = reservationKey;
            SpaceIds = spaceIds;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessGrantErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantErrorsCannotCreateRequestedAccessMethods),
            "cannot_create_requested_access_methods"
        )]
        public abstract class UnmanagedAccessGrantErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantErrorsCannotCreateRequestedAccessMethods_model"
        )]
        public class UnmanagedAccessGrantErrorsCannotCreateRequestedAccessMethods
            : UnmanagedAccessGrantErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantErrorsCannotCreateRequestedAccessMethods() { }

            public UnmanagedAccessGrantErrorsCannotCreateRequestedAccessMethods(
                string createdAt = default,
                string errorCode = default,
                string message = default,
                List<string>? missingDeviceIds = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
                MissingDeviceIds = missingDeviceIds;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "cannot_create_requested_access_methods";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// IDs of the devices that did not receive an access code at grant creation. Use these to identify which specific devices failed when the message reports a partial failure.
            /// </summary>
            [DataMember(Name = "missing_device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? MissingDeviceIds { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantErrorsUnrecognized_model")]
        public class UnmanagedAccessGrantErrorsUnrecognized : UnmanagedAccessGrantErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantErrorsUnrecognized() { }

            public UnmanagedAccessGrantErrorsUnrecognized(
                string errorCode = default,
                string createdAt = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessGrantPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantPendingMutationsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantPendingMutationsUpdatingSpaces),
            "updating_spaces"
        )]
        public abstract class UnmanagedAccessGrantPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingSpaces_model")]
        public class UnmanagedAccessGrantPendingMutationsUpdatingSpaces
            : UnmanagedAccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingSpaces() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingSpaces(
                string createdAt = default,
                UnmanagedAccessGrantPendingMutationsUpdatingSpacesFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAccessGrantPendingMutationsUpdatingSpacesTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous location configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessGrantPendingMutationsUpdatingSpacesFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_spaces";

            /// <summary>
            /// New location configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessGrantPendingMutationsUpdatingSpacesTo To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingSpacesFrom_model"
        )]
        public class UnmanagedAccessGrantPendingMutationsUpdatingSpacesFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingSpacesFrom() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingSpacesFrom(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// Previous device IDs where access codes existed.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingSpacesTo_model"
        )]
        public class UnmanagedAccessGrantPendingMutationsUpdatingSpacesTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingSpacesTo() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingSpacesTo(
                string? commonCodeKey = default,
                List<string> deviceIds = default
            )
            {
                CommonCodeKey = commonCodeKey;
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// Common code key to ensure PIN code reuse across devices.
            /// </summary>
            [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonCodeKey { get; set; }

            /// <summary>
            /// New device IDs where access codes should be created.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingAccessTimes_model"
        )]
        public class UnmanagedAccessGrantPendingMutationsUpdatingAccessTimes
            : UnmanagedAccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingAccessTimes() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingAccessTimes(
                List<string> accessMethodIds = default,
                string createdAt = default,
                UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo to = default
            )
            {
                AccessMethodIds = accessMethodIds;
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            /// <summary>
            /// IDs of the access methods being updated.
            /// </summary>
            [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> AccessMethodIds { get; set; }

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous access time configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_times";

            /// <summary>
            /// New access time configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo To { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom_model"
        )]
        public class UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesFrom(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            /// <summary>
            /// Previous end time for access.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Previous start time for access.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo_model"
        )]
        public class UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo() { }

            public UnmanagedAccessGrantPendingMutationsUpdatingAccessTimesTo(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            /// <summary>
            /// New end time for access.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// New start time for access.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantPendingMutationsUnrecognized_model")]
        public class UnmanagedAccessGrantPendingMutationsUnrecognized
            : UnmanagedAccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantPendingMutationsUnrecognized() { }

            public UnmanagedAccessGrantPendingMutationsUnrecognized(
                string mutationCode = default,
                string createdAt = default,
                string message = default
            )
            {
                MutationCode = mutationCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessGrantWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated),
            "device_time_constraints_violated"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsDeviceDoesNotSupportAccessCodes),
            "device_does_not_support_access_codes"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsRequestedCodeUnavailable),
            "requested_code_unavailable"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsOverprovisionedAccess),
            "overprovisioned_access"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsUnderprovisionedAccess),
            "underprovisioned_access"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessGrantWarningsBeingDeleted),
            "being_deleted"
        )]
        public abstract class UnmanagedAccessGrantWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantWarningsBeingDeleted_model")]
        public class UnmanagedAccessGrantWarningsBeingDeleted : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsBeingDeleted() { }

            public UnmanagedAccessGrantWarningsBeingDeleted(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "being_deleted";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantWarningsUnderprovisionedAccess_model")]
        public class UnmanagedAccessGrantWarningsUnderprovisionedAccess
            : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsUnderprovisionedAccess() { }

            public UnmanagedAccessGrantWarningsUnderprovisionedAccess(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "underprovisioned_access";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantWarningsOverprovisionedAccess_model")]
        public class UnmanagedAccessGrantWarningsOverprovisionedAccess
            : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsOverprovisionedAccess() { }

            public UnmanagedAccessGrantWarningsOverprovisionedAccess(
                string createdAt = default,
                List<UnmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices>? failedDevices =
                    default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                FailedDevices = failedDevices;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Devices whose access codes could not be revoked during reconciliation. Present when the provider does not support revoking an offline access code (e.g. Dormakaba oracode with exhausted override budget).
            /// </summary>
            [DataMember(Name = "failed_devices", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices>? FailedDevices { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "overprovisioned_access";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices_model"
        )]
        public class UnmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices() { }

            public UnmanagedAccessGrantWarningsOverprovisionedAccessFailedDevices(
                string deviceId = default,
                string errorCode = default,
                string message = default
            )
            {
                DeviceId = deviceId;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Device whose access code could not be revoked.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Reason the access code could not be revoked (e.g. `offline_access_code_not_revocable`).
            /// </summary>
            [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
            public string ErrorCode { get; set; }

            /// <summary>
            /// Human-readable description of why revocation failed.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public string Message { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantWarningsUpdatingAccessTimes_model")]
        public class UnmanagedAccessGrantWarningsUpdatingAccessTimes : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsUpdatingAccessTimes() { }

            public UnmanagedAccessGrantWarningsUpdatingAccessTimes(
                List<string> accessMethodIds = default,
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                AccessMethodIds = accessMethodIds;
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// IDs of the access methods being updated.
            /// </summary>
            [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> AccessMethodIds { get; set; }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "updating_access_times";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantWarningsRequestedCodeUnavailable_model"
        )]
        public class UnmanagedAccessGrantWarningsRequestedCodeUnavailable
            : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsRequestedCodeUnavailable() { }

            public UnmanagedAccessGrantWarningsRequestedCodeUnavailable(
                string createdAt = default,
                string deviceId = default,
                string message = default,
                string newCode = default,
                string originalCode = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                DeviceId = deviceId;
                Message = message;
                NewCode = newCode;
                OriginalCode = originalCode;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// ID of the device where the requested code was unavailable.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// The new PIN code that was assigned instead.
            /// </summary>
            [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
            public string NewCode { get; set; }

            /// <summary>
            /// The originally requested PIN code that was unavailable.
            /// </summary>
            [DataMember(Name = "original_code", IsRequired = false, EmitDefaultValue = false)]
            public string OriginalCode { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "requested_code_unavailable";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantWarningsDeviceDoesNotSupportAccessCodes_model"
        )]
        public class UnmanagedAccessGrantWarningsDeviceDoesNotSupportAccessCodes
            : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsDeviceDoesNotSupportAccessCodes() { }

            public UnmanagedAccessGrantWarningsDeviceDoesNotSupportAccessCodes(
                string createdAt = default,
                string deviceId = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                DeviceId = deviceId;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// ID of the device that does not support access codes.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "device_does_not_support_access_codes";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessGrantWarningsDeviceTimeConstraintsViolated_model"
        )]
        public class UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated
            : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated() { }

            public UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated(
                string createdAt = default,
                string deviceId = default,
                string message = default,
                UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated.ReasonEnum reason =
                    default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                DeviceId = deviceId;
                Message = message;
                Reason = reason;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Specific reason why the grant&apos;s times are not programmable on the device.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ReasonEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "duration_exceeds_max")]
                DurationExceedsMax = 1,

                [EnumMember(Value = "times_do_not_match_slots")]
                TimesDoNotMatchSlots = 2,

                [EnumMember(Value = "ongoing_not_supported")]
                OngoingNotSupported = 3,
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// ID of the device whose time constraints the access grant violates.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            /// <summary>
            /// Specific reason why the grant&apos;s times are not programmable on the device.
            /// </summary>
            [DataMember(Name = "reason", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessGrantWarningsDeviceTimeConstraintsViolated.ReasonEnum Reason { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "device_time_constraints_violated";

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        [DataContract(Name = "seamModel_unmanagedAccessGrantWarningsUnrecognized_model")]
        public class UnmanagedAccessGrantWarningsUnrecognized : UnmanagedAccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessGrantWarningsUnrecognized() { }

            public UnmanagedAccessGrantWarningsUnrecognized(
                string warningCode = default,
                string createdAt = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            public override string ToString()
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

                StringWriter stringWriter = new StringWriter(
                    new StringBuilder(256),
                    System.Globalization.CultureInfo.InvariantCulture
                );
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.IndentChar = ' ';
                    jsonTextWriter.Indentation = 2;
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonSerializer.Serialize(jsonTextWriter, this, null);
                }

                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// ID of the Access Grant.
        /// </summary>
        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        /// <summary>
        /// IDs of the access methods created for the Access Grant.
        /// </summary>
        [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessMethodIds { get; set; }

        /// <summary>
        /// Date and time at which the Access Grant was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name of the Access Grant.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time at which the Access Grant ends.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [access grant](https://docs.seam.co/use-cases/granting-access).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessGrantErrors> Errors { get; set; }

        [Obsolete("Use `space_ids`.")]
        [DataMember(Name = "location_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> LocationIds { get; set; }

        /// <summary>
        /// Name of the Access Grant. If not provided, the display name will be computed.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// List of pending mutations for the access grant. This shows updates that are in progress.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessGrantPendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Access methods that the user requested for the Access Grant.
        /// </summary>
        [DataMember(
            Name = "requested_access_methods",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<UnmanagedAccessGrantRequestedAccessMethods> RequestedAccessMethods { get; set; }

        /// <summary>
        /// Reservation key for the access grant.
        /// </summary>
        [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ReservationKey { get; set; }

        /// <summary>
        /// IDs of the spaces to which the Access Grant gives access.
        /// </summary>
        [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        /// <summary>
        /// Date and time at which the Access Grant starts.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        /// <summary>
        /// ID of user identity to which the Access Grant gives access.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Warnings associated with the [access grant](https://docs.seam.co/use-cases/granting-access).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessGrantWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the Seam workspace associated with the Access Grant.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_unmanagedAccessGrantRequestedAccessMethods_model")]
    public class UnmanagedAccessGrantRequestedAccessMethods
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessGrantRequestedAccessMethods() { }

        public UnmanagedAccessGrantRequestedAccessMethods(
            string? code = default,
            List<string> createdAccessMethodIds = default,
            string createdAt = default,
            string displayName = default,
            int? instantKeyMaxUseCount = default,
            UnmanagedAccessGrantRequestedAccessMethods.ModeEnum mode = default
        )
        {
            Code = code;
            CreatedAccessMethodIds = createdAccessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            InstantKeyMaxUseCount = instantKeyMaxUseCount;
            Mode = mode;
        }

        /// <summary>
        /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// Specific PIN code to use for this access method. Only applicable when mode is &apos;code&apos;.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// IDs of the access methods created for the requested access method.
        /// </summary>
        [DataMember(
            Name = "created_access_method_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string> CreatedAccessMethodIds { get; set; }

        /// <summary>
        /// Date and time at which the requested access method was added to the Access Grant.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name of the access method.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Maximum number of times the instant key can be used. Only applicable when mode is &apos;mobile_key&apos;. Defaults to 1 if not specified.
        /// </summary>
        [DataMember(
            Name = "instant_key_max_use_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public int? InstantKeyMaxUseCount { get; set; }

        /// <summary>
        /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAccessGrantRequestedAccessMethods.ModeEnum Mode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }
}
