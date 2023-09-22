using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Seam.Model
{
    [DataContract(Name = "coSeamModel_event_model")]
    public class Event
    {
        [JsonConstructorAttribute]
        protected Event() { }

        public Event(
            string eventId = default,
            string? deviceId = default,
            string eventType = default,
            string workspaceId = default,
            string createdAt = default,
            string occurredAt = default
        )
        {
            EventId = eventId;
            DeviceId = deviceId;
            EventType = eventType;
            WorkspaceId = workspaceId;
            CreatedAt = createdAt;
            OccurredAt = occurredAt;
        }

        [DataMember(Name = "event_id", IsRequired = true, EmitDefaultValue = false)]
        public string EventId { get; set; }

        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string? DeviceId { get; set; }

        [DataMember(Name = "event_type", IsRequired = true, EmitDefaultValue = false)]
        public string EventType { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "occurred_at", IsRequired = true, EmitDefaultValue = false)]
        public string OccurredAt { get; set; }
    }
}
