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
public class AccessMethods
{
private ISeamClient _seam;

public AccessMethods(ISeamClient seam)
{
_seam = seam;
}

[DataContract(Name = "assignCardRequest_request")]
public class AssignCardRequest
{
[JsonConstructorAttribute]
protected AssignCardRequest() { }

public AssignCardRequest(string accessMethodId = default, string cardNumber = default)
{
AccessMethodId = accessMethodId;
CardNumber = cardNumber;
}

[DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
public string AccessMethodId { get; set; }

[DataMember(Name = "card_number", IsRequired = true, EmitDefaultValue = false)]
public string CardNumber { get; set; }

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

[DataContract(Name = "assignCardResponse_response")]
public class AssignCardResponse
{
[JsonConstructorAttribute]
protected AssignCardResponse() { }

public AssignCardResponse(ActionAttempt actionAttempt = default)
{
ActionAttempt = actionAttempt;
}

[DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
public ActionAttempt ActionAttempt { get; set; }

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

public ActionAttempt AssignCard(AssignCardRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<AssignCardResponse>("/access_methods/assign_card", requestOptions).Data.ActionAttempt;
}

public ActionAttempt AssignCard(string accessMethodId = default, string cardNumber = default)
{
return AssignCard(new AssignCardRequest(accessMethodId: accessMethodId, cardNumber: cardNumber));
}

public async Task<ActionAttempt> AssignCardAsync(AssignCardRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<AssignCardResponse>("/access_methods/assign_card", requestOptions)).Data.ActionAttempt;
}

public async Task<ActionAttempt> AssignCardAsync(string accessMethodId = default, string cardNumber = default)
{
return (await AssignCardAsync(new AssignCardRequest(accessMethodId: accessMethodId, cardNumber: cardNumber)));
}

[DataContract(Name = "deleteRequest_request")]
public class DeleteRequest
{
[JsonConstructorAttribute]
protected DeleteRequest() { }

public DeleteRequest(string? accessMethodId = default, string? accessGrantId = default, string? reservationKey = default)
{
AccessMethodId = accessMethodId;
AccessGrantId = accessGrantId;
ReservationKey = reservationKey;
}

[DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
public string? AccessMethodId { get; set; }

[DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
public string? AccessGrantId { get; set; }

[DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
public string? ReservationKey { get; set; }

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

public void Delete(DeleteRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
_seam.Post<object>("/access_methods/delete", requestOptions);
}

public void Delete(string? accessMethodId = default, string? accessGrantId = default, string? reservationKey = default)
{
Delete(new DeleteRequest(accessMethodId: accessMethodId, accessGrantId: accessGrantId, reservationKey: reservationKey));
}

public async Task DeleteAsync(DeleteRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
await _seam.PostAsync<object>("/access_methods/delete", requestOptions);
}

public async Task DeleteAsync(string? accessMethodId = default, string? accessGrantId = default, string? reservationKey = default)
{
await DeleteAsync(new DeleteRequest(accessMethodId: accessMethodId, accessGrantId: accessGrantId, reservationKey: reservationKey));
}

[DataContract(Name = "encodeRequest_request")]
public class EncodeRequest
{
[JsonConstructorAttribute]
protected EncodeRequest() { }

public EncodeRequest(string accessMethodId = default, string acsEncoderId = default)
{
AccessMethodId = accessMethodId;
AcsEncoderId = acsEncoderId;
}

[DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
public string AccessMethodId { get; set; }

[DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
public string AcsEncoderId { get; set; }

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

[DataContract(Name = "encodeResponse_response")]
public class EncodeResponse
{
[JsonConstructorAttribute]
protected EncodeResponse() { }

public EncodeResponse(ActionAttempt actionAttempt = default)
{
ActionAttempt = actionAttempt;
}

[DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
public ActionAttempt ActionAttempt { get; set; }

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

public ActionAttempt Encode(EncodeRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<EncodeResponse>("/access_methods/encode", requestOptions).Data.ActionAttempt;
}

public ActionAttempt Encode(string accessMethodId = default, string acsEncoderId = default)
{
return Encode(new EncodeRequest(accessMethodId: accessMethodId, acsEncoderId: acsEncoderId));
}

public async Task<ActionAttempt> EncodeAsync(EncodeRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<EncodeResponse>("/access_methods/encode", requestOptions)).Data.ActionAttempt;
}

public async Task<ActionAttempt> EncodeAsync(string accessMethodId = default, string acsEncoderId = default)
{
return (await EncodeAsync(new EncodeRequest(accessMethodId: accessMethodId, acsEncoderId: acsEncoderId)));
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
return _seam.Post<GetResponse>("/access_methods/get", requestOptions).Data.AccessMethod;
}

public AccessMethod Get(string accessMethodId = default)
{
return Get(new GetRequest(accessMethodId: accessMethodId));
}

public async Task<AccessMethod> GetAsync(GetRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<GetResponse>("/access_methods/get", requestOptions)).Data.AccessMethod;
}

public async Task<AccessMethod> GetAsync(string accessMethodId = default)
{
return (await GetAsync(new GetRequest(accessMethodId: accessMethodId)));
}

[DataContract(Name = "getRelatedRequest_request")]
public class GetRelatedRequest
{
[JsonConstructorAttribute]
protected GetRelatedRequest() { }

public GetRelatedRequest(List<string> accessMethodIds = default, List<GetRelatedRequest.ExcludeEnum>? exclude = default, List<GetRelatedRequest.IncludeEnum>? include = default)
{
AccessMethodIds = accessMethodIds;
Exclude = exclude;
Include = include;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum ExcludeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "spaces")]
Spaces = 1,

[EnumMember(Value = "devices")]
Devices = 2,

[EnumMember(Value = "acs_entrances")]
AcsEntrances = 3,

[EnumMember(Value = "access_grants")]
AccessGrants = 4,

[EnumMember(Value = "access_methods")]
AccessMethods = 5,

[EnumMember(Value = "instant_keys")]
InstantKeys = 6,

[EnumMember(Value = "client_sessions")]
ClientSessions = 7,

[EnumMember(Value = "acs_credentials")]
AcsCredentials = 8,
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum IncludeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "spaces")]
Spaces = 1,

[EnumMember(Value = "devices")]
Devices = 2,

[EnumMember(Value = "acs_entrances")]
AcsEntrances = 3,

[EnumMember(Value = "access_grants")]
AccessGrants = 4,

[EnumMember(Value = "access_methods")]
AccessMethods = 5,

[EnumMember(Value = "instant_keys")]
InstantKeys = 6,

[EnumMember(Value = "client_sessions")]
ClientSessions = 7,

[EnumMember(Value = "acs_credentials")]
AcsCredentials = 8,
}

[DataMember(Name = "access_method_ids", IsRequired = true, EmitDefaultValue = false)]
public List<string> AccessMethodIds { get; set; }

[DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
public List<GetRelatedRequest.ExcludeEnum>? Exclude { get; set; }

[DataMember(Name = "include", IsRequired = false, EmitDefaultValue = false)]
public List<GetRelatedRequest.IncludeEnum>? Include { get; set; }

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

[DataContract(Name = "getRelatedResponse_response")]
public class GetRelatedResponse
{
[JsonConstructorAttribute]
protected GetRelatedResponse() { }

public GetRelatedResponse(Batch batch = default)
{
Batch = batch;
}

[DataMember(Name = "batch", IsRequired = false, EmitDefaultValue = false)]
public Batch Batch { get; set; }

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

public Batch GetRelated(GetRelatedRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<GetRelatedResponse>("/access_methods/get_related", requestOptions).Data.Batch;
}

public Batch GetRelated(List<string> accessMethodIds = default, List<GetRelatedRequest.ExcludeEnum>? exclude = default, List<GetRelatedRequest.IncludeEnum>? include = default)
{
return GetRelated(new GetRelatedRequest(accessMethodIds: accessMethodIds, exclude: exclude, include: include));
}

public async Task<Batch> GetRelatedAsync(GetRelatedRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<GetRelatedResponse>("/access_methods/get_related", requestOptions)).Data.Batch;
}

public async Task<Batch> GetRelatedAsync(List<string> accessMethodIds = default, List<GetRelatedRequest.ExcludeEnum>? exclude = default, List<GetRelatedRequest.IncludeEnum>? include = default)
{
return (await GetRelatedAsync(new GetRelatedRequest(accessMethodIds: accessMethodIds, exclude: exclude, include: include)));
}

[DataContract(Name = "listRequest_request")]
public class ListRequest
{
[JsonConstructorAttribute]
protected ListRequest() { }

public ListRequest(string? accessCodeId = default, string? accessGrantId = default, string? accessGrantKey = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
AccessCodeId = accessCodeId;
AccessGrantId = accessGrantId;
AccessGrantKey = accessGrantKey;
AcsEntranceId = acsEntranceId;
DeviceId = deviceId;
SpaceId = spaceId;
}

[DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
public string? AccessCodeId { get; set; }

[DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
public string? AccessGrantId { get; set; }

[DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
public string? AccessGrantKey { get; set; }

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

public ListResponse(List<AccessMethod> accessMethods = default)
{
AccessMethods = accessMethods;
}

[DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
public List<AccessMethod> AccessMethods { get; set; }

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

public List<AccessMethod> List(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<ListResponse>("/access_methods/list", requestOptions).Data.AccessMethods;
}

public List<AccessMethod> List(string? accessCodeId = default, string? accessGrantId = default, string? accessGrantKey = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
return List(new ListRequest(accessCodeId: accessCodeId, accessGrantId: accessGrantId, accessGrantKey: accessGrantKey, acsEntranceId: acsEntranceId, deviceId: deviceId, spaceId: spaceId));
}

public async Task<List<AccessMethod>> ListAsync(ListRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<ListResponse>("/access_methods/list", requestOptions)).Data.AccessMethods;
}

public async Task<List<AccessMethod>> ListAsync(string? accessCodeId = default, string? accessGrantId = default, string? accessGrantKey = default, string? acsEntranceId = default, string? deviceId = default, string? spaceId = default)
{
return (await ListAsync(new ListRequest(accessCodeId: accessCodeId, accessGrantId: accessGrantId, accessGrantKey: accessGrantKey, acsEntranceId: acsEntranceId, deviceId: deviceId, spaceId: spaceId)));
}

[DataContract(Name = "unlockDoorRequest_request")]
public class UnlockDoorRequest
{
[JsonConstructorAttribute]
protected UnlockDoorRequest() { }

public UnlockDoorRequest(string accessMethodId = default, string acsEntranceId = default)
{
AccessMethodId = accessMethodId;
AcsEntranceId = acsEntranceId;
}

[DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
public string AccessMethodId { get; set; }

[DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
public string AcsEntranceId { get; set; }

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

[DataContract(Name = "unlockDoorResponse_response")]
public class UnlockDoorResponse
{
[JsonConstructorAttribute]
protected UnlockDoorResponse() { }

public UnlockDoorResponse(ActionAttempt actionAttempt = default)
{
ActionAttempt = actionAttempt;
}

[DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
public ActionAttempt ActionAttempt { get; set; }

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

public ActionAttempt UnlockDoor(UnlockDoorRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return _seam.Post<UnlockDoorResponse>("/access_methods/unlock_door", requestOptions).Data.ActionAttempt;
}

public ActionAttempt UnlockDoor(string accessMethodId = default, string acsEntranceId = default)
{
return UnlockDoor(new UnlockDoorRequest(accessMethodId: accessMethodId, acsEntranceId: acsEntranceId));
}

public async Task<ActionAttempt> UnlockDoorAsync(UnlockDoorRequest request)
{
var requestOptions = new RequestOptions();
requestOptions.Data = request;
return (await _seam.PostAsync<UnlockDoorResponse>("/access_methods/unlock_door", requestOptions)).Data.ActionAttempt;
}

public async Task<ActionAttempt> UnlockDoorAsync(string accessMethodId = default, string acsEntranceId = default)
{
return (await UnlockDoorAsync(new UnlockDoorRequest(accessMethodId: accessMethodId, acsEntranceId: acsEntranceId)));
}
}
}

namespace Seam.Client
{
public partial class SeamClient
{
public Api.AccessMethods AccessMethods => new(this);
}

public partial interface ISeamClient
{
public Api.AccessMethods AccessMethods { get; }
}
}
