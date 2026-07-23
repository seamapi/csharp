using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
[DataContract(Name = "seamModel_space_model")]
public class Space
{
[JsonConstructorAttribute]
protected Space() { }

public Space(float? acsEntranceCount = default, string? createdAt = default, SpaceCustomerData? customerData = default, string? customerKey = default, float? deviceCount = default, string? displayName = default, SpaceGeolocation? geolocation = default, string? name = default, string? parentSpaceId = default, string? parentSpaceKey = default, string? spaceId = default, string? spaceKey = default, string? workspaceId = default)
{
AcsEntranceCount = acsEntranceCount;
CreatedAt = createdAt;
CustomerData = customerData;
CustomerKey = customerKey;
DeviceCount = deviceCount;
DisplayName = displayName;
Geolocation = geolocation;
Name = name;
ParentSpaceId = parentSpaceId;
ParentSpaceKey = parentSpaceKey;
SpaceId = spaceId;
SpaceKey = spaceKey;
WorkspaceId = workspaceId;
}

[DataMember(Name = "acs_entrance_count", IsRequired = false, EmitDefaultValue = false)]
public float? AcsEntranceCount { get; set; }

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "customer_data", IsRequired = false, EmitDefaultValue = false)]
public SpaceCustomerData? CustomerData { get; set; }

[DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
public string? CustomerKey { get; set; }

[DataMember(Name = "device_count", IsRequired = false, EmitDefaultValue = false)]
public float? DeviceCount { get; set; }

[DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
public string? DisplayName { get; set; }

[DataMember(Name = "geolocation", IsRequired = false, EmitDefaultValue = false)]
public SpaceGeolocation? Geolocation { get; set; }

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

[DataMember(Name = "parent_space_id", IsRequired = false, EmitDefaultValue = false)]
public string? ParentSpaceId { get; set; }

[DataMember(Name = "parent_space_key", IsRequired = false, EmitDefaultValue = false)]
public string? ParentSpaceKey { get; set; }

[DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
public string? SpaceId { get; set; }

[DataMember(Name = "space_key", IsRequired = false, EmitDefaultValue = false)]
public string? SpaceKey { get; set; }

[DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
public string? WorkspaceId { get; set; }

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

[DataContract(Name = "seamModel_spaceCustomerData_model")]
public class SpaceCustomerData
{
[JsonConstructorAttribute]
protected SpaceCustomerData() { }

public SpaceCustomerData(string? address = default, string? defaultCheckinTime = default, string? defaultCheckoutTime = default, string? timeZone = default)
{
Address = address;
DefaultCheckinTime = defaultCheckinTime;
DefaultCheckoutTime = defaultCheckoutTime;
TimeZone = timeZone;
}

[DataMember(Name = "address", IsRequired = false, EmitDefaultValue = false)]
public string? Address { get; set; }

[DataMember(Name = "default_checkin_time", IsRequired = false, EmitDefaultValue = false)]
public string? DefaultCheckinTime { get; set; }

[DataMember(Name = "default_checkout_time", IsRequired = false, EmitDefaultValue = false)]
public string? DefaultCheckoutTime { get; set; }

[DataMember(Name = "time_zone", IsRequired = false, EmitDefaultValue = false)]
public string? TimeZone { get; set; }

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

[DataContract(Name = "seamModel_spaceGeolocation_model")]
public class SpaceGeolocation
{
[JsonConstructorAttribute]
protected SpaceGeolocation() { }

public SpaceGeolocation(float? latitude = default, float? longitude = default)
{
Latitude = latitude;
Longitude = longitude;
}

[DataMember(Name = "latitude", IsRequired = false, EmitDefaultValue = false)]
public float? Latitude { get; set; }

[DataMember(Name = "longitude", IsRequired = false, EmitDefaultValue = false)]
public float? Longitude { get; set; }

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
