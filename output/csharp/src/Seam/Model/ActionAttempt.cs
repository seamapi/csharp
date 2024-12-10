using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "action_type")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateNoiseThreshold), "UPDATE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteNoiseThreshold), "DELETE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateNoiseThreshold), "CREATE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateAccessCode), "UPDATE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteAccessCode), "DELETE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateAccessCode), "CREATE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSyncAccessCodes), "SYNC_ACCESS_CODES")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptActivateClimatePreset),
        "ACTIVATE_CLIMATE_PRESET"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetThermostatOff), "SET_THERMOSTAT_OFF")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetFanMode), "SET_FAN_MODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeatCool), "SET_HEAT_COOL")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeat), "SET_HEAT")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetCool), "SET_COOL")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptResetSandboxWorkspace),
        "RESET_SANDBOX_WORKSPACE"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptEncodeCredential), "ENCODE_CREDENTIAL")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptScanCredential), "SCAN_CREDENTIAL")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUnlockDoor), "UNLOCK_DOOR")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptLockDoor), "LOCK_DOOR")]
    public abstract class ActionAttempt
    {
        public abstract string ActionType { get; }

        public abstract override string ToString();
    }

    [DataContract(Name = "seamModel_actionAttemptLockDoor_model")]
    public class ActionAttemptLockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoor() { }

        public ActionAttemptLockDoor(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptLockDoor.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "LOCK_DOOR";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptLockDoor.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUnlockDoor_model")]
    public class ActionAttemptUnlockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnlockDoor() { }

        public ActionAttemptUnlockDoor(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptUnlockDoor.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UNLOCK_DOOR";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUnlockDoor.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptScanCredential_model")]
    public class ActionAttemptScanCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredential() { }

        public ActionAttemptScanCredential(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptScanCredential.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SCAN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptScanCredential.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptEncodeCredential_model")]
    public class ActionAttemptEncodeCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredential() { }

        public ActionAttemptEncodeCredential(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptEncodeCredential.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ENCODE_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredential.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptResetSandboxWorkspace_model")]
    public class ActionAttemptResetSandboxWorkspace : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptResetSandboxWorkspace() { }

        public ActionAttemptResetSandboxWorkspace(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptResetSandboxWorkspace.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "RESET_SANDBOX_WORKSPACE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptResetSandboxWorkspace.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetCool_model")]
    public class ActionAttemptSetCool : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetCool() { }

        public ActionAttemptSetCool(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSetCool.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_COOL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetCool.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeat_model")]
    public class ActionAttemptSetHeat : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeat() { }

        public ActionAttemptSetHeat(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSetHeat.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeat.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatCool_model")]
    public class ActionAttemptSetHeatCool : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeatCool() { }

        public ActionAttemptSetHeatCool(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSetHeatCool.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT_COOL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeatCool.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetFanMode_model")]
    public class ActionAttemptSetFanMode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetFanMode() { }

        public ActionAttemptSetFanMode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSetFanMode.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_FAN_MODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetFanMode.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetThermostatOff_model")]
    public class ActionAttemptSetThermostatOff : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetThermostatOff() { }

        public ActionAttemptSetThermostatOff(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSetThermostatOff.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_THERMOSTAT_OFF";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetThermostatOff.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptActivateClimatePreset_model")]
    public class ActionAttemptActivateClimatePreset : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptActivateClimatePreset() { }

        public ActionAttemptActivateClimatePreset(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptActivateClimatePreset.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ACTIVATE_CLIMATE_PRESET";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptActivateClimatePreset.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSyncAccessCodes_model")]
    public class ActionAttemptSyncAccessCodes : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSyncAccessCodes() { }

        public ActionAttemptSyncAccessCodes(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptSyncAccessCodes.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SYNC_ACCESS_CODES";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSyncAccessCodes.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCode_model")]
    public class ActionAttemptCreateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCode() { }

        public ActionAttemptCreateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptCreateAccessCode.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateAccessCode.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteAccessCode_model")]
    public class ActionAttemptDeleteAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteAccessCode() { }

        public ActionAttemptDeleteAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptDeleteAccessCode.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteAccessCode.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCode_model")]
    public class ActionAttemptUpdateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCode() { }

        public ActionAttemptUpdateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptUpdateAccessCode.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateAccessCode.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateNoiseThreshold_model")]
    public class ActionAttemptCreateNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateNoiseThreshold() { }

        public ActionAttemptCreateNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptCreateNoiseThreshold.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateNoiseThreshold.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteNoiseThreshold_model")]
    public class ActionAttemptDeleteNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteNoiseThreshold() { }

        public ActionAttemptDeleteNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptDeleteNoiseThreshold.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteNoiseThreshold.StatusEnum Status { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThreshold_model")]
    public class ActionAttemptUpdateNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThreshold() { }

        public ActionAttemptUpdateNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            Object result = default,
            ActionAttemptUpdateNoiseThreshold.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateNoiseThreshold.StatusEnum Status { get; set; }

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
