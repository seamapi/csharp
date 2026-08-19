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
    /// Represents an app user&apos;s mobile phone.
    /// </summary>
    [DataContract(Name = "seamModel_phone_model")]
    public class Phone
    {
        [JsonConstructorAttribute]
        protected Phone() { }

        public Phone(
            string createdAt = default,
            object customMetadata = default,
            string deviceId = default,
            Phone.DeviceTypeEnum deviceType = default,
            string displayName = default,
            List<PhoneErrors> errors = default,
            string? nickname = default,
            PhoneProperties properties = default,
            List<PhoneWarnings> warnings = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            DeviceId = deviceId;
            DeviceType = deviceType;
            DisplayName = displayName;
            Errors = errors;
            Nickname = nickname;
            Properties = properties;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Type of the phone device, such as `ios_phone` or `android_phone`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 1,

            [EnumMember(Value = "android_phone")]
            AndroidPhone = 2,
        }

        /// <summary>
        /// Date and time at which the phone was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Optional [custom metadata](https://docs.seam.co/core-concepts/devices/adding-custom-metadata-to-a-device) for the phone.
        /// </summary>
        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object CustomMetadata { get; set; }

        /// <summary>
        /// ID of the phone.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Type of the phone device, such as `ios_phone` or `android_phone`.
        /// </summary>
        [DataMember(Name = "device_type", IsRequired = false, EmitDefaultValue = false)]
        public Phone.DeviceTypeEnum DeviceType { get; set; }

        /// <summary>
        /// Display name of the phone. Defaults to `nickname` (if it is set) or `properties.appearance.name`, otherwise. Enables administrators and users to identify the phone easily, especially when there are numerous phones.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Errors associated with the phone.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<PhoneErrors> Errors { get; set; }

        /// <summary>
        /// Optional nickname to describe the phone, settable through Seam.
        /// </summary>
        [DataMember(Name = "nickname", IsRequired = false, EmitDefaultValue = false)]
        public string? Nickname { get; set; }

        /// <summary>
        /// Properties of the phone.
        /// </summary>
        [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
        public PhoneProperties Properties { get; set; }

        /// <summary>
        /// Warnings associated with the phone.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<PhoneWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the phone.
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

    [DataContract(Name = "seamModel_phoneErrors_model")]
    public class PhoneErrors
    {
        [JsonConstructorAttribute]
        protected PhoneErrors() { }

        public PhoneErrors(
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
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error.
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

    [DataContract(Name = "seamModel_phoneProperties_model")]
    public class PhoneProperties
    {
        [JsonConstructorAttribute]
        protected PhoneProperties() { }

        public PhoneProperties(
            PhonePropertiesAssaAbloyCredentialServiceMetadata? assaAbloyCredentialServiceMetadata =
                default,
            PhonePropertiesSaltoSpaceCredentialServiceMetadata? saltoSpaceCredentialServiceMetadata =
                default
        )
        {
            AssaAbloyCredentialServiceMetadata = assaAbloyCredentialServiceMetadata;
            SaltoSpaceCredentialServiceMetadata = saltoSpaceCredentialServiceMetadata;
        }

        /// <summary>
        /// ASSA ABLOY Credential Service metadata for the phone.
        /// </summary>
        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

        /// <summary>
        /// Salto Space credential service metadata for the phone.
        /// </summary>
        [DataMember(
            Name = "salto_space_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesSaltoSpaceCredentialServiceMetadata? SaltoSpaceCredentialServiceMetadata { get; set; }

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

    [DataContract(Name = "seamModel_phonePropertiesAssaAbloyCredentialServiceMetadata_model")]
    public class PhonePropertiesAssaAbloyCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesAssaAbloyCredentialServiceMetadata() { }

        public PhonePropertiesAssaAbloyCredentialServiceMetadata(
            List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? endpoints = default,
            bool? hasActiveEndpoint = default
        )
        {
            Endpoints = endpoints;
            HasActiveEndpoint = hasActiveEndpoint;
        }

        /// <summary>
        /// Endpoints associated with the phone.
        /// </summary>
        [DataMember(Name = "endpoints", IsRequired = false, EmitDefaultValue = false)]
        public List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints>? Endpoints { get; set; }

        /// <summary>
        /// Indicates whether the credential service has active endpoints associated with the phone.
        /// </summary>
        [DataMember(Name = "has_active_endpoint", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasActiveEndpoint { get; set; }

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
        Name = "seamModel_phonePropertiesAssaAbloyCredentialServiceMetadataEndpoints_model"
    )]
    public class PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints() { }

        public PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints(
            string? endpointId = default,
            bool? isActive = default
        )
        {
            EndpointId = endpointId;
            IsActive = isActive;
        }

        /// <summary>
        /// ID of the associated endpoint.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Indicated whether the endpoint is active.
        /// </summary>
        [DataMember(Name = "is_active", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsActive { get; set; }

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

    [DataContract(Name = "seamModel_phonePropertiesSaltoSpaceCredentialServiceMetadata_model")]
    public class PhonePropertiesSaltoSpaceCredentialServiceMetadata
    {
        [JsonConstructorAttribute]
        protected PhonePropertiesSaltoSpaceCredentialServiceMetadata() { }

        public PhonePropertiesSaltoSpaceCredentialServiceMetadata(bool? hasActivePhone = default)
        {
            HasActivePhone = hasActivePhone;
        }

        /// <summary>
        /// Indicates whether the credential service has an active associated phone.
        /// </summary>
        [DataMember(Name = "has_active_phone", IsRequired = false, EmitDefaultValue = false)]
        public bool? HasActivePhone { get; set; }

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

    [DataContract(Name = "seamModel_phoneWarnings_model")]
    public class PhoneWarnings
    {
        [JsonConstructorAttribute]
        protected PhoneWarnings() { }

        public PhoneWarnings(
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
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
