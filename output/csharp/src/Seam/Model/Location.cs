using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_location_model")]
    public class Location
    {
        [JsonConstructorAttribute]
        protected Location() { }

        public Location(
            string createdAt = default,
            string displayName = default,
            LocationGeolocation? geolocation = default,
            string locationId = default,
            string name = default,
            string? timeZone = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            DisplayName = displayName;
            Geolocation = geolocation;
            LocationId = locationId;
            Name = name;
            TimeZone = timeZone;
            WorkspaceId = workspaceId;
        }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "geolocation", IsRequired = false, EmitDefaultValue = false)]
        public LocationGeolocation? Geolocation { get; set; }

        [DataMember(Name = "location_id", IsRequired = true, EmitDefaultValue = false)]
        public string LocationId { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
        public string? TimeZone { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_locationGeolocation_model")]
    public class LocationGeolocation
    {
        [JsonConstructorAttribute]
        protected LocationGeolocation() { }

        public LocationGeolocation(float latitude = default, float longitude = default)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [DataMember(Name = "latitude", IsRequired = true, EmitDefaultValue = false)]
        public float Latitude { get; set; }

        [DataMember(Name = "longitude", IsRequired = true, EmitDefaultValue = false)]
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
