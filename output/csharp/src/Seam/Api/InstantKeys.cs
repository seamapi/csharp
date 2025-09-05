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
    public class InstantKeys
    {
        private ISeamClient _seam;

        public InstantKeys(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string instantKeyId = default)
            {
                InstantKeyId = instantKeyId;
            }

            [DataMember(Name = "instant_key_id", IsRequired = true, EmitDefaultValue = false)]
            public string InstantKeyId { get; set; }

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
            _seam.Post<object>("/instant_keys/delete", requestOptions);
        }

        public void Delete(string instantKeyId = default)
        {
            Delete(new DeleteRequest(instantKeyId: instantKeyId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/instant_keys/delete", requestOptions);
        }

        public async Task DeleteAsync(string instantKeyId = default)
        {
            await DeleteAsync(new DeleteRequest(instantKeyId: instantKeyId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? instantKeyId = default, string? instantKeyUrl = default)
            {
                InstantKeyId = instantKeyId;
                InstantKeyUrl = instantKeyUrl;
            }

            [DataMember(Name = "instant_key_id", IsRequired = false, EmitDefaultValue = false)]
            public string? InstantKeyId { get; set; }

            [DataMember(Name = "instant_key_url", IsRequired = false, EmitDefaultValue = false)]
            public string? InstantKeyUrl { get; set; }

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

            public GetResponse(InstantKey instantKey = default)
            {
                InstantKey = instantKey;
            }

            [DataMember(Name = "instant_key", IsRequired = false, EmitDefaultValue = false)]
            public InstantKey InstantKey { get; set; }

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

        public InstantKey Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/instant_keys/get", requestOptions).Data.InstantKey;
        }

        public InstantKey Get(string? instantKeyId = default, string? instantKeyUrl = default)
        {
            return Get(new GetRequest(instantKeyId: instantKeyId, instantKeyUrl: instantKeyUrl));
        }

        public async Task<InstantKey> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/instant_keys/get", requestOptions))
                .Data
                .InstantKey;
        }

        public async Task<InstantKey> GetAsync(
            string? instantKeyId = default,
            string? instantKeyUrl = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(instantKeyId: instantKeyId, instantKeyUrl: instantKeyUrl)
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string? userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

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

            public ListResponse(List<InstantKey> instantKeys = default)
            {
                InstantKeys = instantKeys;
            }

            [DataMember(Name = "instant_keys", IsRequired = false, EmitDefaultValue = false)]
            public List<InstantKey> InstantKeys { get; set; }

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

        public List<InstantKey> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/instant_keys/list", requestOptions).Data.InstantKeys;
        }

        public List<InstantKey> List(string? userIdentityId = default)
        {
            return List(new ListRequest(userIdentityId: userIdentityId));
        }

        public async Task<List<InstantKey>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/instant_keys/list", requestOptions))
                .Data
                .InstantKeys;
        }

        public async Task<List<InstantKey>> ListAsync(string? userIdentityId = default)
        {
            return (await ListAsync(new ListRequest(userIdentityId: userIdentityId)));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.InstantKeys InstantKeys => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.InstantKeys InstantKeys { get; }
    }
}
