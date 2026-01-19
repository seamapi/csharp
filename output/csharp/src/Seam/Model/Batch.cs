using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_batch_model")]
    public class Batch
    {
        [JsonConstructorAttribute]
        protected Batch() { }

        public Batch(
            List<AccessCode>? accessCodes = default,
            List<AccessGrant>? accessGrants = default,
            List<AccessMethod>? accessMethods = default,
            List<AcsAccessGroup>? acsAccessGroups = default,
            List<AcsCredential>? acsCredentials = default,
            List<AcsEncoder>? acsEncoders = default,
            List<AcsEntrance>? acsEntrances = default,
            List<AcsSystem>? acsSystems = default,
            List<AcsUser>? acsUsers = default,
            List<ActionAttempt>? actionAttempts = default,
            List<ClientSession>? clientSessions = default,
            List<ConnectWebview>? connectWebviews = default,
            List<ConnectedAccount>? connectedAccounts = default,
            List<CustomizationProfile>? customizationProfiles = default,
            List<Device>? devices = default,
            List<Event>? events = default,
            List<InstantKey>? instantKeys = default,
            List<NoiseThreshold>? noiseThresholds = default,
            List<Space>? spaces = default,
            List<ThermostatDailyProgram>? thermostatDailyPrograms = default,
            List<ThermostatSchedule>? thermostatSchedules = default,
            List<UnmanagedAccessCode>? unmanagedAccessCodes = default,
            List<UnmanagedAcsAccessGroup>? unmanagedAcsAccessGroups = default,
            List<UnmanagedAcsCredential>? unmanagedAcsCredentials = default,
            List<UnmanagedAcsUser>? unmanagedAcsUsers = default,
            List<UnmanagedDevice>? unmanagedDevices = default,
            List<UserIdentity>? userIdentities = default,
            List<Workspace>? workspaces = default
        )
        {
            AccessCodes = accessCodes;
            AccessGrants = accessGrants;
            AccessMethods = accessMethods;
            AcsAccessGroups = acsAccessGroups;
            AcsCredentials = acsCredentials;
            AcsEncoders = acsEncoders;
            AcsEntrances = acsEntrances;
            AcsSystems = acsSystems;
            AcsUsers = acsUsers;
            ActionAttempts = actionAttempts;
            ClientSessions = clientSessions;
            ConnectWebviews = connectWebviews;
            ConnectedAccounts = connectedAccounts;
            CustomizationProfiles = customizationProfiles;
            Devices = devices;
            Events = events;
            InstantKeys = instantKeys;
            NoiseThresholds = noiseThresholds;
            Spaces = spaces;
            ThermostatDailyPrograms = thermostatDailyPrograms;
            ThermostatSchedules = thermostatSchedules;
            UnmanagedAccessCodes = unmanagedAccessCodes;
            UnmanagedAcsAccessGroups = unmanagedAcsAccessGroups;
            UnmanagedAcsCredentials = unmanagedAcsCredentials;
            UnmanagedAcsUsers = unmanagedAcsUsers;
            UnmanagedDevices = unmanagedDevices;
            UserIdentities = userIdentities;
            Workspaces = workspaces;
        }

        [DataMember(Name = "access_codes", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessCode>? AccessCodes { get; set; }

        [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessGrant>? AccessGrants { get; set; }

        [DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
        public List<AccessMethod>? AccessMethods { get; set; }

        [DataMember(Name = "acs_access_groups", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsAccessGroup>? AcsAccessGroups { get; set; }

        [DataMember(Name = "acs_credentials", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsCredential>? AcsCredentials { get; set; }

        [DataMember(Name = "acs_encoders", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEncoder>? AcsEncoders { get; set; }

        [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntrance>? AcsEntrances { get; set; }

        [DataMember(Name = "acs_systems", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsSystem>? AcsSystems { get; set; }

        [DataMember(Name = "acs_users", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsUser>? AcsUsers { get; set; }

        [DataMember(Name = "action_attempts", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttempt>? ActionAttempts { get; set; }

        [DataMember(Name = "client_sessions", IsRequired = false, EmitDefaultValue = false)]
        public List<ClientSession>? ClientSessions { get; set; }

        [DataMember(Name = "connect_webviews", IsRequired = false, EmitDefaultValue = false)]
        public List<ConnectWebview>? ConnectWebviews { get; set; }

        [DataMember(Name = "connected_accounts", IsRequired = false, EmitDefaultValue = false)]
        public List<ConnectedAccount>? ConnectedAccounts { get; set; }

        [DataMember(Name = "customization_profiles", IsRequired = false, EmitDefaultValue = false)]
        public List<CustomizationProfile>? CustomizationProfiles { get; set; }

        [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
        public List<Device>? Devices { get; set; }

        [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
        public List<Event>? Events { get; set; }

        [DataMember(Name = "instant_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<InstantKey>? InstantKeys { get; set; }

        [DataMember(Name = "noise_thresholds", IsRequired = false, EmitDefaultValue = false)]
        public List<NoiseThreshold>? NoiseThresholds { get; set; }

        [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
        public List<Space>? Spaces { get; set; }

        [DataMember(
            Name = "thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<ThermostatDailyProgram>? ThermostatDailyPrograms { get; set; }

        [DataMember(Name = "thermostat_schedules", IsRequired = false, EmitDefaultValue = false)]
        public List<ThermostatSchedule>? ThermostatSchedules { get; set; }

        [DataMember(Name = "unmanaged_access_codes", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAccessCode>? UnmanagedAccessCodes { get; set; }

        [DataMember(
            Name = "unmanaged_acs_access_groups",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<UnmanagedAcsAccessGroup>? UnmanagedAcsAccessGroups { get; set; }

        [DataMember(
            Name = "unmanaged_acs_credentials",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<UnmanagedAcsCredential>? UnmanagedAcsCredentials { get; set; }

        [DataMember(Name = "unmanaged_acs_users", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAcsUser>? UnmanagedAcsUsers { get; set; }

        [DataMember(Name = "unmanaged_devices", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedDevice>? UnmanagedDevices { get; set; }

        [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
        public List<UserIdentity>? UserIdentities { get; set; }

        [DataMember(Name = "workspaces", IsRequired = false, EmitDefaultValue = false)]
        public List<Workspace>? Workspaces { get; set; }

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
