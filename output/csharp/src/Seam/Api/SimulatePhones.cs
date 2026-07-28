using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Request parameters for Create a Sandbox Phone.
        /// </summary>
        [DataContract(Name = "createSandboxPhoneRequest_request")]
        public class CreateSandboxPhoneRequest
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneRequest() { }

            public CreateSandboxPhoneRequest(
                CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default,
                string? customSdkInstallationId = default,
                CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
                string userIdentityId = default
            )
            {
                AssaAbloyMetadata = assaAbloyMetadata;
                CustomSdkInstallationId = customSdkInstallationId;
                PhoneMetadata = phoneMetadata;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ASSA ABLOY metadata that you want to associate with the simulated phone.
            /// </summary>
            [DataMember(Name = "assa_abloy_metadata", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestAssaAbloyMetadata? AssaAbloyMetadata { get; set; }

            /// <summary>
            /// ID of the custom SDK installation that you want to use for the simulated phone.
            /// </summary>
            [DataMember(
                Name = "custom_sdk_installation_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomSdkInstallationId { get; set; }

            /// <summary>
            /// Metadata that you want to associate with the simulated phone.
            /// </summary>
            [DataMember(Name = "phone_metadata", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestPhoneMetadata? PhoneMetadata { get; set; }

            /// <summary>
            /// ID of the user identity that you want to associate with the simulated phone.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
                string? applicationVersion = default,
                bool? bleCapability = default,
                bool? hceCapability = default,
                bool? nfcCapability = default,
                string? seosAppletVersion = default,
                float? seosTsmEndpointId = default
            )
            {
                ApplicationVersion = applicationVersion;
                BleCapability = bleCapability;
                HceCapability = hceCapability;
                NfcCapability = nfcCapability;
                SeosAppletVersion = seosAppletVersion;
                SeosTsmEndpointId = seosTsmEndpointId;
            }

            /// <summary>
            /// Application version that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "application_version", IsRequired = false, EmitDefaultValue = false)]
            public string? ApplicationVersion { get; set; }

            /// <summary>
            /// Indicates whether the simulated phone should have Bluetooth low energy (BLE) capability.
            /// </summary>
            [DataMember(Name = "ble_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? BleCapability { get; set; }

            /// <summary>
            /// Indicates whether the simulated phone should have host card emulation (HCE) capability.
            /// </summary>
            [DataMember(Name = "hce_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? HceCapability { get; set; }

            /// <summary>
            /// Indicates whether the simulated phone should have near-field communication (NFC) capability.
            /// </summary>
            [DataMember(Name = "nfc_capability", IsRequired = false, EmitDefaultValue = false)]
            public bool? NfcCapability { get; set; }

            /// <summary>
            /// SEOS applet version that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "seos_applet_version", IsRequired = false, EmitDefaultValue = false)]
            public string? SeosAppletVersion { get; set; }

            /// <summary>
            /// ID of the SEOS trusted service manager (TSM) endpoint that you want to use for the simulated phone.
            /// </summary>
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

        [DataContract(Name = "createSandboxPhoneRequestPhoneMetadata_model")]
        public class CreateSandboxPhoneRequestPhoneMetadata
        {
            [JsonConstructorAttribute]
            protected CreateSandboxPhoneRequestPhoneMetadata() { }

            public CreateSandboxPhoneRequestPhoneMetadata(
                string? deviceManufacturer = default,
                string? deviceModel = default,
                CreateSandboxPhoneRequestPhoneMetadata.OperatingSystemEnum? operatingSystem =
                    default,
                string? osVersion = default
            )
            {
                DeviceManufacturer = deviceManufacturer;
                DeviceModel = deviceModel;
                OperatingSystem = operatingSystem;
                OsVersion = osVersion;
            }

            /// <summary>
            /// Mobile operating system that you want to use for the simulated phone.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum OperatingSystemEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "android")]
                Android = 1,

                [EnumMember(Value = "ios")]
                Ios = 2,
            }

            /// <summary>
            /// Manufacturer that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "device_manufacturer", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceManufacturer { get; set; }

            /// <summary>
            /// Device model that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "device_model", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceModel { get; set; }

            /// <summary>
            /// Mobile operating system that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "operating_system", IsRequired = false, EmitDefaultValue = false)]
            public CreateSandboxPhoneRequestPhoneMetadata.OperatingSystemEnum? OperatingSystem { get; set; }

            /// <summary>
            /// Mobile operating system version that you want to use for the simulated phone.
            /// </summary>
            [DataMember(Name = "os_version", IsRequired = false, EmitDefaultValue = false)]
            public string? OsVersion { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new simulated phone in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Creating a Simulated Phone for a User Identity](https://docs.seam.co/capability-guides/mobile-access/developing-in-a-sandbox-workspace#creating-a-simulated-phone-for-a-user-identity).
        /// </summary>
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

        /// <summary>
        /// Creates a new simulated phone in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Creating a Simulated Phone for a User Identity](https://docs.seam.co/capability-guides/mobile-access/developing-in-a-sandbox-workspace#creating-a-simulated-phone-for-a-user-identity).
        /// </summary>
        public Phone CreateSandboxPhone(
            CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default,
            string? customSdkInstallationId = default,
            CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
            string userIdentityId = default
        )
        {
            return CreateSandboxPhone(
                new CreateSandboxPhoneRequest(
                    assaAbloyMetadata: assaAbloyMetadata,
                    customSdkInstallationId: customSdkInstallationId,
                    phoneMetadata: phoneMetadata,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Creates a new simulated phone in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Creating a Simulated Phone for a User Identity](https://docs.seam.co/capability-guides/mobile-access/developing-in-a-sandbox-workspace#creating-a-simulated-phone-for-a-user-identity).
        /// </summary>
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

        /// <summary>
        /// Creates a new simulated phone in a [sandbox workspace](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Creating a Simulated Phone for a User Identity](https://docs.seam.co/capability-guides/mobile-access/developing-in-a-sandbox-workspace#creating-a-simulated-phone-for-a-user-identity).
        /// </summary>
        public async Task<Phone> CreateSandboxPhoneAsync(
            CreateSandboxPhoneRequestAssaAbloyMetadata? assaAbloyMetadata = default,
            string? customSdkInstallationId = default,
            CreateSandboxPhoneRequestPhoneMetadata? phoneMetadata = default,
            string userIdentityId = default
        )
        {
            return (
                await CreateSandboxPhoneAsync(
                    new CreateSandboxPhoneRequest(
                        assaAbloyMetadata: assaAbloyMetadata,
                        customSdkInstallationId: customSdkInstallationId,
                        phoneMetadata: phoneMetadata,
                        userIdentityId: userIdentityId
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
