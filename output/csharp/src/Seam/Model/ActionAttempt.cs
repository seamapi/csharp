using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "ActionType")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateNoiseThreshold), "update_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateNoiseThreshold), "update_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateNoiseThreshold), "update_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteNoiseThreshold), "delete_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteNoiseThreshold), "delete_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteNoiseThreshold), "delete_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateNoiseThreshold), "create_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateNoiseThreshold), "create_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateNoiseThreshold), "create_noise_threshold")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateAccessCode), "update_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateAccessCode), "update_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateAccessCode), "update_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteAccessCode), "delete_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteAccessCode), "delete_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteAccessCode), "delete_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateAccessCode), "create_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateAccessCode), "create_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateAccessCode), "create_access_code")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSyncAccessCodes), "sync_access_codes")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSyncAccessCodes), "sync_access_codes")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSyncAccessCodes), "sync_access_codes")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptActivateClimatePreset),
        "activate_climate_preset"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptActivateClimatePreset),
        "activate_climate_preset"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptActivateClimatePreset),
        "activate_climate_preset"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetThermostatOff), "set_thermostat_off")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetThermostatOff), "set_thermostat_off")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetThermostatOff), "set_thermostat_off")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetFanMode), "set_fan_mode")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetFanMode), "set_fan_mode")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetFanMode), "set_fan_mode")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeatCool), "set_heat_cool")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeatCool), "set_heat_cool")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeatCool), "set_heat_cool")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeat), "set_heat")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeat), "set_heat")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHeat), "set_heat")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetCool), "set_cool")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetCool), "set_cool")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetCool), "set_cool")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptResetSandboxWorkspace),
        "reset_sandbox_workspace"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptResetSandboxWorkspace),
        "reset_sandbox_workspace"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptResetSandboxWorkspace),
        "reset_sandbox_workspace"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptEncodeCredential), "encode_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptEncodeCredential), "encode_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptEncodeCredential), "encode_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptScanCredential), "scan_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptScanCredential), "scan_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptScanCredential), "scan_credential")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUnlockDoor), "unlock_door")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUnlockDoor), "unlock_door")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUnlockDoor), "unlock_door")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptLockDoor), "lock_door")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptLockDoor), "lock_door")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptLockDoor), "lock_door")]
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

    [DataContract(Name = "seamModel_actionAttemptLockDoor_model")]
    public class ActionAttemptLockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoor() { }

        public ActionAttemptLockDoor(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptLockDoorResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "LOCK_DOOR";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptLockDoorResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptLockDoorResult_model")]
    public class ActionAttemptLockDoorResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptLockDoorResult() { }

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

    [DataContract(Name = "seamModel_actionAttemptLockDoor_model")]
    public class ActionAttemptLockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoor() { }

        public ActionAttemptLockDoor(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptLockDoorError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "LOCK_DOOR";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptLockDoorError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptLockDoorError_model")]
    public class ActionAttemptLockDoorError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoorError() { }

        public ActionAttemptLockDoorError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUnlockDoor_model")]
    public class ActionAttemptUnlockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnlockDoor() { }

        public ActionAttemptUnlockDoor(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptUnlockDoorResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UNLOCK_DOOR";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUnlockDoorResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUnlockDoorResult_model")]
    public class ActionAttemptUnlockDoorResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptUnlockDoorResult() { }

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
            ActionAttemptUnlockDoorError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UNLOCK_DOOR";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUnlockDoorError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUnlockDoorError_model")]
    public class ActionAttemptUnlockDoorError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnlockDoorError() { }

        public ActionAttemptUnlockDoorError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptScanCredential_model")]
    public class ActionAttemptScanCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredential() { }

        public ActionAttemptScanCredential(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptScanCredentialResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SCAN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptScanCredentialResult_model")]
    public class ActionAttemptScanCredentialResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResult() { }

        public ActionAttemptScanCredentialResult(
            ActionAttemptScanCredentialResultAcsCredentialOnEncoder acsCredentialOnEncoder =
                default,
            JObject? acsCredentialOnSeam = default,
            List<ActionAttemptScanCredentialResultWarnings> warnings = default
        )
        {
            AcsCredentialOnEncoder = acsCredentialOnEncoder;
            AcsCredentialOnSeam = acsCredentialOnSeam;
            Warnings = warnings;
        }

        [DataMember(
            Name = "acs_credential_on_encoder",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public ActionAttemptScanCredentialResultAcsCredentialOnEncoder AcsCredentialOnEncoder { get; set; }

        [DataMember(Name = "acs_credential_on_seam", IsRequired = false, EmitDefaultValue = false)]
        public JObject? AcsCredentialOnSeam { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<ActionAttemptScanCredentialResultWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnEncoder_model")]
    public class ActionAttemptScanCredentialResultAcsCredentialOnEncoder
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnEncoder() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnEncoder(
            string? cardNumber = default,
            string? createdAt = default,
            string? endsAt = default,
            bool? isIssued = default,
            string? startsAt = default,
            ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata? visionlineMetadata =
                default
        )
        {
            CardNumber = cardNumber;
            CreatedAt = createdAt;
            EndsAt = endsAt;
            IsIssued = isIssued;
            StartsAt = startsAt;
            VisionlineMetadata = visionlineMetadata;
        }

        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata? VisionlineMetadata { get; set; }

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

    [DataContract(
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata(
            bool cancelled = default,
            ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata.CardFormatEnum cardFormat =
                default,
            string? cardHolder = default,
            string cardId = default,
            List<string>? commonAcsEntranceIds = default,
            bool discarded = default,
            bool expired = default,
            List<string>? guestAcsEntranceIds = default,
            float numberOfIssuedCards = default,
            bool? overridden = default,
            bool overwritten = default,
            bool pendingAutoUpdate = default
        )
        {
            Cancelled = cancelled;
            CardFormat = cardFormat;
            CardHolder = cardHolder;
            CardId = cardId;
            CommonAcsEntranceIds = commonAcsEntranceIds;
            Discarded = discarded;
            Expired = expired;
            GuestAcsEntranceIds = guestAcsEntranceIds;
            NumberOfIssuedCards = numberOfIssuedCards;
            Overridden = overridden;
            Overwritten = overwritten;
            PendingAutoUpdate = pendingAutoUpdate;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum CardFormatEnum
        {
            [EnumMember(Value = "TLCode")]
            TlCode = 0,

            [EnumMember(Value = "rfid48")]
            Rfid48 = 1,
        }

        [DataMember(Name = "cancelled", IsRequired = true, EmitDefaultValue = false)]
        public bool Cancelled { get; set; }

        [DataMember(Name = "card_format", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata.CardFormatEnum CardFormat { get; set; }

        [DataMember(Name = "card_holder", IsRequired = false, EmitDefaultValue = false)]
        public string? CardHolder { get; set; }

        [DataMember(Name = "card_id", IsRequired = true, EmitDefaultValue = false)]
        public string CardId { get; set; }

        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        [DataMember(Name = "discarded", IsRequired = true, EmitDefaultValue = false)]
        public bool Discarded { get; set; }

        [DataMember(Name = "expired", IsRequired = true, EmitDefaultValue = false)]
        public bool Expired { get; set; }

        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        [DataMember(Name = "number_of_issued_cards", IsRequired = true, EmitDefaultValue = false)]
        public float NumberOfIssuedCards { get; set; }

        [DataMember(Name = "overridden", IsRequired = false, EmitDefaultValue = false)]
        public bool? Overridden { get; set; }

        [DataMember(Name = "overwritten", IsRequired = true, EmitDefaultValue = false)]
        public bool Overwritten { get; set; }

        [DataMember(Name = "pending_auto_update", IsRequired = true, EmitDefaultValue = false)]
        public bool PendingAutoUpdate { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptScanCredentialResultWarnings_model")]
    public class ActionAttemptScanCredentialResultWarnings
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultWarnings() { }

        public ActionAttemptScanCredentialResultWarnings(
            ActionAttemptScanCredentialResultWarnings.WarningCodeEnum warningCode = default,
            string warningMessage = default
        )
        {
            WarningCode = warningCode;
            WarningMessage = warningMessage;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "acs_credential_on_encoder_out_of_sync")]
            AcsCredentialOnEncoderOutOfSync = 0,
        }

        [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultWarnings.WarningCodeEnum WarningCode { get; set; }

        [DataMember(Name = "warning_message", IsRequired = true, EmitDefaultValue = false)]
        public string WarningMessage { get; set; }

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
            JObject error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SCAN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public JObject Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptEncodeCredential_model")]
    public class ActionAttemptEncodeCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredential() { }

        public ActionAttemptEncodeCredential(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            JObject result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ENCODE_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public JObject Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptEncodeCredential_model")]
    public class ActionAttemptEncodeCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredential() { }

        public ActionAttemptEncodeCredential(
            string actionAttemptId = default,
            string actionType = default,
            JObject error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ENCODE_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public JObject Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptResetSandboxWorkspace_model")]
    public class ActionAttemptResetSandboxWorkspace : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptResetSandboxWorkspace() { }

        public ActionAttemptResetSandboxWorkspace(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptResetSandboxWorkspaceResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "RESET_SANDBOX_WORKSPACE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptResetSandboxWorkspaceResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptResetSandboxWorkspaceResult_model")]
    public class ActionAttemptResetSandboxWorkspaceResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptResetSandboxWorkspaceResult() { }

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
            ActionAttemptResetSandboxWorkspaceError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "RESET_SANDBOX_WORKSPACE";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptResetSandboxWorkspaceError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptResetSandboxWorkspaceError_model")]
    public class ActionAttemptResetSandboxWorkspaceError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptResetSandboxWorkspaceError() { }

        public ActionAttemptResetSandboxWorkspaceError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetCool_model")]
    public class ActionAttemptSetCool : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetCool() { }

        public ActionAttemptSetCool(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSetCoolResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_COOL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetCoolResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetCoolResult_model")]
    public class ActionAttemptSetCoolResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetCoolResult() { }

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
            ActionAttemptSetCoolError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_COOL";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetCoolError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetCoolError_model")]
    public class ActionAttemptSetCoolError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetCoolError() { }

        public ActionAttemptSetCoolError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeat_model")]
    public class ActionAttemptSetHeat : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeat() { }

        public ActionAttemptSetHeat(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSetHeatResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeatResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatResult_model")]
    public class ActionAttemptSetHeatResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetHeatResult() { }

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
            ActionAttemptSetHeatError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeatError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatError_model")]
    public class ActionAttemptSetHeatError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeatError() { }

        public ActionAttemptSetHeatError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatCool_model")]
    public class ActionAttemptSetHeatCool : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeatCool() { }

        public ActionAttemptSetHeatCool(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSetHeatCoolResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT_COOL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeatCoolResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatCoolResult_model")]
    public class ActionAttemptSetHeatCoolResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetHeatCoolResult() { }

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
            ActionAttemptSetHeatCoolError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HEAT_COOL";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetHeatCoolError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetHeatCoolError_model")]
    public class ActionAttemptSetHeatCoolError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHeatCoolError() { }

        public ActionAttemptSetHeatCoolError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetFanMode_model")]
    public class ActionAttemptSetFanMode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetFanMode() { }

        public ActionAttemptSetFanMode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSetFanModeResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_FAN_MODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetFanModeResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetFanModeResult_model")]
    public class ActionAttemptSetFanModeResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetFanModeResult() { }

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
            ActionAttemptSetFanModeError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_FAN_MODE";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetFanModeError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetFanModeError_model")]
    public class ActionAttemptSetFanModeError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetFanModeError() { }

        public ActionAttemptSetFanModeError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetThermostatOff_model")]
    public class ActionAttemptSetThermostatOff : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetThermostatOff() { }

        public ActionAttemptSetThermostatOff(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSetThermostatOffResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_THERMOSTAT_OFF";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetThermostatOffResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetThermostatOffResult_model")]
    public class ActionAttemptSetThermostatOffResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetThermostatOffResult() { }

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
            ActionAttemptSetThermostatOffError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_THERMOSTAT_OFF";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSetThermostatOffError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSetThermostatOffError_model")]
    public class ActionAttemptSetThermostatOffError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetThermostatOffError() { }

        public ActionAttemptSetThermostatOffError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptActivateClimatePreset_model")]
    public class ActionAttemptActivateClimatePreset : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptActivateClimatePreset() { }

        public ActionAttemptActivateClimatePreset(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptActivateClimatePresetResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ACTIVATE_CLIMATE_PRESET";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptActivateClimatePresetResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptActivateClimatePresetResult_model")]
    public class ActionAttemptActivateClimatePresetResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptActivateClimatePresetResult() { }

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
            ActionAttemptActivateClimatePresetError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ACTIVATE_CLIMATE_PRESET";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptActivateClimatePresetError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptActivateClimatePresetError_model")]
    public class ActionAttemptActivateClimatePresetError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptActivateClimatePresetError() { }

        public ActionAttemptActivateClimatePresetError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSyncAccessCodes_model")]
    public class ActionAttemptSyncAccessCodes : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSyncAccessCodes() { }

        public ActionAttemptSyncAccessCodes(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptSyncAccessCodesResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SYNC_ACCESS_CODES";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSyncAccessCodesResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSyncAccessCodesResult_model")]
    public class ActionAttemptSyncAccessCodesResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSyncAccessCodesResult() { }

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
            ActionAttemptSyncAccessCodesError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SYNC_ACCESS_CODES";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptSyncAccessCodesError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptSyncAccessCodesError_model")]
    public class ActionAttemptSyncAccessCodesError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSyncAccessCodesError() { }

        public ActionAttemptSyncAccessCodesError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCode_model")]
    public class ActionAttemptCreateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCode() { }

        public ActionAttemptCreateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptCreateAccessCodeResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateAccessCodeResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCodeResult_model")]
    public class ActionAttemptCreateAccessCodeResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCodeResult() { }

        public ActionAttemptCreateAccessCodeResult(Object accessCode = default)
        {
            AccessCode = accessCode;
        }

        [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
        public Object AccessCode { get; set; }

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
            ActionAttemptCreateAccessCodeError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateAccessCodeError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCodeError_model")]
    public class ActionAttemptCreateAccessCodeError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCodeError() { }

        public ActionAttemptCreateAccessCodeError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteAccessCode_model")]
    public class ActionAttemptDeleteAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteAccessCode() { }

        public ActionAttemptDeleteAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptDeleteAccessCodeResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteAccessCodeResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteAccessCodeResult_model")]
    public class ActionAttemptDeleteAccessCodeResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptDeleteAccessCodeResult() { }

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
            ActionAttemptDeleteAccessCodeError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteAccessCodeError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteAccessCodeError_model")]
    public class ActionAttemptDeleteAccessCodeError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteAccessCodeError() { }

        public ActionAttemptDeleteAccessCodeError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCode_model")]
    public class ActionAttemptUpdateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCode() { }

        public ActionAttemptUpdateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptUpdateAccessCodeResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateAccessCodeResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCodeResult_model")]
    public class ActionAttemptUpdateAccessCodeResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCodeResult() { }

        public ActionAttemptUpdateAccessCodeResult(Object accessCode = default)
        {
            AccessCode = accessCode;
        }

        [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
        public Object AccessCode { get; set; }

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
            ActionAttemptUpdateAccessCodeError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_ACCESS_CODE";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateAccessCodeError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCodeError_model")]
    public class ActionAttemptUpdateAccessCodeError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCodeError() { }

        public ActionAttemptUpdateAccessCodeError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateNoiseThreshold_model")]
    public class ActionAttemptCreateNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateNoiseThreshold() { }

        public ActionAttemptCreateNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptCreateNoiseThresholdResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateNoiseThresholdResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateNoiseThresholdResult_model")]
    public class ActionAttemptCreateNoiseThresholdResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateNoiseThresholdResult() { }

        public ActionAttemptCreateNoiseThresholdResult(Object noiseThreshold = default)
        {
            NoiseThreshold = noiseThreshold;
        }

        [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
        public Object NoiseThreshold { get; set; }

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
            ActionAttemptCreateNoiseThresholdError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptCreateNoiseThresholdError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptCreateNoiseThresholdError_model")]
    public class ActionAttemptCreateNoiseThresholdError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateNoiseThresholdError() { }

        public ActionAttemptCreateNoiseThresholdError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteNoiseThreshold_model")]
    public class ActionAttemptDeleteNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteNoiseThreshold() { }

        public ActionAttemptDeleteNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptDeleteNoiseThresholdResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteNoiseThresholdResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteNoiseThresholdResult_model")]
    public class ActionAttemptDeleteNoiseThresholdResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptDeleteNoiseThresholdResult() { }

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
            ActionAttemptDeleteNoiseThresholdError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptDeleteNoiseThresholdError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptDeleteNoiseThresholdError_model")]
    public class ActionAttemptDeleteNoiseThresholdError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptDeleteNoiseThresholdError() { }

        public ActionAttemptDeleteNoiseThresholdError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThreshold_model")]
    public class ActionAttemptUpdateNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThreshold() { }

        public ActionAttemptUpdateNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            Object error = default,
            ActionAttemptUpdateNoiseThresholdResult result = default,
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
            [EnumMember(Value = "success")]
            Success = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public Object Error { get; set; }

        [DataMember(Name = "result", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateNoiseThresholdResult Result { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThresholdResult_model")]
    public class ActionAttemptUpdateNoiseThresholdResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThresholdResult() { }

        public ActionAttemptUpdateNoiseThresholdResult(Object noiseThreshold = default)
        {
            NoiseThreshold = noiseThreshold;
        }

        [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
        public Object NoiseThreshold { get; set; }

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
            ActionAttemptUpdateNoiseThresholdError error = default,
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
            [EnumMember(Value = "error")]
            Error = 0,
        }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_NOISE_THRESHOLD";

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptUpdateNoiseThresholdError Error { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThresholdError_model")]
    public class ActionAttemptUpdateNoiseThresholdError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThresholdError() { }

        public ActionAttemptUpdateNoiseThresholdError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

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
