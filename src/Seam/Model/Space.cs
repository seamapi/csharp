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
    /// Represents a space that is a logical grouping of devices and entrances. You can assign access to an entire space, thereby making granting access more efficient.
    /// </summary>
    [DataContract(Name = "seamModel_space_model")]
    public class Space
    {
        [JsonConstructorAttribute]
        protected Space() { }

        public Space(
            float acsEntranceCount = default,
            string createdAt = default,
            SpaceCustomerData? customerData = default,
            string? customerKey = default,
            float deviceCount = default,
            string displayName = default,
            SpaceGeolocation? geolocation = default,
            string name = default,
            string spaceId = default,
            string? spaceKey = default,
            List<SpaceWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AcsEntranceCount = acsEntranceCount;
            CreatedAt = createdAt;
            CustomerData = customerData;
            CustomerKey = customerKey;
            DeviceCount = deviceCount;
            DisplayName = displayName;
            Geolocation = geolocation;
            Name = name;
            SpaceId = spaceId;
            SpaceKey = spaceKey;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(SpaceWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(SpaceWarningsNoiseSensorConfigurationMismatch),
            "noise_sensor_configuration_mismatch"
        )]
        [JsonSubtypes.KnownSubType(typeof(SpaceWarningsBeingDeleted), "being_deleted")]
        public abstract class SpaceWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_spaceWarningsBeingDeleted_model")]
        public class SpaceWarningsBeingDeleted : SpaceWarnings
        {
            [JsonConstructorAttribute]
            protected SpaceWarningsBeingDeleted() { }

            public SpaceWarningsBeingDeleted(
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
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "being_deleted";

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

        [DataContract(Name = "seamModel_spaceWarningsNoiseSensorConfigurationMismatch_model")]
        public class SpaceWarningsNoiseSensorConfigurationMismatch : SpaceWarnings
        {
            [JsonConstructorAttribute]
            protected SpaceWarningsNoiseSensorConfigurationMismatch() { }

            public SpaceWarningsNoiseSensorConfigurationMismatch(
                string createdAt = default,
                List<string> deviceIds = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                DeviceIds = deviceIds;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// IDs of the noise sensors in the space that Seam could not bring in line with the noise sensor automation.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "noise_sensor_configuration_mismatch";

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

        [DataContract(Name = "seamModel_spaceWarningsUnrecognized_model")]
        public class SpaceWarningsUnrecognized : SpaceWarnings
        {
            [JsonConstructorAttribute]
            protected SpaceWarningsUnrecognized() { }

            public SpaceWarningsUnrecognized(
                string warningCode = default,
                string createdAt = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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
        /// Number of entrances in the space.
        /// </summary>
        [DataMember(Name = "acs_entrance_count", IsRequired = false, EmitDefaultValue = false)]
        public float AcsEntranceCount { get; set; }

        /// <summary>
        /// Date and time at which the space was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Reservation/stay-related defaults for the space. Also carries the provider/PMS-supplied name under a `&lt;connector_type&gt;_name` key (e.g. `guesty_name`), which Seam preserves when you rename the space (read-only — managed by Seam).
        /// </summary>
        [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
        public SpaceCustomerData? CustomerData { get; set; }

        /// <summary>
        /// Customer key associated with the space.
        /// </summary>
        [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CustomerKey { get; set; }

        /// <summary>
        /// Number of devices in the space.
        /// </summary>
        [DataMember(Name = "device_count", IsRequired = false, EmitDefaultValue = false)]
        public float DeviceCount { get; set; }

        /// <summary>
        /// Display name for the space.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Geographic coordinates (latitude and longitude) of the space.
        /// </summary>
        [DataMember(Name = "geolocation", IsRequired = false, EmitDefaultValue = false)]
        public SpaceGeolocation? Geolocation { get; set; }

        /// <summary>
        /// Name of the space.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// ID of the space.
        /// </summary>
        [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
        public string SpaceId { get; set; }

        /// <summary>
        /// Unique key for the space within the workspace.
        /// </summary>
        [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
        public string? SpaceKey { get; set; }

        /// <summary>
        /// Warnings associated with the space.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<SpaceWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace associated with the space.
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

    [DataContract(Name = "seamModel_spaceCustomerData_model")]
    public class SpaceCustomerData
    {
        [JsonConstructorAttribute]
        protected SpaceCustomerData() { }

        public SpaceCustomerData(
            string? address = default,
            string? defaultCheckinTime = default,
            string? defaultCheckoutTime = default,
            string? timeZone = default
        )
        {
            Address = address;
            DefaultCheckinTime = defaultCheckinTime;
            DefaultCheckoutTime = defaultCheckoutTime;
            TimeZone = timeZone;
        }

        /// <summary>
        /// Postal address for the space.
        /// </summary>
        [DataMember(Name = "address", IsRequired = false, EmitDefaultValue = false)]
        public string? Address { get; set; }

        /// <summary>
        /// Default check-in time for reservations at the space, as HH:mm or HH:mm:ss.
        /// </summary>
        [DataMember(Name = "default_checkin_time", IsRequired = false, EmitDefaultValue = false)]
        public string? DefaultCheckinTime { get; set; }

        /// <summary>
        /// Default check-out time for reservations at the space, as HH:mm or HH:mm:ss.
        /// </summary>
        [DataMember(Name = "default_checkout_time", IsRequired = false, EmitDefaultValue = false)]
        public string? DefaultCheckoutTime { get; set; }

        /// <summary>
        /// IANA time zone for the space, e.g. America/Los_Angeles.
        /// </summary>
        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

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

    [DataContract(Name = "seamModel_spaceGeolocation_model")]
    public class SpaceGeolocation
    {
        [JsonConstructorAttribute]
        protected SpaceGeolocation() { }

        public SpaceGeolocation(float latitude = default, float longitude = default)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude of the space, in decimal degrees.
        /// </summary>
        [DataMember(Name = "latitude", IsRequired = false, EmitDefaultValue = false)]
        public float Latitude { get; set; }

        /// <summary>
        /// Longitude of the space, in decimal degrees.
        /// </summary>
        [DataMember(Name = "longitude", IsRequired = false, EmitDefaultValue = false)]
        public float Longitude { get; set; }

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
