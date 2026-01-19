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
            public override string ErrorCode { get; } = "cannot_create_requested_access_methods";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_accessGrantErrorsUnrecognized_model")]
        public class AccessGrantErrorsUnrecognized : AccessGrantErrors
        {
            [JsonConstructorAttribute]
            protected AccessGrantErrorsUnrecognized() { }

            public AccessGrantErrorsUnrecognized(
                string errorCode = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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
        [JsonSubtypes.KnownSubType(typeof(AccessGrantWarningsBeingDeleted), "being_deleted")]
        public abstract class AccessGrantWarnings
        {
            public abstract string WarningCode { get; }

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

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_accessGrantWarningsUnrecognized_model")]
        public class AccessGrantWarningsUnrecognized : AccessGrantWarnings
        {
            [JsonConstructorAttribute]
            protected AccessGrantWarningsUnrecognized() { }

            public AccessGrantWarningsUnrecognized(
                string warningCode = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

        [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessGrantId { get; set; }

        [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessGrantKey { get; set; }

        [DataMember(Name = "access_method_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> AccessMethodIds { get; set; }

        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionToken { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessGrantErrors> Errors { get; set; }

        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        [DataMember(Name = "location_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> LocationIds { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "requested_access_methods", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessGrantRequestedAccessMethods> RequestedAccessMethods { get; set; }

        [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
        public string? ReservationKey { get; set; }

        [DataMember(Name = "space_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessGrantWarnings> Warnings { get; set; }

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
            AccessGrantRequestedAccessMethods.ModeEnum mode = default
        )
        {
            Code = code;
            CreatedAccessMethodIds = createdAccessMethodIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
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
        }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(
            Name = "created_access_method_ids",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public List<string> CreatedAccessMethodIds { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
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
