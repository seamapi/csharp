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
public class UnmanagedAccessMethods
{
private ISeamClient _seam;

public UnmanagedAccessMethods(ISeamClient seam)
{
_seam = seam;
}

[DataContract(Name = "getRequest_request")]
public class GetRequest
{
[JsonConstructorAttribute]
protected GetRequest() { }

public GetRequest(string accessMethodId = default)
{
AccessMethodId = accessMethodId;
}

[DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
public string AccessMethodId { get; set; }

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

public GetResponse(AccessMethod accessMethod = default)
{
AccessMethod = accessMethod;
}

[DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
public AccessMethod AccessMethod { get; set; }

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

public AccessMethod Get(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<GetResponse>("/access_methods/unmanaged/get", requestOptions).Data.AccessMethod;
}

public AccessMethod Get(string accessMethodId = default)
{
return Get(new GetRequest(accessMethodId: accessMethodId));
}

public async Task<AccessMethod> GetAsync(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<GetResponse>("/access_methods/unmanaged/get", requestOptions)).Data.AccessMethod;
}

public async Task<AccessMethod> GetAsync(string accessMethodId = default)
{
return (await GetAsync(new GetRequest(accessMethodId: accessMethodId)));
}

[DataContract(Name = "listRequest_request")]
public class ListRequest
{
[JsonConstructorAttribute]
protected ListRequest() { }

public ListRequest(string accessGrantId = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
AccessGrantId = accessGrantId;
AcsEntranceId = acsEntranceId;
DeviceId = deviceId;
SpaceId = spaceId;
}

[DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
public string AccessGrantId { get; set; }

[DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsEntranceId { get; set; }

[DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
public string? DeviceId { get; set; }

[DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
public string? SpaceId { get; set; }

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

[DataContract(Name = "listResponse_response")]
public class ListResponse
{
[JsonConstructorAttribute]
protected ListResponse() { }

public ListResponse(List<object> accessMethods = default)
{
AccessMethods = accessMethods;
}

[DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
public List<object> AccessMethods { get; set; }

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

public List<object> List(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<ListResponse>("/access_methods/unmanaged/list", requestOptions).Data.AccessMethods;
}

public List<object> List(string accessGrantId = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
return List(new ListRequest(accessGrantId: accessGrantId, acsEntranceId: acsEntranceId, deviceId: deviceId, spaceId: spaceId));
}

public async Task<List<object>> ListAsync(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<ListResponse>("/access_methods/unmanaged/list", requestOptions)).Data.AccessMethods;
}

public async Task<List<object>> ListAsync(string accessGrantId = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
return (await ListAsync(new ListRequest(accessGrantId: accessGrantId, acsEntranceId: acsEntranceId, deviceId: deviceId, spaceId: spaceId)));
}
}
}

namespace Seam.Client
{
public partial class SeamClient
{
public Api.UnmanagedAccessMethods UnmanagedAccessMethods => new(this);
}

public partial interface ISeamClient
{
public Api.UnmanagedAccessMethods UnmanagedAccessMethods { get; }
}
}
