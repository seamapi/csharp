using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_deviceProvider_model")]
    public class DeviceProvider
    {
        [JsonConstructorAttribute]
        protected DeviceProvider() { }

        public DeviceProvider(
            DeviceProvider.DeviceProviderNameEnum deviceProviderName = default,
            string displayName = default,
            string imageUrl = default,
            List<DeviceProvider.ProviderCategoriesEnum> providerCategories = default
        )
        {
            DeviceProviderName = deviceProviderName;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            ProviderCategories = providerCategories;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceProviderNameEnum
        {
            [EnumMember(Value = "akuvox")]
            Akuvox = 0,

            [EnumMember(Value = "august")]
            August = 1,

            [EnumMember(Value = "avigilon_alta")]
            AvigilonAlta = 2,

            [EnumMember(Value = "brivo")]
            Brivo = 3,

            [EnumMember(Value = "butterflymx")]
            Butterflymx = 4,

            [EnumMember(Value = "schlage")]
            Schlage = 5,

            [EnumMember(Value = "smartthings")]
            Smartthings = 6,

            [EnumMember(Value = "yale")]
            Yale = 7,

            [EnumMember(Value = "genie")]
            Genie = 8,

            [EnumMember(Value = "doorking")]
            Doorking = 9,

            [EnumMember(Value = "salto")]
            Salto = 10,

            [EnumMember(Value = "lockly")]
            Lockly = 11,

            [EnumMember(Value = "ttlock")]
            Ttlock = 12,

            [EnumMember(Value = "linear")]
            Linear = 13,

            [EnumMember(Value = "noiseaware")]
            Noiseaware = 14,

            [EnumMember(Value = "nuki")]
            Nuki = 15,

            [EnumMember(Value = "seam_relay_admin")]
            SeamRelayAdmin = 16,

            [EnumMember(Value = "igloo")]
            Igloo = 17,

            [EnumMember(Value = "kwikset")]
            Kwikset = 18,

            [EnumMember(Value = "minut")]
            Minut = 19,

            [EnumMember(Value = "my_2n")]
            My_2n = 20,

            [EnumMember(Value = "controlbyweb")]
            Controlbyweb = 21,

            [EnumMember(Value = "nest")]
            Nest = 22,

            [EnumMember(Value = "igloohome")]
            Igloohome = 23,

            [EnumMember(Value = "ecobee")]
            Ecobee = 24,

            [EnumMember(Value = "hubitat")]
            Hubitat = 25,

            [EnumMember(Value = "four_suites")]
            FourSuites = 26,

            [EnumMember(Value = "dormakaba_oracode")]
            DormakabaOracode = 27,

            [EnumMember(Value = "pti")]
            Pti = 28,

            [EnumMember(Value = "wyze")]
            Wyze = 29,

            [EnumMember(Value = "seam_passport")]
            SeamPassport = 30,

            [EnumMember(Value = "visionline")]
            Visionline = 31,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 32,

            [EnumMember(Value = "seam_bridge")]
            SeamBridge = 33,

            [EnumMember(Value = "tedee")]
            Tedee = 34,

            [EnumMember(Value = "honeywell_resideo")]
            HoneywellResideo = 35,

            [EnumMember(Value = "latch")]
            Latch = 36,

            [EnumMember(Value = "dormakaba_community")]
            DormakabaCommunity = 37,

            [EnumMember(Value = "legic_connect")]
            LegicConnect = 38,

            [EnumMember(Value = "salto_ks")]
            SaltoKs = 39,

            [EnumMember(Value = "akiles")]
            Akiles = 40,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 41,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 42
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProviderCategoriesEnum
        {
            [EnumMember(Value = "stable")]
            Stable = 0,

            [EnumMember(Value = "consumer_smartlocks")]
            ConsumerSmartlocks = 1,

            [EnumMember(Value = "thermostats")]
            Thermostats = 2,

            [EnumMember(Value = "noise_sensors")]
            NoiseSensors = 3,

            [EnumMember(Value = "access_control_systems")]
            AccessControlSystems = 4
        }

        [DataMember(Name = "device_provider_name", IsRequired = true, EmitDefaultValue = false)]
        public DeviceProvider.DeviceProviderNameEnum DeviceProviderName { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "image_url", IsRequired = true, EmitDefaultValue = false)]
        public string ImageUrl { get; set; }

        [DataMember(Name = "provider_categories", IsRequired = true, EmitDefaultValue = false)]
        public List<DeviceProvider.ProviderCategoriesEnum> ProviderCategories { get; set; }

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
