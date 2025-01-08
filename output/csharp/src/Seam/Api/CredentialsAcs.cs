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
    public class CredentialsAcs
    {
        private ISeamClient _seam;

        public CredentialsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "assignRequest_request")]
        public class AssignRequest
        {
            [JsonConstructorAttribute]
            protected AssignRequest() { }

            public AssignRequest(string acsCredentialId = default, string acsUserId = default)
            {
                AcsCredentialId = acsCredentialId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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

        public void Assign(AssignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/credentials/assign", requestOptions);
        }

        public void Assign(string acsCredentialId = default, string acsUserId = default)
        {
            Assign(new AssignRequest(acsCredentialId: acsCredentialId, acsUserId: acsUserId));
        }

        public async Task AssignAsync(AssignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/credentials/assign", requestOptions);
        }

        public async Task AssignAsync(string acsCredentialId = default, string acsUserId = default)
        {
            await AssignAsync(
                new AssignRequest(acsCredentialId: acsCredentialId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                CreateRequest.AccessMethodEnum accessMethod = default,
                string acsUserId = default,
                List<string>? allowedAcsEntranceIds = default,
                CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
                string? code = default,
                string? credentialManagerAcsSystemId = default,
                string? endsAt = default,
                bool? isMultiPhoneSyncCredential = default,
                CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
                string? startsAt = default,
                CreateRequestVisionlineMetadata? visionlineMetadata = default
            )
            {
                AccessMethod = accessMethod;
                AcsUserId = acsUserId;
                AllowedAcsEntranceIds = allowedAcsEntranceIds;
                AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
                Code = code;
                CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
                EndsAt = endsAt;
                IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
                SaltoSpaceMetadata = saltoSpaceMetadata;
                StartsAt = startsAt;
                VisionlineMetadata = visionlineMetadata;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum AccessMethodEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "code")]
                Code = 1,

                [EnumMember(Value = "card")]
                Card = 2,

                [EnumMember(Value = "mobile_key")]
                MobileKey = 3,
            }

            [DataMember(Name = "access_method", IsRequired = true, EmitDefaultValue = false)]
            public CreateRequest.AccessMethodEnum AccessMethod { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(
                Name = "allowed_acs_entrance_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? AllowedAcsEntranceIds { get; set; }

            [DataMember(
                Name = "assa_abloy_vostio_metadata",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequestAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(
                Name = "credential_manager_acs_system_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CredentialManagerAcsSystemId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(
                Name = "is_multi_phone_sync_credential",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsMultiPhoneSyncCredential { get; set; }

            [DataMember(
                Name = "salto_space_metadata",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequestSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "visionline_metadata", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestVisionlineMetadata? VisionlineMetadata { get; set; }

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

        [DataContract(Name = "createRequestAssaAbloyVostioMetadata_model")]
        public class CreateRequestAssaAbloyVostioMetadata
        {
            [JsonConstructorAttribute]
            protected CreateRequestAssaAbloyVostioMetadata() { }

            public CreateRequestAssaAbloyVostioMetadata(
                bool? joinAllGuestAcsEntrances = default,
                bool? overrideAllGuestAcsEntrances = default,
                List<string>? overrideGuestAcsEntranceIds = default
            )
            {
                JoinAllGuestAcsEntrances = joinAllGuestAcsEntrances;
                OverrideAllGuestAcsEntrances = overrideAllGuestAcsEntrances;
                OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
            }

            [DataMember(
                Name = "join_all_guest_acs_entrances",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? JoinAllGuestAcsEntrances { get; set; }

            [DataMember(
                Name = "override_all_guest_acs_entrances",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? OverrideAllGuestAcsEntrances { get; set; }

            [DataMember(
                Name = "override_guest_acs_entrance_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? OverrideGuestAcsEntranceIds { get; set; }

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

        [DataContract(Name = "createRequestSaltoSpaceMetadata_model")]
        public class CreateRequestSaltoSpaceMetadata
        {
            [JsonConstructorAttribute]
            protected CreateRequestSaltoSpaceMetadata() { }

            public CreateRequestSaltoSpaceMetadata(
                bool? assignNewKey = default,
                bool? updateCurrentKey = default
            )
            {
                AssignNewKey = assignNewKey;
                UpdateCurrentKey = updateCurrentKey;
            }

            [DataMember(Name = "assign_new_key", IsRequired = false, EmitDefaultValue = false)]
            public bool? AssignNewKey { get; set; }

            [DataMember(Name = "update_current_key", IsRequired = false, EmitDefaultValue = false)]
            public bool? UpdateCurrentKey { get; set; }

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

        [DataContract(Name = "createRequestVisionlineMetadata_model")]
        public class CreateRequestVisionlineMetadata
        {
            [JsonConstructorAttribute]
            protected CreateRequestVisionlineMetadata() { }

            public CreateRequestVisionlineMetadata(
                string? assaAbloyCredentialServiceMobileEndpointId = default,
                bool? autoJoin = default,
                CreateRequestVisionlineMetadata.CardFormatEnum? cardFormat = default,
                CreateRequestVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType = default,
                bool? isOverrideKey = default,
                List<string>? joinerAcsCredentialIds = default,
                bool? mustOverride = default
            )
            {
                AssaAbloyCredentialServiceMobileEndpointId =
                    assaAbloyCredentialServiceMobileEndpointId;
                AutoJoin = autoJoin;
                CardFormat = cardFormat;
                CardFunctionType = cardFunctionType;
                IsOverrideKey = isOverrideKey;
                JoinerAcsCredentialIds = joinerAcsCredentialIds;
                Override = mustOverride;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum CardFormatEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "TLCode")]
                TlCode = 1,

                [EnumMember(Value = "rfid48")]
                Rfid48 = 2,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum CardFunctionTypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "guest")]
                Guest = 1,

                [EnumMember(Value = "staff")]
                Staff = 2,
            }

            [DataMember(
                Name = "assa_abloy_credential_service_mobile_endpoint_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? AssaAbloyCredentialServiceMobileEndpointId { get; set; }

            [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
            public bool? AutoJoin { get; set; }

            [DataMember(Name = "card_format", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestVisionlineMetadata.CardFormatEnum? CardFormat { get; set; }

            [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

            [DataMember(Name = "is_override_key", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOverrideKey { get; set; }

            [DataMember(
                Name = "joiner_acs_credential_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? JoinerAcsCredentialIds { get; set; }

            [DataMember(Name = "override", IsRequired = false, EmitDefaultValue = false)]
            public bool? Override { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(AcsCredential acsCredential = default)
            {
                AcsCredential = acsCredential;
            }

            [DataMember(Name = "acs_credential", IsRequired = false, EmitDefaultValue = false)]
            public AcsCredential AcsCredential { get; set; }

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

        public AcsCredential Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/acs/credentials/create", requestOptions)
                .Data.AcsCredential;
        }

        public AcsCredential Create(
            CreateRequest.AccessMethodEnum accessMethod = default,
            string acsUserId = default,
            List<string>? allowedAcsEntranceIds = default,
            CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? code = default,
            string? credentialManagerAcsSystemId = default,
            string? endsAt = default,
            bool? isMultiPhoneSyncCredential = default,
            CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
            string? startsAt = default,
            CreateRequestVisionlineMetadata? visionlineMetadata = default
        )
        {
            return Create(
                new CreateRequest(
                    accessMethod: accessMethod,
                    acsUserId: acsUserId,
                    allowedAcsEntranceIds: allowedAcsEntranceIds,
                    assaAbloyVostioMetadata: assaAbloyVostioMetadata,
                    code: code,
                    credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                    endsAt: endsAt,
                    isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                    saltoSpaceMetadata: saltoSpaceMetadata,
                    startsAt: startsAt,
                    visionlineMetadata: visionlineMetadata
                )
            );
        }

        public async Task<AcsCredential> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/acs/credentials/create", requestOptions)
            )
                .Data
                .AcsCredential;
        }

        public async Task<AcsCredential> CreateAsync(
            CreateRequest.AccessMethodEnum accessMethod = default,
            string acsUserId = default,
            List<string>? allowedAcsEntranceIds = default,
            CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? code = default,
            string? credentialManagerAcsSystemId = default,
            string? endsAt = default,
            bool? isMultiPhoneSyncCredential = default,
            CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
            string? startsAt = default,
            CreateRequestVisionlineMetadata? visionlineMetadata = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        accessMethod: accessMethod,
                        acsUserId: acsUserId,
                        allowedAcsEntranceIds: allowedAcsEntranceIds,
                        assaAbloyVostioMetadata: assaAbloyVostioMetadata,
                        code: code,
                        credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                        endsAt: endsAt,
                        isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                        saltoSpaceMetadata: saltoSpaceMetadata,
                        startsAt: startsAt,
                        visionlineMetadata: visionlineMetadata
                    )
                )
            );
        }

        [DataContract(Name = "createOfflineCodeRequest_request")]
        public class CreateOfflineCodeRequest
        {
            [JsonConstructorAttribute]
            protected CreateOfflineCodeRequest() { }

            public CreateOfflineCodeRequest(
                string acsUserId = default,
                string allowedAcsEntranceId = default,
                string? endsAt = default,
                bool? isOneTimeUse = default,
                string? startsAt = default
            )
            {
                AcsUserId = acsUserId;
                AllowedAcsEntranceId = allowedAcsEntranceId;
                EndsAt = endsAt;
                IsOneTimeUse = isOneTimeUse;
                StartsAt = startsAt;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(
                Name = "allowed_acs_entrance_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string AllowedAcsEntranceId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOneTimeUse { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

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

        [DataContract(Name = "createOfflineCodeResponse_response")]
        public class CreateOfflineCodeResponse
        {
            [JsonConstructorAttribute]
            protected CreateOfflineCodeResponse() { }

            public CreateOfflineCodeResponse(AcsCredential acsCredential = default)
            {
                AcsCredential = acsCredential;
            }

            [DataMember(Name = "acs_credential", IsRequired = false, EmitDefaultValue = false)]
            public AcsCredential AcsCredential { get; set; }

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

        public AcsCredential CreateOfflineCode(CreateOfflineCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateOfflineCodeResponse>(
                    "/acs/credentials/create_offline_code",
                    requestOptions
                )
                .Data.AcsCredential;
        }

        public AcsCredential CreateOfflineCode(
            string acsUserId = default,
            string allowedAcsEntranceId = default,
            string? endsAt = default,
            bool? isOneTimeUse = default,
            string? startsAt = default
        )
        {
            return CreateOfflineCode(
                new CreateOfflineCodeRequest(
                    acsUserId: acsUserId,
                    allowedAcsEntranceId: allowedAcsEntranceId,
                    endsAt: endsAt,
                    isOneTimeUse: isOneTimeUse,
                    startsAt: startsAt
                )
            );
        }

        public async Task<AcsCredential> CreateOfflineCodeAsync(CreateOfflineCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateOfflineCodeResponse>(
                    "/acs/credentials/create_offline_code",
                    requestOptions
                )
            )
                .Data
                .AcsCredential;
        }

        public async Task<AcsCredential> CreateOfflineCodeAsync(
            string acsUserId = default,
            string allowedAcsEntranceId = default,
            string? endsAt = default,
            bool? isOneTimeUse = default,
            string? startsAt = default
        )
        {
            return (
                await CreateOfflineCodeAsync(
                    new CreateOfflineCodeRequest(
                        acsUserId: acsUserId,
                        allowedAcsEntranceId: allowedAcsEntranceId,
                        endsAt: endsAt,
                        isOneTimeUse: isOneTimeUse,
                        startsAt: startsAt
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

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
            _seam.Post<object>("/acs/credentials/delete", requestOptions);
        }

        public void Delete(string acsCredentialId = default)
        {
            Delete(new DeleteRequest(acsCredentialId: acsCredentialId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/credentials/delete", requestOptions);
        }

        public async Task DeleteAsync(string acsCredentialId = default)
        {
            await DeleteAsync(new DeleteRequest(acsCredentialId: acsCredentialId));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

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

            public GetResponse(AcsCredential acsCredential = default)
            {
                AcsCredential = acsCredential;
            }

            [DataMember(Name = "acs_credential", IsRequired = false, EmitDefaultValue = false)]
            public AcsCredential AcsCredential { get; set; }

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

        public AcsCredential Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/acs/credentials/get", requestOptions)
                .Data.AcsCredential;
        }

        public AcsCredential Get(string acsCredentialId = default)
        {
            return Get(new GetRequest(acsCredentialId: acsCredentialId));
        }

        public async Task<AcsCredential> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/acs/credentials/get", requestOptions))
                .Data
                .AcsCredential;
        }

        public async Task<AcsCredential> GetAsync(string acsCredentialId = default)
        {
            return (await GetAsync(new GetRequest(acsCredentialId: acsCredentialId)));
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsUserId = default,
                string? acsSystemId = default,
                string? userIdentityId = default,
                string? createdBefore = default,
                bool? isMultiPhoneSyncCredential = default,
                float? limit = default
            )
            {
                AcsUserId = acsUserId;
                AcsSystemId = acsSystemId;
                UserIdentityId = userIdentityId;
                CreatedBefore = createdBefore;
                IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
                Limit = limit;
            }

            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            [DataMember(
                Name = "is_multi_phone_sync_credential",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsMultiPhoneSyncCredential { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

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

            public ListResponse(List<AcsCredential> acsCredentials = default)
            {
                AcsCredentials = acsCredentials;
            }

            [DataMember(Name = "acs_credentials", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsCredential> AcsCredentials { get; set; }

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

        public List<AcsCredential> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/acs/credentials/list", requestOptions)
                .Data.AcsCredentials;
        }

        public List<AcsCredential> List(
            string? acsUserId = default,
            string? acsSystemId = default,
            string? userIdentityId = default,
            string? createdBefore = default,
            bool? isMultiPhoneSyncCredential = default,
            float? limit = default
        )
        {
            return List(
                new ListRequest(
                    acsUserId: acsUserId,
                    acsSystemId: acsSystemId,
                    userIdentityId: userIdentityId,
                    createdBefore: createdBefore,
                    isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                    limit: limit
                )
            );
        }

        public async Task<List<AcsCredential>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/acs/credentials/list", requestOptions))
                .Data
                .AcsCredentials;
        }

        public async Task<List<AcsCredential>> ListAsync(
            string? acsUserId = default,
            string? acsSystemId = default,
            string? userIdentityId = default,
            string? createdBefore = default,
            bool? isMultiPhoneSyncCredential = default,
            float? limit = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsUserId: acsUserId,
                        acsSystemId: acsSystemId,
                        userIdentityId: userIdentityId,
                        createdBefore: createdBefore,
                        isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                        limit: limit
                    )
                )
            );
        }

        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

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

        [DataContract(Name = "listAccessibleEntrancesResponse_response")]
        public class ListAccessibleEntrancesResponse
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesResponse() { }

            public ListAccessibleEntrancesResponse(List<AcsEntrance> acsEntrances = default)
            {
                AcsEntrances = acsEntrances;
            }

            [DataMember(Name = "acs_entrances", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsEntrance> AcsEntrances { get; set; }

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

        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleEntrancesResponse>(
                    "/acs/credentials/list_accessible_entrances",
                    requestOptions
                )
                .Data.AcsEntrances;
        }

        public List<AcsEntrance> ListAccessibleEntrances(string acsCredentialId = default)
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(acsCredentialId: acsCredentialId)
            );
        }

        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            ListAccessibleEntrancesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAccessibleEntrancesResponse>(
                    "/acs/credentials/list_accessible_entrances",
                    requestOptions
                )
            )
                .Data
                .AcsEntrances;
        }

        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            string acsCredentialId = default
        )
        {
            return (
                await ListAccessibleEntrancesAsync(
                    new ListAccessibleEntrancesRequest(acsCredentialId: acsCredentialId)
                )
            );
        }

        [DataContract(Name = "unassignRequest_request")]
        public class UnassignRequest
        {
            [JsonConstructorAttribute]
            protected UnassignRequest() { }

            public UnassignRequest(string acsCredentialId = default, string acsUserId = default)
            {
                AcsCredentialId = acsCredentialId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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

        public void Unassign(UnassignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/credentials/unassign", requestOptions);
        }

        public void Unassign(string acsCredentialId = default, string acsUserId = default)
        {
            Unassign(new UnassignRequest(acsCredentialId: acsCredentialId, acsUserId: acsUserId));
        }

        public async Task UnassignAsync(UnassignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/credentials/unassign", requestOptions);
        }

        public async Task UnassignAsync(
            string acsCredentialId = default,
            string acsUserId = default
        )
        {
            await UnassignAsync(
                new UnassignRequest(acsCredentialId: acsCredentialId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string acsCredentialId = default,
                string? code = default,
                string? endsAt = default
            )
            {
                AcsCredentialId = acsCredentialId;
                Code = code;
                EndsAt = endsAt;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/credentials/update", requestOptions);
        }

        public void Update(
            string acsCredentialId = default,
            string? code = default,
            string? endsAt = default
        )
        {
            Update(new UpdateRequest(acsCredentialId: acsCredentialId, code: code, endsAt: endsAt));
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/credentials/update", requestOptions);
        }

        public async Task UpdateAsync(
            string acsCredentialId = default,
            string? code = default,
            string? endsAt = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(acsCredentialId: acsCredentialId, code: code, endsAt: endsAt)
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.CredentialsAcs CredentialsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.CredentialsAcs CredentialsAcs { get; }
    }
}
