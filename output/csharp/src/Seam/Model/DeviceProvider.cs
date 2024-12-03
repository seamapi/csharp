using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_deviceProvider_model")]
    public class DeviceProvider
    {
        [JsonConstructorAttribute]
        protected DeviceProvider() { }

        public DeviceProvider(
            bool? canHvacCool = default,
            bool? canHvacHeat = default,
            bool? canHvacHeatCool = default,
            bool? canProgramOfflineAccessCodes = default,
            bool? canProgramOnlineAccessCodes = default,
            bool? canRemotelyLock = default,
            bool? canRemotelyUnlock = default,
            bool? canSimulateConnection = default,
            bool? canSimulateDisconnection = default,
            bool? canSimulateRemoval = default,
            bool? canTurnOffHvac = default,
            DeviceProvider.DeviceProviderNameEnum deviceProviderName = default,
            string displayName = default,
            string imageUrl = default,
            List<DeviceProvider.ProviderCategoriesEnum> providerCategories = default
        )
        {
            CanHvacCool = canHvacCool;
            CanHvacHeat = canHvacHeat;
            CanHvacHeatCool = canHvacHeatCool;
            CanProgramOfflineAccessCodes = canProgramOfflineAccessCodes;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
            CanRemotelyLock = canRemotelyLock;
            CanRemotelyUnlock = canRemotelyUnlock;
            CanSimulateConnection = canSimulateConnection;
            CanSimulateDisconnection = canSimulateDisconnection;
            CanSimulateRemoval = canSimulateRemoval;
            CanTurnOffHvac = canTurnOffHvac;
            DeviceProviderName = deviceProviderName;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            ProviderCategories = providerCategories;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeviceProviderNameEnum
        {
            [EnumMember(Value = "dormakaba_community")]
            DormakabaCommunity = 0,

            [EnumMember(Value = "legic_connect")]
            LegicConnect = 1,

            [EnumMember(Value = "akuvox")]
            Akuvox = 2,

            [EnumMember(Value = "august")]
            August = 3,

            [EnumMember(Value = "avigilon_alta")]
            AvigilonAlta = 4,

            [EnumMember(Value = "brivo")]
            Brivo = 5,

            [EnumMember(Value = "butterflymx")]
            Butterflymx = 6,

            [EnumMember(Value = "schlage")]
            Schlage = 7,

            [EnumMember(Value = "smartthings")]
            Smartthings = 8,

            [EnumMember(Value = "yale")]
            Yale = 9,

            [EnumMember(Value = "genie")]
            Genie = 10,

            [EnumMember(Value = "doorking")]
            Doorking = 11,

            [EnumMember(Value = "salto")]
            Salto = 12,

            [EnumMember(Value = "salto_ks")]
            SaltoKs = 13,

            [EnumMember(Value = "lockly")]
            Lockly = 14,

            [EnumMember(Value = "ttlock")]
            Ttlock = 15,

            [EnumMember(Value = "linear")]
            Linear = 16,

            [EnumMember(Value = "noiseaware")]
            Noiseaware = 17,

            [EnumMember(Value = "nuki")]
            Nuki = 18,

            [EnumMember(Value = "seam_relay_admin")]
            SeamRelayAdmin = 19,

            [EnumMember(Value = "igloo")]
            Igloo = 20,

            [EnumMember(Value = "kwikset")]
            Kwikset = 21,

            [EnumMember(Value = "minut")]
            Minut = 22,

            [EnumMember(Value = "my_2n")]
            My_2n = 23,

            [EnumMember(Value = "controlbyweb")]
            Controlbyweb = 24,

            [EnumMember(Value = "nest")]
            Nest = 25,

            [EnumMember(Value = "igloohome")]
            Igloohome = 26,

            [EnumMember(Value = "ecobee")]
            Ecobee = 27,

            [EnumMember(Value = "hubitat")]
            Hubitat = 28,

            [EnumMember(Value = "four_suites")]
            FourSuites = 29,

            [EnumMember(Value = "dormakaba_oracode")]
            DormakabaOracode = 30,

            [EnumMember(Value = "pti")]
            Pti = 31,

            [EnumMember(Value = "wyze")]
            Wyze = 32,

            [EnumMember(Value = "seam_passport")]
            SeamPassport = 33,

            [EnumMember(Value = "visionline")]
            Visionline = 34,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 35,

            [EnumMember(Value = "seam_bridge")]
            SeamBridge = 36,

            [EnumMember(Value = "tedee")]
            Tedee = 37,

            [EnumMember(Value = "honeywell_resideo")]
            HoneywellResideo = 38,

            [EnumMember(Value = "latch")]
            Latch = 39,

            [EnumMember(Value = "akiles")]
            Akiles = 40,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 41,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 42,
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
            AccessControlSystems = 4,
        }

        [DataMember(Name = "can_hvac_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacCool { get; set; }

        [DataMember(Name = "can_hvac_heat", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeat { get; set; }

        [DataMember(Name = "can_hvac_heat_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeatCool { get; set; }

        [DataMember(
            Name = "can_program_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOfflineAccessCodes { get; set; }

        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

        [DataMember(Name = "can_remotely_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyLock { get; set; }

        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        [DataMember(Name = "can_simulate_connection", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateConnection { get; set; }

        [DataMember(
            Name = "can_simulate_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateDisconnection { get; set; }

        [DataMember(Name = "can_simulate_removal", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateRemoval { get; set; }

        [DataMember(Name = "can_turn_off_hvac", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanTurnOffHvac { get; set; }

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
