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
/// Represents the WebRTC SDP answer that starts streaming video from a camera for a live view session.
/// </summary>
[DataContract(Name = "seamModel_cameraLiveViewAnswer_model")]
public class CameraLiveViewAnswer
{
[JsonConstructorAttribute]
protected CameraLiveViewAnswer() { }

public CameraLiveViewAnswer(string sdpAnswer = default)
{
SdpAnswer = sdpAnswer;
}

/// <summary>
/// WebRTC SDP answer for the offer, limited to 64 KiB of UTF-8 data.
/// </summary>
[DataMember(Name = "sdp_answer", IsRequired = false, EmitDefaultValue = false)]
public string SdpAnswer { get; set; }

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
