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
            object accessCodes = default,
            object accessGrants = default,
            object accessMethods = default,
            object acsAccessGroups = default,
            object acsCredentials = default,
            object acsEncoders = default,
            object acsEntrances = default,
            object acsSystems = default,
            object acsUsers = default,
            object actionAttempts = default,
            object clientSessions = default,
            object connectWebviews = default,
            object connectedAccounts = default,
            object customizationProfiles = default,
            object devices = default,
            object events = default,
            object instantKeys = default,
            object noiseThresholds = default,
            object spaces = default,
            object thermostatDailyPrograms = default,
            object thermostatSchedules = default,
            object unmanagedAccessCodes = default,
            object unmanagedAcsAccessGroups = default,
            object unmanagedAcsCredentials = default,
            object unmanagedAcsUsers = default,
            object unmanagedDevices = default,
            object userIdentities = default,
            object workspaces = default
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
        public object AccessCodes { get; set; }

        [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
        public object AccessGrants { get; set; }

        [DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
        public object AccessMethods { get; set; }

        [DataMember(Name = "acs_access_groups", IsRequired = false, EmitDefaultValue = false)]
        public object AcsAccessGroups { get; set; }

        [DataMember(Name = "acs_credentials", IsRequired = false, EmitDefaultValue = false)]
        public object AcsCredentials { get; set; }

        [DataMember(Name = "acs_encoders", IsRequired = false, EmitDefaultValue = false)]
        public object AcsEncoders { get; set; }

        [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
        public object AcsEntrances { get; set; }

        [DataMember(Name = "acs_systems", IsRequired = false, EmitDefaultValue = false)]
        public object AcsSystems { get; set; }

        [DataMember(Name = "acs_users", IsRequired = false, EmitDefaultValue = false)]
        public object AcsUsers { get; set; }

        [DataMember(Name = "action_attempts", IsRequired = false, EmitDefaultValue = false)]
        public object ActionAttempts { get; set; }

        [DataMember(Name = "client_sessions", IsRequired = false, EmitDefaultValue = false)]
        public object ClientSessions { get; set; }

        [DataMember(Name = "connect_webviews", IsRequired = false, EmitDefaultValue = false)]
        public object ConnectWebviews { get; set; }

        [DataMember(Name = "connected_accounts", IsRequired = false, EmitDefaultValue = false)]
        public object ConnectedAccounts { get; set; }

        [DataMember(Name = "customization_profiles", IsRequired = false, EmitDefaultValue = false)]
        public object CustomizationProfiles { get; set; }

        [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
        public object Devices { get; set; }

        [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
        public object Events { get; set; }

        [DataMember(Name = "instant_keys", IsRequired = false, EmitDefaultValue = false)]
        public object InstantKeys { get; set; }

        [DataMember(Name = "noise_thresholds", IsRequired = false, EmitDefaultValue = false)]
        public object NoiseThresholds { get; set; }

        [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
        public object Spaces { get; set; }

        [DataMember(
            Name = "thermostat_daily_programs",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object ThermostatDailyPrograms { get; set; }

        [DataMember(Name = "thermostat_schedules", IsRequired = false, EmitDefaultValue = false)]
        public object ThermostatSchedules { get; set; }

        [DataMember(Name = "unmanaged_access_codes", IsRequired = false, EmitDefaultValue = false)]
        public object UnmanagedAccessCodes { get; set; }

        [DataMember(
            Name = "unmanaged_acs_access_groups",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object UnmanagedAcsAccessGroups { get; set; }

        [DataMember(
            Name = "unmanaged_acs_credentials",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public object UnmanagedAcsCredentials { get; set; }

        [DataMember(Name = "unmanaged_acs_users", IsRequired = false, EmitDefaultValue = false)]
        public object UnmanagedAcsUsers { get; set; }

        [DataMember(Name = "unmanaged_devices", IsRequired = false, EmitDefaultValue = false)]
        public object UnmanagedDevices { get; set; }

        [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
        public object UserIdentities { get; set; }

        [DataMember(Name = "workspaces", IsRequired = false, EmitDefaultValue = false)]
        public object Workspaces { get; set; }

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
