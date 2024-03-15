using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class SimulatePhones
    {
        private ISeamClient _seam;

        public SimulatePhones(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createSandboxPhoneRequest_request")]
        public class CreateSandboxPhoneRequest
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneRequest() { }

            public CreateSandboxPhoneRequest(
                string? customSdkInstallationId = default,
                string userIdentityId = default,
                CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
                CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default
            )
            {
                CustomSdkInstallationId = customSdkInstallationId;
                UserIdentityId = userIdentityId;
                PhoneMetadata = phoneMetadata;
                AssaAbloyMetadata = assaAbloyMetadata;
            }

            [DataMember(
                Name = "custom_sdk_installation_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomSdkInstallationId { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            [DataMember(Name = "phone_metadata", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestPhoneMetadata? PhoneMetadata { get; set; }

            [DataMember(Name = "assa_abloy_metadata", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestAssaAbloyMetadata? AssaAbloyMetadata { get; set; }

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

        [DataContract(Name = "createSandboxPhoneRequestPhoneMetadata_model")]
        public class CreateSandboxPhoneRequestPhoneMetadata
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneRequestPhoneMetadata() { }

            public CreateSandboxPhoneRequestPhoneMetadata(
                CreateSandboxPhoneRequestPhoneMetadata.OperatingSystemEnum? operatingSystem =
                    default,
                string? osVersion = default,
                string? deviceManufacturer = default,
                string? deviceModel = default
            )
            {
                OperatingSystem = operatingSystem;
                OsVersion = osVersion;
                DeviceManufacturer = deviceManufacturer;
                DeviceModel = deviceModel;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum OperatingSystemEnum
            {
                [EnumMember(Value = "android")]
                Android = 0,

                [EnumMember(Value = "ios")]
                Ios = 1
            }

            [DataMember(Name = "operating_system", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestPhoneMetadata.OperatingSystemEnum? OperatingSystem { get; set; }

            [DataMember(Name = "os_version", IsRequired = false, EmitDefaultValue = false)]
            public string? OsVersion { get; set; }

            [DataMember(Name = "device_manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceManufacturer { get; set; }

            [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceModel { get; set; }

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

        [DataContract(Name = "createSandboxPhoneRequestAssaAbloyMetadata_model")]
        public class CreateSandboxPhoneRequestAssaAbloyMetadata
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneRequestAssaAbloyMetadata() { }

            public CreateSandboxPhoneRequestAssaAbloyMetadata(
                bool? bleCapability = default,
                bool? hceCapability = default,
                bool? nfcCapability = default,
                string? applicationVersion = default,
                string? seosAppletVersion = default,
                float? seosTsmEndpointId = default
            )
            {
                BleCapability = bleCapability;
                HceCapability = hceCapability;
                NfcCapability = nfcCapability;
                ApplicationVersion = applicationVersion;
                SeosAppletVersion = seosAppletVersion;
                SeosTsmEndpointId = seosTsmEndpointId;
            }

            [DataMember(Name = "ble_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? BleCapability { get; set; }

            [DataMember(Name = "hce_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? HceCapability { get; set; }

            [DataMember(Name = "nfc_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? NfcCapability { get; set; }

            [DataMember(Name = "application_version", IsRequired = false, EmitDefaultValue = false)]
            public string? ApplicationVersion { get; set; }

            [DataMember(Name = "seos_applet_version", IsRequired = false, EmitDefaultValue = false)]
            public string? SeosAppletVersion { get; set; }

            [DataMember(
                Name = "seos_tsm_endpoint_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? SeosTsmEndpointId { get; set; }

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

        [DataContract(Name = "createSandboxPhoneResponse_response")]
        public class CreateSandboxPhoneResponse
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneResponse() { }

            public CreateSandboxPhoneResponse(Phone phone = default)
            {
                Phone = phone;
            }

            [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
            public Phone Phone { get; set; }

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

        public Phone CreateSandboxPhone(CreateSandboxPhoneRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateSandboxPhoneResponse>(
                    "/phones/simulate/create_sandbox_phone",
                    requestOptions
                )
                .Data.Phone;
        }

        public Phone CreateSandboxPhone(
            string? customSdkInstallationId = default,
            string userIdentityId = default,
            CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
            CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default
        )
        {
            return CreateSandboxPhone(
                new CreateSandboxPhoneRequest(
                    customSdkInstallationId: customSdkInstallationId,
                    userIdentityId: userIdentityId,
                    phoneMetadata: phoneMetadata,
                    assaAbloyMetadata: assaAbloyMetadata
                )
            );
        }

        public async Task<Phone> CreateSandboxPhoneAsync(CreateSandboxPhoneRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateSandboxPhoneResponse>(
                    "/phones/simulate/create_sandbox_phone",
                    requestOptions
                )
            )
                .Data
                .Phone;
        }

        public async Task<Phone> CreateSandboxPhoneAsync(
            string? customSdkInstallationId = default,
            string userIdentityId = default,
            CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
            CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default
        )
        {
            return (
                await CreateSandboxPhoneAsync(
                    new CreateSandboxPhoneRequest(
                        customSdkInstallationId: customSdkInstallationId,
                        userIdentityId: userIdentityId,
                        phoneMetadata: phoneMetadata,
                        assaAbloyMetadata: assaAbloyMetadata
                    )
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulatePhones SimulatePhones => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulatePhones SimulatePhones { get; }
    }
}
