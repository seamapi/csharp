using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_staffMember_model")]
    public class StaffMember
    {
        [JsonConstructorAttribute]
        protected StaffMember() { }

        public StaffMember(
            List<string>? buildingKeys = default,
            List<string>? commonAreaKeys = default,
            string? emailAddress = default,
            List<string>? facilityKeys = default,
            List<string>? listingKeys = default,
            string name = default,
            string? phoneNumber = default,
            List<string>? propertyKeys = default,
            List<string>? propertyListingKeys = default,
            List<string>? roomKeys = default,
            List<string>? siteKeys = default,
            List<string>? spaceKeys = default,
            string staffMemberKey = default,
            List<string>? unitKeys = default
        )
        {
            BuildingKeys = buildingKeys;
            CommonAreaKeys = commonAreaKeys;
            EmailAddress = emailAddress;
            FacilityKeys = facilityKeys;
            ListingKeys = listingKeys;
            Name = name;
            PhoneNumber = phoneNumber;
            PropertyKeys = propertyKeys;
            PropertyListingKeys = propertyListingKeys;
            RoomKeys = roomKeys;
            SiteKeys = siteKeys;
            SpaceKeys = spaceKeys;
            StaffMemberKey = staffMemberKey;
            UnitKeys = unitKeys;
        }

        [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? BuildingKeys { get; set; }

        [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAreaKeys { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? FacilityKeys { get; set; }

        [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? ListingKeys { get; set; }

        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? PropertyKeys { get; set; }

        [DataMember(Name = "property_listing_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? PropertyListingKeys { get; set; }

        [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? RoomKeys { get; set; }

        [DataMember(Name = "site_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? SiteKeys { get; set; }

        [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? SpaceKeys { get; set; }

        [DataMember(Name = "staff_member_key", IsRequired = true, EmitDefaultValue = false)]
        public string StaffMemberKey { get; set; }

        [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? UnitKeys { get; set; }

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
