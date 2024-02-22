using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
  [DataContract(Name = "seamModel_serviceHealth_model")]
  public class ServiceHealth
  {
    [JsonConstructorAttribute]
    protected ServiceHealth() { }

    public ServiceHealth(
      string service = default,
      ServiceHealth.StatusEnum status = default,
      string description = default
    )
    {
      Service = service;
      Status = status;
      Description = description;
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
      [EnumMember(Value = "healthy")]
      Healthy = 0,

      [EnumMember(Value = "degraded")]
      Degraded = 1,

      [EnumMember(Value = "down")]
      Down = 2
    }

    [DataMember(Name = "service", IsRequired = true, EmitDefaultValue = false)]
    public string Service { get; set; }

    [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
    public ServiceHealth.StatusEnum Status { get; set; }

    [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
    public string Description { get; set; }

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
