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
    public class UserIdentities
    {
        private ISeamClient _seam;

        public UserIdentities(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Add an ACS User to a User Identity.
        /// </summary>
        [DataContract(Name = "addAcsUserRequest_request")]
        public class AddAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected AddAcsUserRequest() { }

            public AddAcsUserRequest(
                string acsUserId = default,
                string? userIdentityId = default,
                string? userIdentityKey = default
            )
            {
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// ID of the access system user that you want to add to the user identity.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity to which you want to add an access system user.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            /// <summary>
            /// Key of the user identity to which you want to add an access system user.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        ///
        /// You must specify either `user_identity_id` or `user_identity_key` to identify the user identity.
        ///
        /// If `user_identity_key` is provided, but the user identity doesn&apos;t exist, a new user identity will be created automatically using information from the ACS user.
        /// </summary>
        public void AddAcsUser(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/user_identities/add_acs_user", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        ///
        /// You must specify either `user_identity_id` or `user_identity_key` to identify the user identity.
        ///
        /// If `user_identity_key` is provided, but the user identity doesn&apos;t exist, a new user identity will be created automatically using information from the ACS user.
        /// </summary>
        public void AddAcsUser(
            string acsUserId = default,
            string? userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            AddAcsUser(
                new AddAcsUserRequest(
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        ///
        /// You must specify either `user_identity_id` or `user_identity_key` to identify the user identity.
        ///
        /// If `user_identity_key` is provided, but the user identity doesn&apos;t exist, a new user identity will be created automatically using information from the ACS user.
        /// </summary>
        public async Task AddAcsUserAsync(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/user_identities/add_acs_user", requestOptions);
        }

        /// <summary>
        /// Adds a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        ///
        /// You must specify either `user_identity_id` or `user_identity_key` to identify the user identity.
        ///
        /// If `user_identity_key` is provided, but the user identity doesn&apos;t exist, a new user identity will be created automatically using information from the ACS user.
        /// </summary>
        public async Task AddAcsUserAsync(
            string acsUserId = default,
            string? userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            await AddAcsUserAsync(
                new AddAcsUserRequest(
                    acsUserId: acsUserId,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        /// <summary>
        /// Request parameters for Create a User Identity.
        /// </summary>
        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                List<string>? acsSystemIds = default,
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default,
                string? userIdentityKey = default
            )
            {
                AcsSystemIds = acsSystemIds;
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// List of access system IDs to associate with the new user identity through access system users. If there&apos;s no user with the same email address or phone number in the specified access systems, a new access system user is created. If there is an existing user with the same email or phone number in the specified access systems, the user is linked to the user identity.
            /// </summary>
            [DataMember(Name = "acs_system_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AcsSystemIds { get; set; }

            /// <summary>
            /// Unique email address for the new user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the user associated with the new user identity.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// Unique phone number for the new user identity in E.164 format (for example, +15555550100).
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// Unique key for the new user identity.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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

            public CreateResponse(UserIdentity userIdentity = default)
            {
                UserIdentity = userIdentity;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
            public UserIdentity UserIdentity { get; set; }

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
        /// Creates a new [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public UserIdentity Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/user_identities/create", requestOptions)
                .EnsureData("/user_identities/create")
                .UserIdentity;
        }

        /// <summary>
        /// Creates a new [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public UserIdentity Create(
            List<string>? acsSystemIds = default,
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string? userIdentityKey = default
        )
        {
            return Create(
                new CreateRequest(
                    acsSystemIds: acsSystemIds,
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        /// <summary>
        /// Creates a new [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<UserIdentity> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateResponse>("/user_identities/create", requestOptions)
            )
                .EnsureData("/user_identities/create")
                .UserIdentity;
        }

        /// <summary>
        /// Creates a new [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<UserIdentity> CreateAsync(
            List<string>? acsSystemIds = default,
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string? userIdentityKey = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        acsSystemIds: acsSystemIds,
                        emailAddress: emailAddress,
                        fullName: fullName,
                        phoneNumber: phoneNumber,
                        userIdentityKey: userIdentityKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete a User Identity.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity that you want to delete.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
        /// Deletes a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This deletes the user identity and all associated resources, including any [credentials](https://docs.seam.co/api/acs/credentials), [acs users](https://docs.seam.co/api/acs/users) and [client sessions](https://docs.seam.co/api/client_sessions).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This deletes the user identity and all associated resources, including any [credentials](https://docs.seam.co/api/acs/credentials), [acs users](https://docs.seam.co/api/acs/users) and [client sessions](https://docs.seam.co/api/client_sessions).
        /// </summary>
        public void Delete(string userIdentityId = default)
        {
            Delete(new DeleteRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Deletes a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This deletes the user identity and all associated resources, including any [credentials](https://docs.seam.co/api/acs/credentials), [acs users](https://docs.seam.co/api/acs/users) and [client sessions](https://docs.seam.co/api/client_sessions).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This deletes the user identity and all associated resources, including any [credentials](https://docs.seam.co/api/acs/credentials), [acs users](https://docs.seam.co/api/acs/users) and [client sessions](https://docs.seam.co/api/client_sessions).
        /// </summary>
        public async Task DeleteAsync(string userIdentityId = default)
        {
            await DeleteAsync(new DeleteRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Request parameters for Generate an Instant Key.
        /// </summary>
        [DataContract(Name = "generateInstantKeyRequest_request")]
        public class GenerateInstantKeyRequest
        {
            [JsonConstructorAttribute]
            protected GenerateInstantKeyRequest() { }

            public GenerateInstantKeyRequest(
                string? customizationProfileId = default,
                float? maxUseCount = default,
                string userIdentityId = default
            )
            {
                CustomizationProfileId = customizationProfileId;
                MaxUseCount = maxUseCount;
                UserIdentityId = userIdentityId;
            }

            [DataMember(
                Name = "customization_profile_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CustomizationProfileId { get; set; }

            /// <summary>
            /// Maximum number of times the instant key can be used. Default: 1.
            /// </summary>
            [DataMember(Name = "max_use_count", IsRequired = false, EmitDefaultValue = false)]
            public float? MaxUseCount { get; set; }

            /// <summary>
            /// ID of the user identity for which you want to generate an instant key.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        [DataContract(Name = "generateInstantKeyResponse_response")]
        public class GenerateInstantKeyResponse
        {
            [JsonConstructorAttribute]
            protected GenerateInstantKeyResponse() { }

            public GenerateInstantKeyResponse(InstantKey instantKey = default)
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
        /// Generates a new [instant key](https://docs.seam.co/capability-guides/instant-keys) for a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public InstantKey GenerateInstantKey(GenerateInstantKeyRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GenerateInstantKeyResponse>(
                    "/user_identities/generate_instant_key",
                    requestOptions
                )
                .EnsureData("/user_identities/generate_instant_key")
                .InstantKey;
        }

        /// <summary>
        /// Generates a new [instant key](https://docs.seam.co/capability-guides/instant-keys) for a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public InstantKey GenerateInstantKey(
            string? customizationProfileId = default,
            float? maxUseCount = default,
            string userIdentityId = default
        )
        {
            return GenerateInstantKey(
                new GenerateInstantKeyRequest(
                    customizationProfileId: customizationProfileId,
                    maxUseCount: maxUseCount,
                    userIdentityId: userIdentityId
                )
            );
        }

        /// <summary>
        /// Generates a new [instant key](https://docs.seam.co/capability-guides/instant-keys) for a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<InstantKey> GenerateInstantKeyAsync(GenerateInstantKeyRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GenerateInstantKeyResponse>(
                    "/user_identities/generate_instant_key",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/generate_instant_key")
                .InstantKey;
        }

        /// <summary>
        /// Generates a new [instant key](https://docs.seam.co/capability-guides/instant-keys) for a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<InstantKey> GenerateInstantKeyAsync(
            string? customizationProfileId = default,
            float? maxUseCount = default,
            string userIdentityId = default
        )
        {
            return (
                await GenerateInstantKeyAsync(
                    new GenerateInstantKeyRequest(
                        customizationProfileId: customizationProfileId,
                        maxUseCount: maxUseCount,
                        userIdentityId: userIdentityId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Get a User Identity.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? userIdentityId = default, string? userIdentityKey = default)
            {
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// ID of the user identity that you want to get.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityId { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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

            public GetResponse(UserIdentity userIdentity = default)
            {
                UserIdentity = userIdentity;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "user_identity", IsRequired = false, EmitDefaultValue = false)]
            public UserIdentity UserIdentity { get; set; }

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
        /// Returns a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public UserIdentity Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/user_identities/get", requestOptions)
                .EnsureData("/user_identities/get")
                .UserIdentity;
        }

        /// <summary>
        /// Returns a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public UserIdentity Get(string? userIdentityId = default, string? userIdentityKey = default)
        {
            return Get(
                new GetRequest(userIdentityId: userIdentityId, userIdentityKey: userIdentityKey)
            );
        }

        /// <summary>
        /// Returns a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<UserIdentity> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/user_identities/get", requestOptions))
                .EnsureData("/user_identities/get")
                .UserIdentity;
        }

        /// <summary>
        /// Returns a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<UserIdentity> GetAsync(
            string? userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(userIdentityId: userIdentityId, userIdentityKey: userIdentityKey)
                )
            );
        }

        /// <summary>
        /// Request parameters for Grant a User Identity Access to a Device.
        /// </summary>
        [DataContract(Name = "grantAccessToDeviceRequest_request")]
        public class GrantAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessToDeviceRequest() { }

            public GrantAccessToDeviceRequest(
                string deviceId = default,
                string userIdentityId = default
            )
            {
                DeviceId = deviceId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the managed device to which you want to grant access to the user identity.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// ID of the user identity that you want to grant access to a device.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
        /// Grants a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) access to a specified [device](https://docs.seam.co/core-concepts/devices/).
        /// </summary>
        public void GrantAccessToDevice(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/user_identities/grant_access_to_device", requestOptions);
        }

        /// <summary>
        /// Grants a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) access to a specified [device](https://docs.seam.co/core-concepts/devices/).
        /// </summary>
        public void GrantAccessToDevice(string deviceId = default, string userIdentityId = default)
        {
            GrantAccessToDevice(
                new GrantAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Grants a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) access to a specified [device](https://docs.seam.co/core-concepts/devices/).
        /// </summary>
        public async Task GrantAccessToDeviceAsync(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/user_identities/grant_access_to_device", requestOptions);
        }

        /// <summary>
        /// Grants a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity) access to a specified [device](https://docs.seam.co/core-concepts/devices/).
        /// </summary>
        public async Task GrantAccessToDeviceAsync(
            string deviceId = default,
            string userIdentityId = default
        )
        {
            await GrantAccessToDeviceAsync(
                new GrantAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Request parameters for List User Identities.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? createdBefore = default,
                string? credentialManagerAcsSystemId = default,
                int? limit = default,
                string? pageCursor = default,
                string? search = default,
                List<string>? userIdentityIds = default
            )
            {
                CreatedBefore = createdBefore;
                CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentityIds = userIdentityIds;
            }

            /// <summary>
            /// Timestamp by which to limit returned user identities. Returns user identities created before this timestamp.
            /// </summary>
            [DataMember(Name = "created_before", IsRequired = false, EmitDefaultValue = false)]
            public string? CreatedBefore { get; set; }

            /// <summary>
            /// `acs_system_id` of the credential manager by which you want to filter the list of user identities.
            /// </summary>
            [DataMember(
                Name = "credential_manager_acs_system_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CredentialManagerAcsSystemId { get; set; }

            /// <summary>
            /// Maximum number of records to return per page.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public int? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned user identities to include all records that satisfy a partial match using `full_name`, `phone_number`, `email_address` or `user_identity_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// Array of user identity IDs by which to filter the list of user identities.
            /// </summary>
            [DataMember(Name = "user_identity_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? UserIdentityIds { get; set; }

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

            public ListResponse(List<UserIdentity> userIdentities = default)
            {
                UserIdentities = userIdentities;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "user_identities", IsRequired = false, EmitDefaultValue = false)]
            public List<UserIdentity> UserIdentities { get; set; }

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
        /// Returns a list of all [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<UserIdentity> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/user_identities/list", requestOptions)
                .EnsureData("/user_identities/list")
                .UserIdentities;
        }

        /// <summary>
        /// Returns a list of all [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<UserIdentity> List(
            string? createdBefore = default,
            string? credentialManagerAcsSystemId = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            List<string>? userIdentityIds = default
        )
        {
            return List(
                new ListRequest(
                    createdBefore: createdBefore,
                    credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentityIds: userIdentityIds
                )
            );
        }

        /// <summary>
        /// Returns a list of all [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<UserIdentity>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/user_identities/list", requestOptions))
                .EnsureData("/user_identities/list")
                .UserIdentities;
        }

        /// <summary>
        /// Returns a list of all [user identities](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<UserIdentity>> ListAsync(
            string? createdBefore = default,
            string? credentialManagerAcsSystemId = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            List<string>? userIdentityIds = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        createdBefore: createdBefore,
                        credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentityIds: userIdentityIds
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Accessible Devices for a User Identity.
        /// </summary>
        [DataContract(Name = "listAccessibleDevicesRequest_request")]
        public class ListAccessibleDevicesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleDevicesRequest() { }

            public ListAccessibleDevicesRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all accessible devices.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        [DataContract(Name = "listAccessibleDevicesResponse_response")]
        public class ListAccessibleDevicesResponse
        {
            [JsonConstructorAttribute]
            protected ListAccessibleDevicesResponse() { }

            public ListAccessibleDevicesResponse(List<Device> devices = default)
            {
                Devices = devices;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "devices", IsRequired = false, EmitDefaultValue = false)]
            public List<Device> Devices { get; set; }

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
        /// Returns a list of all [devices](https://docs.seam.co/core-concepts/devices) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes devices derived from the access grants assigned to the user identity and devices directly linked to the user identity.
        /// </summary>
        public List<Device> ListAccessibleDevices(ListAccessibleDevicesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleDevicesResponse>(
                    "/user_identities/list_accessible_devices",
                    requestOptions
                )
                .EnsureData("/user_identities/list_accessible_devices")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [devices](https://docs.seam.co/core-concepts/devices) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes devices derived from the access grants assigned to the user identity and devices directly linked to the user identity.
        /// </summary>
        public List<Device> ListAccessibleDevices(string userIdentityId = default)
        {
            return ListAccessibleDevices(
                new ListAccessibleDevicesRequest(userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Returns a list of all [devices](https://docs.seam.co/core-concepts/devices) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes devices derived from the access grants assigned to the user identity and devices directly linked to the user identity.
        /// </summary>
        public async Task<List<Device>> ListAccessibleDevicesAsync(
            ListAccessibleDevicesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAccessibleDevicesResponse>(
                    "/user_identities/list_accessible_devices",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/list_accessible_devices")
                .Devices;
        }

        /// <summary>
        /// Returns a list of all [devices](https://docs.seam.co/core-concepts/devices) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes devices derived from the access grants assigned to the user identity and devices directly linked to the user identity.
        /// </summary>
        public async Task<List<Device>> ListAccessibleDevicesAsync(string userIdentityId = default)
        {
            return (
                await ListAccessibleDevicesAsync(
                    new ListAccessibleDevicesRequest(userIdentityId: userIdentityId)
                )
            );
        }

        /// <summary>
        /// Request parameters for List Accessible Entrances for a User Identity.
        /// </summary>
        [DataContract(Name = "listAccessibleEntrancesRequest_request")]
        public class ListAccessibleEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected ListAccessibleEntrancesRequest() { }

            public ListAccessibleEntrancesRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all accessible entrances.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
        /// Returns a list of all [ACS entrances](https://docs.seam.co/api/acs/entrances) accessible to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes entrances derived from the access grants assigned to the user identity and entrances accessible through ACS users linked to the user identity.
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(ListAccessibleEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAccessibleEntrancesResponse>(
                    "/user_identities/list_accessible_entrances",
                    requestOptions
                )
                .EnsureData("/user_identities/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [ACS entrances](https://docs.seam.co/api/acs/entrances) accessible to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes entrances derived from the access grants assigned to the user identity and entrances accessible through ACS users linked to the user identity.
        /// </summary>
        public List<AcsEntrance> ListAccessibleEntrances(string userIdentityId = default)
        {
            return ListAccessibleEntrances(
                new ListAccessibleEntrancesRequest(userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Returns a list of all [ACS entrances](https://docs.seam.co/api/acs/entrances) accessible to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes entrances derived from the access grants assigned to the user identity and entrances accessible through ACS users linked to the user identity.
        /// </summary>
        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            ListAccessibleEntrancesRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAccessibleEntrancesResponse>(
                    "/user_identities/list_accessible_entrances",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/list_accessible_entrances")
                .AcsEntrances;
        }

        /// <summary>
        /// Returns a list of all [ACS entrances](https://docs.seam.co/api/acs/entrances) accessible to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity). This includes entrances derived from the access grants assigned to the user identity and entrances accessible through ACS users linked to the user identity.
        /// </summary>
        public async Task<List<AcsEntrance>> ListAccessibleEntrancesAsync(
            string userIdentityId = default
        )
        {
            return (
                await ListAccessibleEntrancesAsync(
                    new ListAccessibleEntrancesRequest(userIdentityId: userIdentityId)
                )
            );
        }

        /// <summary>
        /// Request parameters for List ACS Systems Associated with a User Identity.
        /// </summary>
        [DataContract(Name = "listAcsSystemsRequest_request")]
        public class ListAcsSystemsRequest
        {
            [JsonConstructorAttribute]
            protected ListAcsSystemsRequest() { }

            public ListAcsSystemsRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all access systems.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        [DataContract(Name = "listAcsSystemsResponse_response")]
        public class ListAcsSystemsResponse
        {
            [JsonConstructorAttribute]
            protected ListAcsSystemsResponse() { }

            public ListAcsSystemsResponse(List<AcsSystem> acsSystems = default)
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
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<AcsSystem> ListAcsSystems(ListAcsSystemsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAcsSystemsResponse>("/user_identities/list_acs_systems", requestOptions)
                .EnsureData("/user_identities/list_acs_systems")
                .AcsSystems;
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<AcsSystem> ListAcsSystems(string userIdentityId = default)
        {
            return ListAcsSystems(new ListAcsSystemsRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<AcsSystem>> ListAcsSystemsAsync(ListAcsSystemsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAcsSystemsResponse>(
                    "/user_identities/list_acs_systems",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/list_acs_systems")
                .AcsSystems;
        }

        /// <summary>
        /// Returns a list of all [access systems](https://docs.seam.co/low-level-apis/access-systems) associated with a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<AcsSystem>> ListAcsSystemsAsync(string userIdentityId = default)
        {
            return (
                await ListAcsSystemsAsync(new ListAcsSystemsRequest(userIdentityId: userIdentityId))
            );
        }

        /// <summary>
        /// Request parameters for List ACS Users Associated with a User Identity.
        /// </summary>
        [DataContract(Name = "listAcsUsersRequest_request")]
        public class ListAcsUsersRequest
        {
            [JsonConstructorAttribute]
            protected ListAcsUsersRequest() { }

            public ListAcsUsersRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the user identity for which you want to retrieve all access system users.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        [DataContract(Name = "listAcsUsersResponse_response")]
        public class ListAcsUsersResponse
        {
            [JsonConstructorAttribute]
            protected ListAcsUsersResponse() { }

            public ListAcsUsersResponse(List<AcsUser> acsUsers = default)
            {
                AcsUsers = acsUsers;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "acs_users", IsRequired = false, EmitDefaultValue = false)]
            public List<AcsUser> AcsUsers { get; set; }

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
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) assigned to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<AcsUser> ListAcsUsers(ListAcsUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListAcsUsersResponse>("/user_identities/list_acs_users", requestOptions)
                .EnsureData("/user_identities/list_acs_users")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) assigned to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public List<AcsUser> ListAcsUsers(string userIdentityId = default)
        {
            return ListAcsUsers(new ListAcsUsersRequest(userIdentityId: userIdentityId));
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) assigned to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<AcsUser>> ListAcsUsersAsync(ListAcsUsersRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListAcsUsersResponse>(
                    "/user_identities/list_acs_users",
                    requestOptions
                )
            )
                .EnsureData("/user_identities/list_acs_users")
                .AcsUsers;
        }

        /// <summary>
        /// Returns a list of all [access system users](https://docs.seam.co/low-level-apis/access-systems/user-management) assigned to a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task<List<AcsUser>> ListAcsUsersAsync(string userIdentityId = default)
        {
            return (
                await ListAcsUsersAsync(new ListAcsUsersRequest(userIdentityId: userIdentityId))
            );
        }

        /// <summary>
        /// Request parameters for Remove an ACS User from a User Identity.
        /// </summary>
        [DataContract(Name = "removeAcsUserRequest_request")]
        public class RemoveAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveAcsUserRequest() { }

            public RemoveAcsUserRequest(string acsUserId = default, string userIdentityId = default)
            {
                AcsUserId = acsUserId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the access system user that you want to remove from the user identity..
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            /// <summary>
            /// ID of the user identity from which you want to remove an access system user.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void RemoveAcsUser(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/remove_acs_user", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void RemoveAcsUser(string acsUserId = default, string userIdentityId = default)
        {
            RemoveAcsUser(
                new RemoveAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task RemoveAcsUserAsync(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/remove_acs_user", requestOptions);
        }

        /// <summary>
        /// Removes a specified [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task RemoveAcsUserAsync(
            string acsUserId = default,
            string userIdentityId = default
        )
        {
            await RemoveAcsUserAsync(
                new RemoveAcsUserRequest(acsUserId: acsUserId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Request parameters for Revoke Access to a Device from a User Identity.
        /// </summary>
        [DataContract(Name = "revokeAccessToDeviceRequest_request")]
        public class RevokeAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToDeviceRequest() { }

            public RevokeAccessToDeviceRequest(
                string deviceId = default,
                string userIdentityId = default
            )
            {
                DeviceId = deviceId;
                UserIdentityId = userIdentityId;
            }

            /// <summary>
            /// ID of the managed device to which you want to revoke access from the user identity.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// ID of the user identity from which you want to revoke access to a device.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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
        /// Revokes access to a specified [device](https://docs.seam.co/core-concepts/devices/) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void RevokeAccessToDevice(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/revoke_access_to_device", requestOptions);
        }

        /// <summary>
        /// Revokes access to a specified [device](https://docs.seam.co/core-concepts/devices/) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void RevokeAccessToDevice(string deviceId = default, string userIdentityId = default)
        {
            RevokeAccessToDevice(
                new RevokeAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Revokes access to a specified [device](https://docs.seam.co/core-concepts/devices/) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task RevokeAccessToDeviceAsync(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/revoke_access_to_device",
                requestOptions
            );
        }

        /// <summary>
        /// Revokes access to a specified [device](https://docs.seam.co/core-concepts/devices/) from a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task RevokeAccessToDeviceAsync(
            string deviceId = default,
            string userIdentityId = default
        )
        {
            await RevokeAccessToDeviceAsync(
                new RevokeAccessToDeviceRequest(deviceId: deviceId, userIdentityId: userIdentityId)
            );
        }

        /// <summary>
        /// Request parameters for Update a User Identity.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default,
                string userIdentityId = default,
                string? userIdentityKey = default
            )
            {
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            /// <summary>
            /// Unique email address for the user identity.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the user associated with the user identity.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// Unique phone number for the user identity.
            /// </summary>
            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            /// <summary>
            /// ID of the user identity that you want to update.
            /// </summary>
            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            /// <summary>
            /// Unique key for the user identity.
            /// </summary>
            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

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
        /// Updates a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/user_identities/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public void Update(
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            Update(
                new UpdateRequest(
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        /// <summary>
        /// Updates a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/user_identities/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [user identity](https://docs.seam.co/capability-guides/mobile-access/managing-mobile-app-user-accounts-with-user-identities#what-is-a-user-identity).
        /// </summary>
        public async Task UpdateAsync(
            string? emailAddress = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    emailAddress: emailAddress,
                    fullName: fullName,
                    phoneNumber: phoneNumber,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UserIdentities UserIdentities => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UserIdentities UserIdentities { get; }
    }
}
