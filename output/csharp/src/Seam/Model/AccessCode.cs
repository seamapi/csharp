using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
  [DataContract(Name = "seamModel_accessCode_model")]
  public class AccessCode
  {
    [JsonConstructorAttribute]
    protected AccessCode() { }

    public AccessCode(
      string? commonCodeKey = default,
      bool? isScheduledOnDevice = default,
      AccessCode.TypeEnum type = default,
      bool? isWaitingForCodeAssignment = default,
      string accessCodeId = default,
      string deviceId = default,
      string? name = default,
      string? code = default,
      string createdAt = default,
      Object errors = default,
      Object warnings = default,
      bool isManaged = default,
      string? startsAt = default,
      string? endsAt = default,
      AccessCode.StatusEnum status = default,
      bool isBackupAccessCodeAvailable = default,
      bool? isBackup = default,
      string? pulledBackupAccessCodeId = default,
      bool isExternalModificationAllowed = default,
      bool isOneTimeUse = default,
      bool isOfflineAccessCode = default
    )
    {
      CommonCodeKey = commonCodeKey;
      IsScheduledOnDevice = isScheduledOnDevice;
      Type = type;
      IsWaitingForCodeAssignment = isWaitingForCodeAssignment;
      AccessCodeId = accessCodeId;
      DeviceId = deviceId;
      Name = name;
      Code = code;
      CreatedAt = createdAt;
      Errors = errors;
      Warnings = warnings;
      IsManaged = isManaged;
      StartsAt = startsAt;
      EndsAt = endsAt;
      Status = status;
      IsBackupAccessCodeAvailable = isBackupAccessCodeAvailable;
      IsBackup = isBackup;
      PulledBackupAccessCodeId = pulledBackupAccessCodeId;
      IsExternalModificationAllowed = isExternalModificationAllowed;
      IsOneTimeUse = isOneTimeUse;
      IsOfflineAccessCode = isOfflineAccessCode;
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
      [EnumMember(Value = "time_bound")]
      TimeBound = 0,

      [EnumMember(Value = "ongoing")]
      Ongoing = 1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
      [EnumMember(Value = "setting")]
      Setting = 0,

      [EnumMember(Value = "set")]
      Set = 1,

      [EnumMember(Value = "unset")]
      Unset = 2,

      [EnumMember(Value = "removing")]
      Removing = 3,

      [EnumMember(Value = "unknown")]
      Unknown = 4
    }

    [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
    public string? CommonCodeKey { get; set; }

    [DataMember(Name = "is_scheduled_on_device", IsRequired = false, EmitDefaultValue = false)]
    public bool? IsScheduledOnDevice { get; set; }

    [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
    public AccessCode.TypeEnum Type { get; set; }

    [DataMember(
      Name = "is_waiting_for_code_assignment",
      IsRequired = false,
      EmitDefaultValue = false
    )]
    public bool? IsWaitingForCodeAssignment { get; set; }

    [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
    public string AccessCodeId { get; set; }

    [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
    public string DeviceId { get; set; }

    [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
    public string? Name { get; set; }

    [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
    public string? Code { get; set; }

    [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
    public string CreatedAt { get; set; }

    [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
    public Object Errors { get; set; }

    [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
    public Object Warnings { get; set; }

    [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
    public bool IsManaged { get; set; }

    [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
    public string? StartsAt { get; set; }

    [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
    public string? EndsAt { get; set; }

    [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
    public AccessCode.StatusEnum Status { get; set; }

    [DataMember(
      Name = "is_backup_access_code_available",
      IsRequired = true,
      EmitDefaultValue = false
    )]
    public bool IsBackupAccessCodeAvailable { get; set; }

    [DataMember(Name = "is_backup", IsRequired = false, EmitDefaultValue = false)]
    public bool? IsBackup { get; set; }

    [DataMember(
      Name = "pulled_backup_access_code_id",
      IsRequired = false,
      EmitDefaultValue = false
    )]
    public string? PulledBackupAccessCodeId { get; set; }

    [DataMember(
      Name = "is_external_modification_allowed",
      IsRequired = true,
      EmitDefaultValue = false
    )]
    public bool IsExternalModificationAllowed { get; set; }

    [DataMember(Name = "is_one_time_use", IsRequired = true, EmitDefaultValue = false)]
    public bool IsOneTimeUse { get; set; }

    [DataMember(Name = "is_offline_access_code", IsRequired = true, EmitDefaultValue = false)]
    public bool IsOfflineAccessCode { get; set; }

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
