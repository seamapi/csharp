using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_accessGrant_model")]
    public class AccessGrant
    {
        [JsonConstructorAttribute]
        protected AccessGrant() { }

        public AccessGrant(
            string accessGrantId = default,
            string? accessGrantKey = default,
            List<string> accessMethodIds = default,
            string? clientSessionToken = default,
            string createdAt = default,
            string? customizationProfileId = default,
            string displayName = default,
            string? endsAt = default,
            List<AccessGrantErrors> errors = default,
            string? instantKeyUrl = default,
            List<string> locationIds = default,
            string? name = default,
            List<AccessGrantPendingMutations> pendingMutations = default,
            List<AccessGrantRequestedAccessMethods> requestedAccessMethods = default,
            string? reservationKey = default,
            List<string> spaceIds = default,
            string startsAt = default,
            string userIdentityId = default,
            List<AccessGrantWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessGrantId = accessGrantId;
            AccessGrantKey = accessGrantKey;
            AccessMethodIds = accessMethodIds;
            ClientSessionToken = clientSessionToken;
            CreatedAt = createdAt;
            CustomizationProfileId = customizationProfileId;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            InstantKeyUrl = instantKeyUrl;
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
        [JsonSubtypes.FallBackSubType(typeof(AccessGrantErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantErrorsCannotCreateRequestedAccessMethods),
            "cannot_create_requested_access_methods"
        )]
        public abstract class AccessGrantErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessGrantErrorsCannotCreateRequestedAccessMethods_model")]
        public class AccessGrantErrorsCannotCreateRequestedAccessMethods : AccessGrantErrors
        {
            [JsonConstructorAttribute]
            protected AccessGrantErrorsCannotCreateRequestedAccessMethods() { }

            public AccessGrantErrorsCannotCreateRequestedAccessMethods(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "cannot_create_requested_access_methods";

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantErrorsUnrecognized_model")]
        public class AccessGrantErrorsUnrecognized : AccessGrantErrors
        {
            [JsonConstructorAttribute]
            protected AccessGrantErrorsUnrecognized() { }

            public AccessGrantErrorsUnrecognized(
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

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessGrantPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantPendingMutationsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantPendingMutationsUpdatingSpaces),
            "updating_spaces"
        )]
        public abstract class AccessGrantPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingSpaces_model")]
        public class AccessGrantPendingMutationsUpdatingSpaces : AccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingSpaces() { }

            public AccessGrantPendingMutationsUpdatingSpaces(
                string createdAt = default,
                AccessGrantPendingMutationsUpdatingSpacesFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessGrantPendingMutationsUpdatingSpacesTo to = default
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
            public AccessGrantPendingMutationsUpdatingSpacesFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_spaces";

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AccessGrantPendingMutationsUpdatingSpacesTo To { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingSpacesFrom_model")]
        public class AccessGrantPendingMutationsUpdatingSpacesFrom
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingSpacesFrom() { }

            public AccessGrantPendingMutationsUpdatingSpacesFrom(List<string> deviceIds = default)
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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingSpacesTo_model")]
        public class AccessGrantPendingMutationsUpdatingSpacesTo
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingSpacesTo() { }

            public AccessGrantPendingMutationsUpdatingSpacesTo(
                string? commonCodeKey = default,
                List<string> deviceIds = default
            )
            {
                CommonCodeKey = commonCodeKey;
                DeviceIds = deviceIds;
            }

            [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonCodeKey { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingAccessTimes_model")]
        public class AccessGrantPendingMutationsUpdatingAccessTimes : AccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingAccessTimes() { }

            public AccessGrantPendingMutationsUpdatingAccessTimes(
                List<string> accessMethodIds = default,
                string createdAt = default,
                AccessGrantPendingMutationsUpdatingAccessTimesFrom from = default,
                string message = default,
                string mutationCode = default,
                AccessGrantPendingMutationsUpdatingAccessTimesTo to = default
            )
            {
                AccessMethodIds = accessMethodIds;
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> AccessMethodIds { get; set; }

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AccessGrantPendingMutationsUpdatingAccessTimesFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_times";

            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AccessGrantPendingMutationsUpdatingAccessTimesTo To { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingAccessTimesFrom_model")]
        public class AccessGrantPendingMutationsUpdatingAccessTimesFrom
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingAccessTimesFrom() { }

            public AccessGrantPendingMutationsUpdatingAccessTimesFrom(
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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUpdatingAccessTimesTo_model")]
        public class AccessGrantPendingMutationsUpdatingAccessTimesTo
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUpdatingAccessTimesTo() { }

            public AccessGrantPendingMutationsUpdatingAccessTimesTo(
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

        [DataContract(Name = "seamModel_accessGrantPendingMutationsUnrecognized_model")]
        public class AccessGrantPendingMutationsUnrecognized : AccessGrantPendingMutations
        {
            [JsonConstructorAttribute]
            protected AccessGrantPendingMutationsUnrecognized() { }

            public AccessGrantPendingMutationsUnrecognized(
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
        [JsonSubtypes.FallBackSubType(typeof(AccessGrantWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsDeviceTimeConstraintsViolated),
            "device_time_constraints_violated"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsDeviceDoesNotSupportAccessCodes),
            "device_does_not_support_access_codes"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsRequestedCodeUnavailable),
            "requested_code_unavailable"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsUpdatingAccessTimes),
            "updating_access_times"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsOverprovisionedAccess),
            "overprovisioned_access"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AccessGrantWarningsUnderprovisionedAccess),
            "underprovisioned_access"
        )]
        [JsonSubtypes.KnownSubType(typeof(AccessGrantWarningsBeingDeleted), "being_deleted")]
        public abstract class AccessGrantWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_accessGrantWarningsBeingDeleted_model")]
        public class AccessGrantWarningsBeingDeleted : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsBeingDeleted() { }

            public AccessGrantWarningsBeingDeleted(
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

        [DataContract(Name = "seamModel_accessGrantWarningsUnderprovisionedAccess_model")]
        public class AccessGrantWarningsUnderprovisionedAccess : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsUnderprovisionedAccess() { }

            public AccessGrantWarningsUnderprovisionedAccess(
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

        [DataContract(Name = "seamModel_accessGrantWarningsOverprovisionedAccess_model")]
        public class AccessGrantWarningsOverprovisionedAccess : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsOverprovisionedAccess() { }

            public AccessGrantWarningsOverprovisionedAccess(
                string createdAt = default,
                List<AccessGrantWarningsOverprovisionedAccessFailedDevices>? failedDevices =
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "failed_devices", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessGrantWarningsOverprovisionedAccessFailedDevices>? FailedDevices { get; set; }

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
            Name = "seamModel_accessGrantWarningsOverprovisionedAccessFailedDevices_model"
        )]
        public class AccessGrantWarningsOverprovisionedAccessFailedDevices
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsOverprovisionedAccessFailedDevices() { }

            public AccessGrantWarningsOverprovisionedAccessFailedDevices(
                string deviceId = default,
                string errorCode = default,
                string message = default
            )
            {
                DeviceId = deviceId;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
            public string ErrorCode { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantWarningsUpdatingAccessTimes_model")]
        public class AccessGrantWarningsUpdatingAccessTimes : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsUpdatingAccessTimes() { }

            public AccessGrantWarningsUpdatingAccessTimes(
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

            [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> AccessMethodIds { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantWarningsRequestedCodeUnavailable_model")]
        public class AccessGrantWarningsRequestedCodeUnavailable : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsRequestedCodeUnavailable() { }

            public AccessGrantWarningsRequestedCodeUnavailable(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
            public string NewCode { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantWarningsDeviceDoesNotSupportAccessCodes_model")]
        public class AccessGrantWarningsDeviceDoesNotSupportAccessCodes : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsDeviceDoesNotSupportAccessCodes() { }

            public AccessGrantWarningsDeviceDoesNotSupportAccessCodes(
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantWarningsDeviceTimeConstraintsViolated_model")]
        public class AccessGrantWarningsDeviceTimeConstraintsViolated : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsDeviceTimeConstraintsViolated() { }

            public AccessGrantWarningsDeviceTimeConstraintsViolated(
                string createdAt = default,
                string deviceId = default,
                string message = default,
                AccessGrantWarningsDeviceTimeConstraintsViolated.ReasonEnum reason = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                DeviceId = deviceId;
                Message = message;
                Reason = reason;
                WarningCode = warningCode;
            }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "reason", IsRequired = false, EmitDefaultValue = false)]
            public AccessGrantWarningsDeviceTimeConstraintsViolated.ReasonEnum Reason { get; set; }

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

        [DataContract(Name = "seamModel_accessGrantWarningsUnrecognized_model")]
        public class AccessGrantWarningsUnrecognized : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsUnrecognized() { }

            public AccessGrantWarningsUnrecognized(
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

        [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessGrantKey { get; set; }

        [DataMember(Name = "access_method_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AccessMethodIds { get; set; }

        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionToken { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessGrantErrors> Errors { get; set; }

        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        [DataMember(Name = "location_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> LocationIds { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessGrantPendingMutations> PendingMutations { get; set; }

        [DataMember(
            Name = "requested_access_methods",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<AccessGrantRequestedAccessMethods> RequestedAccessMethods { get; set; }

        [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ReservationKey { get; set; }

        [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessGrantWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_accessGrantRequestedAccessMethods_model")]
    public class AccessGrantRequestedAccessMethods
    {
        [JsonConstructorAttribute]
        protected AccessGrantRequestedAccessMethods() { }

        public AccessGrantRequestedAccessMethods(
            string? code = default,
            List<string> createdAccessMethodIds = default,
            string createdAt = default,
            string displayName = default,
            int? instantKeyMaxUseCount = default,
            AccessGrantRequestedAccessMethods.ModeEnum mode = default
        )
        {
            Code = code;
            CreatedAccessMethodIds = createdAccessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            InstantKeyMaxUseCount = instantKeyMaxUseCount;
            Mode = mode;
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

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(
            Name = "created_access_method_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string> CreatedAccessMethodIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "instant_key_max_use_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public int? InstantKeyMaxUseCount { get; set; }

        [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
        public AccessGrantRequestedAccessMethods.ModeEnum Mode { get; set; }

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
