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
            string createdAt = default,
            string displayName = default,
            AcsEntranceDormakabaCommunityMetadata? dormakabaCommunityMetadata = default,
            List<AcsEntranceErrors> errors = default,
            AcsEntranceLatchMetadata? latchMetadata = default,
            AcsEntranceSaltoKsMetadata? saltoKsMetadata = default,
            AcsEntranceSaltoSpaceMetadata? saltoSpaceMetadata = default,
            AcsEntranceVisionlineMetadata? visionlineMetadata = default
        )
        {
            AcsEntranceId = acsEntranceId;
            AcsSystemId = acsSystemId;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CreatedAt = createdAt;
            DisplayName = displayName;
            DormakabaCommunityMetadata = dormakabaCommunityMetadata;
            Errors = errors;
            LatchMetadata = latchMetadata;
            SaltoKsMetadata = saltoKsMetadata;
            SaltoSpaceMetadata = saltoSpaceMetadata;
            VisionlineMetadata = visionlineMetadata;
        }

        [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsEntranceId { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(
            Name = "dormakaba_community_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public AcsEntranceDormakabaCommunityMetadata? DormakabaCommunityMetadata { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<AcsEntranceErrors> Errors { get; set; }

        [DataMember(Name = "latch_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceLatchMetadata? LatchMetadata { get; set; }

        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoKsMetadata? SaltoKsMetadata { get; set; }

        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata? VisionlineMetadata { get; set; }

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
            string doorName = default,
            float? doorNumber = default,
            AcsEntranceAssaAbloyVostioMetadata.DoorTypeEnum doorType = default,
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

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "door_number", IsRequired = false, EmitDefaultValue = false)]
        public float? DoorNumber { get; set; }

        [DataMember(Name = "door_type", IsRequired = true, EmitDefaultValue = false)]
        public AcsEntranceAssaAbloyVostioMetadata.DoorTypeEnum DoorType { get; set; }

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

    [DataContract(Name = "seamModel_acsEntranceDormakabaCommunityMetadata_model")]
    public class AcsEntranceDormakabaCommunityMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceDormakabaCommunityMetadata() { }

        public AcsEntranceDormakabaCommunityMetadata(string accessPointName = default)
        {
            AccessPointName = accessPointName;
        }

        [DataMember(Name = "access_point_name", IsRequired = true, EmitDefaultValue = false)]
        public string AccessPointName { get; set; }

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

        public AcsEntranceErrors(string errorCode = default, string message = default)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_acsEntranceLatchMetadata_model")]
    public class AcsEntranceLatchMetadata
    {
        [JsonConstructorAttribute]
        protected AcsEntranceLatchMetadata() { }

        public AcsEntranceLatchMetadata(
            string accessibilityType = default,
            string doorName = default,
            string doorType = default,
            bool isConnected = default
        )
        {
            AccessibilityType = accessibilityType;
            DoorName = doorName;
            DoorType = doorType;
            IsConnected = isConnected;
        }

        [DataMember(Name = "accessibility_type", IsRequired = true, EmitDefaultValue = false)]
        public string AccessibilityType { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "door_type", IsRequired = true, EmitDefaultValue = false)]
        public string DoorType { get; set; }

        [DataMember(Name = "is_connected", IsRequired = true, EmitDefaultValue = false)]
        public bool IsConnected { get; set; }

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
            string batteryLevel = default,
            string doorName = default,
            bool? intrusionAlarm = default,
            bool? leftOpenAlarm = default,
            string lockType = default,
            string lockedState = default,
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

        [DataMember(Name = "battery_level", IsRequired = true, EmitDefaultValue = false)]
        public string BatteryLevel { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "intrusion_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? IntrusionAlarm { get; set; }

        [DataMember(Name = "left_open_alarm", IsRequired = false, EmitDefaultValue = false)]
        public bool? LeftOpenAlarm { get; set; }

        [DataMember(Name = "lock_type", IsRequired = true, EmitDefaultValue = false)]
        public string LockType { get; set; }

        [DataMember(Name = "locked_state", IsRequired = true, EmitDefaultValue = false)]
        public string LockedState { get; set; }

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
            string? doorDescription = default,
            string doorName = default,
            string extDoorId = default
        )
        {
            DoorDescription = doorDescription;
            DoorName = doorName;
            ExtDoorId = extDoorId;
        }

        [DataMember(Name = "door_description", IsRequired = false, EmitDefaultValue = false)]
        public string? DoorDescription { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

        [DataMember(Name = "ext_door_id", IsRequired = true, EmitDefaultValue = false)]
        public string ExtDoorId { get; set; }

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
            AcsEntranceVisionlineMetadata.DoorCategoryEnum doorCategory = default,
            string doorName = default,
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

        [DataMember(Name = "door_category", IsRequired = true, EmitDefaultValue = false)]
        public AcsEntranceVisionlineMetadata.DoorCategoryEnum DoorCategory { get; set; }

        [DataMember(Name = "door_name", IsRequired = true, EmitDefaultValue = false)]
        public string DoorName { get; set; }

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
            string visionlineDoorProfileId = default,
            AcsEntranceVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum visionlineDoorProfileType =
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
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string VisionlineDoorProfileId { get; set; }

        [DataMember(
            Name = "visionline_door_profile_type",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public AcsEntranceVisionlineMetadataProfiles.VisionlineDoorProfileTypeEnum VisionlineDoorProfileType { get; set; }

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
