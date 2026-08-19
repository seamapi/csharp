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

        /// <summary>
        /// Request parameters for Create Customer Portal.
        /// </summary>
        [DataContract(Name = "createPortalRequest_request")]
        public class CreatePortalRequest
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequest() { }

            public CreatePortalRequest(
                List<CreatePortalRequestCustomerResourcesFilters>? customerResourcesFilters =
                    default,
                string? customizationProfileId = default,
                CreatePortalRequestDeepLink? deepLink = default,
                bool? excludeLocalePicker = default,
                CreatePortalRequestFeatures? features = default,
                bool? isEmbedded = default,
                CreatePortalRequestLandingPage? landingPage = default,
                CreatePortalRequest.LocaleEnum? locale = default,
                CreatePortalRequest.NavigationModeEnum? navigationMode = default,
                bool? readOnly = default,
                CreatePortalRequestCustomerData? customerData = default
            )
            {
                CustomerResourcesFilters = customerResourcesFilters;
                CustomizationProfileId = customizationProfileId;
                DeepLink = deepLink;
                ExcludeLocalePicker = excludeLocalePicker;
                Features = features;
                IsEmbedded = isEmbedded;
                LandingPage = landingPage;
                Locale = locale;
                NavigationMode = navigationMode;
                ReadOnly = readOnly;
                CustomerData = customerData;
            }

            /// <summary>
            /// The locale to use for the portal.
            /// </summary>
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

                [EnumMember(Value = "de-DE")]
                DeDe = 6,

                [EnumMember(Value = "nl-NL")]
                NlNl = 7,

                [EnumMember(Value = "el-GR")]
                ElGr = 8,

                [EnumMember(Value = "pl-PL")]
                PlPl = 9,

                [EnumMember(Value = "ru-RU")]
                RuRu = 10,
            }

            /// <summary>
            /// Navigation mode for the portal. &apos;restricted&apos; tells frontend to hide navigation UI, typically used for embedded deep links.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum NavigationModeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "full")]
                Full = 1,

                [EnumMember(Value = "restricted")]
                Restricted = 2,
            }

            /// <summary>
            /// Filter configuration for resources based on their custom_metadata. Each filter specifies a field, operation, and value to match against resource custom_metadata.
            /// </summary>
            [DataMember(
                Name = "customer_resources_filters",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<CreatePortalRequestCustomerResourcesFilters>? CustomerResourcesFilters { get; set; }

            /// <summary>
            /// The ID of the customization profile to use for the portal.
            /// </summary>
            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            /// <summary>
            /// Deep link target resource for initial redirect. When set, the portal will navigate directly to the specified resource.
            /// </summary>
            [DataMember(Name = "deep_link", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestDeepLink? DeepLink { get; set; }

            /// <summary>
            /// Whether to exclude the option to select a locale within the portal UI.
            /// </summary>
            [DataMember(
                Name = "exclude_locale_picker",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ExcludeLocalePicker { get; set; }

            [DataMember(Name = "features", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeatures? Features { get; set; }

            /// <summary>
            /// Whether the portal is embedded in another application.
            /// </summary>
            [DataMember(Name = "is_embedded", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsEmbedded { get; set; }

            /// <summary>
            /// Configuration for the landing page when the portal loads.
            /// </summary>
            [DataMember(Name = "landing_page", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestLandingPage? LandingPage { get; set; }

            /// <summary>
            /// The locale to use for the portal.
            /// </summary>
            [DataMember(Name = "locale", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequest.LocaleEnum? Locale { get; set; }

            /// <summary>
            /// Navigation mode for the portal. &apos;restricted&apos; tells frontend to hide navigation UI, typically used for embedded deep links.
            /// </summary>
            [DataMember(Name = "navigation_mode", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequest.NavigationModeEnum? NavigationMode { get; set; }

            /// <summary>
            /// Whether the portal is read-only. When true, the customer can browse the portal but cannot perform any mutating action; write requests made with the portal&apos;s client session are rejected.
            /// </summary>
            [DataMember(Name = "read_only", IsRequired = false, EmitDefaultValue = false)]
            public bool? ReadOnly { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerResourcesFilters_model")]
        public class CreatePortalRequestCustomerResourcesFilters
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerResourcesFilters() { }

            public CreatePortalRequestCustomerResourcesFilters(
                string? field = default,
                CreatePortalRequestCustomerResourcesFilters.OperationEnum? operation = default,
                string? value = default
            )
            {
                Field = field;
                Operation = operation;
                Value = value;
            }

            /// <summary>
            /// The comparison operation. Currently only &apos;=&apos; is supported.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum OperationEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "=")]
                empty = 1,
            }

            /// <summary>
            /// The custom_metadata field name to filter on.
            /// </summary>
            [DataMember(Name = "field", IsRequired = false, EmitDefaultValue = false)]
            public string? Field { get; set; }

            /// <summary>
            /// The comparison operation. Currently only &apos;=&apos; is supported.
            /// </summary>
            [DataMember(Name = "operation", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestCustomerResourcesFilters.OperationEnum? Operation { get; set; }

            /// <summary>
            /// The value to compare against.
            /// </summary>
            [DataMember(Name = "value", IsRequired = false, EmitDefaultValue = false)]
            public string? Value { get; set; }

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

        [DataContract(Name = "createPortalRequestDeepLink_model")]
        public class CreatePortalRequestDeepLink
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestDeepLink() { }

            public CreatePortalRequestDeepLink(
                string? resourceKey = default,
                CreatePortalRequestDeepLink.ResourceTypeEnum? resourceType = default,
                string? resourceId = default
            )
            {
                ResourceKey = resourceKey;
                ResourceType = resourceType;
                ResourceId = resourceId;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ResourceTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "reservation")]
                Reservation = 1,

                [EnumMember(Value = "space")]
                Space = 2,

                [EnumMember(Value = "device")]
                Device = 3,
            }

            [DataMember(Name = "resource_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResourceKey { get; set; }

            [DataMember(Name = "resource_type", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestDeepLink.ResourceTypeEnum? ResourceType { get; set; }

            [DataMember(Name = "resource_id", IsRequired = false, EmitDefaultValue = false)]
            public string? ResourceId { get; set; }

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

            /// <summary>
            /// Configuration for the configure feature.
            /// </summary>
            [DataMember(Name = "configure", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesConfigure? Configure { get; set; }

            /// <summary>
            /// Configuration for the connect accounts feature.
            /// </summary>
            [DataMember(Name = "connect", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesConnect? Connect { get; set; }

            /// <summary>
            /// Configuration for the manage feature.
            /// </summary>
            [DataMember(Name = "manage", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesManage? Manage { get; set; }

            /// <summary>
            /// Configuration for the manage devices feature.
            /// ---
            /// deprecated: Use `manage` instead.
            /// ---
            /// </summary>
            [DataMember(Name = "manage_devices", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesManageDevices? ManageDevices { get; set; }

            /// <summary>
            /// Configuration for the organize feature.
            /// </summary>
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

            /// <summary>
            /// Indicates whether the customer can customize the access automation rules for their properties.
            /// </summary>
            [DataMember(
                Name = "allow_access_automation_rule_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowAccessAutomationRuleCustomization { get; set; }

            /// <summary>
            /// Indicates whether the customer can customize the climate automation rules for their properties.
            /// </summary>
            [DataMember(
                Name = "allow_climate_automation_rule_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowClimateAutomationRuleCustomization { get; set; }

            /// <summary>
            /// Indicates whether the customer can customize the Instant Key profile for their properties.
            /// </summary>
            [DataMember(
                Name = "allow_instant_key_customization",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowInstantKeyCustomization { get; set; }

            /// <summary>
            /// Whether to exclude this feature from the portal.
            /// </summary>
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

            /// <summary>
            /// List of provider keys to allow for the connect feature. These providers will be shown when the customer tries to connect an account.
            /// </summary>
            [DataMember(Name = "accepted_providers", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcceptedProviders { get; set; }

            /// <summary>
            /// Whether to exclude this feature from the portal.
            /// </summary>
            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

            /// <summary>
            /// List of provider keys to exclude from the connect feature. These providers will not be shown when the customer tries to connect an account.
            /// </summary>
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
                CreatePortalRequestFeaturesManageDeviceManagementConfirmation? deviceManagementConfirmation =
                    default,
                CreatePortalRequestFeaturesManageEvents? events = default,
                bool? exclude = default,
                bool? excludeReservationManagement = default,
                bool? excludeReservationTechnicalDetails = default,
                bool? excludeStaffManagement = default
            )
            {
                DeviceManagementConfirmation = deviceManagementConfirmation;
                Events = events;
                Exclude = exclude;
                ExcludeReservationManagement = excludeReservationManagement;
                ExcludeReservationTechnicalDetails = excludeReservationTechnicalDetails;
                ExcludeStaffManagement = excludeStaffManagement;
            }

            /// <summary>
            /// Custom copy for the confirmation modal shown before unmanaged devices are added to a space and begin being managed (and billed). Only takes effect when the MANAGE_DEVICES_CONFIRMATION_MODAL feature flag is enabled for the workspace. Any omitted string falls back to a localized default.
            /// </summary>
            [DataMember(
                Name = "device_management_confirmation",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreatePortalRequestFeaturesManageDeviceManagementConfirmation? DeviceManagementConfirmation { get; set; }

            /// <summary>
            /// Configuration for event type filtering in the manage feature.
            /// </summary>
            [DataMember(Name = "events", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestFeaturesManageEvents? Events { get; set; }

            /// <summary>
            /// Whether to exclude this feature from the portal.
            /// </summary>
            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public bool? Exclude { get; set; }

            /// <summary>
            /// Indicates whether the customer can manage reservations for their properties.
            /// </summary>
            [DataMember(
                Name = "exclude_reservation_management",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ExcludeReservationManagement { get; set; }

            /// <summary>
            /// Indicates whether to exclude technical details from reservation views.
            /// </summary>
            [DataMember(
                Name = "exclude_reservation_technical_details",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? ExcludeReservationTechnicalDetails { get; set; }

            /// <summary>
            /// Indicates whether the customer can manage staff for their properties.
            /// </summary>
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

        [DataContract(Name = "createPortalRequestFeaturesManageDeviceManagementConfirmation_model")]
        public class CreatePortalRequestFeaturesManageDeviceManagementConfirmation
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesManageDeviceManagementConfirmation() { }

            public CreatePortalRequestFeaturesManageDeviceManagementConfirmation(
                string? body = default,
                string? cancelButtonLabel = default,
                string? confirmButtonLabel = default,
                string? title = default
            )
            {
                Body = body;
                CancelButtonLabel = cancelButtonLabel;
                ConfirmButtonLabel = confirmButtonLabel;
                Title = title;
            }

            /// <summary>
            /// Custom body text for the confirmation modal. May include the {count} token, which is replaced with the number of devices that will begin being managed.
            /// </summary>
            [DataMember(Name = "body", IsRequired = false, EmitDefaultValue = false)]
            public string? Body { get; set; }

            /// <summary>
            /// Custom label for the cancel button.
            /// </summary>
            [DataMember(Name = "cancel_button_label", IsRequired = false, EmitDefaultValue = false)]
            public string? CancelButtonLabel { get; set; }

            /// <summary>
            /// Custom label for the confirm button.
            /// </summary>
            [DataMember(
                Name = "confirm_button_label",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConfirmButtonLabel { get; set; }

            /// <summary>
            /// Custom title for the confirmation modal.
            /// </summary>
            [DataMember(Name = "title", IsRequired = false, EmitDefaultValue = false)]
            public string? Title { get; set; }

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

        [DataContract(Name = "createPortalRequestFeaturesManageEvents_model")]
        public class CreatePortalRequestFeaturesManageEvents
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestFeaturesManageEvents() { }

            public CreatePortalRequestFeaturesManageEvents(
                List<string>? allowedEvents = default,
                List<string>? defaultEvents = default
            )
            {
                AllowedEvents = allowedEvents;
                DefaultEvents = defaultEvents;
            }

            /// <summary>
            /// List of event types to show in the events filter. When set, only these event types will be available. Leave empty to show all events.
            /// </summary>
            [DataMember(Name = "allowed_events", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AllowedEvents { get; set; }

            /// <summary>
            /// List of event types that are pre-selected in the events filter when the user first loads the events tab.
            /// </summary>
            [DataMember(Name = "default_events", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? DefaultEvents { get; set; }

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

            /// <summary>
            /// Whether to exclude this feature from the portal.
            /// </summary>
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

            /// <summary>
            /// Whether to exclude this feature from the portal.
            /// </summary>
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

            public CreatePortalRequestLandingPage(
                CreatePortalRequestLandingPageManage? manage = default
            )
            {
                Manage = manage;
            }

            [DataMember(Name = "manage", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestLandingPageManage? Manage { get; set; }

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

        [DataContract(Name = "createPortalRequestLandingPageManage_model")]
        public class CreatePortalRequestLandingPageManage
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestLandingPageManage() { }

            public CreatePortalRequestLandingPageManage(
                string? spaceKey = default,
                string? propertyKey = default,
                string? roomKey = default,
                string? commonAreaKey = default,
                string? unitKey = default,
                string? facilityKey = default,
                string? buildingKey = default,
                string? listingKey = default,
                string? propertyListingKey = default,
                string? siteKey = default,
                string? reservationKey = default,
                string? bookingKey = default,
                string? accessGrantKey = default
            )
            {
                SpaceKey = spaceKey;
                PropertyKey = propertyKey;
                RoomKey = roomKey;
                CommonAreaKey = commonAreaKey;
                UnitKey = unitKey;
                FacilityKey = facilityKey;
                BuildingKey = buildingKey;
                ListingKey = listingKey;
                PropertyListingKey = propertyListingKey;
                SiteKey = siteKey;
                ReservationKey = reservationKey;
                BookingKey = bookingKey;
                AccessGrantKey = accessGrantKey;
            }

            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

            [DataMember(Name = "property_key", IsRequired = false, EmitDefaultValue = false)]
            public string? PropertyKey { get; set; }

            [DataMember(Name = "room_key", IsRequired = false, EmitDefaultValue = false)]
            public string? RoomKey { get; set; }

            [DataMember(Name = "common_area_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaKey { get; set; }

            [DataMember(Name = "unit_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UnitKey { get; set; }

            [DataMember(Name = "facility_key", IsRequired = false, EmitDefaultValue = false)]
            public string? FacilityKey { get; set; }

            [DataMember(Name = "building_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BuildingKey { get; set; }

            [DataMember(Name = "listing_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ListingKey { get; set; }

            [DataMember(
                Name = "property_listing_key",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? PropertyListingKey { get; set; }

            [DataMember(Name = "site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteKey { get; set; }

            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            [DataMember(Name = "booking_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BookingKey { get; set; }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

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
                string? customerKey = default,
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

            /// <summary>
            /// List of access grants.
            /// </summary>
            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataAccessGrants>? AccessGrants { get; set; }

            /// <summary>
            /// List of bookings.
            /// </summary>
            [DataMember(Name = "bookings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataBookings>? Bookings { get; set; }

            /// <summary>
            /// List of buildings.
            /// </summary>
            [DataMember(Name = "buildings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataBuildings>? Buildings { get; set; }

            /// <summary>
            /// List of shared common areas.
            /// </summary>
            [DataMember(Name = "common_areas", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataCommonAreas>? CommonAreas { get; set; }

            /// <summary>
            /// Your unique identifier for the customer.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// List of gym or fitness facilities.
            /// </summary>
            [DataMember(Name = "facilities", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataFacilities>? Facilities { get; set; }

            /// <summary>
            /// List of guests.
            /// </summary>
            [DataMember(Name = "guests", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataGuests>? Guests { get; set; }

            /// <summary>
            /// List of property listings.
            /// </summary>
            [DataMember(Name = "listings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataListings>? Listings { get; set; }

            /// <summary>
            /// List of short-term rental properties.
            /// </summary>
            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataProperties>? Properties { get; set; }

            /// <summary>
            /// List of property listings.
            /// </summary>
            [DataMember(Name = "property_listings", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataPropertyListings>? PropertyListings { get; set; }

            /// <summary>
            /// List of reservations.
            /// </summary>
            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataReservations>? Reservations { get; set; }

            /// <summary>
            /// List of residents.
            /// </summary>
            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataResidents>? Residents { get; set; }

            /// <summary>
            /// List of hotel or hospitality rooms.
            /// </summary>
            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataRooms>? Rooms { get; set; }

            /// <summary>
            /// List of general sites or areas.
            /// </summary>
            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataSites>? Sites { get; set; }

            /// <summary>
            /// List of general spaces or areas.
            /// </summary>
            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataSpaces>? Spaces { get; set; }

            /// <summary>
            /// List of staff members.
            /// </summary>
            [DataMember(Name = "staff_members", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataStaffMembers>? StaffMembers { get; set; }

            /// <summary>
            /// List of tenants.
            /// </summary>
            [DataMember(Name = "tenants", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataTenants>? Tenants { get; set; }

            /// <summary>
            /// List of multi-family residential units.
            /// </summary>
            [DataMember(Name = "units", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataUnits>? Units { get; set; }

            /// <summary>
            /// List of user identities.
            /// </summary>
            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<CreatePortalRequestCustomerDataUserIdentities>? UserIdentities { get; set; }

            /// <summary>
            /// List of users.
            /// </summary>
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
                string? accessGrantKey = default,
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

            /// <summary>
            /// Your unique identifier for the access grant.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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
                string? bookingKey = default,
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

            /// <summary>
            /// Your unique identifier for the booking.
            /// </summary>
            [DataMember(Name = "booking_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BookingKey { get; set; }

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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
                string? buildingKey = default,
                string? name = default
            )
            {
                BuildingKey = buildingKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the building.
            /// </summary>
            [DataMember(Name = "building_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BuildingKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
                string? commonAreaKey = default,
                string? name = default,
                string? parentSiteKey = default
            )
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
                ParentSiteKey = parentSiteKey;
            }

            /// <summary>
            /// Your unique identifier for the common area.
            /// </summary>
            [DataMember(Name = "common_area_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
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
                string? facilityKey = default,
                string? name = default
            )
            {
                FacilityKey = facilityKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the facility.
            /// </summary>
            [DataMember(Name = "facility_key", IsRequired = false, EmitDefaultValue = false)]
            public string? FacilityKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
                string? guestKey = default,
                string? name = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                GuestKey = guestKey;
                Name = name;
                PhoneNumber = phoneNumber;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your unique identifier for the guest.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
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
                string? listingKey = default,
                string? name = default
            )
            {
                ListingKey = listingKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the listing.
            /// </summary>
            [DataMember(Name = "listing_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ListingKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
                string? name = default,
                string? propertyKey = default
            )
            {
                Name = name;
                PropertyKey = propertyKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the property.
            /// </summary>
            [DataMember(Name = "property_key", IsRequired = false, EmitDefaultValue = false)]
            public string? PropertyKey { get; set; }

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
                string? name = default,
                string? propertyListingKey = default
            )
            {
                CustomMetadata = customMetadata;
                Name = name;
                PropertyListingKey = propertyListingKey;
            }

            /// <summary>
            /// Set key:value pairs. Accepts string or Boolean values. Adding custom metadata to a property listing enables you to store custom information, like customer details or internal IDs from your application. Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the property listing.
            /// </summary>
            [DataMember(
                Name = "property_listing_key",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? PropertyListingKey { get; set; }

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
                object? customMetadata = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string? name = default,
                string? preferredCode = default,
                List<string>? propertyKeys = default,
                string? reservationKey = default,
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
                CustomMetadata = customMetadata;
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

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Set key:value pairs for filtering reservations by custom criteria. Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Your unique identifier for the reservation.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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
                string? name = default,
                string? phoneNumber = default,
                string? residentKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                ResidentKey = residentKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the resident.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

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
                string? name = default,
                string? parentSiteKey = default,
                string? roomKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                RoomKey = roomKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the room.
            /// </summary>
            [DataMember(Name = "room_key", IsRequired = false, EmitDefaultValue = false)]
            public string? RoomKey { get; set; }

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
                string? name = default,
                string? siteKey = default
            )
            {
                Name = name;
                SiteKey = siteKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteKey { get; set; }

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
                CreatePortalRequestCustomerDataSpacesCustomerData? customerData = default,
                int? durationMinutes = default,
                CreatePortalRequestCustomerDataSpacesGeolocation? geolocation = default,
                string? name = default,
                string? parentSiteKey = default,
                string? spaceKey = default
            )
            {
                CustomerData = customerData;
                DurationMinutes = durationMinutes;
                Geolocation = geolocation;
                Name = name;
                ParentSiteKey = parentSiteKey;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// Reservation/stay-related defaults for the space (time zone, default check-in/out times, address).
            /// </summary>
            [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestCustomerDataSpacesCustomerData? CustomerData { get; set; }

            /// <summary>
            /// Default duration of this space in minutes, when the space represents a fixed-length bookable slot (e.g. an appointment type). Used to interpret reservations booked against this space.
            /// </summary>
            [DataMember(Name = "duration_minutes", IsRequired = false, EmitDefaultValue = false)]
            public int? DurationMinutes { get; set; }

            /// <summary>
            /// Geographic coordinates (latitude and longitude) of the space.
            /// </summary>
            [DataMember(Name = "geolocation", IsRequired = false, EmitDefaultValue = false)]
            public CreatePortalRequestCustomerDataSpacesGeolocation? Geolocation { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the space.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

        [DataContract(Name = "createPortalRequestCustomerDataSpacesCustomerData_model")]
        public class CreatePortalRequestCustomerDataSpacesCustomerData
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataSpacesCustomerData() { }

            public CreatePortalRequestCustomerDataSpacesCustomerData(
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
            [DataMember(
                Name = "default_checkin_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckinTime { get; set; }

            /// <summary>
            /// Default check-out time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkout_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
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

        [DataContract(Name = "createPortalRequestCustomerDataSpacesGeolocation_model")]
        public class CreatePortalRequestCustomerDataSpacesGeolocation
        {
            [JsonConstructorAttribute]
            protected CreatePortalRequestCustomerDataSpacesGeolocation() { }

            public CreatePortalRequestCustomerDataSpacesGeolocation(
                float? latitude = default,
                float? longitude = default
            )
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            /// <summary>
            /// Latitude of the space, in decimal degrees.
            /// </summary>
            [DataMember(Name = "latitude", IsRequired = false, EmitDefaultValue = false)]
            public float? Latitude { get; set; }

            /// <summary>
            /// Longitude of the space, in decimal degrees.
            /// </summary>
            [DataMember(Name = "longitude", IsRequired = false, EmitDefaultValue = false)]
            public float? Longitude { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                List<string>? propertyKeys = default,
                List<string>? propertyListingKeys = default,
                List<string>? roomKeys = default,
                List<string>? siteKeys = default,
                List<string>? spaceKeys = default,
                string? staffMemberKey = default,
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

            /// <summary>
            /// List of unique identifiers for the buildings the staff member is associated with.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the common areas the staff member is associated with.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// List of unique identifiers for the facilities the staff member is associated with.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the listings the staff member is associated with.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// List of unique identifiers for the properties the staff member is associated with.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the property listings the staff member is associated with.
            /// </summary>
            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? PropertyListingKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the rooms the staff member is associated with.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the sites the staff member is associated with.
            /// </summary>
            [DataMember(Name = "site_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SiteKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the spaces the staff member is associated with.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Your unique identifier for the staff.
            /// </summary>
            [DataMember(Name = "staff_member_key", IsRequired = false, EmitDefaultValue = false)]
            public string? StaffMemberKey { get; set; }

            /// <summary>
            /// List of unique identifiers for the units the staff member is associated with.
            /// </summary>
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
                string? name = default,
                string? phoneNumber = default,
                string? tenantKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                TenantKey = tenantKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the tenant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

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
                string? name = default,
                string? parentSiteKey = default,
                string? unitKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                UnitKey = unitKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the unit.
            /// </summary>
            [DataMember(Name = "unit_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UnitKey { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                string? userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the user identity.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                string? userKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserKey = userKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the user.
            /// </summary>
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

        [DataContract(Name = "createPortalResponse_response")]
        public class CreatePortalResponse
        {
            [JsonConstructorAttribute]
            protected CreatePortalResponse() { }

            public CreatePortalResponse(CustomerPortal customerPortal = default)
            {
                CustomerPortal = customerPortal;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "customer_portal", IsRequired = false, EmitDefaultValue = false)]
            public CustomerPortal CustomerPortal { get; set; }

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
        /// Creates a new customer portal magic link with configurable features.
        /// </summary>
        public CustomerPortal CreatePortal(CreatePortalRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreatePortalResponse>("/customers/create_portal", requestOptions)
                .EnsureData("/customers/create_portal")
                .CustomerPortal;
        }

        /// <summary>
        /// Creates a new customer portal magic link with configurable features.
        /// </summary>
        public CustomerPortal CreatePortal(
            List<CreatePortalRequestCustomerResourcesFilters>? customerResourcesFilters = default,
            string? customizationProfileId = default,
            CreatePortalRequestDeepLink? deepLink = default,
            bool? excludeLocalePicker = default,
            CreatePortalRequestFeatures? features = default,
            bool? isEmbedded = default,
            CreatePortalRequestLandingPage? landingPage = default,
            CreatePortalRequest.LocaleEnum? locale = default,
            CreatePortalRequest.NavigationModeEnum? navigationMode = default,
            bool? readOnly = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return CreatePortal(
                new CreatePortalRequest(
                    customerResourcesFilters: customerResourcesFilters,
                    customizationProfileId: customizationProfileId,
                    deepLink: deepLink,
                    excludeLocalePicker: excludeLocalePicker,
                    features: features,
                    isEmbedded: isEmbedded,
                    landingPage: landingPage,
                    locale: locale,
                    navigationMode: navigationMode,
                    readOnly: readOnly,
                    customerData: customerData
                )
            );
        }

        /// <summary>
        /// Creates a new customer portal magic link with configurable features.
        /// </summary>
        public async Task<CustomerPortal> CreatePortalAsync(CreatePortalRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreatePortalResponse>(
                    "/customers/create_portal",
                    requestOptions
                )
            )
                .EnsureData("/customers/create_portal")
                .CustomerPortal;
        }

        /// <summary>
        /// Creates a new customer portal magic link with configurable features.
        /// </summary>
        public async Task<CustomerPortal> CreatePortalAsync(
            List<CreatePortalRequestCustomerResourcesFilters>? customerResourcesFilters = default,
            string? customizationProfileId = default,
            CreatePortalRequestDeepLink? deepLink = default,
            bool? excludeLocalePicker = default,
            CreatePortalRequestFeatures? features = default,
            bool? isEmbedded = default,
            CreatePortalRequestLandingPage? landingPage = default,
            CreatePortalRequest.LocaleEnum? locale = default,
            CreatePortalRequest.NavigationModeEnum? navigationMode = default,
            bool? readOnly = default,
            CreatePortalRequestCustomerData? customerData = default
        )
        {
            return (
                await CreatePortalAsync(
                    new CreatePortalRequest(
                        customerResourcesFilters: customerResourcesFilters,
                        customizationProfileId: customizationProfileId,
                        deepLink: deepLink,
                        excludeLocalePicker: excludeLocalePicker,
                        features: features,
                        isEmbedded: isEmbedded,
                        landingPage: landingPage,
                        locale: locale,
                        navigationMode: navigationMode,
                        readOnly: readOnly,
                        customerData: customerData
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete Customer Data.
        /// </summary>
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

            /// <summary>
            /// List of access grant keys to delete.
            /// </summary>
            [DataMember(Name = "access_grant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessGrantKeys { get; set; }

            /// <summary>
            /// List of booking keys to delete.
            /// </summary>
            [DataMember(Name = "booking_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BookingKeys { get; set; }

            /// <summary>
            /// List of building keys to delete.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// List of common area keys to delete.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// List of customer keys to delete all data for.
            /// </summary>
            [DataMember(Name = "customer_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CustomerKeys { get; set; }

            /// <summary>
            /// List of facility keys to delete.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// List of guest keys to delete.
            /// </summary>
            [DataMember(Name = "guest_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? GuestKeys { get; set; }

            /// <summary>
            /// List of listing keys to delete.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// List of property keys to delete.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// List of property listing keys to delete.
            /// </summary>
            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? PropertyListingKeys { get; set; }

            /// <summary>
            /// List of reservation keys to delete.
            /// </summary>
            [DataMember(Name = "reservation_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ReservationKeys { get; set; }

            /// <summary>
            /// List of resident keys to delete.
            /// </summary>
            [DataMember(Name = "resident_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ResidentKeys { get; set; }

            /// <summary>
            /// List of room keys to delete.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// List of space keys to delete.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// List of staff member keys to delete.
            /// </summary>
            [DataMember(Name = "staff_member_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? StaffMemberKeys { get; set; }

            /// <summary>
            /// List of tenant keys to delete.
            /// </summary>
            [DataMember(Name = "tenant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? TenantKeys { get; set; }

            /// <summary>
            /// List of unit keys to delete.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// List of user identity keys to delete.
            /// </summary>
            [DataMember(Name = "user_identity_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityKeys { get; set; }

            /// <summary>
            /// List of user keys to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes customer data including resources like spaces, properties, rooms, users, etc.
        /// This will delete the partner resources and any related Seam resources (user identities, access grants, spaces).
        /// </summary>
        public void DeleteData(DeleteDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/customers/delete_data", requestOptions);
        }

        /// <summary>
        /// Deletes customer data including resources like spaces, properties, rooms, users, etc.
        /// This will delete the partner resources and any related Seam resources (user identities, access grants, spaces).
        /// </summary>
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

        /// <summary>
        /// Deletes customer data including resources like spaces, properties, rooms, users, etc.
        /// This will delete the partner resources and any related Seam resources (user identities, access grants, spaces).
        /// </summary>
        public async Task DeleteDataAsync(DeleteDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/customers/delete_data", requestOptions);
        }

        /// <summary>
        /// Deletes customer data including resources like spaces, properties, rooms, users, etc.
        /// This will delete the partner resources and any related Seam resources (user identities, access grants, spaces).
        /// </summary>
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

        /// <summary>
        /// Request parameters for Push Customer Data.
        /// </summary>
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

            /// <summary>
            /// List of access grants.
            /// </summary>
            [DataMember(Name = "access_grants", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestAccessGrants>? AccessGrants { get; set; }

            /// <summary>
            /// List of bookings.
            /// </summary>
            [DataMember(Name = "bookings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestBookings>? Bookings { get; set; }

            /// <summary>
            /// List of buildings.
            /// </summary>
            [DataMember(Name = "buildings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestBuildings>? Buildings { get; set; }

            /// <summary>
            /// List of shared common areas.
            /// </summary>
            [DataMember(Name = "common_areas", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestCommonAreas>? CommonAreas { get; set; }

            /// <summary>
            /// Your unique identifier for the customer.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
            public string CustomerKey { get; set; }

            /// <summary>
            /// List of gym or fitness facilities.
            /// </summary>
            [DataMember(Name = "facilities", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestFacilities>? Facilities { get; set; }

            /// <summary>
            /// List of guests.
            /// </summary>
            [DataMember(Name = "guests", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestGuests>? Guests { get; set; }

            /// <summary>
            /// List of property listings.
            /// </summary>
            [DataMember(Name = "listings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestListings>? Listings { get; set; }

            /// <summary>
            /// List of short-term rental properties.
            /// </summary>
            [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestProperties>? Properties { get; set; }

            /// <summary>
            /// List of property listings.
            /// </summary>
            [DataMember(Name = "property_listings", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestPropertyListings>? PropertyListings { get; set; }

            /// <summary>
            /// List of reservations.
            /// </summary>
            [DataMember(Name = "reservations", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestReservations>? Reservations { get; set; }

            /// <summary>
            /// List of residents.
            /// </summary>
            [DataMember(Name = "residents", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestResidents>? Residents { get; set; }

            /// <summary>
            /// List of hotel or hospitality rooms.
            /// </summary>
            [DataMember(Name = "rooms", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestRooms>? Rooms { get; set; }

            /// <summary>
            /// List of general sites or areas.
            /// </summary>
            [DataMember(Name = "sites", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestSites>? Sites { get; set; }

            /// <summary>
            /// List of general spaces or areas.
            /// </summary>
            [DataMember(Name = "spaces", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestSpaces>? Spaces { get; set; }

            /// <summary>
            /// List of staff members.
            /// </summary>
            [DataMember(Name = "staff_members", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestStaffMembers>? StaffMembers { get; set; }

            /// <summary>
            /// List of tenants.
            /// </summary>
            [DataMember(Name = "tenants", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestTenants>? Tenants { get; set; }

            /// <summary>
            /// List of multi-family residential units.
            /// </summary>
            [DataMember(Name = "units", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestUnits>? Units { get; set; }

            /// <summary>
            /// List of user identities.
            /// </summary>
            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<PushDataRequestUserIdentities>? UserIdentities { get; set; }

            /// <summary>
            /// List of users.
            /// </summary>
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
                string? accessGrantKey = default,
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

            /// <summary>
            /// Your unique identifier for the access grant.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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
                string? bookingKey = default,
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

            /// <summary>
            /// Your unique identifier for the booking.
            /// </summary>
            [DataMember(Name = "booking_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BookingKey { get; set; }

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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

            public PushDataRequestBuildings(string? buildingKey = default, string? name = default)
            {
                BuildingKey = buildingKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the building.
            /// </summary>
            [DataMember(Name = "building_key", IsRequired = false, EmitDefaultValue = false)]
            public string? BuildingKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
                string? commonAreaKey = default,
                string? name = default,
                string? parentSiteKey = default
            )
            {
                CommonAreaKey = commonAreaKey;
                Name = name;
                ParentSiteKey = parentSiteKey;
            }

            /// <summary>
            /// Your unique identifier for the common area.
            /// </summary>
            [DataMember(Name = "common_area_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
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

            public PushDataRequestFacilities(string? facilityKey = default, string? name = default)
            {
                FacilityKey = facilityKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the facility.
            /// </summary>
            [DataMember(Name = "facility_key", IsRequired = false, EmitDefaultValue = false)]
            public string? FacilityKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
                string? guestKey = default,
                string? name = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                GuestKey = guestKey;
                Name = name;
                PhoneNumber = phoneNumber;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your unique identifier for the guest.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
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

            public PushDataRequestListings(string? listingKey = default, string? name = default)
            {
                ListingKey = listingKey;
                Name = name;
            }

            /// <summary>
            /// Your unique identifier for the listing.
            /// </summary>
            [DataMember(Name = "listing_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ListingKey { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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

            public PushDataRequestProperties(string? name = default, string? propertyKey = default)
            {
                Name = name;
                PropertyKey = propertyKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the property.
            /// </summary>
            [DataMember(Name = "property_key", IsRequired = false, EmitDefaultValue = false)]
            public string? PropertyKey { get; set; }

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
                string? name = default,
                string? propertyListingKey = default
            )
            {
                CustomMetadata = customMetadata;
                Name = name;
                PropertyListingKey = propertyListingKey;
            }

            /// <summary>
            /// Set key:value pairs. Accepts string or Boolean values. Adding custom metadata to a property listing enables you to store custom information, like customer details or internal IDs from your application. Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the property listing.
            /// </summary>
            [DataMember(
                Name = "property_listing_key",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? PropertyListingKey { get; set; }

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
                object? customMetadata = default,
                string? endsAt = default,
                List<string>? facilityKeys = default,
                string? guestKey = default,
                List<string>? listingKeys = default,
                string? name = default,
                string? preferredCode = default,
                List<string>? propertyKeys = default,
                string? reservationKey = default,
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
                CustomMetadata = customMetadata;
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

            /// <summary>
            /// Building keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// Common area keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Set key:value pairs for filtering reservations by custom criteria. Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// Ending date and time for the access grant.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Facility keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// Guest key associated with the access grant.
            /// </summary>
            [DataMember(Name = "guest_key", IsRequired = false, EmitDefaultValue = false)]
            public string? GuestKey { get; set; }

            /// <summary>
            /// Listing keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your name for this access grant resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Preferred PIN code to use when creating access for this reservation.
            /// </summary>
            [DataMember(Name = "preferred_code", IsRequired = false, EmitDefaultValue = false)]
            public string? PreferredCode { get; set; }

            /// <summary>
            /// Property keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// Your unique identifier for the reservation.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

            /// <summary>
            /// Resident key associated with the access grant.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

            /// <summary>
            /// Room keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// Space keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Starting date and time for the access grant.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Tenant key associated with the access grant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

            /// <summary>
            /// Unit keys associated with the access grant.
            /// </summary>
            [DataMember(Name = "unit_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UnitKeys { get; set; }

            /// <summary>
            /// User identity key associated with the access grant.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            /// <summary>
            /// User key associated with the access grant.
            /// </summary>
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
                string? name = default,
                string? phoneNumber = default,
                string? residentKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                ResidentKey = residentKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the resident.
            /// </summary>
            [DataMember(Name = "resident_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ResidentKey { get; set; }

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
                string? name = default,
                string? parentSiteKey = default,
                string? roomKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                RoomKey = roomKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the room.
            /// </summary>
            [DataMember(Name = "room_key", IsRequired = false, EmitDefaultValue = false)]
            public string? RoomKey { get; set; }

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

            public PushDataRequestSites(string? name = default, string? siteKey = default)
            {
                Name = name;
                SiteKey = siteKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SiteKey { get; set; }

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

            public PushDataRequestSpaces(
                PushDataRequestSpacesCustomerData? customerData = default,
                int? durationMinutes = default,
                PushDataRequestSpacesGeolocation? geolocation = default,
                string? name = default,
                string? parentSiteKey = default,
                string? spaceKey = default
            )
            {
                CustomerData = customerData;
                DurationMinutes = durationMinutes;
                Geolocation = geolocation;
                Name = name;
                ParentSiteKey = parentSiteKey;
                SpaceKey = spaceKey;
            }

            /// <summary>
            /// Reservation/stay-related defaults for the space (time zone, default check-in/out times, address).
            /// </summary>
            [DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
            public PushDataRequestSpacesCustomerData? CustomerData { get; set; }

            /// <summary>
            /// Default duration of this space in minutes, when the space represents a fixed-length bookable slot (e.g. an appointment type). Used to interpret reservations booked against this space.
            /// </summary>
            [DataMember(Name = "duration_minutes", IsRequired = false, EmitDefaultValue = false)]
            public int? DurationMinutes { get; set; }

            /// <summary>
            /// Geographic coordinates (latitude and longitude) of the space.
            /// </summary>
            [DataMember(Name = "geolocation", IsRequired = false, EmitDefaultValue = false)]
            public PushDataRequestSpacesGeolocation? Geolocation { get; set; }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the space.
            /// </summary>
            [DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceKey { get; set; }

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

        [DataContract(Name = "pushDataRequestSpacesCustomerData_model")]
        public class PushDataRequestSpacesCustomerData
        {
            [JsonConstructorAttribute]
            protected PushDataRequestSpacesCustomerData() { }

            public PushDataRequestSpacesCustomerData(
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
            [DataMember(
                Name = "default_checkin_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? DefaultCheckinTime { get; set; }

            /// <summary>
            /// Default check-out time for reservations at the space, as HH:mm or HH:mm:ss.
            /// </summary>
            [DataMember(
                Name = "default_checkout_time",
                IsRequired = false,
                EmitDefaultValue = false
            )]
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

        [DataContract(Name = "pushDataRequestSpacesGeolocation_model")]
        public class PushDataRequestSpacesGeolocation
        {
            [JsonConstructorAttribute]
            protected PushDataRequestSpacesGeolocation() { }

            public PushDataRequestSpacesGeolocation(
                float? latitude = default,
                float? longitude = default
            )
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            /// <summary>
            /// Latitude of the space, in decimal degrees.
            /// </summary>
            [DataMember(Name = "latitude", IsRequired = false, EmitDefaultValue = false)]
            public float? Latitude { get; set; }

            /// <summary>
            /// Longitude of the space, in decimal degrees.
            /// </summary>
            [DataMember(Name = "longitude", IsRequired = false, EmitDefaultValue = false)]
            public float? Longitude { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                List<string>? propertyKeys = default,
                List<string>? propertyListingKeys = default,
                List<string>? roomKeys = default,
                List<string>? siteKeys = default,
                List<string>? spaceKeys = default,
                string? staffMemberKey = default,
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

            /// <summary>
            /// List of unique identifiers for the buildings the staff member is associated with.
            /// </summary>
            [DataMember(Name = "building_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? BuildingKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the common areas the staff member is associated with.
            /// </summary>
            [DataMember(Name = "common_area_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? CommonAreaKeys { get; set; }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// List of unique identifiers for the facilities the staff member is associated with.
            /// </summary>
            [DataMember(Name = "facility_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? FacilityKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the listings the staff member is associated with.
            /// </summary>
            [DataMember(Name = "listing_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? ListingKeys { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// List of unique identifiers for the properties the staff member is associated with.
            /// </summary>
            [DataMember(Name = "property_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? PropertyKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the property listings the staff member is associated with.
            /// </summary>
            [DataMember(
                Name = "property_listing_keys",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? PropertyListingKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the rooms the staff member is associated with.
            /// </summary>
            [DataMember(Name = "room_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? RoomKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the sites the staff member is associated with.
            /// </summary>
            [DataMember(Name = "site_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SiteKeys { get; set; }

            /// <summary>
            /// List of unique identifiers for the spaces the staff member is associated with.
            /// </summary>
            [DataMember(Name = "space_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? SpaceKeys { get; set; }

            /// <summary>
            /// Your unique identifier for the staff.
            /// </summary>
            [DataMember(Name = "staff_member_key", IsRequired = false, EmitDefaultValue = false)]
            public string? StaffMemberKey { get; set; }

            /// <summary>
            /// List of unique identifiers for the units the staff member is associated with.
            /// </summary>
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
                string? name = default,
                string? phoneNumber = default,
                string? tenantKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                TenantKey = tenantKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the tenant.
            /// </summary>
            [DataMember(Name = "tenant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? TenantKey { get; set; }

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
                string? name = default,
                string? parentSiteKey = default,
                string? unitKey = default
            )
            {
                Name = name;
                ParentSiteKey = parentSiteKey;
                UnitKey = unitKey;
            }

            /// <summary>
            /// Your display name for this location resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Your unique identifier for the site.
            /// </summary>
            [DataMember(Name = "parent_site_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ParentSiteKey { get; set; }

            /// <summary>
            /// Your unique identifier for the unit.
            /// </summary>
            [DataMember(Name = "unit_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UnitKey { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                string? userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the user identity.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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
                string? name = default,
                string? phoneNumber = default,
                string? userKey = default
            )
            {
                EmailAddress = emailAddress;
                Name = name;
                PhoneNumber = phoneNumber;
                UserKey = userKey;
            }

            /// <summary>
            /// Email address associated with the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Your display name for this user identity resource.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Phone number associated with the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Your unique identifier for the user.
            /// </summary>
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

        /// <summary>
        /// Pushes customer data including resources like spaces, properties, rooms, users, etc.
        /// </summary>
        public void PushData(PushDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/customers/push_data", requestOptions);
        }

        /// <summary>
        /// Pushes customer data including resources like spaces, properties, rooms, users, etc.
        /// </summary>
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

        /// <summary>
        /// Pushes customer data including resources like spaces, properties, rooms, users, etc.
        /// </summary>
        public async Task PushDataAsync(PushDataRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/customers/push_data", requestOptions);
        }

        /// <summary>
        /// Pushes customer data including resources like spaces, properties, rooms, users, etc.
        /// </summary>
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
