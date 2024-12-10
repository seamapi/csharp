using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedAccessCode_model")]
    public class UnmanagedAccessCode
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessCode() { }

        public UnmanagedAccessCode(
            string accessCodeId = default,
            string? code = default,
            string createdAt = default,
            string deviceId = default,
            string? endsAt = default,
            List<JObject> errors = default,
            bool isManaged = default,
            string? name = default,
            string? startsAt = default,
            UnmanagedAccessCode.StatusEnum status = default,
            UnmanagedAccessCode.TypeEnum type = default,
            List<UnmanagedAccessCodeWarnings> warnings = default
        )
        {
            AccessCodeId = accessCodeId;
            Code = code;
            CreatedAt = createdAt;
            DeviceId = deviceId;
            EndsAt = endsAt;
            Errors = errors;
            IsManaged = isManaged;
            Name = name;
            StartsAt = startsAt;
            Status = status;
            Type = type;
            Warnings = warnings;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "set")]
            Set = 0,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "time_bound")]
            TimeBound = 0,

            [EnumMember(Value = "ongoing")]
            Ongoing = 1,
        }

        [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
        public string AccessCodeId { get; set; }

        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Errors { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string? Name { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAccessCode.StatusEnum Status { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public UnmanagedAccessCode.TypeEnum Type { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAccessCodeWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedAccessCodeWarnings_model")]
    public class UnmanagedAccessCodeWarnings
    {
        [JsonConstructorAttribute]
        protected UnmanagedAccessCodeWarnings() { }

        public UnmanagedAccessCodeWarnings(string message = default, string warningCode = default)
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
