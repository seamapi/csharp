using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
public class LiveViewsCameras
{
private ISeamClient _seam;

public LiveViewsCameras(ISeamClient seam)
{
_seam = seam;
}

/// <summary>
/// Request parameters for Create a Camera Live View Session.
/// </summary>
[DataContract(Name = "createRequest_request")]
public class CreateRequest
{
[JsonConstructorAttribute]
protected CreateRequest() { }

public CreateRequest(string deviceId = default, int? durationSeconds = default, bool? includeAudio = default)
{
DeviceId = deviceId;
DurationSeconds = durationSeconds;
IncludeAudio = includeAudio;
}

/// <summary>
/// ID of the camera to view.
/// </summary>
[DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
public string DeviceId { get; set; }

/// <summary>
/// Number of seconds for which the live view session is valid, up to 600.
/// </summary>
[DataMember(Name = "duration_seconds", IsRequired = false, EmitDefaultValue = false)]
public int? DurationSeconds { get; set; }

/// <summary>
/// Indicates whether to include the camera&apos;s audio.
/// </summary>
[DataMember(Name = "include_audio", IsRequired = false, EmitDefaultValue = false)]
public bool? IncludeAudio { get; set; }

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

[DataContract(Name = "createResponse_response")]
public class CreateResponse
{
[JsonConstructorAttribute]
protected CreateResponse() { }

public CreateResponse(CameraLiveViewSession cameraLiveViewSession = default)
{
CameraLiveViewSession = cameraLiveViewSession;
}

/// <summary>
/// OK
/// </summary>
[DataMember(Name = "camera_live_view_session", IsRequired = false, EmitDefaultValue = false)]
public CameraLiveViewSession CameraLiveViewSession { get; set; }

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
/// Creates a short-lived live view session for a single camera. Pass the returned session ID and token to `/cameras/live_views/offer` to start a WebRTC stream, and to `/cameras/live_views/stop` to end the session.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support. To check whether a camera supports live view, use `device.can_stream_live_video`.
/// </summary>
public CameraLiveViewSession Create(CreateRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<CreateResponse>("/cameras/live_views/create", requestOptions).EnsureData("/cameras/live_views/create").CameraLiveViewSession;
}

/// <summary>
/// Creates a short-lived live view session for a single camera. Pass the returned session ID and token to `/cameras/live_views/offer` to start a WebRTC stream, and to `/cameras/live_views/stop` to end the session.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support. To check whether a camera supports live view, use `device.can_stream_live_video`.
/// </summary>
public CameraLiveViewSession Create(string deviceId = default, int? durationSeconds = default, bool? includeAudio = default)
{
return Create(new CreateRequest(deviceId: deviceId, durationSeconds: durationSeconds, includeAudio: includeAudio));
}

/// <summary>
/// Creates a short-lived live view session for a single camera. Pass the returned session ID and token to `/cameras/live_views/offer` to start a WebRTC stream, and to `/cameras/live_views/stop` to end the session.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support. To check whether a camera supports live view, use `device.can_stream_live_video`.
/// </summary>
public async Task<CameraLiveViewSession> CreateAsync(CreateRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<CreateResponse>("/cameras/live_views/create", requestOptions)).EnsureData("/cameras/live_views/create").CameraLiveViewSession;
}

/// <summary>
/// Creates a short-lived live view session for a single camera. Pass the returned session ID and token to `/cameras/live_views/offer` to start a WebRTC stream, and to `/cameras/live_views/stop` to end the session.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support. To check whether a camera supports live view, use `device.can_stream_live_video`.
/// </summary>
public async Task<CameraLiveViewSession> CreateAsync(string deviceId = default, int? durationSeconds = default, bool? includeAudio = default)
{
return (await CreateAsync(new CreateRequest(deviceId: deviceId, durationSeconds: durationSeconds, includeAudio: includeAudio)));
}

/// <summary>
/// Request parameters for Negotiate a Camera Live View.
/// </summary>
[DataContract(Name = "offerRequest_request")]
public class OfferRequest
{
[JsonConstructorAttribute]
protected OfferRequest() { }

public OfferRequest(string cameraLiveViewSessionId = default, string sdpOffer = default, string token = default)
{
CameraLiveViewSessionId = cameraLiveViewSessionId;
SdpOffer = sdpOffer;
Token = token;
}

/// <summary>
/// ID of the camera live view session.
/// </summary>
[DataMember(Name = "camera_live_view_session_id", IsRequired = true, EmitDefaultValue = false)]
public string CameraLiveViewSessionId { get; set; }

/// <summary>
/// WebRTC SDP offer from the viewer, limited to 64 KiB of UTF-8 data.
/// </summary>
[DataMember(Name = "sdp_offer", IsRequired = true, EmitDefaultValue = false)]
public string SdpOffer { get; set; }

/// <summary>
/// Token returned when the camera live view session was created.
/// </summary>
[DataMember(Name = "token", IsRequired = true, EmitDefaultValue = false)]
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

[DataContract(Name = "offerResponse_response")]
public class OfferResponse
{
[JsonConstructorAttribute]
protected OfferResponse() { }

public OfferResponse(CameraLiveViewAnswer cameraLiveViewAnswer = default)
{
CameraLiveViewAnswer = cameraLiveViewAnswer;
}

/// <summary>
/// OK
/// </summary>
[DataMember(Name = "camera_live_view_answer", IsRequired = false, EmitDefaultValue = false)]
public CameraLiveViewAnswer CameraLiveViewAnswer { get; set; }

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
/// Exchanges a WebRTC SDP offer for an SDP answer that starts streaming video from the camera, for a live view session that you created using `/cameras/live_views/create`.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public CameraLiveViewAnswer Offer(OfferRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<OfferResponse>("/cameras/live_views/offer", requestOptions).EnsureData("/cameras/live_views/offer").CameraLiveViewAnswer;
}

/// <summary>
/// Exchanges a WebRTC SDP offer for an SDP answer that starts streaming video from the camera, for a live view session that you created using `/cameras/live_views/create`.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public CameraLiveViewAnswer Offer(string cameraLiveViewSessionId = default, string sdpOffer = default, string token = default)
{
return Offer(new OfferRequest(cameraLiveViewSessionId: cameraLiveViewSessionId, sdpOffer: sdpOffer, token: token));
}

/// <summary>
/// Exchanges a WebRTC SDP offer for an SDP answer that starts streaming video from the camera, for a live view session that you created using `/cameras/live_views/create`.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public async Task<CameraLiveViewAnswer> OfferAsync(OfferRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<OfferResponse>("/cameras/live_views/offer", requestOptions)).EnsureData("/cameras/live_views/offer").CameraLiveViewAnswer;
}

/// <summary>
/// Exchanges a WebRTC SDP offer for an SDP answer that starts streaming video from the camera, for a live view session that you created using `/cameras/live_views/create`.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public async Task<CameraLiveViewAnswer> OfferAsync(string cameraLiveViewSessionId = default, string sdpOffer = default, string token = default)
{
return (await OfferAsync(new OfferRequest(cameraLiveViewSessionId: cameraLiveViewSessionId, sdpOffer: sdpOffer, token: token)));
}

/// <summary>
/// Request parameters for Stop a Camera Live View Session.
/// </summary>
[DataContract(Name = "stopRequest_request")]
public class StopRequest
{
[JsonConstructorAttribute]
protected StopRequest() { }

public StopRequest(string cameraLiveViewSessionId = default, string token = default)
{
CameraLiveViewSessionId = cameraLiveViewSessionId;
Token = token;
}

/// <summary>
/// ID of the camera live view session.
/// </summary>
[DataMember(Name = "camera_live_view_session_id", IsRequired = true, EmitDefaultValue = false)]
public string CameraLiveViewSessionId { get; set; }

/// <summary>
/// Token returned when the camera live view session was created.
/// </summary>
[DataMember(Name = "token", IsRequired = true, EmitDefaultValue = false)]
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

/// <summary>
/// Stops a camera live view session that the current client session owns.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public void Stop(StopRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
_seam.Post<object>("/cameras/live_views/stop", requestOptions);
}

/// <summary>
/// Stops a camera live view session that the current client session owns.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public void Stop(string cameraLiveViewSessionId = default, string token = default)
{
Stop(new StopRequest(cameraLiveViewSessionId: cameraLiveViewSessionId, token: token));
}

/// <summary>
/// Stops a camera live view session that the current client session owns.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public async Task StopAsync(StopRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
await _seam.PostAsync<object>("/cameras/live_views/stop", requestOptions);
}

/// <summary>
/// Stops a camera live view session that the current client session owns.
/// 
/// Camera live view is in beta. To enable it for your workspace, contact Seam support.
/// </summary>
public async Task StopAsync(string cameraLiveViewSessionId = default, string token = default)
{
await StopAsync(new StopRequest(cameraLiveViewSessionId: cameraLiveViewSessionId, token: token));
}
}
}

namespace Seam.Client
{
public partial class SeamClient
{
public Api.LiveViewsCameras LiveViewsCameras => new(this);
}

public partial interface ISeamClient
{
public Api.LiveViewsCameras LiveViewsCameras { get; }
}
}
