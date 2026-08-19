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

        /// <summary>
        /// Request parameters for Assign a Credential to an ACS User.
        /// </summary>
        [DataContract(Name = "assignRequest_request")]
        public class AssignRequest
        {
            [JsonConstructorAttribute]
            protected AssignRequest() { }

            public AssignRequest(
                string acsCredentialId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsCredentialId = acsCredentialId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the credential that you want to assign to an access system user.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the access system user to whom you want to assign a credential. You can only provide one of acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity to whom you want to assign a credential. You can only provide one of acs_user_id or user_identity_id. If the ACS system contains an ACS user with the same `email_address` or `phone_number` as the user identity that you specify, they are linked, and the credential belongs to the ACS user. If the ACS system does not have a corresponding ACS user, one is created.
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

        /// <summary>
        /// Assigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) to a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Assign(AssignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/acs/credentials/assign", requestOptions);
        }

        /// <summary>
        /// Assigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) to a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Assign(
            string acsCredentialId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            Assign(
                new AssignRequest(
                    acsCredentialId: acsCredentialId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Assigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) to a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task AssignAsync(AssignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/acs/credentials/assign", requestOptions);
        }

        /// <summary>
        /// Assigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) to a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task AssignAsync(
            string acsCredentialId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await AssignAsync(
                new AssignRequest(
                    acsCredentialId: acsCredentialId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Create a Credential for an ACS User.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                CreateRequest.AccessMethodEnum accessMethod = default,
                string? acsSystemId = default,
                string? acsUserId = default,
                List<string>? allowedAcsEntranceIds = default,
                CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
                string? code = default,
                string? credentialManagerAcsSystemId = default,
                string? endsAt = default,
                bool? isMultiPhoneSyncCredential = default,
                CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
                string? startsAt = default,
                string? userIdentityId = default,
                CreateRequestVisionlineMetadata? visionlineMetadata = default
            )
            {
                AccessMethod = accessMethod;
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                AllowedAcsEntranceIds = allowedAcsEntranceIds;
                AssaAbloyVostioMetadata = assaAbloyVostioMetadata;
                Code = code;
                CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
                EndsAt = endsAt;
                IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
                SaltoSpaceMetadata = saltoSpaceMetadata;
                StartsAt = startsAt;
                UserIdentityId = userIdentityId;
                VisionlineMetadata = visionlineMetadata;
            }

            /// <summary>
            /// Access method for the new credential. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
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

                [EnumMember(Value = "cloud_key")]
                CloudKey = 4,
            }

            /// <summary>
            /// Access method for the new credential. Supported values: `code`, `card`, `mobile_key`, `cloud_key`.
            /// </summary>
            [DataMember(Name = "access_method", IsRequired = true, EmitDefaultValue = false)]
            public CreateRequest.AccessMethodEnum AccessMethod { get; set; }

            /// <summary>
            /// ID of the access system to which the new credential belongs. You must provide either `acs_user_id` or the combination of `user_identity_id` and `acs_system_id`.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user to whom the new credential belongs. You must provide either `acs_user_id` or the combination of `user_identity_id` and `acs_system_id`.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// Set of IDs of the [entrances](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) for which the new credential grants access.
            /// </summary>
            [DataMember(
                Name = "allowed_acs_entrance_ids",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<string>? AllowedAcsEntranceIds { get; set; }

            /// <summary>
            /// Vostio-specific metadata for the new credential.
            /// </summary>
            [DataMember(
                Name = "assa_abloy_vostio_metadata",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequestAssaAbloyVostioMetadata? AssaAbloyVostioMetadata { get; set; }

            /// <summary>
            /// Access (PIN) code for the new credential. There may be manufacturer-specific code restrictions. For details, see the applicable [device or system integration guide](https://docs.seam.co/device-and-system-integration-guides).
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// ACS system ID of the credential manager for the new credential.
            /// </summary>
            [DataMember(
                Name = "credential_manager_acs_system_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CredentialManagerAcsSystemId { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new credential ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Indicates whether the new credential is a [multi-phone sync credential](https://docs.seam.co/capability-guides/mobile-access/issuing-mobile-credentials-from-an-access-control-system#what-are-multi-phone-sync-credentials).
            /// </summary>
            [DataMember(
                Name = "is_multi_phone_sync_credential",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsMultiPhoneSyncCredential { get; set; }

            /// <summary>
            /// Salto Space-specific metadata for the new credential.
            /// </summary>
            [DataMember(
                Name = "salto_space_metadata",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateRequestSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new credential starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// ID of the user identity to whom the new credential belongs. You must provide either `acs_user_id` or the combination of `user_identity_id` and `acs_system_id`. If the access system contains a user with the same `email_address` or `phone_number` as the user identity that you specify, they are linked, and the credential belongs to the access system user. If the access system does not have a corresponding user, one is created.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// Visionline-specific metadata for the new credential.
            /// </summary>
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
                bool? autoJoin = default,
                bool? joinAllGuestAcsEntrances = default,
                bool? overrideAllGuestAcsEntrances = default,
                List<string>? overrideGuestAcsEntranceIds = default
            )
            {
                AutoJoin = autoJoin;
                JoinAllGuestAcsEntrances = joinAllGuestAcsEntrances;
                OverrideAllGuestAcsEntrances = overrideAllGuestAcsEntrances;
                OverrideGuestAcsEntranceIds = overrideGuestAcsEntranceIds;
            }

            [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
            public bool? AutoJoin { get; set; }

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

            public CreateRequestSaltoSpaceMetadata(bool? assignNewKey = default)
            {
                AssignNewKey = assignNewKey;
            }

            /// <summary>
            /// Indicates whether to assign a first, new card to a user. See also [Programming Salto Space Card-based Credentials](https://docs.seam.co/device-and-system-integration-guides/salto-proaccess-space-access-system/programming-salto-space-card-based-credentials).
            /// </summary>
            [DataMember(Name = "assign_new_key", IsRequired = false, EmitDefaultValue = false)]
            public bool? AssignNewKey { get; set; }

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
                bool? autoJoin = default,
                CreateRequestVisionlineMetadata.CardFormatEnum? cardFormat = default,
                CreateRequestVisionlineMetadata.CardFunctionTypeEnum? cardFunctionType = default,
                List<string>? joinerAcsCredentialIds = default,
                bool? mustOverride = default
            )
            {
                AutoJoin = autoJoin;
                CardFormat = cardFormat;
                CardFunctionType = cardFunctionType;
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

            [DataMember(Name = "auto_join", IsRequired = false, EmitDefaultValue = false)]
            public bool? AutoJoin { get; set; }

            [DataMember(Name = "card_format", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestVisionlineMetadata.CardFormatEnum? CardFormat { get; set; }

            [DataMember(Name = "card_function_type", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequestVisionlineMetadata.CardFunctionTypeEnum? CardFunctionType { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [credential](https://docs.seam.co/low-level-apis/managing-credentials) for a specified [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they create and manage the underlying credentials for you, across access systems and standalone smart locks alike. Use this low-level endpoint only when you need direct control over an individual ACS credential.
        /// </summary>
        public AcsCredential Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/acs/credentials/create", requestOptions)
                .EnsureData("/acs/credentials/create")
                .AcsCredential;
        }

        /// <summary>
        /// Creates a new [credential](https://docs.seam.co/low-level-apis/managing-credentials) for a specified [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they create and manage the underlying credentials for you, across access systems and standalone smart locks alike. Use this low-level endpoint only when you need direct control over an individual ACS credential.
        /// </summary>
        public AcsCredential Create(
            CreateRequest.AccessMethodEnum accessMethod = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            List<string>? allowedAcsEntranceIds = default,
            CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? code = default,
            string? credentialManagerAcsSystemId = default,
            string? endsAt = default,
            bool? isMultiPhoneSyncCredential = default,
            CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
            string? startsAt = default,
            string? userIdentityId = default,
            CreateRequestVisionlineMetadata? visionlineMetadata = default
        )
        {
            return Create(
                new CreateRequest(
                    accessMethod: accessMethod,
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    allowedAcsEntranceIds: allowedAcsEntranceIds,
                    assaAbloyVostioMetadata: assaAbloyVostioMetadata,
                    code: code,
                    credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                    endsAt: endsAt,
                    isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                    saltoSpaceMetadata: saltoSpaceMetadata,
                    startsAt: startsAt,
                    userIdentityId: userIdentityId,
                    visionlineMetadata: visionlineMetadata
                )
            );
        }

        /// <summary>
        /// Creates a new [credential](https://docs.seam.co/low-level-apis/managing-credentials) for a specified [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they create and manage the underlying credentials for you, across access systems and standalone smart locks alike. Use this low-level endpoint only when you need direct control over an individual ACS credential.
        /// </summary>
        public async Task<AcsCredential> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/acs/credentials/create", requestOptions)
            )
                .EnsureData("/acs/credentials/create")
                .AcsCredential;
        }

        /// <summary>
        /// Creates a new [credential](https://docs.seam.co/low-level-apis/managing-credentials) for a specified [ACS user](https://docs.seam.co/low-level-apis/access-systems/user-management). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they create and manage the underlying credentials for you, across access systems and standalone smart locks alike. Use this low-level endpoint only when you need direct control over an individual ACS credential.
        /// </summary>
        public async Task<AcsCredential> CreateAsync(
            CreateRequest.AccessMethodEnum accessMethod = default,
            string? acsSystemId = default,
            string? acsUserId = default,
            List<string>? allowedAcsEntranceIds = default,
            CreateRequestAssaAbloyVostioMetadata? assaAbloyVostioMetadata = default,
            string? code = default,
            string? credentialManagerAcsSystemId = default,
            string? endsAt = default,
            bool? isMultiPhoneSyncCredential = default,
            CreateRequestSaltoSpaceMetadata? saltoSpaceMetadata = default,
            string? startsAt = default,
            string? userIdentityId = default,
            CreateRequestVisionlineMetadata? visionlineMetadata = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        accessMethod: accessMethod,
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        allowedAcsEntranceIds: allowedAcsEntranceIds,
                        assaAbloyVostioMetadata: assaAbloyVostioMetadata,
                        code: code,
                        credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                        endsAt: endsAt,
                        isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                        saltoSpaceMetadata: saltoSpaceMetadata,
                        startsAt: startsAt,
                        userIdentityId: userIdentityId,
                        visionlineMetadata: visionlineMetadata
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a Credential.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            /// <summary>
            /// ID of the credential that you want to delete.
            /// </summary>
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

        /// <summary>
        /// Deletes a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/acs/credentials/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Delete(string acsCredentialId = default)
        {
            Delete(new DeleteRequest(acsCredentialId: acsCredentialId));
        }

        /// <summary>
        /// Deletes a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/acs/credentials/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task DeleteAsync(string acsCredentialId = default)
        {
            await DeleteAsync(new DeleteRequest(acsCredentialId: acsCredentialId));
        }

        /// <summary>
        /// Request parameters for Get a Credential.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            /// <summary>
            /// ID of the credential that you want to get.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public AcsCredential Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/acs/credentials/get", requestOptions)
                .EnsureData("/acs/credentials/get")
                .AcsCredential;
        }

        /// <summary>
        /// Returns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public AcsCredential Get(string acsCredentialId = default)
        {
            return Get(new GetRequest(acsCredentialId: acsCredentialId));
        }

        /// <summary>
        /// Returns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task<AcsCredential> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/acs/credentials/get", requestOptions))
                .EnsureData("/acs/credentials/get")
                .AcsCredential;
        }

        /// <summary>
        /// Returns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task<AcsCredential> GetAsync(string acsCredentialId = default)
        {
            return (await GetAsync(new GetRequest(acsCredentialId: acsCredentialId)));
        }

        /// <summary>
        /// Request parameters for List Credentials.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsSystemId = default,
                string? acsUserId = default,
                string? createdBefore = default,
                bool? isMultiPhoneSyncCredential = default,
                float? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentityId = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                CreatedBefore = createdBefore;
                IsMultiPhoneSyncCredential = isMultiPhoneSyncCredential;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system for which you want to retrieve all credentials.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user for which you want to retrieve all credentials.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// Date and time, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format, before which events to return were created.
            /// </summary>
            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            /// <summary>
            /// Indicates whether you want to retrieve only multi-phone sync credentials or non-multi-phone sync credentials.
            /// </summary>
            [DataMember(
                Name = "is_multi_phone_sync_credential",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsMultiPhoneSyncCredential { get; set; }

            /// <summary>
            /// Number of credentials to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned credentials to include all records that satisfy a partial match using `display_name`, `code`, `card_number`, `acs_user_id` or `acs_credential_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all credentials.
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

            public ListResponse(List<AcsCredential> acsCredentials = default)
            {
                AcsCredentials = acsCredentials;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public List<AcsCredential> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/acs/credentials/list", requestOptions)
                .EnsureData("/acs/credentials/list")
                .AcsCredentials;
        }

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public List<AcsCredential> List(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? createdBefore = default,
            bool? isMultiPhoneSyncCredential = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsSystemId: acsSystemId,
                    acsUserId: acsUserId,
                    createdBefore: createdBefore,
                    isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task<List<AcsCredential>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/acs/credentials/list", requestOptions))
                .EnsureData("/acs/credentials/list")
                .AcsCredentials;
        }

        /// <summary>
        /// Returns a list of all [credentials](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task<List<AcsCredential>> ListAsync(
            string? acsSystemId = default,
            string? acsUserId = default,
            string? createdBefore = default,
            bool? isMultiPhoneSyncCredential = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsSystemId: acsSystemId,
                        acsUserId: acsUserId,
                        createdBefore: createdBefore,
                        isMultiPhoneSyncCredential: isMultiPhoneSyncCredential,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Accessible Entrances.
        /// </summary>
        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(string acsCredentialId = default)
            {
                AcsCredentialId = acsCredentialId;
            }

            /// <summary>
            /// ID of the credential for which you want to retrieve all entrances to which the credential grants access.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [entrances](https://docs.seam.co/api/acs/entrances) to which a [credential](https://docs.seam.co/api/acs/credentials) grants access.
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListAccessibleEntrancesResponse>(
                    "/acs/credentials/list_accessible_entrances",
                    requestOptions
                )
                .EnsureData("/acs/credentials/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [entrances](https://docs.seam.co/api/acs/entrances) to which a [credential](https://docs.seam.co/api/acs/credentials) grants access.
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(string acsCredentialId = default)
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(acsCredentialId: acsCredentialId)
            );
        }

        /// <summary>
        /// Returns a list of all [entrances](https://docs.seam.co/api/acs/entrances) to which a [credential](https://docs.seam.co/api/acs/credentials) grants access.
        /// </summary>
        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            ListAccessibleEntrancesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.GetAsync<ListAccessibleEntrancesResponse>(
                    "/acs/credentials/list_accessible_entrances",
                    requestOptions
                )
            )
                .EnsureData("/acs/credentials/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [entrances](https://docs.seam.co/api/acs/entrances) to which a [credential](https://docs.seam.co/api/acs/credentials) grants access.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Unassign a Credential from an ACS User.
        /// </summary>
        [DataContract(Name = "unassignRequest_request")]
        public class UnassignRequest
        {
            [JsonConstructorAttribute]
            protected UnassignRequest() { }

            public UnassignRequest(
                string acsCredentialId = default,
                string? acsUserId = default,
                string? userIdentityId = default
            )
            {
                AcsCredentialId = acsCredentialId;
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the credential that you want to unassign from an access system user.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the access system user from which you want to unassign a credential. You can only provide one of acs_user_id or user_identity_id.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity from which you want to unassign a credential. You can only provide one of acs_user_id or user_identity_id.
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

        /// <summary>
        /// Unassigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Unassign(UnassignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/acs/credentials/unassign", requestOptions);
        }

        /// <summary>
        /// Unassigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public void Unassign(
            string acsCredentialId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            Unassign(
                new UnassignRequest(
                    acsCredentialId: acsCredentialId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Unassigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task UnassignAsync(UnassignRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/acs/credentials/unassign", requestOptions);
        }

        /// <summary>
        /// Unassigns a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) from a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        public async Task UnassignAsync(
            string acsCredentialId = default,
            string? acsUserId = default,
            string? userIdentityId = default
        )
        {
            await UnassignAsync(
                new UnassignRequest(
                    acsCredentialId: acsCredentialId,
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Request parameters for Update a Credential.
        /// </summary>
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

            /// <summary>
            /// ID of the credential that you want to update.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            /// <summary>
            /// Replacement access (PIN) code for the credential that you want to update.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// Replacement date and time at which the validity of the credential ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after the `starts_at` value that you set when creating the credential.
            /// </summary>
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

        /// <summary>
        /// Updates the code and ends at date and time for a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/acs/credentials/update", requestOptions);
        }

        /// <summary>
        /// Updates the code and ends at date and time for a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public void Update(
            string acsCredentialId = default,
            string? code = default,
            string? endsAt = default
        )
        {
            Update(new UpdateRequest(acsCredentialId: acsCredentialId, code: code, endsAt: endsAt));
        }

        /// <summary>
        /// Updates the code and ends at date and time for a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/acs/credentials/update", requestOptions);
        }

        /// <summary>
        /// Updates the code and ends at date and time for a specified [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials).
        /// </summary>
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
