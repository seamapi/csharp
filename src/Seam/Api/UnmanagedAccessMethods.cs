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
    public class UnmanagedAccessMethods
    {
        private ISeamClient _seam;

        public UnmanagedAccessMethods(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Get an Unmanaged Access Method.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string accessMethodId = default)
            {
                AccessMethodId = accessMethodId;
            }

            /// <summary>
            /// ID of unmanaged access method to get.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

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

            public GetResponse(UnmanagedAccessMethod accessMethod = default)
            {
                AccessMethod = accessMethod;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessMethod AccessMethod { get; set; }

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
        /// Gets an unmanaged access method (where is_managed = false).
        /// </summary>
        public UnmanagedAccessMethod Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/access_methods/unmanaged/get", requestOptions)
                .EnsureData("/access_methods/unmanaged/get")
                .AccessMethod;
        }

        /// <summary>
        /// Gets an unmanaged access method (where is_managed = false).
        /// </summary>
        public UnmanagedAccessMethod Get(string accessMethodId = default)
        {
            return Get(new GetRequest(accessMethodId: accessMethodId));
        }

        /// <summary>
        /// Gets an unmanaged access method (where is_managed = false).
        /// </summary>
        public async Task<UnmanagedAccessMethod> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.GetAsync<GetResponse>("/access_methods/unmanaged/get", requestOptions)
            )
                .EnsureData("/access_methods/unmanaged/get")
                .AccessMethod;
        }

        /// <summary>
        /// Gets an unmanaged access method (where is_managed = false).
        /// </summary>
        public async Task<UnmanagedAccessMethod> GetAsync(string accessMethodId = default)
        {
            return (await GetAsync(new GetRequest(accessMethodId: accessMethodId)));
        }

        /// <summary>
        /// Request parameters for List Unmanaged Access Methods.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string accessGrantId = default,
                string? acsEntranceId = default,
                string? deviceId = default,
                string? spaceId = default
            )
            {
                AccessGrantId = accessGrantId;
                AcsEntranceId = acsEntranceId;
                DeviceId = deviceId;
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of Access Grant to list unmanaged access methods for.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            /// <summary>
            /// ID of the entrance for which you want to retrieve all unmanaged access methods.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the device for which you want to retrieve all unmanaged access methods.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// ID of the space for which you want to retrieve all unmanaged access methods.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

            public ListResponse(List<UnmanagedAccessMethod> accessMethods = default)
            {
                AccessMethods = accessMethods;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAccessMethod> AccessMethods { get; set; }

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
        /// Lists all unmanaged access methods (where is_managed = false), usually filtered by Access Grant.
        /// </summary>
        public List<UnmanagedAccessMethod> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/access_methods/unmanaged/list", requestOptions)
                .EnsureData("/access_methods/unmanaged/list")
                .AccessMethods;
        }

        /// <summary>
        /// Lists all unmanaged access methods (where is_managed = false), usually filtered by Access Grant.
        /// </summary>
        public List<UnmanagedAccessMethod> List(
            string accessGrantId = default,
            string? acsEntranceId = default,
            string? deviceId = default,
            string? spaceId = default
        )
        {
            return List(
                new ListRequest(
                    accessGrantId: accessGrantId,
                    acsEntranceId: acsEntranceId,
                    deviceId: deviceId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Lists all unmanaged access methods (where is_managed = false), usually filtered by Access Grant.
        /// </summary>
        public async Task<List<UnmanagedAccessMethod>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.GetAsync<ListResponse>("/access_methods/unmanaged/list", requestOptions)
            )
                .EnsureData("/access_methods/unmanaged/list")
                .AccessMethods;
        }

        /// <summary>
        /// Lists all unmanaged access methods (where is_managed = false), usually filtered by Access Grant.
        /// </summary>
        public async Task<List<UnmanagedAccessMethod>> ListAsync(
            string accessGrantId = default,
            string? acsEntranceId = default,
            string? deviceId = default,
            string? spaceId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessGrantId: accessGrantId,
                        acsEntranceId: acsEntranceId,
                        deviceId: deviceId,
                        spaceId: spaceId
                    )
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedAccessMethods UnmanagedAccessMethods => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessMethods UnmanagedAccessMethods { get; }
    }
}
