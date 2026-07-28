using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedAccessMethod_model")]
    public class UnmanagedAccessMethod
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessMethod() { }

        public UnmanagedAccessMethod(
            string accessMethodId = default,
            string? code = default,
            string createdAt = default,
            string displayName = default,
            List<UnmanagedAccessMethodErrors> errors = default,
            bool? isAssignmentRequired = default,
            bool? isEncodingRequired = default,
            bool isIssued = default,
            bool? isReadyForAssignment = default,
            bool? isReadyForEncoding = default,
            string? issuedAt = default,
            UnmanagedAccessMethod.ModeEnum mode = default,
            List<UnmanagedAccessMethodPendingMutations> pendingMutations = default,
            List<UnmanagedAccessMethodWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethodId = accessMethodId;
            Code = code;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Errors = errors;
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
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessMethodErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodErrorsFailedToIssue),
            "failed_to_issue"
        )]
        public abstract class UnmanagedAccessMethodErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessMethodErrorsFailedToIssue_model")]
        public class UnmanagedAccessMethodErrorsFailedToIssue : UnmanagedAccessMethodErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodErrorsFailedToIssue() { }

            public UnmanagedAccessMethodErrorsFailedToIssue(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_issue";

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodErrorsUnrecognized_model")]
        public class UnmanagedAccessMethodErrorsUnrecognized : UnmanagedAccessMethodErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodErrorsUnrecognized() { }

            public UnmanagedAccessMethodErrorsUnrecognized(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessMethodPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodPendingMutationsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodPendingMutationsRevokingAccess),
            "revoking_access"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodPendingMutationsProvisioningAccess),
            "provisioning_access"
        )]
        public abstract class UnmanagedAccessMethodPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_unmanagedAccessMethodPendingMutationsProvisioningAccess_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsProvisioningAccess
            : UnmanagedAccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsProvisioningAccess() { }

            public UnmanagedAccessMethodPendingMutationsProvisioningAccess(
                string createdAt = default,
                UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAccessMethodPendingMutationsProvisioningAccessTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "provisioning_access";

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsProvisioningAccessTo To { get; set; }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsProvisioningAccessFrom_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom() { }

            public UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsProvisioningAccessTo_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsProvisioningAccessTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsProvisioningAccessTo() { }

            public UnmanagedAccessMethodPendingMutationsProvisioningAccessTo(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodPendingMutationsRevokingAccess_model")]
        public class UnmanagedAccessMethodPendingMutationsRevokingAccess
            : UnmanagedAccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsRevokingAccess() { }

            public UnmanagedAccessMethodPendingMutationsRevokingAccess(
                string createdAt = default,
                UnmanagedAccessMethodPendingMutationsRevokingAccessFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAccessMethodPendingMutationsRevokingAccessTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsRevokingAccessFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "revoking_access";

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsRevokingAccessTo To { get; set; }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsRevokingAccessFrom_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsRevokingAccessFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsRevokingAccessFrom() { }

            public UnmanagedAccessMethodPendingMutationsRevokingAccessFrom(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsRevokingAccessTo_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsRevokingAccessTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsRevokingAccessTo() { }

            public UnmanagedAccessMethodPendingMutationsRevokingAccessTo(
                List<string> deviceIds = default
            )
            {
                DeviceIds = deviceIds;
            }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsUpdatingAccessTimes_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsUpdatingAccessTimes
            : UnmanagedAccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsUpdatingAccessTimes() { }

            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimes(
                string createdAt = default,
                UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_times";

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo To { get; set; }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom() { }

            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

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
            Name = "seamModel_unmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo_model"
        )]
        public class UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo() { }

            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesTo(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodPendingMutationsUnrecognized_model")]
        public class UnmanagedAccessMethodPendingMutationsUnrecognized
            : UnmanagedAccessMethodPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodPendingMutationsUnrecognized() { }

            public UnmanagedAccessMethodPendingMutationsUnrecognized(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedAccessMethodWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodWarningsDelayInIssuing),
            "delay_in_issuing"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodWarningsPulledBackupAccessCode),
            "pulled_backup_access_code"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodWarningsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAccessMethodWarningsBeingDeleted),
            "being_deleted"
        )]
        public abstract class UnmanagedAccessMethodWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAccessMethodWarningsBeingDeleted_model")]
        public class UnmanagedAccessMethodWarningsBeingDeleted : UnmanagedAccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodWarningsBeingDeleted() { }

            public UnmanagedAccessMethodWarningsBeingDeleted(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodWarningsUpdatingAccessTimes_model")]
        public class UnmanagedAccessMethodWarningsUpdatingAccessTimes
            : UnmanagedAccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodWarningsUpdatingAccessTimes() { }

            public UnmanagedAccessMethodWarningsUpdatingAccessTimes(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodWarningsPulledBackupAccessCode_model")]
        public class UnmanagedAccessMethodWarningsPulledBackupAccessCode
            : UnmanagedAccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodWarningsPulledBackupAccessCode() { }

            public UnmanagedAccessMethodWarningsPulledBackupAccessCode(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodWarningsDelayInIssuing_model")]
        public class UnmanagedAccessMethodWarningsDelayInIssuing : UnmanagedAccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodWarningsDelayInIssuing() { }

            public UnmanagedAccessMethodWarningsDelayInIssuing(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAccessMethodWarningsUnrecognized_model")]
        public class UnmanagedAccessMethodWarningsUnrecognized : UnmanagedAccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAccessMethodWarningsUnrecognized() { }

            public UnmanagedAccessMethodWarningsUnrecognized(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessMethodErrors> Errors { get; set; }

        [DataMember(Name = "is_assignment_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsAssignmentRequired { get; set; }

        [DataMember(Name = "is_encoding_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEncodingRequired { get; set; }

        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool IsIssued { get; set; }

        [DataMember(Name = "is_ready_for_assignment", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForAssignment { get; set; }

        [DataMember(Name = "is_ready_for_encoding", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForEncoding { get; set; }

        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAccessMethod.ModeEnum Mode { get; set; }

        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessMethodPendingMutations> PendingMutations { get; set; }

        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessMethodWarnings> Warnings { get; set; }

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
