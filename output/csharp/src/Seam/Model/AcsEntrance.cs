using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsEntrance_model")]
    public class AcsEntrance
    {
        [JsonConstructorAttribute]
        protected AcsEntrance() { }

        public AcsEntrance(
            string acsEntranceId = default,
            string acsSystemId = default,
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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

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

        [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        [DataMember(Name = "avigilon_alta_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceAvigilonAltaMetadata? AvigilonAltaMetadata { get; set; }

        [DataMember(Name = "brivo_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceBrivoMetadata? BrivoMetadata { get; set; }

        [DataMember(
            Name = "can_belong_to_reservation",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanBelongToReservation { get; set; }

        [DataMember(Name = "can_unlock_with_card", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCard { get; set; }

        [DataMember(
            Name = "can_unlock_with_cloud_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUnlockWithCloudKey { get; set; }

        [DataMember(Name = "can_unlock_with_code", IsRequired = false, EmitDefaultValue = false)]
        public bool? CanUnlockWithCode { get; set; }

        [DataMember(
            Name = "can_unlock_with_mobile_key",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? CanUnlockWithMobileKey { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "dormakaba_ambiance_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceDormakabaAmbianceMetadata? DormakabaAmbianceMetadata { get; set; }

        [DataMember(
            Name = "dormakaba_community_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceDormakabaCommunityMetadata? DormakabaCommunityMetadata { get; set; }

        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEntranceErrors> Errors { get; set; }

        [DataMember(Name = "hotek_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceHotekMetadata? HotekMetadata { get; set; }

        [DataMember(Name = "is_locked", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsLocked { get; set; }

        [DataMember(Name = "latch_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceLatchMetadata? LatchMetadata { get; set; }

        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoKsMetadata? SaltoKsMetadata { get; set; }

        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

        [DataMember(Name = "space_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> SpaceIds { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata? VisionlineMetadata { get; set; }

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

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "door_number", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorNumber { get; set; }

        [DataMember(Name = "door_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceAssaAbloyVostioMetadata.DoorTypeEnum? DoorType { get; set; }

        [DataMember(Name = "pms_id", IsRequired = false, EmitDefaultValue = false)]
        public string? PmsId { get; set; }

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

        [DataMember(Name = "entry_name", IsRequired = false, EmitDefaultValue = false)]
        public string? EntryName { get; set; }

        [DataMember(
            Name = "entry_relays_total_count",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public float? EntryRelaysTotalCount { get; set; }

        [DataMember(Name = "org_name", IsRequired = false, EmitDefaultValue = false)]
        public string? OrgName { get; set; }

        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

        [DataMember(Name = "site_name", IsRequired = false, EmitDefaultValue = false)]
        public string? SiteName { get; set; }

        [DataMember(Name = "zone_id", IsRequired = false, EmitDefaultValue = false)]
        public float? ZoneId { get; set; }

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

        [DataMember(Name = "access_point_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessPointId { get; set; }

        [DataMember(Name = "site_id", IsRequired = false, EmitDefaultValue = false)]
        public float? SiteId { get; set; }

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

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

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

        [DataMember(Name = "common_area_name", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonAreaName { get; set; }

        [DataMember(Name = "common_area_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonAreaNumber { get; set; }

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

        [DataMember(Name = "accessibility_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccessibilityType { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "door_type", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorType { get; set; }

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

        [DataMember(Name = "battery_level", IsRequired = false, EmitDefaultValue = false)]
        public string? BatteryLevel { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "intrusion_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? IntrusionAlarm { get; set; }

        [DataMember(Name = "left_open_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? LeftOpenAlarm { get; set; }

        [DataMember(Name = "lock_type", IsRequired = false, EmitDefaultValue = false)]
        public string? LockType { get; set; }

        [DataMember(Name = "locked_state", IsRequired = false, EmitDefaultValue = false)]
        public string? LockedState { get; set; }

        [DataMember(Name = "online", IsRequired = false, EmitDefaultValue = false)]
        public bool? Online { get; set; }

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

        [DataMember(Name = "audit_on_keys", IsRequired = false, EmitDefaultValue = false)]
        public bool? AuditOnKeys { get; set; }

        [DataMember(Name = "door_description", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorDescription { get; set; }

        [DataMember(Name = "door_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorId { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

        [DataMember(Name = "room_description", IsRequired = false, EmitDefaultValue = false)]
        public string? RoomDescription { get; set; }

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

        [DataMember(Name = "door_category", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata.DoorCategoryEnum? DoorCategory { get; set; }

        [DataMember(Name = "door_name", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorName { get; set; }

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

        [DataMember(
            Name = "visionline_door_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? VisionlineDoorProfileId { get; set; }

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
