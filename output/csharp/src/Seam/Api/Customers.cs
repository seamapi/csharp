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
    public class Customers
    {
        private ISeamClient _seam;

        public Customers(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createPortalRequest_request")]
        public class CreatePortalRequest
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequest() { }

            public CreatePortalRequest(
                CreatePortalRequestFeatures? features = default,
                CreatePortalRequestCustomerData? customerData = default
            )
            {
                Features = features;
                CustomerData = customerData;
            }

            [DataMember(Name = "features", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeatures? Features { get; set; }

            [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestCustomerData? CustomerData { get; set; }

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

        [DataContract(Name = "createPortalRequestFeatures_model")]
        public class CreatePortalRequestFeatures
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeatures() { }

            public CreatePortalRequestFeatures(
                CreatePortalRequestFeaturesConnect? connect = default,
                CreatePortalRequestFeaturesManageDevices? manageDevices = default,
                CreatePortalRequestFeaturesOrganize? organize = default
            )
            {
                Connect = connect;
                ManageDevices = manageDevices;
                Organize = organize;
            }

            [DataMember(Name = "connect", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesConnect? Connect { get; set; }

            [DataMember(Name = "manage_devices", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesManageDevices? ManageDevices { get; set; }

            [DataMember(Name = "organize", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesOrganize? Organize { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesConnect_model")]
        public class CreatePortalRequestFeaturesConnect
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesConnect() { }

            public CreatePortalRequestFeaturesConnect(bool? exclude = default)
            {
                Exclude = exclude;
            }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesManageDevices_model")]
        public class CreatePortalRequestFeaturesManageDevices
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesManageDevices() { }

            public CreatePortalRequestFeaturesManageDevices(bool? exclude = default)
            {
                Exclude = exclude;
            }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesOrganize_model")]
        public class CreatePortalRequestFeaturesOrganize
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesOrganize() { }

            public CreatePortalRequestFeaturesOrganize(bool? exclude = default)
            {
                Exclude = exclude;
            }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerData_model")]
        public class CreatePortalRequestCustomerData
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerData() { }

            public CreatePortalRequestCustomerData(
                List<CreatePortalRequestCustomerDataAccessGrants>? accessGrants = default,
                List<CreatePortalRequestCustomerDataBookings>? bookings = default,
                List<CreatePortalRequestCustomerDataBuildings>? buildings = default,
                List<CreatePortalRequestCustomerDataCommonAreas>? commonAreas = default,
                string customerKey = default,
                List<CreatePortalRequestCustomerDataFacilities>? facilities = default,
                List<CreatePortalRequestCustomerDataGuests>? guests = default,
                List<CreatePortalRequestCustomerDataListings>? listings = default,
                List<CreatePortalRequestCustomerDataProperties>? properties = default,
                List<CreatePortalRequestCustomerDataReservations>? reservations = default,
                List<CreatePortalRequestCustomerDataResidents>? residents = default,
                List<CreatePortalRequestCustomerDataRooms>? rooms = default,
                List<CreatePortalRequestCustomerDataSpaces>? spaces = default,
                List<CreatePortalRequestCustomerDataTenants>? tenants = default,
                List<CreatePortalRequestCustomerDataUnits>? units = default,
                List<CreatePortalRequestCustomerDataUserIdentities>? userIdentities = default,
                List<CreatePortalRequestCustomerDataUsers>? users = default
            )
            {
                AccessGrants = accessGrants;
                Bookings = bookings;
                Buildings = buildings;
                CommonAreas = commonAreas;
                CustomerKey = customerKey;
                Facilities = facilities;
                Guests = guests;
                Listings = listings;
                Properties = properties;
                Reservations = reservations;
                Residents = residents;
                Rooms = rooms;
                Spaces = spaces;
                Tenants = tenants;
                Units = units;
                UserIdentities = userIdentities;
                Users = users;
            }

            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataAccessGrants>? AccessGrants { get; set; }

            [DataMember(Name = "bookings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataBookings>? Bookings { get; set; }

            [DataMember(Name = "buildings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataBuildings>? Buildings { get; set; }

            [DataMember(Name = "common_areas", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataCommonAreas>? CommonAreas { get; set; }

            [DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
            public string CustomerKey { get; set; }

            [DataMember(Name = "facilities", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataFacilities>? Facilities { get; set; }

            [DataMember(Name = "guests", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataGuests>? Guests { get; set; }

            [DataMember(Name = "listings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataListings>? Listings { get; set; }

            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataProperties>? Properties { get; set; }

            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataReservations>? Reservations { get; set; }

            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataResidents>? Residents { get; set; }

            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataRooms>? Rooms { get; set; }

            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataSpaces>? Spaces { get; set; }

            [DataMember(Name = "tenants", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataTenants>? Tenants { get; set; }

            [DataMember(Name = "units", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataUnits>? Units { get; set; }

            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataUserIdentities>? UserIdentities { get; set; }

            [DataMember(Name = "users", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataUsers>? Users { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataAccessGrants_model")]
        public class CreatePortalRequestCustomerDataAccessGrants
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataAccessGrants() { }

            public CreatePortalRequestCustomerDataAccessGrants(
                string accessGrantKey = default,
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                AccessGrantKey = accessGrantKey;
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "access_grant_key", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantKey { get; set; }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataBookings_model")]
        public class CreatePortalRequestCustomerDataBookings
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataBookings() { }

            public CreatePortalRequestCustomerDataBookings(
                string bookingKey = default,
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                BookingKey = bookingKey;
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "booking_key", IsRequired = true, EmitDefaultValue = false)]
            public string BookingKey { get; set; }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataBuildings_model")]
        public class CreatePortalRequestCustomerDataBuildings
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataBuildings() { }

            public CreatePortalRequestCustomerDataBuildings(
                string buildingKey = default,
                string name = default
            )
            {
                BuildingKey = buildingKey;
                Name = name;
            }

            [DataMember(Name = "building_key", IsRequired = true, EmitDefaultValue = false)]
            public string BuildingKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataCommonAreas_model")]
        public class CreatePortalRequestCustomerDataCommonAreas
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataCommonAreas() { }

            public CreatePortalRequestCustomerDataCommonAreas(
                string commonAreaKey = default,
                string name = default
            )
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
            }

            [DataMember(Name = "common_area_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonAreaKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataFacilities_model")]
        public class CreatePortalRequestCustomerDataFacilities
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataFacilities() { }

            public CreatePortalRequestCustomerDataFacilities(
                string facilityKey = default,
                string name = default
            )
            {
                FacilityKey = facilityKey;
                Name = name;
            }

            [DataMember(Name = "facility_key", IsRequired = true, EmitDefaultValue = false)]
            public string FacilityKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataGuests_model")]
        public class CreatePortalRequestCustomerDataGuests
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataGuests() { }

            public CreatePortalRequestCustomerDataGuests(
                string? emailAddress = default,
                string guestKey = default,
                string name = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                GuestKey = guestKey;
                Name = name;
                PhoneNumber = phoneNumber;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "guest_key", IsRequired = true, EmitDefaultValue = false)]
            public string GuestKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataListings_model")]
        public class CreatePortalRequestCustomerDataListings
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataListings() { }

            public CreatePortalRequestCustomerDataListings(
                string listingKey = default,
                string name = default
            )
            {
                ListingKey = listingKey;
                Name = name;
            }

            [DataMember(Name = "listing_key", IsRequired = true, EmitDefaultValue = false)]
            public string ListingKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataProperties_model")]
        public class CreatePortalRequestCustomerDataProperties
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataProperties() { }

            public CreatePortalRequestCustomerDataProperties(
                string name = default,
                string propertyKey = default
            )
            {
                Name = name;
                PropertyKey = propertyKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_key", IsRequired = true, EmitDefaultValue = false)]
            public string PropertyKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataReservations_model")]
        public class CreatePortalRequestCustomerDataReservations
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataReservations() { }

            public CreatePortalRequestCustomerDataReservations(
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string reservationKey = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ReservationKey = reservationKey;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "reservation_key", IsRequired = true, EmitDefaultValue = false)]
            public string ReservationKey { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataResidents_model")]
        public class CreatePortalRequestCustomerDataResidents
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataResidents() { }

            public CreatePortalRequestCustomerDataResidents(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string residentKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                ResidentKey = residentKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "resident_key", IsRequired = true, EmitDefaultValue = false)]
            public string ResidentKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataRooms_model")]
        public class CreatePortalRequestCustomerDataRooms
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataRooms() { }

            public CreatePortalRequestCustomerDataRooms(
                string name = default,
                string roomKey = default
            )
            {
                Name = name;
                RoomKey = roomKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "room_key", IsRequired = true, EmitDefaultValue = false)]
            public string RoomKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataSpaces_model")]
        public class CreatePortalRequestCustomerDataSpaces
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataSpaces() { }

            public CreatePortalRequestCustomerDataSpaces(
                string name = default,
                string spaceKey = default
            )
            {
                Name = name;
                SpaceKey = spaceKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "space_key", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataTenants_model")]
        public class CreatePortalRequestCustomerDataTenants
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataTenants() { }

            public CreatePortalRequestCustomerDataTenants(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string tenantKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                TenantKey = tenantKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = true, EmitDefaultValue = false)]
            public string TenantKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataUnits_model")]
        public class CreatePortalRequestCustomerDataUnits
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataUnits() { }

            public CreatePortalRequestCustomerDataUnits(
                string name = default,
                string unitKey = default
            )
            {
                Name = name;
                UnitKey = unitKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "unit_key", IsRequired = true, EmitDefaultValue = false)]
            public string UnitKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataUserIdentities_model")]
        public class CreatePortalRequestCustomerDataUserIdentities
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataUserIdentities() { }

            public CreatePortalRequestCustomerDataUserIdentities(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataUsers_model")]
        public class CreatePortalRequestCustomerDataUsers
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataUsers() { }

            public CreatePortalRequestCustomerDataUsers(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string userKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserKey = userKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "user_key", IsRequired = true, EmitDefaultValue = false)]
            public string UserKey { get; set; }

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

        [DataContract(Name = "createPortalResponse_response")]
        public class CreatePortalResponse
        {
            [JsonConstructorAttribute]
            protected CreatePortalResponse() { }

            public CreatePortalResponse(MagicLink magicLink = default)
            {
                MagicLink = magicLink;
            }

            [DataMember(Name = "magic_link", IsRequired = false, EmitDefaultValue = false)]
            public MagicLink MagicLink { get; set; }

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

        public MagicLink CreatePortal(CreatePortalRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreatePortalResponse>("/customers/create_portal", requestOptions)
                .Data.MagicLink;
        }

        public MagicLink CreatePortal(
            CreatePortalRequestFeatures? features = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return CreatePortal(
                new CreatePortalRequest(features: features, customerData: customerData)
            );
        }

        public async Task<MagicLink> CreatePortalAsync(CreatePortalRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreatePortalResponse>(
                    "/customers/create_portal",
                    requestOptions
                )
            )
                .Data
                .MagicLink;
        }

        public async Task<MagicLink> CreatePortalAsync(
            CreatePortalRequestFeatures? features = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return (
                await CreatePortalAsync(
                    new CreatePortalRequest(features: features, customerData: customerData)
                )
            );
        }

        [DataContract(Name = "pushDataRequest_request")]
        public class PushDataRequest
        {
            [JsonConstructorAttribute]
            protected PushDataRequest() { }

            public PushDataRequest(
                List<PushDataRequestAccessGrants>? accessGrants = default,
                List<PushDataRequestBookings>? bookings = default,
                List<PushDataRequestBuildings>? buildings = default,
                List<PushDataRequestCommonAreas>? commonAreas = default,
                string customerKey = default,
                List<PushDataRequestFacilities>? facilities = default,
                List<PushDataRequestGuests>? guests = default,
                List<PushDataRequestListings>? listings = default,
                List<PushDataRequestProperties>? properties = default,
                List<PushDataRequestReservations>? reservations = default,
                List<PushDataRequestResidents>? residents = default,
                List<PushDataRequestRooms>? rooms = default,
                List<PushDataRequestSpaces>? spaces = default,
                List<PushDataRequestTenants>? tenants = default,
                List<PushDataRequestUnits>? units = default,
                List<PushDataRequestUserIdentities>? userIdentities = default,
                List<PushDataRequestUsers>? users = default
            )
            {
                AccessGrants = accessGrants;
                Bookings = bookings;
                Buildings = buildings;
                CommonAreas = commonAreas;
                CustomerKey = customerKey;
                Facilities = facilities;
                Guests = guests;
                Listings = listings;
                Properties = properties;
                Reservations = reservations;
                Residents = residents;
                Rooms = rooms;
                Spaces = spaces;
                Tenants = tenants;
                Units = units;
                UserIdentities = userIdentities;
                Users = users;
            }

            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestAccessGrants>? AccessGrants { get; set; }

            [DataMember(Name = "bookings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestBookings>? Bookings { get; set; }

            [DataMember(Name = "buildings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestBuildings>? Buildings { get; set; }

            [DataMember(Name = "common_areas", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestCommonAreas>? CommonAreas { get; set; }

            [DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
            public string CustomerKey { get; set; }

            [DataMember(Name = "facilities", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestFacilities>? Facilities { get; set; }

            [DataMember(Name = "guests", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestGuests>? Guests { get; set; }

            [DataMember(Name = "listings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestListings>? Listings { get; set; }

            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestProperties>? Properties { get; set; }

            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestReservations>? Reservations { get; set; }

            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestResidents>? Residents { get; set; }

            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestRooms>? Rooms { get; set; }

            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestSpaces>? Spaces { get; set; }

            [DataMember(Name = "tenants", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestTenants>? Tenants { get; set; }

            [DataMember(Name = "units", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestUnits>? Units { get; set; }

            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestUserIdentities>? UserIdentities { get; set; }

            [DataMember(Name = "users", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestUsers>? Users { get; set; }

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

        [DataContract(Name = "pushDataRequestAccessGrants_model")]
        public class PushDataRequestAccessGrants
        {
            [JsonConstructorAttribute]
            protected PushDataRequestAccessGrants() { }

            public PushDataRequestAccessGrants(
                string accessGrantKey = default,
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                AccessGrantKey = accessGrantKey;
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "access_grant_key", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantKey { get; set; }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "pushDataRequestBookings_model")]
        public class PushDataRequestBookings
        {
            [JsonConstructorAttribute]
            protected PushDataRequestBookings() { }

            public PushDataRequestBookings(
                string bookingKey = default,
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                BookingKey = bookingKey;
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "booking_key", IsRequired = true, EmitDefaultValue = false)]
            public string BookingKey { get; set; }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "pushDataRequestBuildings_model")]
        public class PushDataRequestBuildings
        {
            [JsonConstructorAttribute]
            protected PushDataRequestBuildings() { }

            public PushDataRequestBuildings(string buildingKey = default, string name = default)
            {
                BuildingKey = buildingKey;
                Name = name;
            }

            [DataMember(Name = "building_key", IsRequired = true, EmitDefaultValue = false)]
            public string BuildingKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "pushDataRequestCommonAreas_model")]
        public class PushDataRequestCommonAreas
        {
            [JsonConstructorAttribute]
            protected PushDataRequestCommonAreas() { }

            public PushDataRequestCommonAreas(string commonAreaKey = default, string name = default)
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
            }

            [DataMember(Name = "common_area_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonAreaKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "pushDataRequestFacilities_model")]
        public class PushDataRequestFacilities
        {
            [JsonConstructorAttribute]
            protected PushDataRequestFacilities() { }

            public PushDataRequestFacilities(string facilityKey = default, string name = default)
            {
                FacilityKey = facilityKey;
                Name = name;
            }

            [DataMember(Name = "facility_key", IsRequired = true, EmitDefaultValue = false)]
            public string FacilityKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "pushDataRequestGuests_model")]
        public class PushDataRequestGuests
        {
            [JsonConstructorAttribute]
            protected PushDataRequestGuests() { }

            public PushDataRequestGuests(
                string? emailAddress = default,
                string guestKey = default,
                string name = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                GuestKey = guestKey;
                Name = name;
                PhoneNumber = phoneNumber;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "guest_key", IsRequired = true, EmitDefaultValue = false)]
            public string GuestKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "pushDataRequestListings_model")]
        public class PushDataRequestListings
        {
            [JsonConstructorAttribute]
            protected PushDataRequestListings() { }

            public PushDataRequestListings(string listingKey = default, string name = default)
            {
                ListingKey = listingKey;
                Name = name;
            }

            [DataMember(Name = "listing_key", IsRequired = true, EmitDefaultValue = false)]
            public string ListingKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "pushDataRequestProperties_model")]
        public class PushDataRequestProperties
        {
            [JsonConstructorAttribute]
            protected PushDataRequestProperties() { }

            public PushDataRequestProperties(string name = default, string propertyKey = default)
            {
                Name = name;
                PropertyKey = propertyKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_key", IsRequired = true, EmitDefaultValue = false)]
            public string PropertyKey { get; set; }

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

        [DataContract(Name = "pushDataRequestReservations_model")]
        public class PushDataRequestReservations
        {
            [JsonConstructorAttribute]
            protected PushDataRequestReservations() { }

            public PushDataRequestReservations(
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string name = default,
                List<string>? propertyKeys = default,
                string reservationKey = default,
                string? residentKey = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                string? startsAt = default,
                string? tenantKey = default,
                List<string>? unitKeys = default,
                string? userIdentityKey = default,
                string? userKey = default
            )
            {
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                EndsAt = endsAt;
                FacilityKeys = facilityKeys;
                GuestKey = guestKey;
                ListingKeys = listingKeys;
                Name = name;
                PropertyKeys = propertyKeys;
                ReservationKey = reservationKey;
                ResidentKey = residentKey;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StartsAt = startsAt;
                TenantKey = tenantKey;
                UnitKeys = unitKeys;
                UserIdentityKey = userIdentityKey;
                UserKey = userKey;
            }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(Name = "reservation_key", IsRequired = true, EmitDefaultValue = false)]
            public string ReservationKey { get; set; }

            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "user_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserKey { get; set; }

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

        [DataContract(Name = "pushDataRequestResidents_model")]
        public class PushDataRequestResidents
        {
            [JsonConstructorAttribute]
            protected PushDataRequestResidents() { }

            public PushDataRequestResidents(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string residentKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                ResidentKey = residentKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "resident_key", IsRequired = true, EmitDefaultValue = false)]
            public string ResidentKey { get; set; }

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

        [DataContract(Name = "pushDataRequestRooms_model")]
        public class PushDataRequestRooms
        {
            [JsonConstructorAttribute]
            protected PushDataRequestRooms() { }

            public PushDataRequestRooms(string name = default, string roomKey = default)
            {
                Name = name;
                RoomKey = roomKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "room_key", IsRequired = true, EmitDefaultValue = false)]
            public string RoomKey { get; set; }

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

        [DataContract(Name = "pushDataRequestSpaces_model")]
        public class PushDataRequestSpaces
        {
            [JsonConstructorAttribute]
            protected PushDataRequestSpaces() { }

            public PushDataRequestSpaces(string name = default, string spaceKey = default)
            {
                Name = name;
                SpaceKey = spaceKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "space_key", IsRequired = true, EmitDefaultValue = false)]
            public string SpaceKey { get; set; }

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

        [DataContract(Name = "pushDataRequestTenants_model")]
        public class PushDataRequestTenants
        {
            [JsonConstructorAttribute]
            protected PushDataRequestTenants() { }

            public PushDataRequestTenants(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string tenantKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                TenantKey = tenantKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "tenant_key", IsRequired = true, EmitDefaultValue = false)]
            public string TenantKey { get; set; }

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

        [DataContract(Name = "pushDataRequestUnits_model")]
        public class PushDataRequestUnits
        {
            [JsonConstructorAttribute]
            protected PushDataRequestUnits() { }

            public PushDataRequestUnits(string name = default, string unitKey = default)
            {
                Name = name;
                UnitKey = unitKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "unit_key", IsRequired = true, EmitDefaultValue = false)]
            public string UnitKey { get; set; }

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

        [DataContract(Name = "pushDataRequestUserIdentities_model")]
        public class PushDataRequestUserIdentities
        {
            [JsonConstructorAttribute]
            protected PushDataRequestUserIdentities() { }

            public PushDataRequestUserIdentities(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityKey { get; set; }

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

        [DataContract(Name = "pushDataRequestUsers_model")]
        public class PushDataRequestUsers
        {
            [JsonConstructorAttribute]
            protected PushDataRequestUsers() { }

            public PushDataRequestUsers(
                string? emailAddress = default,
                string name = default,
                string? phoneNumber = default,
                string userKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserKey = userKey;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "user_key", IsRequired = true, EmitDefaultValue = false)]
            public string UserKey { get; set; }

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

        public void PushData(PushDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/customers/push_data", requestOptions);
        }

        public void PushData(
            List<PushDataRequestAccessGrants>? accessGrants = default,
            List<PushDataRequestBookings>? bookings = default,
            List<PushDataRequestBuildings>? buildings = default,
            List<PushDataRequestCommonAreas>? commonAreas = default,
            string customerKey = default,
            List<PushDataRequestFacilities>? facilities = default,
            List<PushDataRequestGuests>? guests = default,
            List<PushDataRequestListings>? listings = default,
            List<PushDataRequestProperties>? properties = default,
            List<PushDataRequestReservations>? reservations = default,
            List<PushDataRequestResidents>? residents = default,
            List<PushDataRequestRooms>? rooms = default,
            List<PushDataRequestSpaces>? spaces = default,
            List<PushDataRequestTenants>? tenants = default,
            List<PushDataRequestUnits>? units = default,
            List<PushDataRequestUserIdentities>? userIdentities = default,
            List<PushDataRequestUsers>? users = default
        )
        {
            PushData(
                new PushDataRequest(
                    accessGrants: accessGrants,
                    bookings: bookings,
                    buildings: buildings,
                    commonAreas: commonAreas,
                    customerKey: customerKey,
                    facilities: facilities,
                    guests: guests,
                    listings: listings,
                    properties: properties,
                    reservations: reservations,
                    residents: residents,
                    rooms: rooms,
                    spaces: spaces,
                    tenants: tenants,
                    units: units,
                    userIdentities: userIdentities,
                    users: users
                )
            );
        }

        public async Task PushDataAsync(PushDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/customers/push_data", requestOptions);
        }

        public async Task PushDataAsync(
            List<PushDataRequestAccessGrants>? accessGrants = default,
            List<PushDataRequestBookings>? bookings = default,
            List<PushDataRequestBuildings>? buildings = default,
            List<PushDataRequestCommonAreas>? commonAreas = default,
            string customerKey = default,
            List<PushDataRequestFacilities>? facilities = default,
            List<PushDataRequestGuests>? guests = default,
            List<PushDataRequestListings>? listings = default,
            List<PushDataRequestProperties>? properties = default,
            List<PushDataRequestReservations>? reservations = default,
            List<PushDataRequestResidents>? residents = default,
            List<PushDataRequestRooms>? rooms = default,
            List<PushDataRequestSpaces>? spaces = default,
            List<PushDataRequestTenants>? tenants = default,
            List<PushDataRequestUnits>? units = default,
            List<PushDataRequestUserIdentities>? userIdentities = default,
            List<PushDataRequestUsers>? users = default
        )
        {
            await PushDataAsync(
                new PushDataRequest(
                    accessGrants: accessGrants,
                    bookings: bookings,
                    buildings: buildings,
                    commonAreas: commonAreas,
                    customerKey: customerKey,
                    facilities: facilities,
                    guests: guests,
                    listings: listings,
                    properties: properties,
                    reservations: reservations,
                    residents: residents,
                    rooms: rooms,
                    spaces: spaces,
                    tenants: tenants,
                    units: units,
                    userIdentities: userIdentities,
                    users: users
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Customers Customers => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Customers Customers { get; }
    }
}
