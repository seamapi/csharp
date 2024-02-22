using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
  [DataContract(Name = "seamModel_workspace_model")]
  public class Workspace
  {
    [JsonConstructorAttribute]
    protected Workspace() { }

    public Workspace(
      string workspaceId = default,
      string name = default,
      bool isSandbox = default,
      string? connectPartnerName = default
    )
    {
      WorkspaceId = workspaceId;
      Name = name;
      IsSandbox = isSandbox;
      ConnectPartnerName = connectPartnerName;
    }

    [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
    public string WorkspaceId { get; set; }

    [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
    public string Name { get; set; }

    [DataMember(Name = "is_sandbox", IsRequired = true, EmitDefaultValue = false)]
    public bool IsSandbox { get; set; }

    [DataMember(Name = "connect_partner_name", IsRequired = false, EmitDefaultValue = false)]
    public string? ConnectPartnerName { get; set; }

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
