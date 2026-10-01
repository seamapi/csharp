using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a short-lived live view session for a single camera. Use the session ID and token to start a WebRTC stream and to stop the session.
    /// </summary>
    [DataContract(Name = "seamModel_cameraLiveViewSession_model")]
    public class CameraLiveViewSession
    {
        [JsonConstructorAttribute]
        protected CameraLiveViewSession() { }

        public CameraLiveViewSession(
            string cameraLiveViewSessionId = default,
            string deviceId = default,
            string expiresAt = default,
            string token = default
        )
        {
            CameraLiveViewSessionId = cameraLiveViewSessionId;
            DeviceId = deviceId;
            ExpiresAt = expiresAt;
            Token = token;
        }

        /// <summary>
        /// ID of the camera live view session.
        /// </summary>
        [DataMember(
            Name = "camera_live_view_session_id",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string CameraLiveViewSessionId { get; set; }

        /// <summary>
        /// ID of the camera.
        /// </summary>
        [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Date and time at which the live view session expires.
        /// </summary>
        [DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Token that authorizes the offer and stop requests for this session.
        /// </summary>
        [DataMember(Name = "token", IsRequired = false, EmitDefaultValue = false)]
        public string Token { get; set; }

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
