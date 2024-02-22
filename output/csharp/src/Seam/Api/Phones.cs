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
  public class Phones
  {
    private ISeamClient _seam;

    public Phones(ISeamClient seam)
    {
      _seam = seam;
    }

    [DataContract(Name = "listRequest_request")]
    public class ListRequest
    {
      [JsonConstructorAttribute]
      protected ListRequest() { }

      public ListRequest(string? ownerUserIdentityId = default)
      {
        OwnerUserIdentityId = ownerUserIdentityId;
      }

      [DataMember(Name = "owner_user_identity_id", IsRequired = false, EmitDefaultValue = false)]
      public string? OwnerUserIdentityId { get; set; }

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

      public ListResponse(List<Phone> phones = default)
      {
        Phones = phones;
      }

      [DataMember(Name = "phones", IsRequired = false, EmitDefaultValue = false)]
      public List<Phone> Phones { get; set; }

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

    public List<Phone> List(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<ListResponse>("/phones/list", requestOptions).Data.Phones;
    }

    public List<Phone> List(string? ownerUserIdentityId = default)
    {
      return List(new ListRequest(ownerUserIdentityId: ownerUserIdentityId));
    }

    public async Task<List<Phone>> ListAsync(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<ListResponse>("/phones/list", requestOptions)).Data.Phones;
    }

    public async Task<List<Phone>> ListAsync(string? ownerUserIdentityId = default)
    {
      return (await ListAsync(new ListRequest(ownerUserIdentityId: ownerUserIdentityId)));
    }
  }
}

namespace Seam.Client
{
  public partial class SeamClient
  {
    public Api.Phones Phones => new(this);
  }

  public partial interface ISeamClient
  {
    public Api.Phones Phones { get; }
  }
}
