using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

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
            bool? canUnlockWithCode = default,
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
            CanUnlockWithCode = canUnlockWithCode;
            DeviceProviderName = deviceProviderName;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            ProviderCategories = providerCategories;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceProviderNameEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "dormakaba_community")]
            DormakabaCommunity = 1,

            [EnumMember(Value = "legic_connect")]
            LegicConnect = 2,

            [EnumMember(Value = "akuvox")]
            Akuvox = 3,

            [EnumMember(Value = "august")]
            August = 4,

            [EnumMember(Value = "avigilon_alta")]
            AvigilonAlta = 5,

            [EnumMember(Value = "brivo")]
            Brivo = 6,

            [EnumMember(Value = "butterflymx")]
            Butterflymx = 7,

            [EnumMember(Value = "schlage")]
            Schlage = 8,

            [EnumMember(Value = "smartthings")]
            Smartthings = 9,

            [EnumMember(Value = "yale")]
            Yale = 10,

            [EnumMember(Value = "genie")]
            Genie = 11,

            [EnumMember(Value = "doorking")]
            Doorking = 12,

            [EnumMember(Value = "salto")]
            Salto = 13,

            [EnumMember(Value = "salto_ks")]
            SaltoKs = 14,

            [EnumMember(Value = "lockly")]
            Lockly = 15,

            [EnumMember(Value = "ttlock")]
            Ttlock = 16,

            [EnumMember(Value = "linear")]
            Linear = 17,

            [EnumMember(Value = "noiseaware")]
            Noiseaware = 18,

            [EnumMember(Value = "nuki")]
            Nuki = 19,

            [EnumMember(Value = "seam_relay_admin")]
            SeamRelayAdmin = 20,

            [EnumMember(Value = "igloo")]
            Igloo = 21,

            [EnumMember(Value = "kwikset")]
            Kwikset = 22,

            [EnumMember(Value = "minut")]
            Minut = 23,

            [EnumMember(Value = "my_2n")]
            My_2n = 24,

            [EnumMember(Value = "controlbyweb")]
            Controlbyweb = 25,

            [EnumMember(Value = "nest")]
            Nest = 26,

            [EnumMember(Value = "igloohome")]
            Igloohome = 27,

            [EnumMember(Value = "ecobee")]
            Ecobee = 28,

            [EnumMember(Value = "hubitat")]
            Hubitat = 29,

            [EnumMember(Value = "four_suites")]
            FourSuites = 30,

            [EnumMember(Value = "dormakaba_oracode")]
            DormakabaOracode = 31,

            [EnumMember(Value = "pti")]
            Pti = 32,

            [EnumMember(Value = "wyze")]
            Wyze = 33,

            [EnumMember(Value = "seam_passport")]
            SeamPassport = 34,

            [EnumMember(Value = "visionline")]
            Visionline = 35,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 36,

            [EnumMember(Value = "seam_bridge")]
            SeamBridge = 37,

            [EnumMember(Value = "tedee")]
            Tedee = 38,

            [EnumMember(Value = "honeywell_resideo")]
            HoneywellResideo = 39,

            [EnumMember(Value = "latch")]
            Latch = 40,

            [EnumMember(Value = "akiles")]
            Akiles = 41,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 42,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 43,

            [EnumMember(Value = "tado")]
            Tado = 44,

            [EnumMember(Value = "salto_space")]
            SaltoSpace = 45,

            [EnumMember(Value = "sensi")]
            Sensi = 46,

            [EnumMember(Value = "kwikset2")]
            Kwikset2 = 47,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ProviderCategoriesEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "stable")]
            Stable = 1,

            [EnumMember(Value = "consumer_smartlocks")]
            ConsumerSmartlocks = 2,

            [EnumMember(Value = "thermostats")]
            Thermostats = 3,

            [EnumMember(Value = "noise_sensors")]
            NoiseSensors = 4,

            [EnumMember(Value = "access_control_systems")]
            AccessControlSystems = 5,
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

        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

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
