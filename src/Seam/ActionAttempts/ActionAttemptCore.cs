using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Seam.Models
{
    /// <summary>
    /// The status of an action attempt.
    /// </summary>
    /// <remarks>
    /// Declared by the runtime rather than generated: every action attempt shares this wire
    /// shape, and the action attempt resolver depends on it.
    /// </remarks>
    [JsonConverter(typeof(SeamStringEnumConverter))]
    public enum ActionAttemptStatus
    {
        [EnumMember(Value = "unrecognized")]
        Unrecognized = 0,

        [EnumMember(Value = "pending")]
        Pending = 1,

        [EnumMember(Value = "success")]
        Success = 2,

        [EnumMember(Value = "error")]
        Error = 3,
    }

    /// <summary>
    /// The error of a failed action attempt.
    /// </summary>
    public sealed record ActionAttemptError
    {
        [JsonPropertyName("type")]
        public string? Type { get; init; }

        [JsonPropertyName("message")]
        public string? Message { get; init; }
    }
}
