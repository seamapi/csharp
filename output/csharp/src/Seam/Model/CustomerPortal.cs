using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
[DataContract(Name = "seamModel_customerPortal_model")]
public class CustomerPortal
{
[JsonConstructorAttribute]
protected CustomerPortal() { }

public CustomerPortal(string createdAt = default, string customerKey = default, string expiresAt = default, string url = default, string workspaceId = default)
{
CreatedAt = createdAt;
CustomerKey = customerKey;
ExpiresAt = expiresAt;
Url = url;
WorkspaceId = workspaceId;
}

[DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
public string CreatedAt { get; set; }

[DataMember(Name = "customer_key", IsRequired = true, EmitDefaultValue = false)]
public string CustomerKey { get; set; }

[DataMember(Name = "expires_at", IsRequired = true, EmitDefaultValue = false)]
public string ExpiresAt { get; set; }

[DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
public string Url { get; set; }

[DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
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
