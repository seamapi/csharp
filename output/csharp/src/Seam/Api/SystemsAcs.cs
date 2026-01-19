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
    public class SystemsAcs
    {
        private ISeamClient _seam;

        public SystemsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsSystemId = default)
            {
                AcsSystemId = acsSystemId;
            }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

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

            public GetResponse(AcsSystem acsSystem = default)
            {
                AcsSystem = acsSystem;
            }

            [DataMember(Name = "acs_system", IsRequired = false, EmitDefaultValue = false)]
            public AcsSystem AcsSystem { get; set; }

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

        public AcsSystem Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/systems/get", requestOptions).Data.AcsSystem;
        }

        public AcsSystem Get(string acsSystemId = default)
        {
            return Get(new GetRequest(acsSystemId: acsSystemId));
        }

        public async Task<AcsSystem> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/systems/get", requestOptions))
                .Data
                .AcsSystem;
        }

        public async Task<AcsSystem> GetAsync(string acsSystemId = default)
        {
            return (await GetAsync(new GetRequest(acsSystemId: acsSystemId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string? connectedAccountId = default, string? customerKey = default)
            {
                ConnectedAccountId = connectedAccountId;
                CustomerKey = customerKey;
            }

            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

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

            public ListResponse(List<AcsSystem> acsSystems = default)
            {
                AcsSystems = acsSystems;
            }

            [DataMember(Name = "acs_systems", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsSystem> AcsSystems { get; set; }

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

        public List<AcsSystem> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/acs/systems/list", requestOptions).Data.AcsSystems;
        }

        public List<AcsSystem> List(
            string? connectedAccountId = default,
            string? customerKey = default
        )
        {
            return List(
                new ListRequest(connectedAccountId: connectedAccountId, customerKey: customerKey)
            );
        }

        public async Task<List<AcsSystem>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/systems/list", requestOptions))
                .Data
                .AcsSystems;
        }

        public async Task<List<AcsSystem>> ListAsync(
            string? connectedAccountId = default,
            string? customerKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectedAccountId: connectedAccountId,
                        customerKey: customerKey
                    )
                )
            );
        }

        [DataContract(Name = "listCompatibleCredentialManagerAcsSystemsRequest_request")]
        public class ListCompatibleCredentialManagerAcsSystemsRequest
        {
            [JsonConstructorAttribute]
            protected ListCompatibleCredentialManagerAcsSystemsRequest() { }

            public ListCompatibleCredentialManagerAcsSystemsRequest(string acsSystemId = default)
            {
                AcsSystemId = acsSystemId;
            }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

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

        [DataContract(Name = "listCompatibleCredentialManagerAcsSystemsResponse_response")]
        public class ListCompatibleCredentialManagerAcsSystemsResponse
        {
            [JsonConstructorAttribute]
            protected ListCompatibleCredentialManagerAcsSystemsResponse() { }

            public ListCompatibleCredentialManagerAcsSystemsResponse(
                List<AcsSystem> acsSystems = default
            )
            {
                AcsSystems = acsSystems;
            }

            [DataMember(Name = "acs_systems", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsSystem> AcsSystems { get; set; }

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

        public List<AcsSystem> ListCompatibleCredentialManagerAcsSystems(
            ListCompatibleCredentialManagerAcsSystemsRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListCompatibleCredentialManagerAcsSystemsResponse>(
                    "/acs/systems/list_compatible_credential_manager_acs_systems",
                    requestOptions
                )
                .Data.AcsSystems;
        }

        public List<AcsSystem> ListCompatibleCredentialManagerAcsSystems(
            string acsSystemId = default
        )
        {
            return ListCompatibleCredentialManagerAcsSystems(
                new ListCompatibleCredentialManagerAcsSystemsRequest(acsSystemId: acsSystemId)
            );
        }

        public async Task<List<AcsSystem>> ListCompatibleCredentialManagerAcsSystemsAsync(
            ListCompatibleCredentialManagerAcsSystemsRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListCompatibleCredentialManagerAcsSystemsResponse>(
                    "/acs/systems/list_compatible_credential_manager_acs_systems",
                    requestOptions
                )
            )
                .Data
                .AcsSystems;
        }

        public async Task<List<AcsSystem>> ListCompatibleCredentialManagerAcsSystemsAsync(
            string acsSystemId = default
        )
        {
            return (
                await ListCompatibleCredentialManagerAcsSystemsAsync(
                    new ListCompatibleCredentialManagerAcsSystemsRequest(acsSystemId: acsSystemId)
                )
            );
        }

        [DataContract(Name = "reportDevicesRequest_request")]
        public class ReportDevicesRequest
        {
            [JsonConstructorAttribute]
            protected ReportDevicesRequest() { }

            public ReportDevicesRequest(
                List<ReportDevicesRequestAcsEncoders>? acsEncoders = default,
                List<ReportDevicesRequestAcsEntrances>? acsEntrances = default,
                string acsSystemId = default
            )
            {
                AcsEncoders = acsEncoders;
                AcsEntrances = acsEntrances;
                AcsSystemId = acsSystemId;
            }

            [DataMember(Name = "acs_encoders", IsRequired = false, EmitDefaultValue = false)]
            public List<ReportDevicesRequestAcsEncoders>? AcsEncoders { get; set; }

            [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
            public List<ReportDevicesRequestAcsEntrances>? AcsEntrances { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsSystemId { get; set; }

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

        [DataContract(Name = "reportDevicesRequestAcsEncoders_model")]
        public class ReportDevicesRequestAcsEncoders
        {
            [JsonConstructorAttribute]
            protected ReportDevicesRequestAcsEncoders() { }

            public ReportDevicesRequestAcsEncoders(
                ReportDevicesRequestAcsEncodersHotekMetadata hotekMetadata = default,
                bool? isRemoved = default
            )
            {
                HotekMetadata = hotekMetadata;
                IsRemoved = isRemoved;
            }

            [DataMember(Name = "hotek_metadata", IsRequired = true, EmitDefaultValue = false)]
            public ReportDevicesRequestAcsEncodersHotekMetadata HotekMetadata { get; set; }

            [DataMember(Name = "is_removed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsRemoved { get; set; }

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

        [DataContract(Name = "reportDevicesRequestAcsEncodersHotekMetadata_model")]
        public class ReportDevicesRequestAcsEncodersHotekMetadata
        {
            [JsonConstructorAttribute]
            protected ReportDevicesRequestAcsEncodersHotekMetadata() { }

            public ReportDevicesRequestAcsEncodersHotekMetadata(string encoderNumber = default)
            {
                EncoderNumber = encoderNumber;
            }

            [DataMember(Name = "encoder_number", IsRequired = true, EmitDefaultValue = false)]
            public string EncoderNumber { get; set; }

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

        [DataContract(Name = "reportDevicesRequestAcsEntrances_model")]
        public class ReportDevicesRequestAcsEntrances
        {
            [JsonConstructorAttribute]
            protected ReportDevicesRequestAcsEntrances() { }

            public ReportDevicesRequestAcsEntrances(
                ReportDevicesRequestAcsEntrancesHotekMetadata hotekMetadata = default,
                bool? isRemoved = default
            )
            {
                HotekMetadata = hotekMetadata;
                IsRemoved = isRemoved;
            }

            [DataMember(Name = "hotek_metadata", IsRequired = true, EmitDefaultValue = false)]
            public ReportDevicesRequestAcsEntrancesHotekMetadata HotekMetadata { get; set; }

            [DataMember(Name = "is_removed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsRemoved { get; set; }

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

        [DataContract(Name = "reportDevicesRequestAcsEntrancesHotekMetadata_model")]
        public class ReportDevicesRequestAcsEntrancesHotekMetadata
        {
            [JsonConstructorAttribute]
            protected ReportDevicesRequestAcsEntrancesHotekMetadata() { }

            public ReportDevicesRequestAcsEntrancesHotekMetadata(
                string? commonAreaName = default,
                string? commonAreaNumber = default,
                string? roomNumber = default
            )
            {
                CommonAreaName = commonAreaName;
                CommonAreaNumber = commonAreaNumber;
                RoomNumber = roomNumber;
            }

            [DataMember(Name = "common_area_name", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaName { get; set; }

            [DataMember(Name = "common_area_number", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaNumber { get; set; }

            [DataMember(Name = "room_number", IsRequired = false, EmitDefaultValue = false)]
            public string? RoomNumber { get; set; }

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

        public void ReportDevices(ReportDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/systems/report_devices", requestOptions);
        }

        public void ReportDevices(
            List<ReportDevicesRequestAcsEncoders>? acsEncoders = default,
            List<ReportDevicesRequestAcsEntrances>? acsEntrances = default,
            string acsSystemId = default
        )
        {
            ReportDevices(
                new ReportDevicesRequest(
                    acsEncoders: acsEncoders,
                    acsEntrances: acsEntrances,
                    acsSystemId: acsSystemId
                )
            );
        }

        public async Task ReportDevicesAsync(ReportDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/systems/report_devices", requestOptions);
        }

        public async Task ReportDevicesAsync(
            List<ReportDevicesRequestAcsEncoders>? acsEncoders = default,
            List<ReportDevicesRequestAcsEntrances>? acsEntrances = default,
            string acsSystemId = default
        )
        {
            await ReportDevicesAsync(
                new ReportDevicesRequest(
                    acsEncoders: acsEncoders,
                    acsEntrances: acsEntrances,
                    acsSystemId: acsSystemId
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SystemsAcs SystemsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SystemsAcs SystemsAcs { get; }
    }
}
