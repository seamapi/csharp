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

        /// <summary>
        /// Request parameters for Encode a Credential.
        /// </summary>
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

            /// <summary>
            /// ID of the `access_method` to encode onto a card.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            /// <summary>
            /// ID of the `acs_credential` to encode onto a card.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the `acs_encoder` to use to encode the `acs_credential`.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Encodes an existing [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners). Either provide an `acs_credential_id` or an `access_method_id`
        /// </summary>
        public ActionAttempt EncodeCredential(EncodeCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<EncodeCredentialResponse>("/acs/encoders/encode_credential", requestOptions)
                .EnsureData("/acs/encoders/encode_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Encodes an existing [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners). Either provide an `acs_credential_id` or an `access_method_id`
        /// </summary>
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

        /// <summary>
        /// Encodes an existing [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners). Either provide an `acs_credential_id` or an `access_method_id`
        /// </summary>
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
                .EnsureData("/acs/encoders/encode_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Encodes an existing [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners). Either provide an `acs_credential_id` or an `access_method_id`
        /// </summary>
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

        /// <summary>
        /// Request parameters for Get an Encoder.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsEncoderId = default)
            {
                AcsEncoderId = acsEncoderId;
            }

            /// <summary>
            /// ID of the encoder that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public AcsEncoder Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/acs/encoders/get", requestOptions)
                .EnsureData("/acs/encoders/get")
                .AcsEncoder;
        }

        /// <summary>
        /// Returns a specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public AcsEncoder Get(string acsEncoderId = default)
        {
            return Get(new GetRequest(acsEncoderId: acsEncoderId));
        }

        /// <summary>
        /// Returns a specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<AcsEncoder> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/acs/encoders/get", requestOptions))
                .EnsureData("/acs/encoders/get")
                .AcsEncoder;
        }

        /// <summary>
        /// Returns a specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<AcsEncoder> GetAsync(string acsEncoderId = default)
        {
            return (await GetAsync(new GetRequest(acsEncoderId: acsEncoderId)));
        }

        /// <summary>
        /// Request parameters for List Encoders.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                List<string>? acsEncoderIds = default,
                string? acsSystemId = default,
                List<string>? acsSystemIds = default,
                float? limit = default,
                string? pageCursor = default
            )
            {
                AcsEncoderIds = acsEncoderIds;
                AcsSystemId = acsSystemId;
                AcsSystemIds = acsSystemIds;
                Limit = limit;
                PageCursor = pageCursor;
            }

            /// <summary>
            /// IDs of the encoders that you want to retrieve.
            /// </summary>
            [DataMember(Name = "acs_encoder_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsEncoderIds { get; set; }

            /// <summary>
            /// ID of the access system for which you want to retrieve all encoders.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// IDs of the access systems for which you want to retrieve all encoders.
            /// </summary>
            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

            /// <summary>
            /// Number of encoders to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [encoders](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public List<AcsEncoder> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/acs/encoders/list", requestOptions)
                .EnsureData("/acs/encoders/list")
                .AcsEncoders;
        }

        /// <summary>
        /// Returns a list of all [encoders](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public List<AcsEncoder> List(
            List<string>? acsEncoderIds = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            float? limit = default,
            string? pageCursor = default
        )
        {
            return List(
                new ListRequest(
                    acsEncoderIds: acsEncoderIds,
                    acsSystemId: acsSystemId,
                    acsSystemIds: acsSystemIds,
                    limit: limit,
                    pageCursor: pageCursor
                )
            );
        }

        /// <summary>
        /// Returns a list of all [encoders](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<List<AcsEncoder>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/acs/encoders/list", requestOptions))
                .EnsureData("/acs/encoders/list")
                .AcsEncoders;
        }

        /// <summary>
        /// Returns a list of all [encoders](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<List<AcsEncoder>> ListAsync(
            List<string>? acsEncoderIds = default,
            string? acsSystemId = default,
            List<string>? acsSystemIds = default,
            float? limit = default,
            string? pageCursor = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsEncoderIds: acsEncoderIds,
                        acsSystemId: acsSystemId,
                        acsSystemIds: acsSystemIds,
                        limit: limit,
                        pageCursor: pageCursor
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Scan a Credential.
        /// </summary>
        [DataContract(Name = "scanCredentialRequest_request")]
        public class ScanCredentialRequest
        {
            [JsonConstructorAttribute]
            protected ScanCredentialRequest() { }

            public ScanCredentialRequest(
                string acsEncoderId = default,
                ScanCredentialRequestSaltoKsMetadata? saltoKsMetadata = default
            )
            {
                AcsEncoderId = acsEncoderId;
                SaltoKsMetadata = saltoKsMetadata;
            }

            /// <summary>
            /// ID of the encoder to use for the scan.
            /// </summary>
            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            /// <summary>
            /// Salto KS-specific metadata for the scan action.
            /// </summary>
            [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
            public ScanCredentialRequestSaltoKsMetadata? SaltoKsMetadata { get; set; }

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

        [DataContract(Name = "scanCredentialRequestSaltoKsMetadata_model")]
        public class ScanCredentialRequestSaltoKsMetadata
        {
            [JsonConstructorAttribute]
            protected ScanCredentialRequestSaltoKsMetadata() { }

            public ScanCredentialRequestSaltoKsMetadata(bool? detectNewTags = default)
            {
                DetectNewTags = detectNewTags;
            }

            /// <summary>
            /// When true, activates tag registration mode on the encoder to detect new, unregistered tags. When false, only detects existing tags already registered in the system. Defaults to false.
            /// </summary>
            [DataMember(Name = "detect_new_tags", IsRequired = false, EmitDefaultValue = false)]
            public bool? DetectNewTags { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Scans an encoded [acs_credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public ActionAttempt ScanCredential(ScanCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ScanCredentialResponse>("/acs/encoders/scan_credential", requestOptions)
                .EnsureData("/acs/encoders/scan_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Scans an encoded [acs_credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public ActionAttempt ScanCredential(
            string acsEncoderId = default,
            ScanCredentialRequestSaltoKsMetadata? saltoKsMetadata = default
        )
        {
            return ScanCredential(
                new ScanCredentialRequest(
                    acsEncoderId: acsEncoderId,
                    saltoKsMetadata: saltoKsMetadata
                )
            );
        }

        /// <summary>
        /// Scans an encoded [acs_credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
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
                .EnsureData("/acs/encoders/scan_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Scans an encoded [acs_credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<ActionAttempt> ScanCredentialAsync(
            string acsEncoderId = default,
            ScanCredentialRequestSaltoKsMetadata? saltoKsMetadata = default
        )
        {
            return (
                await ScanCredentialAsync(
                    new ScanCredentialRequest(
                        acsEncoderId: acsEncoderId,
                        saltoKsMetadata: saltoKsMetadata
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Scan to Assign a Credential.
        /// </summary>
        [DataContract(Name = "scanToAssignCredentialRequest_request")]
        public class ScanToAssignCredentialRequest
        {
            [JsonConstructorAttribute]
            protected ScanToAssignCredentialRequest() { }

            public ScanToAssignCredentialRequest(
                string acsEncoderId = default,
                string? acsUserId = default,
                ScanToAssignCredentialRequestSaltoKsMetadata? saltoKsMetadata = default,
                string? userIdentityId = default
            )
            {
                AcsEncoderId = acsEncoderId;
                AcsUserId = acsUserId;
                SaltoKsMetadata = saltoKsMetadata;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the `acs_encoder` to use to scan the credential.
            /// </summary>
            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            /// <summary>
            /// ID of the `acs_user` to assign the scanned credential to.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// Salto KS-specific metadata for the scan action.
            /// </summary>
            [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
            public ScanToAssignCredentialRequestSaltoKsMetadata? SaltoKsMetadata { get; set; }

            /// <summary>
            /// ID of the `user_identity` to assign the scanned credential to. If the ACS system contains an ACS user linked to this user identity, it is used. Otherwise, one is created.
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

        [DataContract(Name = "scanToAssignCredentialRequestSaltoKsMetadata_model")]
        public class ScanToAssignCredentialRequestSaltoKsMetadata
        {
            [JsonConstructorAttribute]
            protected ScanToAssignCredentialRequestSaltoKsMetadata() { }

            public ScanToAssignCredentialRequestSaltoKsMetadata(bool? detectNewTags = default)
            {
                DetectNewTags = detectNewTags;
            }

            /// <summary>
            /// When true, activates tag registration mode on the encoder to detect new, unregistered tags. When false, only detects existing tags already registered in the system. Defaults to false.
            /// </summary>
            [DataMember(Name = "detect_new_tags", IsRequired = false, EmitDefaultValue = false)]
            public bool? DetectNewTags { get; set; }

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

        [DataContract(Name = "scanToAssignCredentialResponse_response")]
        public class ScanToAssignCredentialResponse
        {
            [JsonConstructorAttribute]
            protected ScanToAssignCredentialResponse() { }

            public ScanToAssignCredentialResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Scans a physical card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) and assigns the scanned credential to an ACS user. Provide either an `acs_user_id` or a `user_identity_id`.
        /// </summary>
        public ActionAttempt ScanToAssignCredential(ScanToAssignCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ScanToAssignCredentialResponse>(
                    "/acs/encoders/scan_to_assign_credential",
                    requestOptions
                )
                .EnsureData("/acs/encoders/scan_to_assign_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Scans a physical card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) and assigns the scanned credential to an ACS user. Provide either an `acs_user_id` or a `user_identity_id`.
        /// </summary>
        public ActionAttempt ScanToAssignCredential(
            string acsEncoderId = default,
            string? acsUserId = default,
            ScanToAssignCredentialRequestSaltoKsMetadata? saltoKsMetadata = default,
            string? userIdentityId = default
        )
        {
            return ScanToAssignCredential(
                new ScanToAssignCredentialRequest(
                    acsEncoderId: acsEncoderId,
                    acsUserId: acsUserId,
                    saltoKsMetadata: saltoKsMetadata,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Scans a physical card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) and assigns the scanned credential to an ACS user. Provide either an `acs_user_id` or a `user_identity_id`.
        /// </summary>
        public async Task<ActionAttempt> ScanToAssignCredentialAsync(
            ScanToAssignCredentialRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ScanToAssignCredentialResponse>(
                    "/acs/encoders/scan_to_assign_credential",
                    requestOptions
                )
            )
                .EnsureData("/acs/encoders/scan_to_assign_credential")
                .ActionAttempt;
        }

        /// <summary>
        /// Scans a physical card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) and assigns the scanned credential to an ACS user. Provide either an `acs_user_id` or a `user_identity_id`.
        /// </summary>
        public async Task<ActionAttempt> ScanToAssignCredentialAsync(
            string acsEncoderId = default,
            string? acsUserId = default,
            ScanToAssignCredentialRequestSaltoKsMetadata? saltoKsMetadata = default,
            string? userIdentityId = default
        )
        {
            return (
                await ScanToAssignCredentialAsync(
                    new ScanToAssignCredentialRequest(
                        acsEncoderId: acsEncoderId,
                        acsUserId: acsUserId,
                        saltoKsMetadata: saltoKsMetadata,
                        userIdentityId: userIdentityId
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
        public Api.EncodersAcs EncodersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EncodersAcs EncodersAcs { get; }
    }
}
