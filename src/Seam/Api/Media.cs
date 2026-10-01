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
public class Media
{
private ISeamClient _seam;

public Media(ISeamClient seam)
{
_seam = seam;
}

/// <summary>
/// Request parameters for Get Media.
/// </summary>
[DataContract(Name = "getRequest_request")]
public class GetRequest
{
[JsonConstructorAttribute]
protected GetRequest() { }

public GetRequest(GetRequest.FormatEnum? format = default, string mediaId = default)
{
Format = format;
MediaId = mediaId;
}

/// <summary>
/// Response format. `json` returns the media object. `redirect` responds with a `302` redirect to the media&apos;s download URL, so you can use this endpoint directly as the source of an image or video.
/// </summary>
[JsonConverter(typeof(SafeStringEnumConverter))]
public enum FormatEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "json")]
Json = 1,

[EnumMember(Value = "redirect")]
Redirect = 2,
}

/// <summary>
/// Response format. `json` returns the media object. `redirect` responds with a `302` redirect to the media&apos;s download URL, so you can use this endpoint directly as the source of an image or video.
/// </summary>
[DataMember(Name = "format", IsRequired = false, EmitDefaultValue = false)]
public GetRequest.FormatEnum? Format { get; set; }

/// <summary>
/// ID of the media that you want to get.
/// </summary>
[DataMember(Name = "media_id", IsRequired = true, EmitDefaultValue = false)]
public string MediaId { get; set; }

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

[DataContract(Name = "getResponse_response")]
public class GetResponse
{
[JsonConstructorAttribute]
protected GetResponse() { }

public GetResponse(Seam.Model.Media media = default)
{
Media = media;
}

/// <summary>
/// OK
/// </summary>
[DataMember(Name = "media", IsRequired = false, EmitDefaultValue = false)]
public Seam.Model.Media Media { get; set; }

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
/// Returns a specified piece of media, such as a video clip or thumbnail image captured for a camera event, with a short-lived URL from which you can download it. Camera events list their media in `media_ids`. This endpoint is in beta.
/// </summary>
public Seam.Model.Media Get(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Get<GetResponse>("/media/get", requestOptions).EnsureData("/media/get").Media;
}

/// <summary>
/// Returns a specified piece of media, such as a video clip or thumbnail image captured for a camera event, with a short-lived URL from which you can download it. Camera events list their media in `media_ids`. This endpoint is in beta.
/// </summary>
public Seam.Model.Media Get(GetRequest.FormatEnum? format = default, string mediaId = default)
{
return Get(new GetRequest(format: format, mediaId: mediaId));
}

/// <summary>
/// Returns a specified piece of media, such as a video clip or thumbnail image captured for a camera event, with a short-lived URL from which you can download it. Camera events list their media in `media_ids`. This endpoint is in beta.
/// </summary>
public async Task<Seam.Model.Media> GetAsync(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.GetAsync<GetResponse>("/media/get", requestOptions)).EnsureData("/media/get").Media;
}

/// <summary>
/// Returns a specified piece of media, such as a video clip or thumbnail image captured for a camera event, with a short-lived URL from which you can download it. Camera events list their media in `media_ids`. This endpoint is in beta.
/// </summary>
public async Task<Seam.Model.Media> GetAsync(GetRequest.FormatEnum? format = default, string mediaId = default)
{
return (await GetAsync(new GetRequest(format: format, mediaId: mediaId)));
}
}
}

namespace Seam.Client
{
public partial class SeamClient
{
public Api.Media Media => new(this);
}

public partial interface ISeamClient
{
public Api.Media Media { get; }
}
}
