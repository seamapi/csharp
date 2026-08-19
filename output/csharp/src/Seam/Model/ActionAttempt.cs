using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "action_type")]
    [JsonSubtypes.FallBackSubType(typeof(ActionAttemptUnrecognized))]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateNoiseThreshold), "UPDATE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteNoiseThreshold), "DELETE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateNoiseThreshold), "CREATE_NOISE_THRESHOLD")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUpdateAccessCode), "UPDATE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptDeleteAccessCode), "DELETE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptCreateAccessCode), "CREATE_ACCESS_CODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSyncAccessCodes), "SYNC_ACCESS_CODES")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptConfigureAutoLock), "CONFIGURE_AUTO_LOCK")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptPushThermostatPrograms),
        "PUSH_THERMOSTAT_PROGRAMS"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptSimulateManualLockViaKeypad),
        "SIMULATE_MANUAL_LOCK_VIA_KEYPAD"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptSimulateKeypadCodeEntry),
        "SIMULATE_KEYPAD_CODE_ENTRY"
    )]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptActivateClimatePreset),
        "ACTIVATE_CLIMATE_PRESET"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetHvacMode), "SET_HVAC_MODE")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSetFanMode), "SET_FAN_MODE")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptResetSandboxWorkspace),
        "RESET_SANDBOX_WORKSPACE"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptAssignCredential), "ASSIGN_CREDENTIAL")]
    [JsonSubtypes.KnownSubType(
        typeof(ActionAttemptScanToAssignCredential),
        "SCAN_TO_ASSIGN_CREDENTIAL"
    )]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptEncodeCredential), "ENCODE_CREDENTIAL")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptScanCredential), "SCAN_CREDENTIAL")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptUnlockDoor), "UNLOCK_DOOR")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptLockDoor), "LOCK_DOOR")]
    public abstract class ActionAttempt
    {
        public abstract string ActionType { get; }

        public abstract string ActionAttemptId { get; set; }

        public abstract override string ToString();
    }

    /// <summary>
    /// Locking a door is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptLockDoor_model")]
    public class ActionAttemptLockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoor() { }

        public ActionAttemptLockDoor(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptLockDoorError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "LOCK_DOOR";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptLockDoorError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptLockDoorResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptLockDoorResult_model")]
    public class ActionAttemptLockDoorResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptLockDoorResult() { }

        public ActionAttemptLockDoorResult(bool? wasConfirmedByDevice = default)
        {
            WasConfirmedByDevice = wasConfirmedByDevice;
        }

        /// <summary>
        /// Indicates whether the device confirmed that the lock action occurred.
        /// </summary>
        [DataMember(Name = "was_confirmed_by_device", IsRequired = false, EmitDefaultValue = false)]
        public bool? WasConfirmedByDevice { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Unlocking a door is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptUnlockDoor_model")]
    public class ActionAttemptUnlockDoor : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnlockDoor() { }

        public ActionAttemptUnlockDoor(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptUnlockDoorError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UNLOCK_DOOR";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUnlockDoorError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUnlockDoorResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptUnlockDoorResult_model")]
    public class ActionAttemptUnlockDoorResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnlockDoorResult() { }

        public ActionAttemptUnlockDoorResult(bool? wasConfirmedByDevice = default)
        {
            WasConfirmedByDevice = wasConfirmedByDevice;
        }

        /// <summary>
        /// Indicates whether the device confirmed that the unlock action occurred.
        /// </summary>
        [DataMember(Name = "was_confirmed_by_device", IsRequired = false, EmitDefaultValue = false)]
        public bool? WasConfirmedByDevice { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Reading credential data from the physical encoder is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptScanCredential_model")]
    public class ActionAttemptScanCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredential() { }

        public ActionAttemptScanCredential(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptScanCredentialError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SCAN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialError Error { get; set; }

        /// <summary>
        /// Result of scanning a card. If the attempt was successful, includes a snapshot of credential data read from the physical encoder, the corresponding data stored on Seam and the access system, and any associated warnings.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptScanCredentialError_model")]
    public class ActionAttemptScanCredentialError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialError() { }

        public ActionAttemptScanCredentialError(
            string message = default,
            ActionAttemptScanCredentialError.TypeEnum type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Error type to indicate that the Seam Bridge is disconnected or cannot reach the access control system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "uncategorized_error")]
            UncategorizedError = 1,

            [EnumMember(Value = "action_attempt_expired")]
            ActionAttemptExpired = 2,

            [EnumMember(Value = "no_credential_on_encoder")]
            NoCredentialOnEncoder = 3,

            [EnumMember(Value = "encoder_not_online")]
            EncoderNotOnline = 4,

            [EnumMember(Value = "encoder_communication_timeout")]
            EncoderCommunicationTimeout = 5,

            [EnumMember(Value = "bridge_disconnected")]
            BridgeDisconnected = 6,
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Error type to indicate that the Seam Bridge is disconnected or cannot reach the access control system.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialError.TypeEnum Type { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
            ActionAttemptScanCredentialResultAcsCredentialOnEncoder? acsCredentialOnEncoder =
                default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeam? acsCredentialOnSeam = default,
            List<ActionAttemptScanCredentialResultWarnings> warnings = default
        )
        {
            AcsCredentialOnEncoder = acsCredentialOnEncoder;
            AcsCredentialOnSeam = acsCredentialOnSeam;
            Warnings = warnings;
        }

        /// <summary>
        /// Snapshot of credential data read from the physical encoder.
        /// </summary>
        [DataMember(
            Name = "acs_credential_on_encoder",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public ActionAttemptScanCredentialResultAcsCredentialOnEncoder? AcsCredentialOnEncoder { get; set; }

        /// <summary>
        /// Corresponding credential data as stored on Seam and the access system.
        /// </summary>
        [DataMember(Name = "acs_credential_on_seam", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeam? AcsCredentialOnSeam { get; set; }

        /// <summary>
        /// Warnings related to scanning the credential, such as mismatches between the credential data currently encoded on the card and the corresponding data stored on Seam and the access system.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// A number or string that physically identifies the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) will stop being usable.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Indicates whether the credential has been issued (encoded onto a card).
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) becomes usable.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
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
            bool? cancelled = default,
            ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata.CardFormatEnum? cardFormat =
                default,
            string? cardHolder = default,
            string? cardId = default,
            List<string>? commonAcsEntranceIds = default,
            bool? discarded = default,
            bool? expired = default,
            List<string>? guestAcsEntranceIds = default,
            float? numberOfIssuedCards = default,
            bool? overridden = default,
            bool? overwritten = default,
            bool? pendingAutoUpdate = default
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

        /// <summary>
        /// Format of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFormatEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "TLCode")]
            TlCode = 1,

            [EnumMember(Value = "rfid48")]
            Rfid48 = 2,
        }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is cancelled.
        /// </summary>
        [DataMember(Name = "cancelled", IsRequired = false, EmitDefaultValue = false)]
        public bool? Cancelled { get; set; }

        /// <summary>
        /// Format of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_format", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnEncoderVisionlineMetadata.CardFormatEnum? CardFormat { get; set; }

        /// <summary>
        /// Holder of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_holder", IsRequired = false, EmitDefaultValue = false)]
        public string? CardHolder { get; set; }

        /// <summary>
        /// Card ID for the Visionline card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        /// <summary>
        /// IDs of the common [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is discarded.
        /// </summary>
        [DataMember(Name = "discarded", IsRequired = false, EmitDefaultValue = false)]
        public bool? Discarded { get; set; }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is expired.
        /// </summary>
        [DataMember(Name = "expired", IsRequired = false, EmitDefaultValue = false)]
        public bool? Expired { get; set; }

        /// <summary>
        /// IDs of the guest [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        /// <summary>
        /// Number of issued cards associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "number_of_issued_cards", IsRequired = false, EmitDefaultValue = false)]
        public float? NumberOfIssuedCards { get; set; }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is overridden.
        /// </summary>
        [DataMember(Name = "overridden", IsRequired = false, EmitDefaultValue = false)]
        public bool? Overridden { get; set; }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is overwritten.
        /// </summary>
        [DataMember(Name = "overwritten", IsRequired = false, EmitDefaultValue = false)]
        public bool? Overwritten { get; set; }

        /// <summary>
        /// Indicates whether the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is pending auto-update.
        /// </summary>
        [DataMember(Name = "pending_auto_update", IsRequired = false, EmitDefaultValue = false)]
        public bool? PendingAutoUpdate { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeam_model")]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeam
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeam() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeam(
            ActionAttemptScanCredentialResultAcsCredentialOnSeam.AccessMethodEnum accessMethod =
                default,
            string acsCredentialId = default,
            string? acsCredentialPoolId = default,
            string acsSystemId = default,
            string? acsUserId = default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata? akilesMetadata =
                default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata? assaAbloyVostioMetadata =
                default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<ActionAttemptScanCredentialResultAcsCredentialOnSeamErrors> errors = default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeam.ExternalTypeEnum? externalType =
                default,
            string? externalTypeDisplayName = default,
            bool? isIssued = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isMultiPhoneSyncCredential = default,
            bool? isOneTimeUse = default,
            string? issuedAt = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            string? parentAcsCredentialId = default,
            string? startsAt = default,
            string? userIdentityId = default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata? visionlineMetadata =
                default,
            List<ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CardNumber = cardNumber;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsIssued = isIssued;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
            IsOneTimeUse = isOneTimeUse;
            IssuedAt = issuedAt;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            ParentAcsCredentialId = parentAcsCredentialId;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessMethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_card")]
            PtiCard = 1,

            [EnumMember(Value = "brivo_credential")]
            BrivoCredential = 2,

            [EnumMember(Value = "hid_credential")]
            HidCredential = 3,

            [EnumMember(Value = "visionline_card")]
            VisionlineCard = 4,

            [EnumMember(Value = "salto_ks_credential")]
            SaltoKsCredential = 5,

            [EnumMember(Value = "assa_abloy_vostio_key")]
            AssaAbloyVostioKey = 6,

            [EnumMember(Value = "salto_space_key")]
            SaltoSpaceKey = 7,

            [EnumMember(Value = "latch_access")]
            LatchAccess = 8,

            [EnumMember(Value = "dormakaba_ambiance_credential")]
            DormakabaAmbianceCredential = 9,

            [EnumMember(Value = "hotek_card")]
            HotekCard = 10,

            [EnumMember(Value = "salto_ks_tag")]
            SaltoKsTag = 11,

            [EnumMember(Value = "avigilon_alta_credential")]
            AvigilonAltaCredential = 12,

            [EnumMember(Value = "kisi_credential")]
            KisiCredential = 13,

            [EnumMember(Value = "akiles_credential")]
            AkilesCredential = 14,
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeam.AccessMethodEnum AccessMethod { get; set; }

        /// <summary>
        /// ID of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the credential pool to which the credential belongs.
        /// </summary>
        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// Akiles-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// Vostio-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Number of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        /// <summary>
        /// Access (PIN) code for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// ID of the [connected account](https://docs.seam.co/core-concepts/connected-accounts) to which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name that corresponds to the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptScanCredentialResultAcsCredentialOnSeamErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeam.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been encoded onto a card.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the latest state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is a [multi-phone sync credential](https://docs.seam.co/capability-guides/mobile-access/issuing-mobile-credentials-from-an-access-control-system#what-are-multi-phone-sync-credentials).
        /// </summary>
        [DataMember(
            Name = "is_multi_phone_sync_credential",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsMultiPhoneSyncCredential { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) can only be used once. If `true`, the code becomes invalid after the first use.
        /// </summary>
        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneTimeUse { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was encoded onto a card.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Date and time at which the state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was most recently synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        /// <summary>
        /// ID of the parent [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "parent_acs_credential_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ParentAcsCredentialId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// ID of the [user identity](https://docs.seam.co/api/user_identities) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeamAkilesMetadata(
            string? memberPinId = default
        )
        {
            MemberPinId = memberPinId;
        }

        /// <summary>
        /// ID of the Akiles member PIN.
        /// </summary>
        [DataMember(Name = "member_pin_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberPinId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeamAssaAbloyVostioMetadata(
            bool? autoJoin = default,
            List<string>? doorNames = default,
            string? endpointId = default,
            string? keyId = default,
            string? keyIssuingRequestId = default,
            List<string>? overrideGuestAcsEntranceIds = default
        )
        {
            AutoJoin = autoJoin;
            DoorNames = doorNames;
            EndpointId = endpointId;
            KeyId = keyId;
            KeyIssuingRequestId = keyIssuingRequestId;
            OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Names of the doors to which to grant access in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_names", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? DoorNames { get; set; }

        /// <summary>
        /// Endpoint ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Key ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        /// <summary>
        /// Key issuing request ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_issuing_request_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyIssuingRequestId { get; set; }

        /// <summary>
        /// IDs of the guest entrances to override in the Vostio access system.
        /// </summary>
        [DataMember(
            Name = "override_guest_acs_entrance_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? OverrideGuestAcsEntranceIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeamErrors_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeamErrors
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeamErrors() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeamErrors(
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

    [DataContract(
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata(
            bool? autoJoin = default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType =
                default,
            string? cardId = default,
            List<string>? commonAcsEntranceIds = default,
            string? credentialId = default,
            List<string>? guestAcsEntranceIds = default,
            bool? isValid = default,
            List<string>? joinerAcsCredentialIds = default
        )
        {
            AutoJoin = autoJoin;
            CardFunctionType = cardFunctionType;
            CardId = cardId;
            CommonAcsEntranceIds = commonAcsEntranceIds;
            CredentialId = credentialId;
            GuestAcsEntranceIds = guestAcsEntranceIds;
            IsValid = isValid;
            JoinerAcsCredentialIds = joinerAcsCredentialIds;
        }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFunctionTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "guest")]
            Guest = 1,

            [EnumMember(Value = "staff")]
            Staff = 2,
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeamVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

        /// <summary>
        /// ID of the card in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        /// <summary>
        /// Common entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        /// <summary>
        /// ID of the credential in the Visionline access system.
        /// </summary>
        [DataMember(Name = "credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CredentialId { get; set; }

        /// <summary>
        /// Guest entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        /// <summary>
        /// Indicates whether the credential is valid.
        /// </summary>
        [DataMember(Name = "is_valid", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsValid { get; set; }

        /// <summary>
        /// IDs of the credentials to which you want to join.
        /// </summary>
        [DataMember(
            Name = "joiner_acs_credential_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? JoinerAcsCredentialIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptScanCredentialResultAcsCredentialOnSeamWarnings_model"
    )]
    public class ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings() { }

        public ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings(
            string createdAt = default,
            string message = default,
            ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings.WarningCodeEnum warningCode =
                default,
            string? newCode = default,
            string? originalCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
            NewCode = newCode;
            OriginalCode = originalCode;
        }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "waiting_to_be_issued")]
            WaitingToBeIssued = 1,

            [EnumMember(Value = "schedule_externally_modified")]
            ScheduleExternallyModified = 2,

            [EnumMember(Value = "schedule_modified")]
            ScheduleModified = 3,

            [EnumMember(Value = "being_deleted")]
            BeingDeleted = 4,

            [EnumMember(Value = "unknown_issue_with_acs_credential")]
            UnknownIssueWithAcsCredential = 5,

            [EnumMember(Value = "needs_to_be_reissued")]
            NeedsToBeReissued = 6,

            [EnumMember(Value = "requested_code_unavailable")]
            RequestedCodeUnavailable = 7,
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultAcsCredentialOnSeamWarnings.WarningCodeEnum WarningCode { get; set; }

        /// <summary>
        /// The PIN code that was assigned instead.
        /// </summary>
        [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
        public string? NewCode { get; set; }

        /// <summary>
        /// The originally requested PIN code that could not be used.
        /// </summary>
        [DataMember(Name = "original_code", IsRequired = false, EmitDefaultValue = false)]
        public string? OriginalCode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        /// <summary>
        /// Indicates a warning related to scanning a credential.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "acs_credential_on_encoder_out_of_sync")]
            AcsCredentialOnEncoderOutOfSync = 1,

            [EnumMember(Value = "acs_credential_on_seam_not_found")]
            AcsCredentialOnSeamNotFound = 2,
        }

        /// <summary>
        /// Indicates a warning related to scanning a credential.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanCredentialResultWarnings.WarningCodeEnum WarningCode { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "warning_message", IsRequired = false, EmitDefaultValue = false)]
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

    /// <summary>
    /// Encoding credential data from the physical encoder onto a card is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptEncodeCredential_model")]
    public class ActionAttemptEncodeCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredential() { }

        public ActionAttemptEncodeCredential(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptEncodeCredentialError error = default,
            ActionAttemptEncodeCredentialResult result = default,
            ActionAttemptEncodeCredential.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ENCODE_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialError Error { get; set; }

        /// <summary>
        /// Result of an encoding attempt. If the attempt was successful, includes the credential data that was encoded onto the card.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialError_model")]
    public class ActionAttemptEncodeCredentialError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialError() { }

        public ActionAttemptEncodeCredentialError(
            string message = default,
            ActionAttemptEncodeCredentialError.TypeEnum type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Error type to indicate that the credential was deleted and can no longer be encoded.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "uncategorized_error")]
            UncategorizedError = 1,

            [EnumMember(Value = "action_attempt_expired")]
            ActionAttemptExpired = 2,

            [EnumMember(Value = "no_credential_on_encoder")]
            NoCredentialOnEncoder = 3,

            [EnumMember(Value = "incompatible_card_format")]
            IncompatibleCardFormat = 4,

            [EnumMember(Value = "credential_cannot_be_reissued")]
            CredentialCannotBeReissued = 5,

            [EnumMember(Value = "encoder_not_online")]
            EncoderNotOnline = 6,

            [EnumMember(Value = "encoder_communication_timeout")]
            EncoderCommunicationTimeout = 7,

            [EnumMember(Value = "bridge_disconnected")]
            BridgeDisconnected = 8,

            [EnumMember(Value = "encoding_interrupted")]
            EncodingInterrupted = 9,

            [EnumMember(Value = "credential_deleted")]
            CredentialDeleted = 10,
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Error type to indicate that the credential was deleted and can no longer be encoded.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialError.TypeEnum Type { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialResult_model")]
    public class ActionAttemptEncodeCredentialResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResult() { }

        public ActionAttemptEncodeCredentialResult(
            ActionAttemptEncodeCredentialResult.AccessMethodEnum accessMethod = default,
            string acsCredentialId = default,
            string? acsCredentialPoolId = default,
            string acsSystemId = default,
            string? acsUserId = default,
            ActionAttemptEncodeCredentialResultAkilesMetadata? akilesMetadata = default,
            ActionAttemptEncodeCredentialResultAssaAbloyVostioMetadata? assaAbloyVostioMetadata =
                default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<ActionAttemptEncodeCredentialResultErrors> errors = default,
            ActionAttemptEncodeCredentialResult.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            bool? isIssued = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isMultiPhoneSyncCredential = default,
            bool? isOneTimeUse = default,
            string? issuedAt = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            string? parentAcsCredentialId = default,
            string? startsAt = default,
            string? userIdentityId = default,
            ActionAttemptEncodeCredentialResultVisionlineMetadata? visionlineMetadata = default,
            List<ActionAttemptEncodeCredentialResultWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CardNumber = cardNumber;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsIssued = isIssued;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
            IsOneTimeUse = isOneTimeUse;
            IssuedAt = issuedAt;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            ParentAcsCredentialId = parentAcsCredentialId;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessMethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_card")]
            PtiCard = 1,

            [EnumMember(Value = "brivo_credential")]
            BrivoCredential = 2,

            [EnumMember(Value = "hid_credential")]
            HidCredential = 3,

            [EnumMember(Value = "visionline_card")]
            VisionlineCard = 4,

            [EnumMember(Value = "salto_ks_credential")]
            SaltoKsCredential = 5,

            [EnumMember(Value = "assa_abloy_vostio_key")]
            AssaAbloyVostioKey = 6,

            [EnumMember(Value = "salto_space_key")]
            SaltoSpaceKey = 7,

            [EnumMember(Value = "latch_access")]
            LatchAccess = 8,

            [EnumMember(Value = "dormakaba_ambiance_credential")]
            DormakabaAmbianceCredential = 9,

            [EnumMember(Value = "hotek_card")]
            HotekCard = 10,

            [EnumMember(Value = "salto_ks_tag")]
            SaltoKsTag = 11,

            [EnumMember(Value = "avigilon_alta_credential")]
            AvigilonAltaCredential = 12,

            [EnumMember(Value = "kisi_credential")]
            KisiCredential = 13,

            [EnumMember(Value = "akiles_credential")]
            AkilesCredential = 14,
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResult.AccessMethodEnum AccessMethod { get; set; }

        /// <summary>
        /// ID of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the credential pool to which the credential belongs.
        /// </summary>
        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// Akiles-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResultAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// Vostio-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public ActionAttemptEncodeCredentialResultAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Number of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        /// <summary>
        /// Access (PIN) code for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// ID of the [connected account](https://docs.seam.co/core-concepts/connected-accounts) to which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name that corresponds to the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptEncodeCredentialResultErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResult.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been encoded onto a card.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the latest state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is a [multi-phone sync credential](https://docs.seam.co/capability-guides/mobile-access/issuing-mobile-credentials-from-an-access-control-system#what-are-multi-phone-sync-credentials).
        /// </summary>
        [DataMember(
            Name = "is_multi_phone_sync_credential",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsMultiPhoneSyncCredential { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) can only be used once. If `true`, the code becomes invalid after the first use.
        /// </summary>
        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneTimeUse { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was encoded onto a card.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Date and time at which the state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was most recently synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        /// <summary>
        /// ID of the parent [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "parent_acs_credential_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ParentAcsCredentialId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// ID of the [user identity](https://docs.seam.co/api/user_identities) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResultVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptEncodeCredentialResultWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialResultAkilesMetadata_model")]
    public class ActionAttemptEncodeCredentialResultAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResultAkilesMetadata() { }

        public ActionAttemptEncodeCredentialResultAkilesMetadata(string? memberPinId = default)
        {
            MemberPinId = memberPinId;
        }

        /// <summary>
        /// ID of the Akiles member PIN.
        /// </summary>
        [DataMember(Name = "member_pin_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberPinId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptEncodeCredentialResultAssaAbloyVostioMetadata_model"
    )]
    public class ActionAttemptEncodeCredentialResultAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResultAssaAbloyVostioMetadata() { }

        public ActionAttemptEncodeCredentialResultAssaAbloyVostioMetadata(
            bool? autoJoin = default,
            List<string>? doorNames = default,
            string? endpointId = default,
            string? keyId = default,
            string? keyIssuingRequestId = default,
            List<string>? overrideGuestAcsEntranceIds = default
        )
        {
            AutoJoin = autoJoin;
            DoorNames = doorNames;
            EndpointId = endpointId;
            KeyId = keyId;
            KeyIssuingRequestId = keyIssuingRequestId;
            OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Names of the doors to which to grant access in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_names", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? DoorNames { get; set; }

        /// <summary>
        /// Endpoint ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Key ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        /// <summary>
        /// Key issuing request ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_issuing_request_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyIssuingRequestId { get; set; }

        /// <summary>
        /// IDs of the guest entrances to override in the Vostio access system.
        /// </summary>
        [DataMember(
            Name = "override_guest_acs_entrance_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? OverrideGuestAcsEntranceIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialResultErrors_model")]
    public class ActionAttemptEncodeCredentialResultErrors
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResultErrors() { }

        public ActionAttemptEncodeCredentialResultErrors(
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

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialResultVisionlineMetadata_model")]
    public class ActionAttemptEncodeCredentialResultVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResultVisionlineMetadata() { }

        public ActionAttemptEncodeCredentialResultVisionlineMetadata(
            bool? autoJoin = default,
            ActionAttemptEncodeCredentialResultVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType =
                default,
            string? cardId = default,
            List<string>? commonAcsEntranceIds = default,
            string? credentialId = default,
            List<string>? guestAcsEntranceIds = default,
            bool? isValid = default,
            List<string>? joinerAcsCredentialIds = default
        )
        {
            AutoJoin = autoJoin;
            CardFunctionType = cardFunctionType;
            CardId = cardId;
            CommonAcsEntranceIds = commonAcsEntranceIds;
            CredentialId = credentialId;
            GuestAcsEntranceIds = guestAcsEntranceIds;
            IsValid = isValid;
            JoinerAcsCredentialIds = joinerAcsCredentialIds;
        }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFunctionTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "guest")]
            Guest = 1,

            [EnumMember(Value = "staff")]
            Staff = 2,
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResultVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

        /// <summary>
        /// ID of the card in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        /// <summary>
        /// Common entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        /// <summary>
        /// ID of the credential in the Visionline access system.
        /// </summary>
        [DataMember(Name = "credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CredentialId { get; set; }

        /// <summary>
        /// Guest entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        /// <summary>
        /// Indicates whether the credential is valid.
        /// </summary>
        [DataMember(Name = "is_valid", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsValid { get; set; }

        /// <summary>
        /// IDs of the credentials to which you want to join.
        /// </summary>
        [DataMember(
            Name = "joiner_acs_credential_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? JoinerAcsCredentialIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptEncodeCredentialResultWarnings_model")]
    public class ActionAttemptEncodeCredentialResultWarnings
    {
        [JsonConstructorAttribute]
        protected ActionAttemptEncodeCredentialResultWarnings() { }

        public ActionAttemptEncodeCredentialResultWarnings(
            string createdAt = default,
            string message = default,
            ActionAttemptEncodeCredentialResultWarnings.WarningCodeEnum warningCode = default,
            string? newCode = default,
            string? originalCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
            NewCode = newCode;
            OriginalCode = originalCode;
        }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "waiting_to_be_issued")]
            WaitingToBeIssued = 1,

            [EnumMember(Value = "schedule_externally_modified")]
            ScheduleExternallyModified = 2,

            [EnumMember(Value = "schedule_modified")]
            ScheduleModified = 3,

            [EnumMember(Value = "being_deleted")]
            BeingDeleted = 4,

            [EnumMember(Value = "unknown_issue_with_acs_credential")]
            UnknownIssueWithAcsCredential = 5,

            [EnumMember(Value = "needs_to_be_reissued")]
            NeedsToBeReissued = 6,

            [EnumMember(Value = "requested_code_unavailable")]
            RequestedCodeUnavailable = 7,
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptEncodeCredentialResultWarnings.WarningCodeEnum WarningCode { get; set; }

        /// <summary>
        /// The PIN code that was assigned instead.
        /// </summary>
        [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
        public string? NewCode { get; set; }

        /// <summary>
        /// The originally requested PIN code that could not be used.
        /// </summary>
        [DataMember(Name = "original_code", IsRequired = false, EmitDefaultValue = false)]
        public string? OriginalCode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Scanning a physical card and assigning the credential is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredential_model")]
    public class ActionAttemptScanToAssignCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredential() { }

        public ActionAttemptScanToAssignCredential(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptScanToAssignCredentialError error = default,
            ActionAttemptScanToAssignCredentialResult result = default,
            ActionAttemptScanToAssignCredential.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SCAN_TO_ASSIGN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialError Error { get; set; }

        /// <summary>
        /// Result of a scan to assign attempt. If the attempt was successful, includes the credential data that was scanned and assigned.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredential.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredentialError_model")]
    public class ActionAttemptScanToAssignCredentialError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialError() { }

        public ActionAttemptScanToAssignCredentialError(
            string message = default,
            ActionAttemptScanToAssignCredentialError.TypeEnum type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Error type to indicate that there is no credential on the encoder.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "uncategorized_error")]
            UncategorizedError = 1,

            [EnumMember(Value = "action_attempt_expired")]
            ActionAttemptExpired = 2,

            [EnumMember(Value = "no_credential_on_encoder")]
            NoCredentialOnEncoder = 3,
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Error type to indicate that there is no credential on the encoder.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialError.TypeEnum Type { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredentialResult_model")]
    public class ActionAttemptScanToAssignCredentialResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResult() { }

        public ActionAttemptScanToAssignCredentialResult(
            ActionAttemptScanToAssignCredentialResult.AccessMethodEnum accessMethod = default,
            string acsCredentialId = default,
            string? acsCredentialPoolId = default,
            string acsSystemId = default,
            string? acsUserId = default,
            ActionAttemptScanToAssignCredentialResultAkilesMetadata? akilesMetadata = default,
            ActionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata? assaAbloyVostioMetadata =
                default,
            string? cardNumber = default,
            string? code = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? endsAt = default,
            List<ActionAttemptScanToAssignCredentialResultErrors> errors = default,
            ActionAttemptScanToAssignCredentialResult.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            bool? isIssued = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isMultiPhoneSyncCredential = default,
            bool? isOneTimeUse = default,
            string? issuedAt = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            string? parentAcsCredentialId = default,
            string? startsAt = default,
            string? userIdentityId = default,
            ActionAttemptScanToAssignCredentialResultVisionlineMetadata? visionlineMetadata =
                default,
            List<ActionAttemptScanToAssignCredentialResultWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethod = accessMethod;
            AcsCredentialId = acsCredentialId;
            AcsCredentialPoolId = acsCredentialPoolId;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            AkilesMetadata = akilesMetadata;
            AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
            CardNumber = cardNumber;
            Code = code;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EndsAt = endsAt;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsIssued = isIssued;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
            IsOneTimeUse = isOneTimeUse;
            IssuedAt = issuedAt;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            ParentAcsCredentialId = parentAcsCredentialId;
            StartsAt = startsAt;
            UserIdentityId = userIdentityId;
            VisionlineMetadata = visionlineMetadata;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessMethodEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_card")]
            PtiCard = 1,

            [EnumMember(Value = "brivo_credential")]
            BrivoCredential = 2,

            [EnumMember(Value = "hid_credential")]
            HidCredential = 3,

            [EnumMember(Value = "visionline_card")]
            VisionlineCard = 4,

            [EnumMember(Value = "salto_ks_credential")]
            SaltoKsCredential = 5,

            [EnumMember(Value = "assa_abloy_vostio_key")]
            AssaAbloyVostioKey = 6,

            [EnumMember(Value = "salto_space_key")]
            SaltoSpaceKey = 7,

            [EnumMember(Value = "latch_access")]
            LatchAccess = 8,

            [EnumMember(Value = "dormakaba_ambiance_credential")]
            DormakabaAmbianceCredential = 9,

            [EnumMember(Value = "hotek_card")]
            HotekCard = 10,

            [EnumMember(Value = "salto_ks_tag")]
            SaltoKsTag = 11,

            [EnumMember(Value = "avigilon_alta_credential")]
            AvigilonAltaCredential = 12,

            [EnumMember(Value = "kisi_credential")]
            KisiCredential = 13,

            [EnumMember(Value = "akiles_credential")]
            AkilesCredential = 14,
        }

        /// <summary>
        /// Access method for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials). Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResult.AccessMethodEnum AccessMethod { get; set; }

        /// <summary>
        /// ID of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsCredentialId { get; set; }

        /// <summary>
        /// ID of the credential pool to which the credential belongs.
        /// </summary>
        [DataMember(Name = "acs_credential_pool_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsCredentialPoolId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? AcsUserId { get; set; }

        /// <summary>
        /// Akiles-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "akiles_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResultAkilesMetadata? AkilesMetadata { get; set; }

        /// <summary>
        /// Vostio-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "assa_abloy_vostio_metadata",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public ActionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

        /// <summary>
        /// Number of the card associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "card_number", IsRequired = false, EmitDefaultValue = false)]
        public string? CardNumber { get; set; }

        /// <summary>
        /// Access (PIN) code for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// ID of the [connected account](https://docs.seam.co/core-concepts/connected-accounts) to which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name that corresponds to the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Errors associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptScanToAssignCredentialResultErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type. Supported values: `pti_card`, `brivo_credential`, `hid_credential`, `visionline_card`.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResult.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been encoded onto a card.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the latest state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) has been synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the credential.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) is a [multi-phone sync credential](https://docs.seam.co/capability-guides/mobile-access/issuing-mobile-credentials-from-an-access-control-system#what-are-multi-phone-sync-credentials).
        /// </summary>
        [DataMember(
            Name = "is_multi_phone_sync_credential",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsMultiPhoneSyncCredential { get; set; }

        /// <summary>
        /// Indicates whether the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) can only be used once. If `true`, the code becomes invalid after the first use.
        /// </summary>
        [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsOneTimeUse { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was encoded onto a card.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Date and time at which the state of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) was most recently synced from Seam to the provider.
        /// </summary>
        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        /// <summary>
        /// ID of the parent [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(
            Name = "parent_acs_credential_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ParentAcsCredentialId { get; set; }

        /// <summary>
        /// Date and time at which the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) validity starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        /// <summary>
        /// ID of the [user identity](https://docs.seam.co/api/user_identities) to whom the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) belongs.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Visionline-specific metadata for the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResultVisionlineMetadata? VisionlineMetadata { get; set; }

        /// <summary>
        /// Warnings associated with the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptScanToAssignCredentialResultWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredentialResultAkilesMetadata_model")]
    public class ActionAttemptScanToAssignCredentialResultAkilesMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResultAkilesMetadata() { }

        public ActionAttemptScanToAssignCredentialResultAkilesMetadata(
            string? memberPinId = default
        )
        {
            MemberPinId = memberPinId;
        }

        /// <summary>
        /// ID of the Akiles member PIN.
        /// </summary>
        [DataMember(Name = "member_pin_id", IsRequired = false, EmitDefaultValue = false)]
        public string? MemberPinId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
        Name = "seamModel_actionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata_model"
    )]
    public class ActionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata() { }

        public ActionAttemptScanToAssignCredentialResultAssaAbloyVostioMetadata(
            bool? autoJoin = default,
            List<string>? doorNames = default,
            string? endpointId = default,
            string? keyId = default,
            string? keyIssuingRequestId = default,
            List<string>? overrideGuestAcsEntranceIds = default
        )
        {
            AutoJoin = autoJoin;
            DoorNames = doorNames;
            EndpointId = endpointId;
            KeyId = keyId;
            KeyIssuingRequestId = keyIssuingRequestId;
            OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Names of the doors to which to grant access in the Vostio access system.
        /// </summary>
        [DataMember(Name = "door_names", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? DoorNames { get; set; }

        /// <summary>
        /// Endpoint ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "endpoint_id", IsRequired = false, EmitDefaultValue = false)]
        public string? EndpointId { get; set; }

        /// <summary>
        /// Key ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyId { get; set; }

        /// <summary>
        /// Key issuing request ID in the Vostio access system.
        /// </summary>
        [DataMember(Name = "key_issuing_request_id", IsRequired = false, EmitDefaultValue = false)]
        public string? KeyIssuingRequestId { get; set; }

        /// <summary>
        /// IDs of the guest entrances to override in the Vostio access system.
        /// </summary>
        [DataMember(
            Name = "override_guest_acs_entrance_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? OverrideGuestAcsEntranceIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredentialResultErrors_model")]
    public class ActionAttemptScanToAssignCredentialResultErrors
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResultErrors() { }

        public ActionAttemptScanToAssignCredentialResultErrors(
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

    [DataContract(
        Name = "seamModel_actionAttemptScanToAssignCredentialResultVisionlineMetadata_model"
    )]
    public class ActionAttemptScanToAssignCredentialResultVisionlineMetadata
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResultVisionlineMetadata() { }

        public ActionAttemptScanToAssignCredentialResultVisionlineMetadata(
            bool? autoJoin = default,
            ActionAttemptScanToAssignCredentialResultVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType =
                default,
            string? cardId = default,
            List<string>? commonAcsEntranceIds = default,
            string? credentialId = default,
            List<string>? guestAcsEntranceIds = default,
            bool? isValid = default,
            List<string>? joinerAcsCredentialIds = default
        )
        {
            AutoJoin = autoJoin;
            CardFunctionType = cardFunctionType;
            CardId = cardId;
            CommonAcsEntranceIds = commonAcsEntranceIds;
            CredentialId = credentialId;
            GuestAcsEntranceIds = guestAcsEntranceIds;
            IsValid = isValid;
            JoinerAcsCredentialIds = joinerAcsCredentialIds;
        }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum CardFunctionTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "guest")]
            Guest = 1,

            [EnumMember(Value = "staff")]
            Staff = 2,
        }

        /// <summary>
        /// Indicates whether the credential should auto-join. For an auto-join credential, Seam automatically issues an override card if there are no other cards and a joiner card if there are existing cards on the doors.
        /// </summary>
        [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
        public bool? AutoJoin { get; set; }

        /// <summary>
        /// Card function type in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResultVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

        /// <summary>
        /// ID of the card in the Visionline access system.
        /// </summary>
        [DataMember(Name = "card_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CardId { get; set; }

        /// <summary>
        /// Common entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "common_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? CommonAcsEntranceIds { get; set; }

        /// <summary>
        /// ID of the credential in the Visionline access system.
        /// </summary>
        [DataMember(Name = "credential_id", IsRequired = false, EmitDefaultValue = false)]
        public string? CredentialId { get; set; }

        /// <summary>
        /// Guest entrance IDs in the Visionline access system.
        /// </summary>
        [DataMember(Name = "guest_acs_entrance_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string>? GuestAcsEntranceIds { get; set; }

        /// <summary>
        /// Indicates whether the credential is valid.
        /// </summary>
        [DataMember(Name = "is_valid", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsValid { get; set; }

        /// <summary>
        /// IDs of the credentials to which you want to join.
        /// </summary>
        [DataMember(
            Name = "joiner_acs_credential_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string>? JoinerAcsCredentialIds { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptScanToAssignCredentialResultWarnings_model")]
    public class ActionAttemptScanToAssignCredentialResultWarnings
    {
        [JsonConstructorAttribute]
        protected ActionAttemptScanToAssignCredentialResultWarnings() { }

        public ActionAttemptScanToAssignCredentialResultWarnings(
            string createdAt = default,
            string message = default,
            ActionAttemptScanToAssignCredentialResultWarnings.WarningCodeEnum warningCode = default,
            string? newCode = default,
            string? originalCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
            NewCode = newCode;
            OriginalCode = originalCode;
        }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "waiting_to_be_issued")]
            WaitingToBeIssued = 1,

            [EnumMember(Value = "schedule_externally_modified")]
            ScheduleExternallyModified = 2,

            [EnumMember(Value = "schedule_modified")]
            ScheduleModified = 3,

            [EnumMember(Value = "being_deleted")]
            BeingDeleted = 4,

            [EnumMember(Value = "unknown_issue_with_acs_credential")]
            UnknownIssueWithAcsCredential = 5,

            [EnumMember(Value = "needs_to_be_reissued")]
            NeedsToBeReissued = 6,

            [EnumMember(Value = "requested_code_unavailable")]
            RequestedCodeUnavailable = 7,
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptScanToAssignCredentialResultWarnings.WarningCodeEnum WarningCode { get; set; }

        /// <summary>
        /// The PIN code that was assigned instead.
        /// </summary>
        [DataMember(Name = "new_code", IsRequired = false, EmitDefaultValue = false)]
        public string? NewCode { get; set; }

        /// <summary>
        /// The originally requested PIN code that could not be used.
        /// </summary>
        [DataMember(Name = "original_code", IsRequired = false, EmitDefaultValue = false)]
        public string? OriginalCode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Assigning a credential to an access method is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptAssignCredential_model")]
    public class ActionAttemptAssignCredential : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredential() { }

        public ActionAttemptAssignCredential(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptAssignCredentialError error = default,
            ActionAttemptAssignCredentialResult result = default,
            ActionAttemptAssignCredential.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ASSIGN_CREDENTIAL";

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialError Error { get; set; }

        /// <summary>
        /// Result of assigning a credential. If successful, includes the updated access method with the assigned credential.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredential.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialError_model")]
    public class ActionAttemptAssignCredentialError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialError() { }

        public ActionAttemptAssignCredentialError(
            string message = default,
            ActionAttemptAssignCredentialError.TypeEnum type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Error type to indicate that no matching credential was found.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum TypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "uncategorized_error")]
            UncategorizedError = 1,

            [EnumMember(Value = "action_attempt_expired")]
            ActionAttemptExpired = 2,

            [EnumMember(Value = "credential_not_found")]
            CredentialNotFound = 3,
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Error type to indicate that no matching credential was found.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialError.TypeEnum Type { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResult_model")]
    public class ActionAttemptAssignCredentialResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResult() { }

        public ActionAttemptAssignCredentialResult(
            string accessMethodId = default,
            string? clientSessionToken = default,
            string? code = default,
            string createdAt = default,
            string? customizationProfileId = default,
            string displayName = default,
            string displayStatus = default,
            List<ActionAttemptAssignCredentialResultErrors> errors = default,
            string? instantKeyUrl = default,
            bool? isAssignmentRequired = default,
            bool? isEncodingRequired = default,
            bool isIssued = default,
            bool? isReadyForAssignment = default,
            bool? isReadyForEncoding = default,
            string? issuedAt = default,
            ActionAttemptAssignCredentialResult.ModeEnum mode = default,
            List<ActionAttemptAssignCredentialResultPendingMutations> pendingMutations = default,
            List<ActionAttemptAssignCredentialResultWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessMethodId = accessMethodId;
            ClientSessionToken = clientSessionToken;
            Code = code;
            CreatedAt = createdAt;
            CustomizationProfileId = customizationProfileId;
            DisplayName = displayName;
            DisplayStatus = displayStatus;
            Errors = errors;
            InstantKeyUrl = instantKeyUrl;
            IsAssignmentRequired = isAssignmentRequired;
            IsEncodingRequired = isEncodingRequired;
            IsIssued = isIssued;
            IsReadyForAssignment = isReadyForAssignment;
            IsReadyForEncoding = isReadyForEncoding;
            IssuedAt = issuedAt;
            Mode = mode;
            PendingMutations = pendingMutations;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ModeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "code")]
            Code = 1,

            [EnumMember(Value = "card")]
            Card = 2,

            [EnumMember(Value = "mobile_key")]
            MobileKey = 3,

            [EnumMember(Value = "cloud_key")]
            CloudKey = 4,
        }

        /// <summary>
        /// ID of the access method.
        /// </summary>
        [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
        public string AccessMethodId { get; set; }

        /// <summary>
        /// Token of the client session associated with the access method.
        /// </summary>
        [DataMember(Name = "client_session_token", IsRequired = false, EmitDefaultValue = false)]
        public string? ClientSessionToken { get; set; }

        /// <summary>
        /// The actual PIN code for code access methods.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
        public string? Code { get; set; }

        /// <summary>
        /// Date and time at which the access method was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ID of the customization profile associated with the access method.
        /// </summary>
        [DataMember(
            Name = "customization_profile_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? CustomizationProfileId { get; set; }

        /// <summary>
        /// Display name of the access method.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Human-readable sentence describing where the access method sits in its relationship with the device or access system, for example `Awaiting encoding`. For display only. The wording is not stable and is not an enumeration — it may change at any time, so never compare against or branch on it. To make decisions, read `is_issued`, `errors`, and `pending_mutations`.
        /// </summary>
        [DataMember(Name = "display_status", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayStatus { get; set; }

        /// <summary>
        /// Errors associated with the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptAssignCredentialResultErrors> Errors { get; set; }

        /// <summary>
        /// URL of the Instant Key for mobile key access methods.
        /// </summary>
        [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
        public string? InstantKeyUrl { get; set; }

        /// <summary>
        /// Indicates whether an existing card credential must be assigned to this access method before it can be issued. Only applies to card-mode access methods on systems that support credential assignment.
        /// </summary>
        [DataMember(Name = "is_assignment_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsAssignmentRequired { get; set; }

        /// <summary>
        /// Indicates whether encoding with an card encoder is required to issue or reissue the plastic card associated with the access method.
        /// </summary>
        [DataMember(Name = "is_encoding_required", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsEncodingRequired { get; set; }

        /// <summary>
        /// Indicates whether the access method has been issued.
        /// </summary>
        [DataMember(Name = "is_issued", IsRequired = false, EmitDefaultValue = false)]
        public bool IsIssued { get; set; }

        /// <summary>
        /// Indicates whether the access method is ready for card assignment. This is true when the access method is in card mode, has not yet been issued, and the system supports credential assignment.
        /// </summary>
        [DataMember(Name = "is_ready_for_assignment", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForAssignment { get; set; }

        /// <summary>
        /// Indicates whether the access method is ready to be encoded. This is true when the credential has been created and the card has not yet been issued.
        /// </summary>
        [DataMember(Name = "is_ready_for_encoding", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsReadyForEncoding { get; set; }

        /// <summary>
        /// Date and time at which the access method was issued.
        /// </summary>
        [DataMember(Name = "issued_at", IsRequired = false, EmitDefaultValue = false)]
        public string? IssuedAt { get; set; }

        /// <summary>
        /// Access method mode. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
        /// </summary>
        [DataMember(Name = "mode", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResult.ModeEnum Mode { get; set; }

        /// <summary>
        /// Pending mutations for the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant). Indicates operations that are in progress.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptAssignCredentialResultPendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Warnings associated with the [access method](https://docs.seam.co/use-cases/granting-access/creating-an-access-grant).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<ActionAttemptAssignCredentialResultWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the Seam workspace associated with the access method.
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResultErrors_model")]
    public class ActionAttemptAssignCredentialResultErrors
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResultErrors() { }

        public ActionAttemptAssignCredentialResultErrors(
            string createdAt = default,
            ActionAttemptAssignCredentialResultErrors.ErrorCodeEnum errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "failed_to_issue")]
            FailedToIssue = 1,
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
        public ActionAttemptAssignCredentialResultErrors.ErrorCodeEnum ErrorCode { get; set; }

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

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResultPendingMutations_model")]
    public class ActionAttemptAssignCredentialResultPendingMutations
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResultPendingMutations() { }

        public ActionAttemptAssignCredentialResultPendingMutations(
            string createdAt = default,
            ActionAttemptAssignCredentialResultPendingMutationsFrom from = default,
            string message = default,
            ActionAttemptAssignCredentialResultPendingMutations.MutationCodeEnum mutationCode =
                default,
            ActionAttemptAssignCredentialResultPendingMutationsTo to = default
        )
        {
            CreatedAt = createdAt;
            From = from;
            Message = message;
            MutationCode = mutationCode;
            To = to;
        }

        /// <summary>
        /// Mutation code to indicate that Seam is in the process of updating the access times for this access method.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum MutationCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "provisioning_access")]
            ProvisioningAccess = 1,

            [EnumMember(Value = "revoking_access")]
            RevokingAccess = 2,

            [EnumMember(Value = "updating_access_times")]
            UpdatingAccessTimes = 3,
        }

        /// <summary>
        /// Date and time at which the mutation was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Previous access time configuration.
        /// </summary>
        [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResultPendingMutationsFrom From { get; set; }

        /// <summary>
        /// Detailed description of the mutation.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Mutation code to indicate that Seam is in the process of updating the access times for this access method.
        /// </summary>
        [DataMember(Name = "mutation_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResultPendingMutations.MutationCodeEnum MutationCode { get; set; }

        /// <summary>
        /// New access time configuration.
        /// </summary>
        [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResultPendingMutationsTo To { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResultPendingMutationsFrom_model")]
    public class ActionAttemptAssignCredentialResultPendingMutationsFrom
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResultPendingMutationsFrom() { }

        public ActionAttemptAssignCredentialResultPendingMutationsFrom(
            string? endsAt = default,
            string? startsAt = default
        )
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        /// <summary>
        /// Previous end time for access.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Previous start time for access.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResultPendingMutationsTo_model")]
    public class ActionAttemptAssignCredentialResultPendingMutationsTo
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResultPendingMutationsTo() { }

        public ActionAttemptAssignCredentialResultPendingMutationsTo(
            string? endsAt = default,
            string? startsAt = default
        )
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        /// <summary>
        /// New end time for access.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// New start time for access.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
        public string? StartsAt { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptAssignCredentialResultWarnings_model")]
    public class ActionAttemptAssignCredentialResultWarnings
    {
        [JsonConstructorAttribute]
        protected ActionAttemptAssignCredentialResultWarnings() { }

        public ActionAttemptAssignCredentialResultWarnings(
            string createdAt = default,
            string message = default,
            ActionAttemptAssignCredentialResultWarnings.WarningCodeEnum warningCode = default,
            string? originalAccessMethodId = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
            OriginalAccessMethodId = originalAccessMethodId;
        }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "being_deleted")]
            BeingDeleted = 1,

            [EnumMember(Value = "updating_access_times")]
            UpdatingAccessTimes = 2,

            [EnumMember(Value = "pulled_backup_access_code")]
            PulledBackupAccessCode = 3,

            [EnumMember(Value = "delay_in_issuing")]
            DelayInIssuing = 4,
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptAssignCredentialResultWarnings.WarningCodeEnum WarningCode { get; set; }

        /// <summary>
        /// ID of the original access method from which this backup access method was split, if applicable.
        /// </summary>
        [DataMember(
            Name = "original_access_method_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? OriginalAccessMethodId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Resetting a sandbox workspace is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptResetSandboxWorkspace_model")]
    public class ActionAttemptResetSandboxWorkspace : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptResetSandboxWorkspace() { }

        public ActionAttemptResetSandboxWorkspace(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptResetSandboxWorkspaceError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "RESET_SANDBOX_WORKSPACE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptResetSandboxWorkspaceError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptResetSandboxWorkspaceResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    /// <summary>
    /// Setting the fan mode is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptSetFanMode_model")]
    public class ActionAttemptSetFanMode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetFanMode() { }

        public ActionAttemptSetFanMode(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptSetFanModeError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_FAN_MODE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSetFanModeError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSetFanModeResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    /// <summary>
    /// Setting the HVAC mode is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptSetHvacMode_model")]
    public class ActionAttemptSetHvacMode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHvacMode() { }

        public ActionAttemptSetHvacMode(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptSetHvacModeError error = default,
            ActionAttemptSetHvacModeResult result = default,
            ActionAttemptSetHvacMode.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SET_HVAC_MODE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSetHvacModeError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSetHvacModeResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSetHvacMode.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptSetHvacModeError_model")]
    public class ActionAttemptSetHvacModeError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSetHvacModeError() { }

        public ActionAttemptSetHvacModeError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptSetHvacModeResult_model")]
    public class ActionAttemptSetHvacModeResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSetHvacModeResult() { }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Activating a climate preset is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptActivateClimatePreset_model")]
    public class ActionAttemptActivateClimatePreset : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptActivateClimatePreset() { }

        public ActionAttemptActivateClimatePreset(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptActivateClimatePresetError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "ACTIVATE_CLIMATE_PRESET";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptActivateClimatePresetError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptActivateClimatePresetResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    /// <summary>
    /// Simulating a keypad code entry is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptSimulateKeypadCodeEntry_model")]
    public class ActionAttemptSimulateKeypadCodeEntry : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSimulateKeypadCodeEntry() { }

        public ActionAttemptSimulateKeypadCodeEntry(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptSimulateKeypadCodeEntryError error = default,
            ActionAttemptSimulateKeypadCodeEntryResult result = default,
            ActionAttemptSimulateKeypadCodeEntry.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SIMULATE_KEYPAD_CODE_ENTRY";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateKeypadCodeEntryError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateKeypadCodeEntryResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateKeypadCodeEntry.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptSimulateKeypadCodeEntryError_model")]
    public class ActionAttemptSimulateKeypadCodeEntryError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSimulateKeypadCodeEntryError() { }

        public ActionAttemptSimulateKeypadCodeEntryError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptSimulateKeypadCodeEntryResult_model")]
    public class ActionAttemptSimulateKeypadCodeEntryResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSimulateKeypadCodeEntryResult() { }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Simulating a manual lock action using a keypad is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptSimulateManualLockViaKeypad_model")]
    public class ActionAttemptSimulateManualLockViaKeypad : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSimulateManualLockViaKeypad() { }

        public ActionAttemptSimulateManualLockViaKeypad(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptSimulateManualLockViaKeypadError error = default,
            ActionAttemptSimulateManualLockViaKeypadResult result = default,
            ActionAttemptSimulateManualLockViaKeypad.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SIMULATE_MANUAL_LOCK_VIA_KEYPAD";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateManualLockViaKeypadError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateManualLockViaKeypadResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSimulateManualLockViaKeypad.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptSimulateManualLockViaKeypadError_model")]
    public class ActionAttemptSimulateManualLockViaKeypadError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSimulateManualLockViaKeypadError() { }

        public ActionAttemptSimulateManualLockViaKeypadError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptSimulateManualLockViaKeypadResult_model")]
    public class ActionAttemptSimulateManualLockViaKeypadResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptSimulateManualLockViaKeypadResult() { }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Pushing thermostat weekly programs is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptPushThermostatPrograms_model")]
    public class ActionAttemptPushThermostatPrograms : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptPushThermostatPrograms() { }

        public ActionAttemptPushThermostatPrograms(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptPushThermostatProgramsError error = default,
            ActionAttemptPushThermostatProgramsResult result = default,
            ActionAttemptPushThermostatPrograms.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "PUSH_THERMOSTAT_PROGRAMS";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptPushThermostatProgramsError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptPushThermostatProgramsResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptPushThermostatPrograms.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptPushThermostatProgramsError_model")]
    public class ActionAttemptPushThermostatProgramsError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptPushThermostatProgramsError() { }

        public ActionAttemptPushThermostatProgramsError(
            string message = default,
            string type = default
        )
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptPushThermostatProgramsResult_model")]
    public class ActionAttemptPushThermostatProgramsResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptPushThermostatProgramsResult() { }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
    /// Configuring the auto-lock is pending.
    /// </summary>
    [DataContract(Name = "seamModel_actionAttemptConfigureAutoLock_model")]
    public class ActionAttemptConfigureAutoLock : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptConfigureAutoLock() { }

        public ActionAttemptConfigureAutoLock(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptConfigureAutoLockError error = default,
            ActionAttemptConfigureAutoLockResult result = default,
            ActionAttemptConfigureAutoLock.StatusEnum status = default
        )
        {
            ActionAttemptId = actionAttemptId;
            ActionType = actionType;
            Error = error;
            Result = result;
            Status = status;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CONFIGURE_AUTO_LOCK";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptConfigureAutoLockError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptConfigureAutoLockResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptConfigureAutoLock.StatusEnum Status { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptConfigureAutoLockError_model")]
    public class ActionAttemptConfigureAutoLockError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptConfigureAutoLockError() { }

        public ActionAttemptConfigureAutoLockError(string message = default, string type = default)
        {
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptConfigureAutoLockResult_model")]
    public class ActionAttemptConfigureAutoLockResult
    {
        [JsonConstructorAttribute]
        public ActionAttemptConfigureAutoLockResult() { }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "SYNC_ACCESS_CODES";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSyncAccessCodesError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptSyncAccessCodesResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCode_model")]
    public class ActionAttemptCreateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCode() { }

        public ActionAttemptCreateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptCreateAccessCodeError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_ACCESS_CODE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptCreateAccessCodeError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptCreateAccessCodeResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptCreateAccessCodeResult_model")]
    public class ActionAttemptCreateAccessCodeResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateAccessCodeResult() { }

        public ActionAttemptCreateAccessCodeResult(object accessCode = default)
        {
            AccessCode = accessCode;
        }

        /// <summary>
        /// Created access code.
        /// </summary>
        [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
        public object AccessCode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_ACCESS_CODE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptDeleteAccessCodeError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptDeleteAccessCodeResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCode_model")]
    public class ActionAttemptUpdateAccessCode : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCode() { }

        public ActionAttemptUpdateAccessCode(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptUpdateAccessCodeError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_ACCESS_CODE";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUpdateAccessCodeError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUpdateAccessCodeResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptUpdateAccessCodeResult_model")]
    public class ActionAttemptUpdateAccessCodeResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateAccessCodeResult() { }

        public ActionAttemptUpdateAccessCodeResult(object? accessCode = default)
        {
            AccessCode = accessCode;
        }

        /// <summary>
        /// Updated access code.
        /// </summary>
        [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
        public object? AccessCode { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "CREATE_NOISE_THRESHOLD";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptCreateNoiseThresholdError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptCreateNoiseThresholdResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptCreateNoiseThresholdResult_model")]
    public class ActionAttemptCreateNoiseThresholdResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptCreateNoiseThresholdResult() { }

        public ActionAttemptCreateNoiseThresholdResult(object noiseThreshold = default)
        {
            NoiseThreshold = noiseThreshold;
        }

        /// <summary>
        /// Created noise threshold.
        /// </summary>
        [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
        public object NoiseThreshold { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "DELETE_NOISE_THRESHOLD";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptDeleteNoiseThresholdError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptDeleteNoiseThresholdResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThreshold_model")]
    public class ActionAttemptUpdateNoiseThreshold : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThreshold() { }

        public ActionAttemptUpdateNoiseThreshold(
            string actionAttemptId = default,
            string actionType = default,
            ActionAttemptUpdateNoiseThresholdError error = default,
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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "success")]
            Success = 1,

            [EnumMember(Value = "pending")]
            Pending = 2,

            [EnumMember(Value = "error")]
            Error = 3,
        }

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "UPDATE_NOISE_THRESHOLD";

        /// <summary>
        /// Error associated with the action.
        /// </summary>
        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUpdateNoiseThresholdError Error { get; set; }

        /// <summary>
        /// Result of the action.
        /// </summary>
        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public ActionAttemptUpdateNoiseThresholdResult Result { get; set; }

        [DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the error.
        /// </summary>
        [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_actionAttemptUpdateNoiseThresholdResult_model")]
    public class ActionAttemptUpdateNoiseThresholdResult
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUpdateNoiseThresholdResult() { }

        public ActionAttemptUpdateNoiseThresholdResult(object noiseThreshold = default)
        {
            NoiseThreshold = noiseThreshold;
        }

        /// <summary>
        /// Updated noise threshold.
        /// </summary>
        [DataMember(Name = "noise_threshold", IsRequired = false, EmitDefaultValue = false)]
        public object NoiseThreshold { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
            {
                jsonTextWriter.IndentChar = ' ';
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonTextWriter, this, null);
            }

            return stringWriter.ToString();
        }
    }

    [DataContract(Name = "seamModel_actionAttemptUnrecognized_model")]
    public class ActionAttemptUnrecognized : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptUnrecognized() { }

        public ActionAttemptUnrecognized(
            string actionType = default,
            string actionAttemptId = default
        )
        {
            ActionType = actionType;
            ActionAttemptId = actionAttemptId;
        }

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public override string ActionType { get; } = "unrecognized";

        /// <summary>
        /// ID of the action attempt.
        /// </summary>
        [DataMember(Name = "action_attempt_id", IsRequired = false, EmitDefaultValue = false)]
        public override string ActionAttemptId { get; set; }

        public override string ToString()
        {
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            StringWriter stringWriter = new StringWriter(
                new StringBuilder(256),
                System.Globalization.CultureInfo.InvariantCulture
            );
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
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
