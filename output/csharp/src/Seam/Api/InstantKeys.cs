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

        /// <summary>
        /// Request parameters for Delete an Instant Key.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string instantKeyId = default)
            {
                InstantKeyId = instantKeyId;
            }

            /// <summary>
            /// ID of the Instant Key that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a specified [Instant Key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/instant_keys/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [Instant Key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public void Delete(string instantKeyId = default)
        {
            Delete(new DeleteRequest(instantKeyId: instantKeyId));
        }

        /// <summary>
        /// Deletes a specified [Instant Key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/instant_keys/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [Instant Key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public async Task DeleteAsync(string instantKeyId = default)
        {
            await DeleteAsync(new DeleteRequest(instantKeyId: instantKeyId));
        }

        /// <summary>
        /// Request parameters for Get an Instant Key.
        /// </summary>
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

            /// <summary>
            /// ID of the instant key to get.
            /// </summary>
            [DataMember(Name = "instant_key_id", IsRequired = false, EmitDefaultValue = false)]
            public string? InstantKeyId { get; set; }

            /// <summary>
            /// URL of the instant key to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Gets an [instant key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public InstantKey Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/instant_keys/get", requestOptions)
                .EnsureData("/instant_keys/get")
                .InstantKey;
        }

        /// <summary>
        /// Gets an [instant key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public InstantKey Get(string? instantKeyId = default, string? instantKeyUrl = default)
        {
            return Get(new GetRequest(instantKeyId: instantKeyId, instantKeyUrl: instantKeyUrl));
        }

        /// <summary>
        /// Gets an [instant key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public async Task<InstantKey> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/instant_keys/get", requestOptions))
                .EnsureData("/instant_keys/get")
                .InstantKey;
        }

        /// <summary>
        /// Gets an [instant key](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
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

        /// <summary>
        /// Request parameters for List Instant Keys.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string? userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity by which you want to filter the list of Instant Keys.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [instant keys](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public List<InstantKey> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/instant_keys/list", requestOptions)
                .EnsureData("/instant_keys/list")
                .InstantKeys;
        }

        /// <summary>
        /// Returns a list of all [instant keys](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public List<InstantKey> List(string? userIdentityId = default)
        {
            return List(new ListRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Returns a list of all [instant keys](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
        public async Task<List<InstantKey>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/instant_keys/list", requestOptions))
                .EnsureData("/instant_keys/list")
                .InstantKeys;
        }

        /// <summary>
        /// Returns a list of all [instant keys](https://docs.seam.co/capability-guides/instant-keys).
        /// </summary>
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
