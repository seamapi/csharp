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
            string? clientSessionToken = default,
            string? code = default,
            string createdAt = default,
            string? customizationProfileId = default,
            string displayName = default,
            string? instantKeyUrl = default,
            bool? isEncodingRequired = default,
            bool isIssued = default,
            string? issuedAt = default,
            AccessMethod.ModeEnum mode = default,
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
            InstantKeyUrl = instantKeyUrl;
            IsEncodingRequired = isEncodingRequired;
            IsIssued = isIssued;
            IssuedAt = issuedAt;
            Mode = mode;
            Warnings = warnings;
            WorkspaceId = workspaceId;
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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AccessMethodWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AccessMethodWarningsBeingDeleted), "being_deleted")]
        public abstract class AccessMethodWarnings
        {
            public abstract string WarningCode { get; }

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

        [DataContract(Name = "seamModel_accessMethodWarningsUnrecognized_model")]
        public class AccessMethodWarningsUnrecognized : AccessMethodWarnings
        {
            [JsonConstructorAttribute]
            protected AccessMethodWarningsUnrecognized() { }

            public AccessMethodWarningsUnrecognized(
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

        [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionToken { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

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

        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        [DataMember(Name = "is_encoding_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEncodingRequired { get; set; }

        [DataMember(Name = "is_issued", IsRequired = true, EmitDefaultValue = false)]
        public bool IsIssued { get; set; }

        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        [DataMember(Name = "mode", IsRequired = true, EmitDefaultValue = false)]
        public AccessMethod.ModeEnum Mode { get; set; }

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
