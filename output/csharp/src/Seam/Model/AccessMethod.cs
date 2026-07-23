using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_accessMethod_model")]
    public class AccessMethod
    {
        [JsonConstructorAttribute]
        protected AccessMethod() { }

        public AccessMethod(
            string accessMethodId = default,
            string clientSessionToken = default,
            string? code = default,
            string createdAt = default,
            string customizationProfileId = default,
            string displayName = default,
            List<AccessMethodErrors> errors = default,
            string instantKeyUrl = default,
            bool isAssignmentRequired = default,
            bool isEncodingRequired = default,
            bool isIssued = default,
            bool isReadyForAssignment = default,
            bool isReadyForEncoding = default,
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_issue";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_accessMethodErrorsUnrecognized_model")]
        public class AccessMethodErrorsUnrecognized : AccessMethodErrors
        {
            [JsonConstructorAttribute]
            protected AccessMethodErrorsUnrecognized() { }

            public AccessMethodErrorsUnrecognized(string errorCode = default)
            {
                ErrorCode = errorCode;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsProvisioningAccessFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "provisioning_access";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsRevokingAccessFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "revoking_access";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public AccessMethodPendingMutationsUpdatingAccessTimesFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_times";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
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

            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
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

            public AccessMethodPendingMutationsUnrecognized(string mutationCode = default)
            {
                MutationCode = mutationCode;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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
                string originalAccessMethodId = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                OriginalAccessMethodId = originalAccessMethodId;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(
                Name = "original_access_method_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string OriginalAccessMethodId { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

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

            public AccessMethodWarningsUnrecognized(string warningCode = default)
            {
                WarningCode = warningCode;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

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

        [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string ClientSessionToken { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string CustomizationProfileId { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessMethodErrors> Errors { get; set; }

        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string InstantKeyUrl { get; set; }

        [DataMember(Name = "is_assignment_required", IsRequired = false, EmitDefaultValue = false)]
        public bool IsAssignmentRequired { get; set; }

        [DataMember(Name = "is_encoding_required", IsRequired = false, EmitDefaultValue = false)]
        public bool IsEncodingRequired { get; set; }

        [DataMember(Name = "is_issued", IsRequired = true, EmitDefaultValue = false)]
        public bool IsIssued { get; set; }

        [DataMember(Name = "is_ready_for_assignment", IsRequired = false, EmitDefaultValue = false)]
        public bool IsReadyForAssignment { get; set; }

        [DataMember(Name = "is_ready_for_encoding", IsRequired = false, EmitDefaultValue = false)]
        public bool IsReadyForEncoding { get; set; }

        [DataMember(Name = "issued_at", IsRequired = true, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
        public AccessMethod.ModeEnum Mode { get; set; }

        [DataMember(Name = "pending_mutations", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessMethodPendingMutations> PendingMutations { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessMethodWarnings> Warnings { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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
