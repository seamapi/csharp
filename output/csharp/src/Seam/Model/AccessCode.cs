using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_accessCode_model")]
    public class AccessCode
    {
        [JsonConstructorAttribute]
        protected AccessCode() { }

        public AccessCode(
            string accessCodeId = default,
            string? code = default,
            string? commonCodeKey = default,
            string createdAt = default,
            string deviceId = default,
            string? endsAt = default,
            List<JObject> errors = default,
            bool? isBackup = default,
            bool isBackupAccessCodeAvailable = default,
            bool isExternalModificationAllowed = default,
            bool isManaged = default,
            bool isOfflineAccessCode = default,
            bool isOneTimeUse = default,
            bool? isScheduledOnDevice = default,
            bool? isWaitingForCodeAssignment = default,
            string? name = default,
            string? pulledBackupAccessCodeId = default,
            string? startsAt = default,
            AccessCode.StatusEnum status = default,
            AccessCode.TypeEnum type = default,
            List<AccessCodeWarnings> warnings = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            CommonCodeKey = commonCodeKey;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EndsAt = endsAt;
            Errors = errors;
            IsBackup = isBackup;
            IsBackupAccessCodeAvailable = isBackupAccessCodeAvailable;
            IsExternalModificationAllowed = isExternalModificationAllowed;
            IsManaged = isManaged;
            IsOfflineAccessCode = isOfflineAccessCode;
            IsOneTimeUse = isOneTimeUse;
            IsScheduledOnDevice = isScheduledOnDevice;
            IsWaitingForCodeAssignment = isWaitingForCodeAssignment;
            Name = name;
            PulledBackupAccessCodeId = pulledBackupAccessCodeId;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "setting")]
            Setting = 1,

            [EnumMember(Value = "set")]
            Set = 2,

            [EnumMember(Value = "unset")]
            Unset = 3,

            [EnumMember(Value = "removing")]
            Removing = 4,

            [EnumMember(Value = "unknown")]
            Unknown = 5,
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "time_bound")]
            TimeBound = 1,

            [EnumMember(Value = "ongoing")]
            Ongoing = 2,
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
        public string? CommonCodeKey { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Errors { get; set; }

        [DataMember(Name = "is_backup", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsBackup { get; set; }

        [DataMember(
            Name = "is_backup_access_code_available",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsBackupAccessCodeAvailable { get; set; }

        [DataMember(
            Name = "is_external_modification_allowed",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsExternalModificationAllowed { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "is_offline_access_code", IsRequired = true, EmitDefaultValue = false)]
        public bool IsOfflineAccessCode { get; set; }

        [DataMember(Name = "is_one_time_use", IsRequired = true, EmitDefaultValue = false)]
        public bool IsOneTimeUse { get; set; }

        [DataMember(Name = "is_scheduled_on_device", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsScheduledOnDevice { get; set; }

        [DataMember(
            Name = "is_waiting_for_code_assignment",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsWaitingForCodeAssignment { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(
            Name = "pulled_backup_access_code_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? PulledBackupAccessCodeId { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public AccessCode.StatusEnum Status { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public AccessCode.TypeEnum Type { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<AccessCodeWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_accessCodeWarnings_model")]
    public class AccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected AccessCodeWarnings() { }

        public AccessCodeWarnings(string message = default, string warningCode = default)
        {
            Message = message;
            WarningCode = warningCode;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
        public string WarningCode { get; set; }

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
