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
                string? customizationProfileId = default,
                CreatePortalRequestFeatures? features = default,
                bool? isEmbedded = default,
                CreatePortalRequestLandingPage? landingPage = default,
                CreatePortalRequest.LocaleEnum? locale = default,
                object? propertyListingFilter = default,
                CreatePortalRequestCustomerData? customerData = default
            )
            {
                CustomizationProfileId = customizationProfileId;
                Features = features;
                IsEmbedded = isEmbedded;
                LandingPage = landingPage;
                Locale = locale;
                PropertyListingFilter = propertyListingFilter;
                CustomerData = customerData;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum LocaleEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "en-US")]
                EnUs = 1,

                [EnumMember(Value = "pt-PT")]
                PtPt = 2,

                [EnumMember(Value = "fr-FR")]
                FrFr = 3,

                [EnumMember(Value = "it-IT")]
                ItIt = 4,

                [EnumMember(Value = "es-ES")]
                EsEs = 5,
            }

            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            [DataMember(Name = "features", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeatures? Features { get; set; }

            [DataMember(Name = "is_embedded", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsEmbedded { get; set; }

            [DataMember(Name = "landing_page", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestLandingPage? LandingPage { get; set; }

            [DataMember(Name = "locale", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequest.LocaleEnum? Locale { get; set; }

            [DataMember(
                Name = "property_listing_filter",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public object? PropertyListingFilter { get; set; }

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
                CreatePortalRequestFeaturesConfigure? configure = default,
                CreatePortalRequestFeaturesConnect? connect = default,
                CreatePortalRequestFeaturesManage? manage = default,
                CreatePortalRequestFeaturesManageDevices? manageDevices = default,
                CreatePortalRequestFeaturesOrganize? organize = default
            )
            {
                Configure = configure;
                Connect = connect;
                Manage = manage;
                ManageDevices = manageDevices;
                Organize = organize;
            }

            [DataMember(Name = "configure", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesConfigure? Configure { get; set; }

            [DataMember(Name = "connect", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesConnect? Connect { get; set; }

            [DataMember(Name = "manage", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesManage? Manage { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesConfigure_model")]
        public class CreatePortalRequestFeaturesConfigure
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesConfigure() { }

            public CreatePortalRequestFeaturesConfigure(
                bool? allowAccessAutomationRuleCustomization = default,
                bool? allowClimateAutomationRuleCustomization = default,
                bool? allowInstantKeyCustomization = default,
                bool? exclude = default
            )
            {
                AllowAccessAutomationRuleCustomization = allowAccessAutomationRuleCustomization;
                AllowClimateAutomationRuleCustomization = allowClimateAutomationRuleCustomization;
                AllowInstantKeyCustomization = allowInstantKeyCustomization;
                Exclude = exclude;
            }

            [DataMember(
                Name = "allow_access_automation_rule_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowAccessAutomationRuleCustomization { get; set; }

            [DataMember(
                Name = "allow_climate_automation_rule_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowClimateAutomationRuleCustomization { get; set; }

            [DataMember(
                Name = "allow_instant_key_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowInstantKeyCustomization { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesConnect_model")]
        public class CreatePortalRequestFeaturesConnect
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesConnect() { }

            public CreatePortalRequestFeaturesConnect(
                List<string>? acceptedProviders = default,
                bool? exclude = default,
                List<string>? excludedProviders = default
            )
            {
                AcceptedProviders = acceptedProviders;
                Exclude = exclude;
                ExcludedProviders = excludedProviders;
            }

            [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcceptedProviders { get; set; }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

            [DataMember(Name = "excluded_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ExcludedProviders { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesManage_model")]
        public class CreatePortalRequestFeaturesManage
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesManage() { }

            public CreatePortalRequestFeaturesManage(
                bool? exclude = default,
                bool? excludeReservationManagement = default,
                bool? excludeStaffManagement = default
            )
            {
                Exclude = exclude;
                ExcludeReservationManagement = excludeReservationManagement;
                ExcludeStaffManagement = excludeStaffManagement;
            }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

            [DataMember(
                Name = "exclude_reservation_management",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ExcludeReservationManagement { get; set; }

            [DataMember(
                Name = "exclude_staff_management",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ExcludeStaffManagement { get; set; }

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

        [DataContract(Name = "createPortalRequestLandingPage_model")]
        public class CreatePortalRequestLandingPage
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestLandingPage() { }

            public CreatePortalRequestLandingPage(JObject? manage = default)
            {
                Manage = manage;
            }

            [DataMember(Name = "manage", IsRequired = false, EmitDefaultValue = false)]
            public JObject? Manage { get; set; }

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
                List<CreatePortalRequestCustomerDataPropertyListings>? propertyListings = default,
                List<CreatePortalRequestCustomerDataReservations>? reservations = default,
                List<CreatePortalRequestCustomerDataResidents>? residents = default,
                List<CreatePortalRequestCustomerDataRooms>? rooms = default,
                List<CreatePortalRequestCustomerDataSites>? sites = default,
                List<CreatePortalRequestCustomerDataSpaces>? spaces = default,
                List<CreatePortalRequestCustomerDataStaffMembers>? staffMembers = default,
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
                PropertyListings = propertyListings;
                Reservations = reservations;
                Residents = residents;
                Rooms = rooms;
                Sites = sites;
                Spaces = spaces;
                StaffMembers = staffMembers;
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

            [DataMember(Name = "property_listings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataPropertyListings>? PropertyListings { get; set; }

            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataReservations>? Reservations { get; set; }

            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataResidents>? Residents { get; set; }

            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataRooms>? Rooms { get; set; }

            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataSites>? Sites { get; set; }

            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataSpaces>? Spaces { get; set; }

            [DataMember(Name = "staff_members", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataStaffMembers>? StaffMembers { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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
                string name = default,
                string? parentSiteKey = default
            )
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
                ParentSiteKey = parentSiteKey;
            }

            [DataMember(Name = "common_area_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonAreaKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataPropertyListings_model")]
        public class CreatePortalRequestCustomerDataPropertyListings
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataPropertyListings() { }

            public CreatePortalRequestCustomerDataPropertyListings(
                object? customMetadata = default,
                string name = default,
                string propertyListingKey = default
            )
            {
                CustomMetadata = customMetadata;
                Name = name;
                PropertyListingKey = propertyListingKey;
            }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_listing_key", IsRequired = true, EmitDefaultValue = false)]
            public string PropertyListingKey { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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
                string? parentSiteKey = default,
                string roomKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                RoomKey = roomKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataSites_model")]
        public class CreatePortalRequestCustomerDataSites
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataSites() { }

            public CreatePortalRequestCustomerDataSites(
                string name = default,
                string siteKey = default
            )
            {
                Name = name;
                SiteKey = siteKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "site_key", IsRequired = true, EmitDefaultValue = false)]
            public string SiteKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataStaffMembers_model")]
        public class CreatePortalRequestCustomerDataStaffMembers
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataStaffMembers() { }

            public CreatePortalRequestCustomerDataStaffMembers(
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

            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
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
                string? parentSiteKey = default,
                string unitKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                UnitKey = unitKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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
            string? customizationProfileId = default,
            CreatePortalRequestFeatures? features = default,
            bool? isEmbedded = default,
            CreatePortalRequestLandingPage? landingPage = default,
            CreatePortalRequest.LocaleEnum? locale = default,
            object? propertyListingFilter = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return CreatePortal(
                new CreatePortalRequest(
                    customizationProfileId: customizationProfileId,
                    features: features,
                    isEmbedded: isEmbedded,
                    landingPage: landingPage,
                    locale: locale,
                    propertyListingFilter: propertyListingFilter,
                    customerData: customerData
                )
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
            string? customizationProfileId = default,
            CreatePortalRequestFeatures? features = default,
            bool? isEmbedded = default,
            CreatePortalRequestLandingPage? landingPage = default,
            CreatePortalRequest.LocaleEnum? locale = default,
            object? propertyListingFilter = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return (
                await CreatePortalAsync(
                    new CreatePortalRequest(
                        customizationProfileId: customizationProfileId,
                        features: features,
                        isEmbedded: isEmbedded,
                        landingPage: landingPage,
                        locale: locale,
                        propertyListingFilter: propertyListingFilter,
                        customerData: customerData
                    )
                )
            );
        }

        [DataContract(Name = "deleteDataRequest_request")]
        public class DeleteDataRequest
        {
            [JsonConstructorAttribute]
            protected DeleteDataRequest() { }

            public DeleteDataRequest(
                List<string>? accessGrantKeys = default,
                List<string>? bookingKeys = default,
                List<string>? buildingKeys = default,
                List<string>? commonAreaKeys = default,
                List<string>? customerKeys = default,
                List<string>? facilityKeys = default,
                List<string>? guestKeys = default,
                List<string>? listingKeys = default,
                List<string>? propertyKeys = default,
                List<string>? propertyListingKeys = default,
                List<string>? reservationKeys = default,
                List<string>? residentKeys = default,
                List<string>? roomKeys = default,
                List<string>? spaceKeys = default,
                List<string>? staffMemberKeys = default,
                List<string>? tenantKeys = default,
                List<string>? unitKeys = default,
                List<string>? userIdentityKeys = default,
                List<string>? userKeys = default
            )
            {
                AccessGrantKeys = accessGrantKeys;
                BookingKeys = bookingKeys;
                BuildingKeys = buildingKeys;
                CommonAreaKeys = commonAreaKeys;
                CustomerKeys = customerKeys;
                FacilityKeys = facilityKeys;
                GuestKeys = guestKeys;
                ListingKeys = listingKeys;
                PropertyKeys = propertyKeys;
                PropertyListingKeys = propertyListingKeys;
                ReservationKeys = reservationKeys;
                ResidentKeys = residentKeys;
                RoomKeys = roomKeys;
                SpaceKeys = spaceKeys;
                StaffMemberKeys = staffMemberKeys;
                TenantKeys = tenantKeys;
                UnitKeys = unitKeys;
                UserIdentityKeys = userIdentityKeys;
                UserKeys = userKeys;
            }

            [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantKeys { get; set; }

            [DataMember(Name = "booking_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BookingKeys { get; set; }

            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            [DataMember(Name = "customer_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CustomerKeys { get; set; }

            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            [DataMember(Name = "guest_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? GuestKeys { get; set; }

            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? PropertyListingKeys { get; set; }

            [DataMember(Name = "reservation_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ReservationKeys { get; set; }

            [DataMember(Name = "resident_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ResidentKeys { get; set; }

            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            [DataMember(Name = "staff_member_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? StaffMemberKeys { get; set; }

            [DataMember(Name = "tenant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? TenantKeys { get; set; }

            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            [DataMember(Name = "user_identity_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityKeys { get; set; }

            [DataMember(Name = "user_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserKeys { get; set; }

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

        public void DeleteData(DeleteDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/customers/delete_data", requestOptions);
        }

        public void DeleteData(
            List<string>? accessGrantKeys = default,
            List<string>? bookingKeys = default,
            List<string>? buildingKeys = default,
            List<string>? commonAreaKeys = default,
            List<string>? customerKeys = default,
            List<string>? facilityKeys = default,
            List<string>? guestKeys = default,
            List<string>? listingKeys = default,
            List<string>? propertyKeys = default,
            List<string>? propertyListingKeys = default,
            List<string>? reservationKeys = default,
            List<string>? residentKeys = default,
            List<string>? roomKeys = default,
            List<string>? spaceKeys = default,
            List<string>? staffMemberKeys = default,
            List<string>? tenantKeys = default,
            List<string>? unitKeys = default,
            List<string>? userIdentityKeys = default,
            List<string>? userKeys = default
        )
        {
            DeleteData(
                new DeleteDataRequest(
                    accessGrantKeys: accessGrantKeys,
                    bookingKeys: bookingKeys,
                    buildingKeys: buildingKeys,
                    commonAreaKeys: commonAreaKeys,
                    customerKeys: customerKeys,
                    facilityKeys: facilityKeys,
                    guestKeys: guestKeys,
                    listingKeys: listingKeys,
                    propertyKeys: propertyKeys,
                    propertyListingKeys: propertyListingKeys,
                    reservationKeys: reservationKeys,
                    residentKeys: residentKeys,
                    roomKeys: roomKeys,
                    spaceKeys: spaceKeys,
                    staffMemberKeys: staffMemberKeys,
                    tenantKeys: tenantKeys,
                    unitKeys: unitKeys,
                    userIdentityKeys: userIdentityKeys,
                    userKeys: userKeys
                )
            );
        }

        public async Task DeleteDataAsync(DeleteDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/customers/delete_data", requestOptions);
        }

        public async Task DeleteDataAsync(
            List<string>? accessGrantKeys = default,
            List<string>? bookingKeys = default,
            List<string>? buildingKeys = default,
            List<string>? commonAreaKeys = default,
            List<string>? customerKeys = default,
            List<string>? facilityKeys = default,
            List<string>? guestKeys = default,
            List<string>? listingKeys = default,
            List<string>? propertyKeys = default,
            List<string>? propertyListingKeys = default,
            List<string>? reservationKeys = default,
            List<string>? residentKeys = default,
            List<string>? roomKeys = default,
            List<string>? spaceKeys = default,
            List<string>? staffMemberKeys = default,
            List<string>? tenantKeys = default,
            List<string>? unitKeys = default,
            List<string>? userIdentityKeys = default,
            List<string>? userKeys = default
        )
        {
            await DeleteDataAsync(
                new DeleteDataRequest(
                    accessGrantKeys: accessGrantKeys,
                    bookingKeys: bookingKeys,
                    buildingKeys: buildingKeys,
                    commonAreaKeys: commonAreaKeys,
                    customerKeys: customerKeys,
                    facilityKeys: facilityKeys,
                    guestKeys: guestKeys,
                    listingKeys: listingKeys,
                    propertyKeys: propertyKeys,
                    propertyListingKeys: propertyListingKeys,
                    reservationKeys: reservationKeys,
                    residentKeys: residentKeys,
                    roomKeys: roomKeys,
                    spaceKeys: spaceKeys,
                    staffMemberKeys: staffMemberKeys,
                    tenantKeys: tenantKeys,
                    unitKeys: unitKeys,
                    userIdentityKeys: userIdentityKeys,
                    userKeys: userKeys
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
                List<PushDataRequestPropertyListings>? propertyListings = default,
                List<PushDataRequestReservations>? reservations = default,
                List<PushDataRequestResidents>? residents = default,
                List<PushDataRequestRooms>? rooms = default,
                List<PushDataRequestSites>? sites = default,
                List<PushDataRequestSpaces>? spaces = default,
                List<PushDataRequestStaffMembers>? staffMembers = default,
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
                PropertyListings = propertyListings;
                Reservations = reservations;
                Residents = residents;
                Rooms = rooms;
                Sites = sites;
                Spaces = spaces;
                StaffMembers = staffMembers;
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

            [DataMember(Name = "property_listings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestPropertyListings>? PropertyListings { get; set; }

            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestReservations>? Reservations { get; set; }

            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestResidents>? Residents { get; set; }

            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestRooms>? Rooms { get; set; }

            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestSites>? Sites { get; set; }

            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestSpaces>? Spaces { get; set; }

            [DataMember(Name = "staff_members", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestStaffMembers>? StaffMembers { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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

            public PushDataRequestCommonAreas(
                string commonAreaKey = default,
                string name = default,
                string? parentSiteKey = default
            )
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
                ParentSiteKey = parentSiteKey;
            }

            [DataMember(Name = "common_area_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonAreaKey { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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

        [DataContract(Name = "pushDataRequestPropertyListings_model")]
        public class PushDataRequestPropertyListings
        {
            [JsonConstructorAttribute]
            protected PushDataRequestPropertyListings() { }

            public PushDataRequestPropertyListings(
                object? customMetadata = default,
                string name = default,
                string propertyListingKey = default
            )
            {
                CustomMetadata = customMetadata;
                Name = name;
                PropertyListingKey = propertyListingKey;
            }

            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "property_listing_key", IsRequired = true, EmitDefaultValue = false)]
            public string PropertyListingKey { get; set; }

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
                string? name = default,
                string? preferredCode = default,
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
                PreferredCode = preferredCode;
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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

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

            public PushDataRequestRooms(
                string name = default,
                string? parentSiteKey = default,
                string roomKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                RoomKey = roomKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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

        [DataContract(Name = "pushDataRequestSites_model")]
        public class PushDataRequestSites
        {
            [JsonConstructorAttribute]
            protected PushDataRequestSites() { }

            public PushDataRequestSites(string name = default, string siteKey = default)
            {
                Name = name;
                SiteKey = siteKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "site_key", IsRequired = true, EmitDefaultValue = false)]
            public string SiteKey { get; set; }

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

        [DataContract(Name = "pushDataRequestStaffMembers_model")]
        public class PushDataRequestStaffMembers
        {
            [JsonConstructorAttribute]
            protected PushDataRequestStaffMembers() { }

            public PushDataRequestStaffMembers(
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

            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
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

            public PushDataRequestUnits(
                string name = default,
                string? parentSiteKey = default,
                string unitKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                UnitKey = unitKey;
            }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

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
            List<PushDataRequestPropertyListings>? propertyListings = default,
            List<PushDataRequestReservations>? reservations = default,
            List<PushDataRequestResidents>? residents = default,
            List<PushDataRequestRooms>? rooms = default,
            List<PushDataRequestSites>? sites = default,
            List<PushDataRequestSpaces>? spaces = default,
            List<PushDataRequestStaffMembers>? staffMembers = default,
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
                    propertyListings: propertyListings,
                    reservations: reservations,
                    residents: residents,
                    rooms: rooms,
                    sites: sites,
                    spaces: spaces,
                    staffMembers: staffMembers,
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
            List<PushDataRequestPropertyListings>? propertyListings = default,
            List<PushDataRequestReservations>? reservations = default,
            List<PushDataRequestResidents>? residents = default,
            List<PushDataRequestRooms>? rooms = default,
            List<PushDataRequestSites>? sites = default,
            List<PushDataRequestSpaces>? spaces = default,
            List<PushDataRequestStaffMembers>? staffMembers = default,
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
                    propertyListings: propertyListings,
                    reservations: reservations,
                    residents: residents,
                    rooms: rooms,
                    sites: sites,
                    spaces: spaces,
                    staffMembers: staffMembers,
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
