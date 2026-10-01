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
/// Represents a piece of media, such as a video clip or a thumbnail image, that a device captured for an event. Media is in beta.
/// </summary>
[DataContract(Name = "seamModel_media_model")]
public class Media
{
[JsonConstructorAttribute]
protected Media() { }

public Media(string? contentType = default, string createdAt = default, string? deviceId = default, string? eventId = default, string? expiresAt = default, string mediaId = default, Media.MediaTypeEnum mediaType = default, Media.StatusEnum status = default, string? url = default, Media.VideoCodecEnum? videoCodec = default, string workspaceId = default)
{
ContentType = contentType;
CreatedAt = createdAt;
DeviceId = deviceId;
EventId = eventId;
ExpiresAt = expiresAt;
MediaId = mediaId;
MediaType = mediaType;
Status = status;
Url = url;
VideoCodec = videoCodec;
WorkspaceId = workspaceId;
}

/// <summary>
/// Type of the media: a video clip or a still image.
/// </summary>
[JsonConverter(typeof(SafeStringEnumConverter))]
public enum MediaTypeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "video")]
Video = 1,

[EnumMember(Value = "image")]
Image = 2,
}

/// <summary>
/// Status of the media. `pending` means that Seam is still retrieving the media. `available` means that `url` can be used to download it. `unavailable` means that no media exists for the event, and `failed` means that Seam could not retrieve it.
/// </summary>
[JsonConverter(typeof(SafeStringEnumConverter))]
public enum StatusEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "pending")]
Pending = 1,

[EnumMember(Value = "available")]
Available = 2,

[EnumMember(Value = "unavailable")]
Unavailable = 3,

[EnumMember(Value = "failed")]
Failed = 4,
}

/// <summary>
/// Video codec used to encode the media. Only present for video media. `hevc` (H.265) playback support varies by browser and device, so check compatibility before assuming a clip plays inline.
/// </summary>
[JsonConverter(typeof(SafeStringEnumConverter))]
public enum VideoCodecEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "h264")]
H264 = 1,

[EnumMember(Value = "hevc")]
Hevc = 2,
}

/// <summary>
/// MIME type of the media, such as `video/mp4` or `image/jpeg`.
/// </summary>
[DataMember(Name = "content_type", IsRequired = false, EmitDefaultValue = false)]
public string? ContentType { get; set; }

/// <summary>
/// Date and time at which the media was created.
/// </summary>
[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string CreatedAt { get; set; }

/// <summary>
/// ID of the device that captured the media.
/// </summary>
[DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
public string? DeviceId { get; set; }

/// <summary>
/// ID of the event that the media belongs to.
/// </summary>
[DataMember(Name = "event_id", IsRequired = false, EmitDefaultValue = false)]
public string? EventId { get; set; }

/// <summary>
/// Date and time at which the media stops being available. Null when Seam does not know when the media expires.
/// </summary>
[DataMember(Name = "expires_at", IsRequired = false, EmitDefaultValue = false)]
public string? ExpiresAt { get; set; }

/// <summary>
/// ID of the media.
/// </summary>
[DataMember(Name = "media_id", IsRequired = false, EmitDefaultValue = false)]
public string MediaId { get; set; }

/// <summary>
/// Type of the media: a video clip or a still image.
/// </summary>
[DataMember(Name = "media_type", IsRequired = false, EmitDefaultValue = false)]
public Media.MediaTypeEnum MediaType { get; set; }

/// <summary>
/// Status of the media. `pending` means that Seam is still retrieving the media. `available` means that `url` can be used to download it. `unavailable` means that no media exists for the event, and `failed` means that Seam could not retrieve it.
/// </summary>
[DataMember(Name = "status", IsRequired = false, EmitDefaultValue = false)]
public Media.StatusEnum Status { get; set; }

/// <summary>
/// Short-lived URL from which you can download the media. Null unless `status` is `available`. The URL expires after about five minutes. Call `/media/get` again for a new URL.
/// </summary>
[DataMember(Name = "url", IsRequired = false, EmitDefaultValue = false)]
public string? Url { get; set; }

/// <summary>
/// Video codec used to encode the media. Only present for video media. `hevc` (H.265) playback support varies by browser and device, so check compatibility before assuming a clip plays inline.
/// </summary>
[DataMember(Name = "video_codec", IsRequired = false, EmitDefaultValue = false)]
public Media.VideoCodecEnum? VideoCodec { get; set; }

/// <summary>
/// ID of the workspace that contains the media.
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

}
