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
    public class UnmanagedAccessGroupsAcs
    {
        private ISeamClient _seam;

        public UnmanagedAccessGroupsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsAccessGroupId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

            public GetResponse(UnmanagedAcsAccessGroup acsAccessGroup = default)
            {
                AcsAccessGroup = acsAccessGroup;
            }

            [DataMember(Name = "acs_access_group", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAcsAccessGroup AcsAccessGroup { get; set; }

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

        public UnmanagedAcsAccessGroup Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/access_groups/unmanaged/get", requestOptions)
                .Data.AcsAccessGroup;
        }

        public UnmanagedAcsAccessGroup Get(string acsAccessGroupId = default)
        {
            return Get(new GetRequest(acsAccessGroupId: acsAccessGroupId));
        }

        public async Task<UnmanagedAcsAccessGroup> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>(
                    "/acs/access_groups/unmanaged/get",
                    requestOptions
                )
            )
                .Data
                .AcsAccessGroup;
        }

        public async Task<UnmanagedAcsAccessGroup> GetAsync(string acsAccessGroupId = default)
        {
            return (await GetAsync(new GetRequest(acsAccessGroupId: acsAccessGroupId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string? acsSystemId = default, string? acsUserId = default)
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

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

            public ListResponse(List<UnmanagedAcsAccessGroup> acsAccessGroups = default)
            {
                AcsAccessGroups = acsAccessGroups;
            }

            [DataMember(Name = "acs_access_groups", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAcsAccessGroup> AcsAccessGroups { get; set; }

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

        public List<UnmanagedAcsAccessGroup> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/access_groups/unmanaged/list", requestOptions)
                .Data.AcsAccessGroups;
        }

        public List<UnmanagedAcsAccessGroup> List(
            string? acsSystemId = default,
            string? acsUserId = default
        )
        {
            return List(new ListRequest(acsSystemId: acsSystemId, acsUserId: acsUserId));
        }

        public async Task<List<UnmanagedAcsAccessGroup>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>(
                    "/acs/access_groups/unmanaged/list",
                    requestOptions
                )
            )
                .Data
                .AcsAccessGroups;
        }

        public async Task<List<UnmanagedAcsAccessGroup>> ListAsync(
            string? acsSystemId = default,
            string? acsUserId = default
        )
        {
            return (
                await ListAsync(new ListRequest(acsSystemId: acsSystemId, acsUserId: acsUserId))
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedAccessGroupsAcs UnmanagedAccessGroupsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessGroupsAcs UnmanagedAccessGroupsAcs { get; }
    }
}
