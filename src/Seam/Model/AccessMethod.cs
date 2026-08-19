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
    /// Represents an access method for an Access Grant. Access methods describe the modes of access, such as PIN codes, plastic cards, and mobile keys. For a mobile key, the access method also stores the URL for the associated Instant Key.
    /// </summary>
    [DataContract(Name = "seamModel_accessMethod_model")]
    public class AccessMethod
    {
        [JsonConstructorAttribute]
        protected AccessMethod() { }

        public AccessMethod(
            string accessMethodId = default,
            string? clientSessionToken = default,
            string? code = default,
            string createdAt = default,
            string? customizationProfileId = default,
            string displayName = default,
            string displayStatus = default,
            List<AccessMethodErrors> errors = default,
            string? instantKeyUrl = default,
            bool? isAssignmentRequired = default,
            bool? isEncodingRequired = default,
            bool isIssued = default,
            bool? isReadyForAssignment = default,
            bool? isReadyForEncoding = default,
            string? issuedAt = default,
            AccessMethod.ModeEnum mode = default,
            List<AccessMethodPendingMutations> pendingMutations = default,
            List<AccessMethodWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethodId = accessMethodId;
            ClientSessionToken = clientSessionToken;
            Code = code;
            CreatedAt = createdAt;
            CustomizationProfileId = customizationProfileId;
            DisplayName = displayName;
            DisplayStatus = displayStatus;
            Errors = errors;
            InstantKeyUrl = instantKeyUrl;
            IsAssignmentRequired = isAssignmentRequired;
            IsEncodingRequired = isEncodingRequired;
            IsIssued = isIssued;
            IsReadyForAssignment = isReadyForAssignment;
            IsReadyForEncoding = isReadyForEncoding;
            IssuedAt = issuedAt;
            Mode = mode;
            PendingMutations = pendingMutations;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessMethodErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AccessMethodErrorsFailedToIssue), "failed_to_issue")]
        public abstract class AccessMethodErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessMethodErrorsFailedToIssue_model")]
        public class AccessMethodErrorsFailedToIssue : AccessMethodErrors
        {
            [JsonConstructorAttribute]
            protected AccessMethodErrorsFailedToIssue() { }

            public AccessMethodErrorsFailedToIssue(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_issue";

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

        [DataContract(Name = "seamModel_accessMethodErrorsUnrecognized_model")]
        public class AccessMethodErrorsUnrecognized : AccessMethodErrors
        {
            [JsonConstructorAttribute]
            protected AccessMethodErrorsUnrecognized() { }

            public AccessMethodErrorsUnrecognized(
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

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessMethodPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessMethodPendingMutationsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessMethodPendingMutationsRevokingAccess),
            "revoking_access"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessMethodPendingMutationsProvisioningAccess),
            "provisioning_access"
        )]
        public abstract class AccessMethodPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessMethodPendingMutationsProvisioningAccess_model")]
        public class AccessMethodPendingMutationsProvisioningAccess : AccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsProvisioningAccess() { }

            public AccessMethodPendingMutationsProvisioningAccess(
                string createdAt = default,
                AccessMethodPendingMutationsProvisioningAccessFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessMethodPendingMutationsProvisioningAccessTo to = default
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
            /// Previous device configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsProvisioningAccessFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "provisioning_access";

            /// <summary>
            /// New device configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsProvisioningAccessTo To { get; set; }

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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsProvisioningAccessFrom_model")]
        public class AccessMethodPendingMutationsProvisioningAccessFrom
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsProvisioningAccessFrom() { }

            public AccessMethodPendingMutationsProvisioningAccessFrom(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// Previous device IDs where access was provisioned.
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsProvisioningAccessTo_model")]
        public class AccessMethodPendingMutationsProvisioningAccessTo
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsProvisioningAccessTo() { }

            public AccessMethodPendingMutationsProvisioningAccessTo(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// New device IDs where access is being provisioned.
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsRevokingAccess_model")]
        public class AccessMethodPendingMutationsRevokingAccess : AccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsRevokingAccess() { }

            public AccessMethodPendingMutationsRevokingAccess(
                string createdAt = default,
                AccessMethodPendingMutationsRevokingAccessFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessMethodPendingMutationsRevokingAccessTo to = default
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
            /// Previous device configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsRevokingAccessFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "revoking_access";

            /// <summary>
            /// New device configuration.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsRevokingAccessTo To { get; set; }

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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsRevokingAccessFrom_model")]
        public class AccessMethodPendingMutationsRevokingAccessFrom
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsRevokingAccessFrom() { }

            public AccessMethodPendingMutationsRevokingAccessFrom(List<string> deviceIds = default)
            {
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// Previous device IDs where access existed.
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsRevokingAccessTo_model")]
        public class AccessMethodPendingMutationsRevokingAccessTo
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsRevokingAccessTo() { }

            public AccessMethodPendingMutationsRevokingAccessTo(List<string> deviceIds = default)
            {
                DeviceIds = deviceIds;
            }

            /// <summary>
            /// New device IDs where access should remain.
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsUpdatingAccessTimes_model")]
        public class AccessMethodPendingMutationsUpdatingAccessTimes : AccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsUpdatingAccessTimes() { }

            public AccessMethodPendingMutationsUpdatingAccessTimes(
                string createdAt = default,
                AccessMethodPendingMutationsUpdatingAccessTimesFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessMethodPendingMutationsUpdatingAccessTimesTo to = default
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
            /// Previous access time configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsUpdatingAccessTimesFrom From { get; set; }

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
            public AccessMethodPendingMutationsUpdatingAccessTimesTo To { get; set; }

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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsUpdatingAccessTimesFrom_model")]
        public class AccessMethodPendingMutationsUpdatingAccessTimesFrom
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsUpdatingAccessTimesFrom() { }

            public AccessMethodPendingMutationsUpdatingAccessTimesFrom(
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsUpdatingAccessTimesTo_model")]
        public class AccessMethodPendingMutationsUpdatingAccessTimesTo
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsUpdatingAccessTimesTo() { }

            public AccessMethodPendingMutationsUpdatingAccessTimesTo(
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

        [DataContract(Name = "seamModel_accessMethodPendingMutationsUnrecognized_model")]
        public class AccessMethodPendingMutationsUnrecognized : AccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessMethodPendingMutationsUnrecognized() { }

            public AccessMethodPendingMutationsUnrecognized(
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
        [JsonSubtypes.FallBackSubType(typeof(AccessMethodWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AccessMethodWarningsDelayInIssuing), "delay_in_issuing")]
        [JsonSubtypes.KnownSubType(
            typeof(AccessMethodWarningsPulledBackupAccessCode),
            "pulled_backup_access_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessMethodWarningsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessMethodWarningsBeingDeleted), "being_deleted")]
        public abstract class AccessMethodWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessMethodWarningsBeingDeleted_model")]
        public class AccessMethodWarningsBeingDeleted : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsBeingDeleted() { }

            public AccessMethodWarningsBeingDeleted(
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

        [DataContract(Name = "seamModel_accessMethodWarningsUpdatingAccessTimes_model")]
        public class AccessMethodWarningsUpdatingAccessTimes : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsUpdatingAccessTimes() { }

            public AccessMethodWarningsUpdatingAccessTimes(
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

        [DataContract(Name = "seamModel_accessMethodWarningsPulledBackupAccessCode_model")]
        public class AccessMethodWarningsPulledBackupAccessCode : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsPulledBackupAccessCode() { }

            public AccessMethodWarningsPulledBackupAccessCode(
                string createdAt = default,
                string message = default,
                string? originalAccessMethodId = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                OriginalAccessMethodId = originalAccessMethodId;
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

            /// <summary>
            /// ID of the original access method from which this backup access method was split, if applicable.
            /// </summary>
            [DataMember(
                Name = "original_access_method_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? OriginalAccessMethodId { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "pulled_backup_access_code";

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

        [DataContract(Name = "seamModel_accessMethodWarningsDelayInIssuing_model")]
        public class AccessMethodWarningsDelayInIssuing : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsDelayInIssuing() { }

            public AccessMethodWarningsDelayInIssuing(
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
            public override string WarningCode { get; } = "delay_in_issuing";

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

        [DataContract(Name = "seamModel_accessMethodWarningsUnrecognized_model")]
        public class AccessMethodWarningsUnrecognized : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsUnrecognized() { }

            public AccessMethodWarningsUnrecognized(
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
        /// ID of the access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Token of the client session associated with the access method.
        /// </summary>
        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionToken { get; set; }

        /// <summary>
        /// The actual PIN code for code access methods.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Date and time at which the access method was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the customization profile associated with the access method.
        /// </summary>
        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        /// <summary>
        /// Display name of the access method.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Human-readable sentence describing where the access method sits in its relationship with the device or access system, for example `Awaiting encoding`. For display only. The wording is not stable and is not an enumeration — it may change at any time, so never compare against or branch on it. To make decisions, read `is_issued`, `errors`, and `pending_mutations`.
        /// </summary>
        [DataMember(Name = "display_status", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayStatus { get; set; }

        /// <summary>
        /// Errors associated with the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessMethodErrors> Errors { get; set; }

        /// <summary>
        /// URL of the Instant Key for mobile key access methods.
        /// </summary>
        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        /// <summary>
        /// Indicates whether an existing card credential must be assigned to this access method before it can be issued. Only applies to card-mode access methods on systems that support credential assignment.
        /// </summary>
        [DataMember(Name = "is_assignment_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsAssignmentRequired { get; set; }

        /// <summary>
        /// Indicates whether encoding with an card encoder is required to issue or reissue the plastic card associated with the access method.
        /// </summary>
        [DataMember(Name = "is_encoding_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEncodingRequired { get; set; }

        /// <summary>
        /// Indicates whether the access method has been issued.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the access method is ready for card assignment. This is true when the access method is in card mode, has not yet been issued, and the system supports credential assignment.
        /// </summary>
        [DataMember(Name = "is_ready_for_assignment", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForAssignment { get; set; }

        /// <summary>
        /// Indicates whether the access method is ready to be encoded. This is true when the credential has been created and the card has not yet been issued.
        /// </summary>
        [DataMember(Name = "is_ready_for_encoding", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForEncoding { get; set; }

        /// <summary>
        /// Date and time at which the access method was issued.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
        public AccessMethod.ModeEnum Mode { get; set; }

        /// <summary>
        /// Pending mutations for the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant). Indicates operations that are in progress.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessMethodPendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Warnings associated with the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessMethodWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the Seam workspace associated with the access method.
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
}
