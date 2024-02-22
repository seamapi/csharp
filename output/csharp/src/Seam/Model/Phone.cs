using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_phone_model")]
    public class Phone
    {
        [JsonConstructorAttribute]
        protected Phone() { }

        public Phone(
            string deviceId = default,
            Phone.DeviceTypeEnum deviceType = default,
            List<Phone.CapabilitiesSupportedEnum> capabilitiesSupported = default,
            PhoneProperties properties = default,
            PhoneLocation? location = default,
            string workspaceId = default,
            List<PhoneErrors> errors = default,
            List<PhoneWarnings> warnings = default,
            string createdAt = default,
            bool isManaged = default,
            object? customMetadata = default,
            bool? canRemotelyUnlock = default,
            bool? canProgramOnlineAccessCodes = default
        )
        {
            DeviceId = deviceId;
            DeviceType = deviceType;
            CapabilitiesSupported = capabilitiesSupported;
            Properties = properties;
            Location = location;
            WorkspaceId = workspaceId;
            Errors = errors;
            Warnings = warnings;
            CreatedAt = createdAt;
            IsManaged = isManaged;
            CustomMetadata = customMetadata;
            CanRemotelyUnlock = canRemotelyUnlock;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceTypeEnum
        {
            [EnumMember(Value = "android_phone")]
            AndroidPhone = 0,

            [EnumMember(Value = "ios_phone")]
            IosPhone = 1
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum CapabilitiesSupportedEnum
        {
            [EnumMember(Value = "access_code")]
            AccessCode = 0,

            [EnumMember(Value = "lock")]
            Lock = 1,

            [EnumMember(Value = "noise_detection")]
            NoiseDetection = 2,

            [EnumMember(Value = "thermostat")]
            Thermostat = 3,

            [EnumMember(Value = "battery")]
            Battery = 4,

            [EnumMember(Value = "phone")]
            Phone = 5
        }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "device_type", IsRequired = true, EmitDefaultValue = false)]
        public Phone.DeviceTypeEnum DeviceType { get; set; }

        [DataMember(Name = "capabilities_supported", IsRequired = true, EmitDefaultValue = false)]
        public List<Phone.CapabilitiesSupportedEnum> CapabilitiesSupported { get; set; }

        [DataMember(Name = "properties", IsRequired = true, EmitDefaultValue = false)]
        public PhoneProperties Properties { get; set; }

        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = false)]
        public PhoneLocation? Location { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneErrors> Errors { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<PhoneWarnings> Warnings { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

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
                default
        )
        {
            AssaAbloyCredentialServiceMetadata = assaAbloyCredentialServiceMetadata;
        }

        [DataMember(
            Name = "assa_abloy_credential_service_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public PhonePropertiesAssaAbloyCredentialServiceMetadata? AssaAbloyCredentialServiceMetadata { get; set; }

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
            bool hasActiveEndpoint = default,
            List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints> endpoints = default
        )
        {
            HasActiveEndpoint = hasActiveEndpoint;
            Endpoints = endpoints;
        }

        [DataMember(Name = "has_active_endpoint", IsRequired = true, EmitDefaultValue = false)]
        public bool HasActiveEndpoint { get; set; }

        [DataMember(Name = "endpoints", IsRequired = true, EmitDefaultValue = false)]
        public List<PhonePropertiesAssaAbloyCredentialServiceMetadataEndpoints> Endpoints { get; set; }

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
            string endpointId = default,
            bool isActive = default
        )
        {
            EndpointId = endpointId;
            IsActive = isActive;
        }

        [DataMember(Name = "endpoint_id", IsRequired = true, EmitDefaultValue = false)]
        public string EndpointId { get; set; }

        [DataMember(Name = "is_active", IsRequired = true, EmitDefaultValue = false)]
        public bool IsActive { get; set; }

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

    [DataContract(Name = "seamModel_phoneLocation_model")]
    public class PhoneLocation
    {
        [JsonConstructorAttribute]
        protected PhoneLocation() { }

        public PhoneLocation(string? locationName = default, string? timezone = default)
        {
            LocationName = locationName;
            Timezone = timezone;
        }

        [DataMember(Name = "location_name", IsRequired = false, EmitDefaultValue = false)]
        public string? LocationName { get; set; }

        [DataMember(Name = "timezone", IsRequired = false, EmitDefaultValue = false)]
        public string? Timezone { get; set; }

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

        public PhoneErrors(string errorCode = default, string message = default)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

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

    [DataContract(Name = "seamModel_phoneWarnings_model")]
    public class PhoneWarnings
    {
        [JsonConstructorAttribute]
        protected PhoneWarnings() { }

        public PhoneWarnings(string warningCode = default, string message = default)
        {
            WarningCode = warningCode;
            Message = message;
        }

        [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
}
