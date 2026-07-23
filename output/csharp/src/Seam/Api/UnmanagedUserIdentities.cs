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
public class UnmanagedUserIdentities
{
private ISeamClient _seam;

public UnmanagedUserIdentities(ISeamClient seam)
{
_seam = seam;
}

[DataContract(Name = "getRequest_request")]
public class GetRequest
{
[JsonConstructorAttribute]
protected GetRequest() { }

public GetRequest(string userIdentityId = default)
{
UserIdentityId = userIdentityId;
}

[DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
public string UserIdentityId { get; set; }

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

public GetResponse(UserIdentity userIdentity = default)
{
UserIdentity = userIdentity;
}

[DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
public UserIdentity UserIdentity { get; set; }

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

public UserIdentity Get(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<GetResponse>("/user_identities/unmanaged/get", requestOptions).Data.UserIdentity;
}

public UserIdentity Get(string userIdentityId = default)
{
return Get(new GetRequest(userIdentityId: userIdentityId));
}

public async Task<UserIdentity> GetAsync(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<GetResponse>("/user_identities/unmanaged/get", requestOptions)).Data.UserIdentity;
}

public async Task<UserIdentity> GetAsync(string userIdentityId = default)
{
return (await GetAsync(new GetRequest(userIdentityId: userIdentityId)));
}

[DataContract(Name = "listRequest_request")]
public class ListRequest
{
[JsonConstructorAttribute]
protected ListRequest() { }

public ListRequest(string? createdBefore = default, int? limit = default, string? pageCursor = default, string? search = default)
{
CreatedBefore = createdBefore;
Limit = limit;
PageCursor = pageCursor;
Search = search;
}

[DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedBefore { get; set; }

[DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
public int? Limit { get; set; }

[DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
public string? PageCursor { get; set; }

[DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
public string? Search { get; set; }

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

public ListResponse(List<Unknown> userIdentities = default)
{
UserIdentities = userIdentities;
}

[DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
public List<Unknown> UserIdentities { get; set; }

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

public List<Unknown> List(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<ListResponse>("/user_identities/unmanaged/list", requestOptions).Data.UserIdentities;
}

public List<Unknown> List(string? createdBefore = default, int? limit = default, string? pageCursor = default, string? search = default)
{
return List(new ListRequest(createdBefore: createdBefore, limit: limit, pageCursor: pageCursor, search: search));
}

public async Task<List<Unknown>> ListAsync(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<ListResponse>("/user_identities/unmanaged/list", requestOptions)).Data.UserIdentities;
}

public async Task<List<Unknown>> ListAsync(string? createdBefore = default, int? limit = default, string? pageCursor = default, string? search = default)
{
return (await ListAsync(new ListRequest(createdBefore: createdBefore, limit: limit, pageCursor: pageCursor, search: search)));
}

[DataContract(Name = "updateRequest_request")]
public class UpdateRequest
{
[JsonConstructorAttribute]
protected UpdateRequest() { }

public UpdateRequest(bool isManaged = default, string userIdentityId = default, string? userIdentityKey = default)
{
IsManaged = isManaged;
UserIdentityId = userIdentityId;
UserIdentityKey = userIdentityKey;
}

[DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
public bool IsManaged { get; set; }

[DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
public string UserIdentityId { get; set; }

[DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
public string? UserIdentityKey { get; set; }

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

public void Update(UpdateRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
_seam.Post<object>("/user_identities/unmanaged/update", requestOptions);
}

public void Update(bool isManaged = default, string userIdentityId = default, string? userIdentityKey = default)
{
Update(new UpdateRequest(isManaged: isManaged, userIdentityId: userIdentityId, userIdentityKey: userIdentityKey));
}

public async Task UpdateAsync(UpdateRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
await _seam.PostAsync<object>("/user_identities/unmanaged/update", requestOptions);
}

public async Task UpdateAsync(bool isManaged = default, string userIdentityId = default, string? userIdentityKey = default)
{
await UpdateAsync(new UpdateRequest(isManaged: isManaged, userIdentityId: userIdentityId, userIdentityKey: userIdentityKey));
}
}
}

namespace Seam.Client
{
public partial class SeamClient
{
public Api.UnmanagedUserIdentities UnmanagedUserIdentities => new(this);
}

public partial interface ISeamClient
{
public Api.UnmanagedUserIdentities UnmanagedUserIdentities { get; }
}
}
