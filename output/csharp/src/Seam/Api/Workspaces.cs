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
  public class Workspaces
  {
    private ISeamClient _seam;

    public Workspaces(ISeamClient seam)
    {
      _seam = seam;
    }

    [DataContract(Name = "getRequest_request")]
    public class GetRequest
    {
      [JsonConstructorAttribute]
      public GetRequest() { }

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

      public GetResponse(Workspace? workspace = default)
      {
        Workspace = workspace;
      }

      [DataMember(Name = "workspace", IsRequired = false, EmitDefaultValue = false)]
      public Workspace? Workspace { get; set; }

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

    public Workspace Get(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<GetResponse>("/workspaces/get", requestOptions).Data.Workspace;
    }

    public Workspace Get()
    {
      return Get(new GetRequest());
    }

    public async Task<Workspace> GetAsync(GetRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<GetResponse>("/workspaces/get", requestOptions)).Data.Workspace;
    }

    public async Task<Workspace> GetAsync()
    {
      return (await GetAsync(new GetRequest()));
    }

    [DataContract(Name = "listRequest_request")]
    public class ListRequest
    {
      [JsonConstructorAttribute]
      public ListRequest() { }

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

      public ListResponse(List<Workspace> workspaces = default)
      {
        Workspaces = workspaces;
      }

      [DataMember(Name = "workspaces", IsRequired = false, EmitDefaultValue = false)]
      public List<Workspace> Workspaces { get; set; }

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

    public List<Workspace> List(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return _seam.Post<ListResponse>("/workspaces/list", requestOptions).Data.Workspaces;
    }

    public List<Workspace> List()
    {
      return List(new ListRequest());
    }

    public async Task<List<Workspace>> ListAsync(ListRequest request)
    {
      var requestOptions = new RequestOptions();
      requestOptions.Data = request;
      return (await _seam.PostAsync<ListResponse>("/workspaces/list", requestOptions))
        .Data
        .Workspaces;
    }

    public async Task<List<Workspace>> ListAsync()
    {
      return (await ListAsync(new ListRequest()));
    }
  }
}

namespace Seam.Client
{
  public partial class SeamClient
  {
    public Api.Workspaces Workspaces => new(this);
  }

  public partial interface ISeamClient
  {
    public Api.Workspaces Workspaces { get; }
  }
}
