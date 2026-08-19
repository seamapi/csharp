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
    /// Represents an unmanaged access method. Unmanaged access methods do not have client sessions, instant keys, customization profiles, or keys.
    /// </summary>
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
            string displayStatus = default,
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
            DisplayStatus = displayStatus;
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous device configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsProvisioningAccessFrom From { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous device configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsRevokingAccessFrom From { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous access time configuration.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethodPendingMutationsUpdatingAccessTimesFrom From { get; set; }

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
        public List<UnmanagedAccessMethodErrors> Errors { get; set; }

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
        public UnmanagedAccessMethod.ModeEnum Mode { get; set; }

        /// <summary>
        /// Pending mutations for the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant). Indicates operations that are in progress.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessMethodPendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Warnings associated with the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessMethodWarnings> Warnings { get; set; }

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
