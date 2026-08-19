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
    /// Represents an [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) within an [access control system](https://docs.seam.co/low-level-apis/access-systems).
    ///
    /// In an access control system, an entrance is a secured door, gate, zone, or other method of entry. You can list details for all the `acs_entrance` resources in your workspace or get these details for a specific `acs_entrance`. You can also list all entrances associated with a specific credential, and you can list all credentials associated with a specific entrance.
    /// </summary>
    [DataContract(Name = "seamModel_acsEntrance_model")]
    public class AcsEntrance
    {
        [JsonConstructorAttribute]
        protected AcsEntrance() { }

        public AcsEntrance(
            string acsEntranceId = default,
            string acsSystemId = default,
            AcsEntranceAkilesMetadata? akilesMetadata = default,
            AcsEntranceAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            AcsEntranceAvigilonAltaMetadata? avigilonAltaMetadata = default,
            AcsEntranceBrivoMetadata? brivoMetadata = default,
            bool? canBelongToReservation = default,
            bool? canUnlockWithCard = default,
            bool? canUnlockWithCloudKey = default,
            bool? canUnlockWithCode = default,
            bool? canUnlockWithMobileKey = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            AcsEntranceDormakabaAmbianceMetadata? dormakabaAmbianceMetadata = default,
            AcsEntranceDormakabaCommunityMetadata? dormakabaCommunityMetadata = default,
            List<AcsEntranceErrors> errors = default,
            AcsEntranceHotekMetadata? hotekMetadata = default,
            bool? isLocked = default,
            AcsEntranceLatchMetadata? latchMetadata = default,
            AcsEntranceSaltoKsMetadata? saltoKsMetadata = default,
            AcsEntranceSaltoSpaceMetadata? saltoSpaceMetadata = default,
            List<string> spaceIds = default,
            AcsEntranceVisionlineMetadata? visionlineMetadata = default,
            List<AcsEntranceWarnings> warnings = default
        )
        {
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            AvigilonAltaMetadata = avigilonAltaMetadata;
            BrivoMetadata = brivoMetadata;
            CanBelongToReservation = canBelongToReservation;
            CanUnlockWithCard = canUnlockWithCard;
            CanUnlockWithCloudKey = canUnlockWithCloudKey;
            CanUnlockWithCode = canUnlockWithCode;
            CanUnlockWithMobileKey = canUnlockWithMobileKey;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            DormakabaAmbianceMetadata = dormakabaAmbianceMetadata;
            DormakabaCommunityMetadata = dormakabaCommunityMetadata;
            Errors = errors;
            HotekMetadata = hotekMetadata;
            IsLocked = isLocked;
            LatchMetadata = latchMetadata;
            SaltoKsMetadata = saltoKsMetadata;
            SaltoSpaceMetadata = saltoSpaceMetadata;
            SpaceIds = spaceIds;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
        }

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsEntranceWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AcsEntranceWarningsPrivacyMode), "privacy_mode")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsEntranceWarningsSaltoKsPrivacyMode),
            "salto_ks_privacy_mode"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsEntranceWarningsEntranceSetupRequired),
            "entrance_setup_required"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsEntranceWarningsEntranceSharesZone),
            "entrance_shares_zone"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsEntranceWarningsSaltoKsEntranceAccessCodeSupportRemoved),
            "salto_ks_entrance_access_code_support_removed"
        )]
        public abstract class AcsEntranceWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(
            Name = "seamModel_acsEntranceWarningsSaltoKsEntranceAccessCodeSupportRemoved_model"
        )]
        public class AcsEntranceWarningsSaltoKsEntranceAccessCodeSupportRemoved
            : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsSaltoKsEntranceAccessCodeSupportRemoved() { }

            public AcsEntranceWarningsSaltoKsEntranceAccessCodeSupportRemoved(
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
            public override string WarningCode { get; } =
                "salto_ks_entrance_access_code_support_removed";

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

        [DataContract(Name = "seamModel_acsEntranceWarningsEntranceSharesZone_model")]
        public class AcsEntranceWarningsEntranceSharesZone : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsEntranceSharesZone() { }

            public AcsEntranceWarningsEntranceSharesZone(
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
            public override string WarningCode { get; } = "entrance_shares_zone";

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

        [DataContract(Name = "seamModel_acsEntranceWarningsEntranceSetupRequired_model")]
        public class AcsEntranceWarningsEntranceSetupRequired : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsEntranceSetupRequired() { }

            public AcsEntranceWarningsEntranceSetupRequired(
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
            public override string WarningCode { get; } = "entrance_setup_required";

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

        [DataContract(Name = "seamModel_acsEntranceWarningsSaltoKsPrivacyMode_model")]
        public class AcsEntranceWarningsSaltoKsPrivacyMode : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsSaltoKsPrivacyMode() { }

            public AcsEntranceWarningsSaltoKsPrivacyMode(
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
            public override string WarningCode { get; } = "salto_ks_privacy_mode";

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

        [DataContract(Name = "seamModel_acsEntranceWarningsPrivacyMode_model")]
        public class AcsEntranceWarningsPrivacyMode : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsPrivacyMode() { }

            public AcsEntranceWarningsPrivacyMode(
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
            public override string WarningCode { get; } = "privacy_mode";

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

        [DataContract(Name = "seamModel_acsEntranceWarningsUnrecognized_model")]
        public class AcsEntranceWarningsUnrecognized : AcsEntranceWarnings
        {
            [JsonConstructorAttribute]
            protected AcsEntranceWarningsUnrecognized() { }

            public AcsEntranceWarningsUnrecognized(
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
        /// ID of the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// Akiles-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// ASSA ABLOY Vostio-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Avigilon Alta-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "avigilon_alta_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceAvigilonAltaMetadata? AvigilonAltaMetadata { get; set; }

        /// <summary>
        /// Brivo-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "brivo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceBrivoMetadata? BrivoMetadata { get; set; }

        /// <summary>
        /// Indicates whether the ACS entrance can belong to a reservation via an access_grant.reservation_key.
        /// </summary>
        [DataMember(
            Name = "can_belong_to_reservation",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanBelongToReservation { get; set; }

        /// <summary>
        /// Indicates whether the ACS entrance can be unlocked with card credentials.
        /// </summary>
        [DataMember(Name = "can_unlock_with_card", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCard { get; set; }

        /// <summary>
        /// Indicates whether the ACS entrance can be unlocked with cloud key credentials.
        /// </summary>
        [DataMember(
            Name = "can_unlock_with_cloud_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUnlockWithCloudKey { get; set; }

        /// <summary>
        /// Indicates whether the ACS entrance can be unlocked with pin codes.
        /// </summary>
        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

        /// <summary>
        /// Indicates whether the ACS entrance can be unlocked with mobile key credentials.
        /// </summary>
        [DataMember(
            Name = "can_unlock_with_mobile_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUnlockWithMobileKey { get; set; }

        /// <summary>
        /// ID of the [connected account](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name for the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// dormakaba Ambiance-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(
            Name = "dormakaba_ambiance_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceDormakabaAmbianceMetadata? DormakabaAmbianceMetadata { get; set; }

        /// <summary>
        /// dormakaba Community-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(
            Name = "dormakaba_community_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceDormakabaCommunityMetadata? DormakabaCommunityMetadata { get; set; }

        /// <summary>
        /// Errors associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntranceErrors> Errors { get; set; }

        /// <summary>
        /// Hotek-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "hotek_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceHotekMetadata? HotekMetadata { get; set; }

        /// <summary>
        /// Indicates whether the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) is currently locked.
        /// </summary>
        [DataMember(Name = "is_locked", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsLocked { get; set; }

        /// <summary>
        /// Latch-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "latch_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceLatchMetadata? LatchMetadata { get; set; }

        /// <summary>
        /// Salto KS-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoKsMetadata? SaltoKsMetadata { get; set; }

        /// <summary>
        /// Salto Space-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

        /// <summary>
        /// IDs of the spaces that the entrance is in.
        /// </summary>
        [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        /// <summary>
        /// Visionline-specific metadata associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntranceWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceAkilesMetadata_model")]
    public class AcsEntranceAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceAkilesMetadata() { }

        public AcsEntranceAkilesMetadata(
            List<AcsEntranceAkilesMetadataActions>? actions = default,
            string? gadgetId = default,
            string? siteId = default,
            string? siteName = default
        )
        {
            Actions = actions;
            GadgetId = gadgetId;
            SiteId = siteId;
            SiteName = siteName;
        }

        /// <summary>
        /// Actions the gadget exposes (for example, open).
        /// </summary>
        [DataMember(Name = "actions", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntranceAkilesMetadataActions>? Actions { get; set; }

        /// <summary>
        /// ID of the Akiles gadget.
        /// </summary>
        [DataMember(Name = "gadget_id", IsRequired = false, EmitDefaultValue = false)]
        public string? GadgetId { get; set; }

        /// <summary>
        /// ID of the Akiles site the gadget belongs to.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteId { get; set; }

        /// <summary>
        /// Name of the Akiles site the gadget belongs to.
        /// </summary>
        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceAkilesMetadataActions_model")]
    public class AcsEntranceAkilesMetadataActions
    {
        [JsonConstructorAttribute]
        protected AcsEntranceAkilesMetadataActions() { }

        public AcsEntranceAkilesMetadataActions(string? id = default, string? name = default)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// ID of the gadget action.
        /// </summary>
        [DataMember(Name = "id", IsRequired = false, EmitDefaultValue = false)]
        public string? Id { get; set; }

        /// <summary>
        /// Name of the gadget action.
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

    [DataContract(Name = "seamModel_acsEntranceAssaAbloyVostioMetadata_model")]
    public class AcsEntranceAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceAssaAbloyVostioMetadata() { }

        public AcsEntranceAssaAbloyVostioMetadata(
            string? doorName = default,
            float? doorNumber = default,
            AcsEntranceAssaAbloyVostioMetadata.DoorTypeEnum? doorType = default,
            string? pmsId = default,
            bool? standOpen = default
        )
        {
            DoorName = doorName;
            DoorNumber = doorNumber;
            DoorType = doorType;
            PmsId = pmsId;
            StandOpen = standOpen;
        }

        /// <summary>
        /// Type of the door in the Vostio access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DoorTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "CommonDoor")]
            CommonDoor = 1,

            [EnumMember(Value = "EntranceDoor")]
            EntranceDoor = 2,

            [EnumMember(Value = "GuestDoor")]
            GuestDoor = 3,

            [EnumMember(Value = "Elevator")]
            Elevator = 4,
        }

        /// <summary>
        /// Name of the door in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// Number of the door in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_number", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorNumber { get; set; }

        /// <summary>
        /// Type of the door in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceAssaAbloyVostioMetadata.DoorTypeEnum? DoorType { get; set; }

        /// <summary>
        /// PMS ID of the door in the Vostio access system.
        /// </summary>
        [DataMember(Name = "pms_id", IsRequired = false, EmitDefaultValue = false)]
        public string? PmsId { get; set; }

        /// <summary>
        /// Indicates whether keys are allowed to set the door in stand open mode in the Vostio access system.
        /// </summary>
        [DataMember(Name = "stand_open", IsRequired = false, EmitDefaultValue = false)]
        public bool? StandOpen { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceAvigilonAltaMetadata_model")]
    public class AcsEntranceAvigilonAltaMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceAvigilonAltaMetadata() { }

        public AcsEntranceAvigilonAltaMetadata(
            string? entryName = default,
            float? entryRelaysTotalCount = default,
            string? orgName = default,
            float? siteId = default,
            string? siteName = default,
            float? zoneId = default,
            string? zoneName = default
        )
        {
            EntryName = entryName;
            EntryRelaysTotalCount = entryRelaysTotalCount;
            OrgName = orgName;
            SiteId = siteId;
            SiteName = siteName;
            ZoneId = zoneId;
            ZoneName = zoneName;
        }

        /// <summary>
        /// Entry name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "entry_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EntryName { get; set; }

        /// <summary>
        /// Total count of entry relays for an Avigilon Alta system.
        /// </summary>
        [DataMember(
            Name = "entry_relays_total_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? EntryRelaysTotalCount { get; set; }

        /// <summary>
        /// Organization name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "org_name", IsRequired = false, EmitDefaultValue = false)]
        public string? OrgName { get; set; }

        /// <summary>
        /// Site ID for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        /// <summary>
        /// Site name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        /// <summary>
        /// Zone ID for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "zone_id", IsRequired = false, EmitDefaultValue = false)]
        public float? ZoneId { get; set; }

        /// <summary>
        /// Zone name for an Avigilon Alta system.
        /// </summary>
        [DataMember(Name = "zone_name", IsRequired = false, EmitDefaultValue = false)]
        public string? ZoneName { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceBrivoMetadata_model")]
    public class AcsEntranceBrivoMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceBrivoMetadata() { }

        public AcsEntranceBrivoMetadata(
            string? accessPointId = default,
            float? siteId = default,
            string? siteName = default
        )
        {
            AccessPointId = accessPointId;
            SiteId = siteId;
            SiteName = siteName;
        }

        /// <summary>
        /// ID of the access point in the Brivo access system.
        /// </summary>
        [DataMember(Name = "access_point_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessPointId { get; set; }

        /// <summary>
        /// ID of the site that the access point belongs to.
        /// </summary>
        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        /// <summary>
        /// Name of the site that the access point belongs to.
        /// </summary>
        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceDormakabaAmbianceMetadata_model")]
    public class AcsEntranceDormakabaAmbianceMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceDormakabaAmbianceMetadata() { }

        public AcsEntranceDormakabaAmbianceMetadata(string? accessPointName = default)
        {
            AccessPointName = accessPointName;
        }

        /// <summary>
        /// Name of the access point in the dormakaba Ambiance access system.
        /// </summary>
        [DataMember(Name = "access_point_name", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessPointName { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceDormakabaCommunityMetadata_model")]
    public class AcsEntranceDormakabaCommunityMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceDormakabaCommunityMetadata() { }

        public AcsEntranceDormakabaCommunityMetadata(string? accessPointProfile = default)
        {
            AccessPointProfile = accessPointProfile;
        }

        /// <summary>
        /// Type of access point profile in the dormakaba Community access system.
        /// </summary>
        [DataMember(Name = "access_point_profile", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessPointProfile { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceErrors_model")]
    public class AcsEntranceErrors
    {
        [JsonConstructorAttribute]
        protected AcsEntranceErrors() { }

        public AcsEntranceErrors(
            string createdAt = default,
            string errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceHotekMetadata_model")]
    public class AcsEntranceHotekMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceHotekMetadata() { }

        public AcsEntranceHotekMetadata(
            string? commonAreaName = default,
            string? commonAreaNumber = default,
            string? roomNumber = default
        )
        {
            CommonAreaName = commonAreaName;
            CommonAreaNumber = commonAreaNumber;
            RoomNumber = roomNumber;
        }

        /// <summary>
        /// Display name of the entrance.
        /// </summary>
        [DataMember(Name = "common_area_name", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonAreaName { get; set; }

        /// <summary>
        /// Display name of the entrance.
        /// </summary>
        [DataMember(Name = "common_area_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonAreaNumber { get; set; }

        /// <summary>
        /// Room number of the entrance.
        /// </summary>
        [DataMember(Name = "room_number", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomNumber { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceLatchMetadata_model")]
    public class AcsEntranceLatchMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceLatchMetadata() { }

        public AcsEntranceLatchMetadata(
            string? accessibilityType = default,
            string? doorName = default,
            string? doorType = default,
            bool? isConnected = default
        )
        {
            AccessibilityType = accessibilityType;
            DoorName = doorName;
            DoorType = doorType;
            IsConnected = isConnected;
        }

        /// <summary>
        /// Accessibility type in the Latch access system.
        /// </summary>
        [DataMember(Name = "accessibility_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessibilityType { get; set; }

        /// <summary>
        /// Name of the door in the Latch access system.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// Type of the door in the Latch access system.
        /// </summary>
        [DataMember(Name = "door_type", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorType { get; set; }

        /// <summary>
        /// Indicates whether the entrance is connected.
        /// </summary>
        [DataMember(Name = "is_connected", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsConnected { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceSaltoKsMetadata_model")]
    public class AcsEntranceSaltoKsMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceSaltoKsMetadata() { }

        public AcsEntranceSaltoKsMetadata(
            string? batteryLevel = default,
            string? doorName = default,
            bool? intrusionAlarm = default,
            bool? leftOpenAlarm = default,
            string? lockType = default,
            string? lockedState = default,
            bool? online = default,
            bool? privacyMode = default
        )
        {
            BatteryLevel = batteryLevel;
            DoorName = doorName;
            IntrusionAlarm = intrusionAlarm;
            LeftOpenAlarm = leftOpenAlarm;
            LockType = lockType;
            LockedState = lockedState;
            Online = online;
            PrivacyMode = privacyMode;
        }

        /// <summary>
        /// Battery level of the door access device.
        /// </summary>
        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        /// <summary>
        /// Name of the door in the Salto KS access system.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// Indicates whether an intrusion alarm is active on the door.
        /// </summary>
        [DataMember(Name = "intrusion_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? IntrusionAlarm { get; set; }

        /// <summary>
        /// Indicates whether the door is left open.
        /// </summary>
        [DataMember(Name = "left_open_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? LeftOpenAlarm { get; set; }

        /// <summary>
        /// Type of the lock in the Salto KS access system.
        /// </summary>
        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

        /// <summary>
        /// Locked state of the door in the Salto KS access system.
        /// </summary>
        [DataMember(Name = "locked_state", IsRequired = false, EmitDefaultValue = false)]
        public string? LockedState { get; set; }

        /// <summary>
        /// Indicates whether the door access device is online.
        /// </summary>
        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool? Online { get; set; }

        /// <summary>
        /// Indicates whether privacy mode is enabled for the lock.
        /// </summary>
        [DataMember(Name = "privacy_mode", IsRequired = false, EmitDefaultValue = false)]
        public bool? PrivacyMode { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceSaltoSpaceMetadata_model")]
    public class AcsEntranceSaltoSpaceMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceSaltoSpaceMetadata() { }

        public AcsEntranceSaltoSpaceMetadata(
            bool? auditOnKeys = default,
            string? doorDescription = default,
            string? doorId = default,
            string? doorName = default,
            string? roomDescription = default,
            string? roomName = default
        )
        {
            AuditOnKeys = auditOnKeys;
            DoorDescription = doorDescription;
            DoorId = doorId;
            DoorName = doorName;
            RoomDescription = roomDescription;
            RoomName = roomName;
        }

        /// <summary>
        /// Indicates whether AuditOnKeys is enabled for the door in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "audit_on_keys", IsRequired = false, EmitDefaultValue = false)]
        public bool? AuditOnKeys { get; set; }

        /// <summary>
        /// Description of the door in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "door_description", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorDescription { get; set; }

        /// <summary>
        /// Door ID in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorId { get; set; }

        /// <summary>
        /// Name of the door in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// Description of the room in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "room_description", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomDescription { get; set; }

        /// <summary>
        /// Name of the room in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "room_name", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomName { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceVisionlineMetadata_model")]
    public class AcsEntranceVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceVisionlineMetadata() { }

        public AcsEntranceVisionlineMetadata(
            AcsEntranceVisionlineMetadata.DoorCategoryEnum? doorCategory = default,
            string? doorName = default,
            List<AcsEntranceVisionlineMetadataProfiles>? profiles = default
        )
        {
            DoorCategory = doorCategory;
            DoorName = doorName;
            Profiles = profiles;
        }

        /// <summary>
        /// Category of the door in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum DoorCategoryEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "entrance")]
            Entrance = 1,

            [EnumMember(Value = "guest")]
            Guest = 2,

            [EnumMember(Value = "elevator reader")]
            ElevatorReader = 3,

            [EnumMember(Value = "common")]
            Common = 4,

            [EnumMember(Value = "common (PMS)")]
            CommonPms = 5,
        }

        /// <summary>
        /// Category of the door in the Visionline access system.
        /// </summary>
        [DataMember(Name = "door_category", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata.DoorCategoryEnum? DoorCategory { get; set; }

        /// <summary>
        /// Name of the door in the Visionline access system.
        /// </summary>
        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        /// <summary>
        /// Profile for the door in the Visionline access system.
        /// </summary>
        [DataMember(Name = "profiles", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntranceVisionlineMetadataProfiles>? Profiles { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceVisionlineMetadataProfiles_model")]
    public class AcsEntranceVisionlineMetadataProfiles
    {
        [JsonConstructorAttribute]
        protected AcsEntranceVisionlineMetadataProfiles() { }

        public AcsEntranceVisionlineMetadataProfiles(
            string? visionlineDoorProfileId = default,
            AcsEntranceVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum? visionlineDoorProfileType =
                default
        )
        {
            VisionlineDoorProfileId = visionlineDoorProfileId;
            VisionlineDoorProfileType = visionlineDoorProfileType;
        }

        /// <summary>
        /// Door profile type in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum VisionlineDoorProfileTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "BLE")]
            Ble = 1,

            [EnumMember(Value = "commonDoor")]
            CommonDoor = 2,

            [EnumMember(Value = "touch")]
            Touch = 3,
        }

        /// <summary>
        /// Door profile ID in the Visionline access system.
        /// </summary>
        [DataMember(
            Name = "visionline_door_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? VisionlineDoorProfileId { get; set; }

        /// <summary>
        /// Door profile type in the Visionline access system.
        /// </summary>
        [DataMember(
            Name = "visionline_door_profile_type",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum? VisionlineDoorProfileType { get; set; }

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
