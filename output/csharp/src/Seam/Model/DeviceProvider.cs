using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Seam.Model
{
  [DataContract(Name = "seamModel_deviceProvider_model")]
  public class DeviceProvider
  {
    [JsonConstructorAttribute]
    protected DeviceProvider() { }

    public DeviceProvider(
      string deviceProviderName = default,
      string displayName = default,
      string imageUrl = default,
      List<DeviceProvider.ProviderCategoriesEnum> providerCategories = default
    )
    {
      DeviceProviderName = deviceProviderName;
      DisplayName = displayName;
      ImageUrl = imageUrl;
      ProviderCategories = providerCategories;
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProviderCategoriesEnum
    {
      [EnumMember(Value = "stable")]
      Stable = 0,

      [EnumMember(Value = "consumer_smartlocks")]
      ConsumerSmartlocks = 1
    }

    [DataMember(Name = "device_provider_name", IsRequired = true, EmitDefaultValue = false)]
    public string DeviceProviderName { get; set; }

    [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    [DataMember(Name = "image_url", IsRequired = true, EmitDefaultValue = false)]
    public string ImageUrl { get; set; }

    [DataMember(Name = "provider_categories", IsRequired = true, EmitDefaultValue = false)]
    public List<DeviceProvider.ProviderCategoriesEnum> ProviderCategories { get; set; }

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
