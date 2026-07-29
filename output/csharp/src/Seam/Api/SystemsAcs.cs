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

        /// <summary>
        /// Request parameters for Get an ACS System.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsSystemId = default)
            {
                AcsSystemId = acsSystemId;
            }

            /// <summary>
            /// ID of the access system that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        public AcsSystem Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/systems/get", requestOptions).Data.AcsSystem;
        }

        /// <summary>
        /// Returns a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        public AcsSystem Get(string acsSystemId = default)
        {
            return Get(new GetRequest(acsSystemId: acsSystemId));
        }

        /// <summary>
        /// Returns a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        public async Task<AcsSystem> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/systems/get", requestOptions))
                .Data
                .AcsSystem;
        }

        /// <summary>
        /// Returns a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        /// </summary>
        public async Task<AcsSystem> GetAsync(string acsSystemId = default)
        {
            return (await GetAsync(new GetRequest(acsSystemId: acsSystemId)));
        }

        /// <summary>
        /// Request parameters for List ACS Systems.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? connectedAccountId = default,
                string? customerKey = default,
                string? search = default
            )
            {
                ConnectedAccountId = connectedAccountId;
                CustomerKey = customerKey;
                Search = search;
            }

            /// <summary>
            /// ID of the connected account by which you want to filter the list of access systems.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Customer key for which you want to list access systems.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// String for which to search. Filters returned access systems to include all records that satisfy a partial match using `name` or `acs_system_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// To filter the list of returned access systems by a specific connected account ID, include the `connected_account_id` in the request body. If you omit the `connected_account_id` parameter, the response includes all access systems connected to your workspace.
        /// </summary>
        public List<AcsSystem> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/acs/systems/list", requestOptions).Data.AcsSystems;
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// To filter the list of returned access systems by a specific connected account ID, include the `connected_account_id` in the request body. If you omit the `connected_account_id` parameter, the response includes all access systems connected to your workspace.
        /// </summary>
        public List<AcsSystem> List(
            string? connectedAccountId = default,
            string? customerKey = default,
            string? search = default
        )
        {
            return List(
                new ListRequest(
                    connectedAccountId: connectedAccountId,
                    customerKey: customerKey,
                    search: search
                )
            );
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// To filter the list of returned access systems by a specific connected account ID, include the `connected_account_id` in the request body. If you omit the `connected_account_id` parameter, the response includes all access systems connected to your workspace.
        /// </summary>
        public async Task<List<AcsSystem>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/systems/list", requestOptions))
                .Data
                .AcsSystems;
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// To filter the list of returned access systems by a specific connected account ID, include the `connected_account_id` in the request body. If you omit the `connected_account_id` parameter, the response includes all access systems connected to your workspace.
        /// </summary>
        public async Task<List<AcsSystem>> ListAsync(
            string? connectedAccountId = default,
            string? customerKey = default,
            string? search = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        connectedAccountId: connectedAccountId,
                        customerKey: customerKey,
                        search: search
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Compatible Credential Manager ACS Systems.
        /// </summary>
        [DataContract(Name = "listCompatibleCredentialManagerAcsSystemsRequest_request")]
        public class ListCompatibleCredentialManagerAcsSystemsRequest
        {
            [JsonConstructorAttribute]
            protected ListCompatibleCredentialManagerAcsSystemsRequest() { }

            public ListCompatibleCredentialManagerAcsSystemsRequest(string acsSystemId = default)
            {
                AcsSystemId = acsSystemId;
            }

            /// <summary>
            /// ID of the access system for which you want to retrieve all compatible credential manager systems.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all credential manager systems that are compatible with a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// Specify the access system for which you want to retrieve all compatible credential manager systems by including the corresponding `acs_system_id` in the request body.
        /// </summary>
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

        /// <summary>
        /// Returns a list of all credential manager systems that are compatible with a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// Specify the access system for which you want to retrieve all compatible credential manager systems by including the corresponding `acs_system_id` in the request body.
        /// </summary>
        public List<AcsSystem> ListCompatibleCredentialManagerAcsSystems(
            string acsSystemId = default
        )
        {
            return ListCompatibleCredentialManagerAcsSystems(
                new ListCompatibleCredentialManagerAcsSystemsRequest(acsSystemId: acsSystemId)
            );
        }

        /// <summary>
        /// Returns a list of all credential manager systems that are compatible with a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// Specify the access system for which you want to retrieve all compatible credential manager systems by including the corresponding `acs_system_id` in the request body.
        /// </summary>
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

        /// <summary>
        /// Returns a list of all credential manager systems that are compatible with a specified [access system](https://docs.seam.co/low-level-apis/access-systems).
        ///
        /// Specify the access system for which you want to retrieve all compatible credential manager systems by including the corresponding `acs_system_id` in the request body.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Report Devices.
        /// </summary>
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

            /// <summary>
            /// Array of ACS encoders to report
            /// </summary>
            [DataMember(Name = "acs_encoders", IsRequired = false, EmitDefaultValue = false)]
            public List<ReportDevicesRequestAcsEncoders>? AcsEncoders { get; set; }

            /// <summary>
            /// Array of ACS entrances to report
            /// </summary>
            [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
            public List<ReportDevicesRequestAcsEntrances>? AcsEntrances { get; set; }

            /// <summary>
            /// ID of the ACS system to report resources for
            /// </summary>
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
                ReportDevicesRequestAcsEncodersHotekMetadata? hotekMetadata = default,
                bool? isRemoved = default
            )
            {
                HotekMetadata = hotekMetadata;
                IsRemoved = isRemoved;
            }

            /// <summary>
            /// Hotek-specific metadata associated with the entrance.
            /// </summary>
            [DataMember(Name = "hotek_metadata", IsRequired = false, EmitDefaultValue = false)]
            public ReportDevicesRequestAcsEncodersHotekMetadata? HotekMetadata { get; set; }

            /// <summary>
            /// Whether the encoder is removed
            /// </summary>
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

            public ReportDevicesRequestAcsEncodersHotekMetadata(string? encoderNumber = default)
            {
                EncoderNumber = encoderNumber;
            }

            /// <summary>
            /// The encoder number determined by the USB port connection.
            /// </summary>
            [DataMember(Name = "encoder_number", IsRequired = false, EmitDefaultValue = false)]
            public string? EncoderNumber { get; set; }

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
                ReportDevicesRequestAcsEntrancesHotekMetadata? hotekMetadata = default,
                bool? isRemoved = default
            )
            {
                HotekMetadata = hotekMetadata;
                IsRemoved = isRemoved;
            }

            /// <summary>
            /// Hotek-specific metadata associated with the entrance.
            /// </summary>
            [DataMember(Name = "hotek_metadata", IsRequired = false, EmitDefaultValue = false)]
            public ReportDevicesRequestAcsEntrancesHotekMetadata? HotekMetadata { get; set; }

            /// <summary>
            /// Whether the entrance is removed
            /// </summary>
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

            /// <summary>
            /// The common area name
            /// </summary>
            [DataMember(Name = "common_area_name", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaName { get; set; }

            /// <summary>
            /// The room number identifier
            /// </summary>
            [DataMember(Name = "common_area_number", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonAreaNumber { get; set; }

            /// <summary>
            /// The room number identifier
            /// </summary>
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

        /// <summary>
        /// Reports ACS system device status including encoders and entrances.
        /// </summary>
        public void ReportDevices(ReportDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/systems/report_devices", requestOptions);
        }

        /// <summary>
        /// Reports ACS system device status including encoders and entrances.
        /// </summary>
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

        /// <summary>
        /// Reports ACS system device status including encoders and entrances.
        /// </summary>
        public async Task ReportDevicesAsync(ReportDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/systems/report_devices", requestOptions);
        }

        /// <summary>
        /// Reports ACS system device status including encoders and entrances.
        /// </summary>
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
