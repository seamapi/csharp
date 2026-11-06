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
            bool? canActivateWeeklyProgram = default,
            bool? canConfigureAutoLock = default,
            bool? canHvacCool = default,
            bool? canHvacHeat = default,
            bool? canHvacHeatCool = default,
            bool? canProgramOfflineAccessCodes = default,
            bool? canProgramOnlineAccessCodes = default,
            bool? canProgramThermostatProgramsAsDifferentEachDay = default,
            bool? canProgramThermostatProgramsAsSameEachDay = default,
            bool? canProgramThermostatProgramsAsWeekdayWeekend = default,
            bool? canRemotelyLock = default,
            bool? canRemotelyUnlock = default,
            bool? canRunThermostatPrograms = default,
            bool? canSimulateConnection = default,
            bool? canSimulateDisconnection = default,
            bool? canSimulateHubConnection = default,
            bool? canSimulateHubDisconnection = default,
            bool? canSimulatePaidSubscription = default,
            bool? canSimulateRemoval = default,
            bool? canStreamLiveVideo = default,
            bool? canTurnOffHvac = default,
            bool? canUnlockWithCode = default,
            DeviceProvider.DeviceProviderNameEnum deviceProviderName = default,
            string displayName = default,
            string imageUrl = default,
            List<DeviceProvider.ProviderCategoriesEnum> providerCategories = default
        )
        {
            CanActivateWeeklyProgram = canActivateWeeklyProgram;
            CanConfigureAutoLock = canConfigureAutoLock;
            CanHvacCool = canHvacCool;
            CanHvacHeat = canHvacHeat;
            CanHvacHeatCool = canHvacHeatCool;
            CanProgramOfflineAccessCodes = canProgramOfflineAccessCodes;
            CanProgramOnlineAccessCodes = canProgramOnlineAccessCodes;
            CanProgramThermostatProgramsAsDifferentEachDay =
                canProgramThermostatProgramsAsDifferentEachDay;
            CanProgramThermostatProgramsAsSameEachDay = canProgramThermostatProgramsAsSameEachDay;
            CanProgramThermostatProgramsAsWeekdayWeekend =
                canProgramThermostatProgramsAsWeekdayWeekend;
            CanRemotelyLock = canRemotelyLock;
            CanRemotelyUnlock = canRemotelyUnlock;
            CanRunThermostatPrograms = canRunThermostatPrograms;
            CanSimulateConnection = canSimulateConnection;
            CanSimulateDisconnection = canSimulateDisconnection;
            CanSimulateHubConnection = canSimulateHubConnection;
            CanSimulateHubDisconnection = canSimulateHubDisconnection;
            CanSimulatePaidSubscription = canSimulatePaidSubscription;
            CanSimulateRemoval = canSimulateRemoval;
            CanStreamLiveVideo = canStreamLiveVideo;
            CanTurnOffHvac = canTurnOffHvac;
            CanUnlockWithCode = canUnlockWithCode;
            DeviceProviderName = deviceProviderName;
            DisplayName = displayName;
            ImageUrl = imageUrl;
            ProviderCategories = providerCategories;
        }

        /// <summary>
        /// Name of the device provider.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DeviceProviderNameEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "hotek")]
            Hotek = 1,

            [EnumMember(Value = "dormakaba_community")]
            DormakabaCommunity = 2,

            [EnumMember(Value = "legic_connect")]
            LegicConnect = 3,

            [EnumMember(Value = "akuvox")]
            Akuvox = 4,

            [EnumMember(Value = "august")]
            August = 5,

            [EnumMember(Value = "avigilon_alta")]
            AvigilonAlta = 6,

            [EnumMember(Value = "brivo")]
            Brivo = 7,

            [EnumMember(Value = "butterflymx")]
            Butterflymx = 8,

            [EnumMember(Value = "schlage")]
            Schlage = 9,

            [EnumMember(Value = "smartthings")]
            Smartthings = 10,

            [EnumMember(Value = "yale")]
            Yale = 11,

            [EnumMember(Value = "yale_access")]
            YaleAccess = 12,

            [EnumMember(Value = "yale_home")]
            YaleHome = 13,

            [EnumMember(Value = "genie")]
            Genie = 14,

            [EnumMember(Value = "doorking")]
            Doorking = 15,

            [EnumMember(Value = "salto")]
            Salto = 16,

            [EnumMember(Value = "salto_ks")]
            SaltoKs = 17,

            [EnumMember(Value = "salto_ks_accept")]
            SaltoKsAccept = 18,

            [EnumMember(Value = "lockly")]
            Lockly = 19,

            [EnumMember(Value = "ttlock")]
            Ttlock = 20,

            [EnumMember(Value = "linear")]
            Linear = 21,

            [EnumMember(Value = "noiseaware")]
            Noiseaware = 22,

            [EnumMember(Value = "nuki")]
            Nuki = 23,

            [EnumMember(Value = "igloo")]
            Igloo = 24,

            [EnumMember(Value = "kwikset")]
            Kwikset = 25,

            [EnumMember(Value = "minut")]
            Minut = 26,

            [EnumMember(Value = "my_2n")]
            My_2n = 27,

            [EnumMember(Value = "controlbyweb")]
            Controlbyweb = 28,

            [EnumMember(Value = "nest")]
            Nest = 29,

            [EnumMember(Value = "igloohome")]
            Igloohome = 30,

            [EnumMember(Value = "ecobee")]
            Ecobee = 31,

            [EnumMember(Value = "four_suites")]
            FourSuites = 32,

            [EnumMember(Value = "dormakaba_oracode")]
            DormakabaOracode = 33,

            [EnumMember(Value = "dormakaba_oracode_iho")]
            DormakabaOracodeIho = 34,

            [EnumMember(Value = "pti")]
            Pti = 35,

            [EnumMember(Value = "wyze")]
            Wyze = 36,

            [EnumMember(Value = "seam_passport")]
            SeamPassport = 37,

            [EnumMember(Value = "visionline")]
            Visionline = 38,

            [EnumMember(Value = "assa_abloy_credential_service")]
            AssaAbloyCredentialService = 39,

            [EnumMember(Value = "tedee")]
            Tedee = 40,

            [EnumMember(Value = "honeywell_resideo")]
            HoneywellResideo = 41,

            [EnumMember(Value = "first_alert")]
            FirstAlert = 42,

            [EnumMember(Value = "latch")]
            Latch = 43,

            [EnumMember(Value = "akiles")]
            Akiles = 44,

            [EnumMember(Value = "assa_abloy_vostio")]
            AssaAbloyVostio = 45,

            [EnumMember(Value = "assa_abloy_vostio_credential_service")]
            AssaAbloyVostioCredentialService = 46,

            [EnumMember(Value = "tado")]
            Tado = 47,

            [EnumMember(Value = "salto_space")]
            SaltoSpace = 48,

            [EnumMember(Value = "sensi")]
            Sensi = 49,

            [EnumMember(Value = "keynest")]
            Keynest = 50,

            [EnumMember(Value = "korelock")]
            Korelock = 51,

            [EnumMember(Value = "keyincode")]
            Keyincode = 52,

            [EnumMember(Value = "dormakaba_ambiance")]
            DormakabaAmbiance = 53,

            [EnumMember(Value = "ultraloq")]
            Ultraloq = 54,

            [EnumMember(Value = "yacan")]
            Yacan = 55,

            [EnumMember(Value = "dusaw")]
            Dusaw = 56,

            [EnumMember(Value = "sifely")]
            Sifely = 57,

            [EnumMember(Value = "thirty_three_lock")]
            ThirtyThreeLock = 58,

            [EnumMember(Value = "ring")]
            Ring = 59,

            [EnumMember(Value = "tapo")]
            Tapo = 60,

            [EnumMember(Value = "arlo")]
            Arlo = 61,

            [EnumMember(Value = "reolink")]
            Reolink = 62,

            [EnumMember(Value = "unifi_protect")]
            UnifiProtect = 63,

            [EnumMember(Value = "yale_connect")]
            YaleConnect = 64,

            [EnumMember(Value = "ical")]
            Ical = 65,

            [EnumMember(Value = "lodgify")]
            Lodgify = 66,

            [EnumMember(Value = "hostaway")]
            Hostaway = 67,

            [EnumMember(Value = "guesty")]
            Guesty = 68,

            [EnumMember(Value = "acuity_scheduling")]
            AcuityScheduling = 69,

            [EnumMember(Value = "omnitec")]
            Omnitec = 70,

            [EnumMember(Value = "kisi")]
            Kisi = 71,

            [EnumMember(Value = "aqara")]
            Aqara = 72,

            [EnumMember(Value = "eufy")]
            Eufy = 73,

            [EnumMember(Value = "sonos")]
            Sonos = 74,
        }

        /// <summary>
        /// List of provider categories to which the device provider belongs, such as `stable`, `consumer_smartlocks`, `thermostats`, and so on.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ProviderCategoriesEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "stable")]
            Stable = 1,

            [EnumMember(Value = "consumer_smartlocks")]
            ConsumerSmartlocks = 2,

            [EnumMember(Value = "beta")]
            Beta = 3,

            [EnumMember(Value = "thermostats")]
            Thermostats = 4,

            [EnumMember(Value = "noise_sensors")]
            NoiseSensors = 5,

            [EnumMember(Value = "access_control_systems")]
            AccessControlSystems = 6,

            [EnumMember(Value = "cameras")]
            Cameras = 7,

            [EnumMember(Value = "connectors")]
            Connectors = 8,
        }

        /// <summary>
        /// Indicates whether the thermostat can be returned to its weekly program, the schedule that is configured on the device itself, releasing any hold that Seam has set.
        /// </summary>
        [DataMember(
            Name = "can_activate_weekly_program",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanActivateWeeklyProgram { get; set; }

        /// <summary>
        /// Indicates whether the lock supports configuring automatic locking.
        /// </summary>
        [DataMember(Name = "can_configure_auto_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanConfigureAutoLock { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports cooling.
        /// </summary>
        [DataMember(Name = "can_hvac_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacCool { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports heating.
        /// </summary>
        [DataMember(Name = "can_hvac_heat", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeat { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports simultaneous heating and cooling.
        /// </summary>
        [DataMember(Name = "can_hvac_heat_cool", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanHvacHeatCool { get; set; }

        /// <summary>
        /// Indicates whether the device supports programming offline access codes.
        /// </summary>
        [DataMember(
            Name = "can_program_offline_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOfflineAccessCodes { get; set; }

        /// <summary>
        /// Indicates whether the device supports programming online access codes.
        /// </summary>
        [DataMember(
            Name = "can_program_online_access_codes",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramOnlineAccessCodes { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports different climate programs for each day of the week.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_different_each_day",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsDifferentEachDay { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports a single climate program applied to every day.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_same_each_day",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsSameEachDay { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports weekday/weekend climate programs.
        /// </summary>
        [DataMember(
            Name = "can_program_thermostat_programs_as_weekday_weekend",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanProgramThermostatProgramsAsWeekdayWeekend { get; set; }

        /// <summary>
        /// Indicates whether the device supports remote locking.
        /// </summary>
        [DataMember(Name = "can_remotely_lock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyLock { get; set; }

        /// <summary>
        /// Indicates whether the device supports remote unlocking.
        /// </summary>
        [DataMember(Name = "can_remotely_unlock", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanRemotelyUnlock { get; set; }

        /// <summary>
        /// Indicates whether the thermostat supports running climate programs.
        /// </summary>
        [DataMember(
            Name = "can_run_thermostat_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanRunThermostatPrograms { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating connection in a sandbox.
        /// </summary>
        [DataMember(Name = "can_simulate_connection", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateConnection { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating disconnection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateDisconnection { get; set; }

        /// <summary>
        /// Indicates whether the hub supports simulating connection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_hub_connection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateHubConnection { get; set; }

        /// <summary>
        /// Indicates whether the hub supports simulating disconnection in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_hub_disconnection",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulateHubDisconnection { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating a paid subscription in a sandbox.
        /// </summary>
        [DataMember(
            Name = "can_simulate_paid_subscription",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanSimulatePaidSubscription { get; set; }

        /// <summary>
        /// Indicates whether the device supports simulating removal in a sandbox.
        /// </summary>
        [DataMember(Name = "can_simulate_removal", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanSimulateRemoval { get; set; }

        /// <summary>
        /// Indicates whether the camera can stream live video through a camera live view session. `false` while the camera is offline.
        /// </summary>
        [DataMember(Name = "can_stream_live_video", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanStreamLiveVideo { get; set; }

        /// <summary>
        /// Indicates whether the thermostat can be turned off.
        /// </summary>
        [DataMember(Name = "can_turn_off_hvac", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanTurnOffHvac { get; set; }

        /// <summary>
        /// Indicates whether the lock supports unlocking with an access code.
        /// </summary>
        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

        /// <summary>
        /// Name of the device provider.
        /// </summary>
        [DataMember(Name = "device_provider_name", IsRequired = false, EmitDefaultValue = false)]
        public DeviceProvider.DeviceProviderNameEnum DeviceProviderName { get; set; }

        /// <summary>
        /// Display name for the device provider.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Image URL for the device provider.
        /// </summary>
        [DataMember(Name = "image_url", IsRequired = false, EmitDefaultValue = false)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// List of provider categories to which the device provider belongs, such as `stable`, `consumer_smartlocks`, `thermostats`, and so on.
        /// </summary>
        [DataMember(Name = "provider_categories", IsRequired = false, EmitDefaultValue = false)]
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
