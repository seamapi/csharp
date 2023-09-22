using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [JsonConverter(typeof(JsonSubtypes), "Status")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptError), "error")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptPending), "pending")]
    [JsonSubtypes.KnownSubType(typeof(ActionAttemptSuccess), "success")]
    public abstract class ActionAttempt
    {
        public abstract string Status { get; }
    }

    [DataContract(Name = "seamModel_actionAttemptSuccess_model")]
    public class ActionAttemptSuccess : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptSuccess() { }

        public ActionAttemptSuccess(
            string status = default,
            string actionType = default,
            string actionAttemptId = default,
            Object result = default,
            string? error = default
        )
        {
            Status = status;
            ActionType = actionType;
            ActionAttemptId = actionAttemptId;
            Result = result;
            Error = error;
        }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public override string Status { get; } = "success";

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public Object Result { get; set; }

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public string? Error { get; set; }
    }

    [DataContract(Name = "seamModel_actionAttemptPending_model")]
    public class ActionAttemptPending : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptPending() { }

        public ActionAttemptPending(
            string status = default,
            string actionType = default,
            string actionAttemptId = default,
            string? result = default,
            string? error = default
        )
        {
            Status = status;
            ActionType = actionType;
            ActionAttemptId = actionAttemptId;
            Result = result;
            Error = error;
        }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public override string Status { get; } = "pending";

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public string? Result { get; set; }

        [DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false)]
        public string? Error { get; set; }
    }

    [DataContract(Name = "seamModel_actionAttemptError_model")]
    public class ActionAttemptError : ActionAttempt
    {
        [JsonConstructorAttribute]
        protected ActionAttemptError() { }

        public ActionAttemptError(
            string status = default,
            string actionType = default,
            string actionAttemptId = default,
            string? result = default,
            ActionAttemptErrorError error = default
        )
        {
            Status = status;
            ActionType = actionType;
            ActionAttemptId = actionAttemptId;
            Result = result;
            Error = error;
        }

        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public override string Status { get; } = "error";

        [DataMember(Name = "action_type", IsRequired = true, EmitDefaultValue = false)]
        public string ActionType { get; set; }

        [DataMember(Name = "action_attempt_id", IsRequired = true, EmitDefaultValue = false)]
        public string ActionAttemptId { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public string? Result { get; set; }

        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public ActionAttemptErrorError Error { get; set; }
    }

    [DataContract(Name = "seamModel_actionAttemptErrorError_model")]
    public class ActionAttemptErrorError
    {
        [JsonConstructorAttribute]
        protected ActionAttemptErrorError() { }

        public ActionAttemptErrorError(string type = default, string message = default)
        {
            Type = type;
            Message = message;
        }

        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }
    }
}
