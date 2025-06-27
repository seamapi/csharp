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
    public class EncodersAcs
    {
        private ISeamClient _seam;

        public EncodersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "encodeCredentialRequest_request")]
        public class EncodeCredentialRequest
        {
            [JsonConstructorAttribute]
            protected EncodeCredentialRequest() { }

            public EncodeCredentialRequest(
                string? accessMethodId = default,
                string? acsCredentialId = default,
                string acsEncoderId = default
            )
            {
                AccessMethodId = accessMethodId;
                AcsCredentialId = acsCredentialId;
                AcsEncoderId = acsEncoderId;
            }

            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

        [DataContract(Name = "encodeCredentialResponse_response")]
        public class EncodeCredentialResponse
        {
            [JsonConstructorAttribute]
            protected EncodeCredentialResponse() { }

            public EncodeCredentialResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt EncodeCredential(EncodeCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<EncodeCredentialResponse>("/acs/encoders/encode_credential", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt EncodeCredential(
            string? accessMethodId = default,
            string? acsCredentialId = default,
            string acsEncoderId = default
        )
        {
            return EncodeCredential(
                new EncodeCredentialRequest(
                    accessMethodId: accessMethodId,
                    acsCredentialId: acsCredentialId,
                    acsEncoderId: acsEncoderId
                )
            );
        }

        public async Task<ActionAttempt> EncodeCredentialAsync(EncodeCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<EncodeCredentialResponse>(
                    "/acs/encoders/encode_credential",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> EncodeCredentialAsync(
            string? accessMethodId = default,
            string? acsCredentialId = default,
            string acsEncoderId = default
        )
        {
            return (
                await EncodeCredentialAsync(
                    new EncodeCredentialRequest(
                        accessMethodId: accessMethodId,
                        acsCredentialId: acsCredentialId,
                        acsEncoderId: acsEncoderId
                    )
                )
            );
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsEncoderId = default)
            {
                AcsEncoderId = acsEncoderId;
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

            public GetResponse(AcsEncoder acsEncoder = default)
            {
                AcsEncoder = acsEncoder;
            }

            [DataMember(Name = "acs_encoder", IsRequired = false, EmitDefaultValue = false)]
            public AcsEncoder AcsEncoder { get; set; }

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

        public AcsEncoder Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/acs/encoders/get", requestOptions).Data.AcsEncoder;
        }

        public AcsEncoder Get(string acsEncoderId = default)
        {
            return Get(new GetRequest(acsEncoderId: acsEncoderId));
        }

        public async Task<AcsEncoder> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/encoders/get", requestOptions))
                .Data
                .AcsEncoder;
        }

        public async Task<AcsEncoder> GetAsync(string acsEncoderId = default)
        {
            return (await GetAsync(new GetRequest(acsEncoderId: acsEncoderId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsSystemId = default,
                float? limit = default,
                List<string>? acsSystemIds = default,
                List<string>? acsEncoderIds = default
            )
            {
                AcsSystemId = acsSystemId;
                Limit = limit;
                AcsSystemIds = acsSystemIds;
                AcsEncoderIds = acsEncoderIds;
            }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

            [DataMember(Name = "acs_encoder_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEncoderIds { get; set; }

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

            public ListResponse(List<AcsEncoder> acsEncoders = default)
            {
                AcsEncoders = acsEncoders;
            }

            [DataMember(Name = "acs_encoders", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsEncoder> AcsEncoders { get; set; }

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

        public List<AcsEncoder> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/acs/encoders/list", requestOptions).Data.AcsEncoders;
        }

        public List<AcsEncoder> List(
            string? acsSystemId = default,
            float? limit = default,
            List<string>? acsSystemIds = default,
            List<string>? acsEncoderIds = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    limit: limit,
                    acsSystemIds: acsSystemIds,
                    acsEncoderIds: acsEncoderIds
                )
            );
        }

        public async Task<List<AcsEncoder>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/encoders/list", requestOptions))
                .Data
                .AcsEncoders;
        }

        public async Task<List<AcsEncoder>> ListAsync(
            string? acsSystemId = default,
            float? limit = default,
            List<string>? acsSystemIds = default,
            List<string>? acsEncoderIds = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        limit: limit,
                        acsSystemIds: acsSystemIds,
                        acsEncoderIds: acsEncoderIds
                    )
                )
            );
        }

        [DataContract(Name = "scanCredentialRequest_request")]
        public class ScanCredentialRequest
        {
            [JsonConstructorAttribute]
            protected ScanCredentialRequest() { }

            public ScanCredentialRequest(string acsEncoderId = default)
            {
                AcsEncoderId = acsEncoderId;
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

        [DataContract(Name = "scanCredentialResponse_response")]
        public class ScanCredentialResponse
        {
            [JsonConstructorAttribute]
            protected ScanCredentialResponse() { }

            public ScanCredentialResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt ScanCredential(ScanCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ScanCredentialResponse>("/acs/encoders/scan_credential", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt ScanCredential(string acsEncoderId = default)
        {
            return ScanCredential(new ScanCredentialRequest(acsEncoderId: acsEncoderId));
        }

        public async Task<ActionAttempt> ScanCredentialAsync(ScanCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ScanCredentialResponse>(
                    "/acs/encoders/scan_credential",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ScanCredentialAsync(string acsEncoderId = default)
        {
            return (
                await ScanCredentialAsync(new ScanCredentialRequest(acsEncoderId: acsEncoderId))
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.EncodersAcs EncodersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EncodersAcs EncodersAcs { get; }
    }
}
