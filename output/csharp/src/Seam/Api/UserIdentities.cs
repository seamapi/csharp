using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
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

        [DataContract(Name = "addAcsUserRequest_request")]
        public class AddAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected AddAcsUserRequest() { }

            public AddAcsUserRequest(string userIdentityId = default, string acsUserId = default)
            {
                UserIdentityId = userIdentityId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        public void AddAcsUser(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/add_acs_user", requestOptions);
        }

        public void AddAcsUser(string userIdentityId = default, string acsUserId = default)
        {
            AddAcsUser(new AddAcsUserRequest(userIdentityId: userIdentityId, acsUserId: acsUserId));
        }

        public async Task AddAcsUserAsync(AddAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/add_acs_user", requestOptions);
        }

        public async Task AddAcsUserAsync(
            string userIdentityId = default,
            string acsUserId = default
        )
        {
            await AddAcsUserAsync(
                new AddAcsUserRequest(userIdentityId: userIdentityId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string userIdentityId = default)
            {
                UserIdentityId = userIdentityId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/delete", requestOptions);
        }

        public void Delete(string userIdentityId = default)
        {
            Delete(new DeleteRequest(userIdentityId: userIdentityId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/delete", requestOptions);
        }

        public async Task DeleteAsync(string userIdentityId = default)
        {
            await DeleteAsync(new DeleteRequest(userIdentityId: userIdentityId));
        }

        [DataContract(Name = "grantAccessToDeviceRequest_request")]
        public class GrantAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessToDeviceRequest() { }

            public GrantAccessToDeviceRequest(
                string userIdentityId = default,
                string deviceId = default
            )
            {
                UserIdentityId = userIdentityId;
                DeviceId = deviceId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        public void GrantAccessToDevice(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/grant_access_to_device", requestOptions);
        }

        public void GrantAccessToDevice(string userIdentityId = default, string deviceId = default)
        {
            GrantAccessToDevice(
                new GrantAccessToDeviceRequest(userIdentityId: userIdentityId, deviceId: deviceId)
            );
        }

        public async Task GrantAccessToDeviceAsync(GrantAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/grant_access_to_device",
                requestOptions
            );
        }

        public async Task GrantAccessToDeviceAsync(
            string userIdentityId = default,
            string deviceId = default
        )
        {
            await GrantAccessToDeviceAsync(
                new GrantAccessToDeviceRequest(userIdentityId: userIdentityId, deviceId: deviceId)
            );
        }

        [DataContract(Name = "removeAcsUserRequest_request")]
        public class RemoveAcsUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveAcsUserRequest() { }

            public RemoveAcsUserRequest(string userIdentityId = default, string acsUserId = default)
            {
                UserIdentityId = userIdentityId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        public void RemoveAcsUser(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/remove_acs_user", requestOptions);
        }

        public void RemoveAcsUser(string userIdentityId = default, string acsUserId = default)
        {
            RemoveAcsUser(
                new RemoveAcsUserRequest(userIdentityId: userIdentityId, acsUserId: acsUserId)
            );
        }

        public async Task RemoveAcsUserAsync(RemoveAcsUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/remove_acs_user", requestOptions);
        }

        public async Task RemoveAcsUserAsync(
            string userIdentityId = default,
            string acsUserId = default
        )
        {
            await RemoveAcsUserAsync(
                new RemoveAcsUserRequest(userIdentityId: userIdentityId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "revokeAccessToDeviceRequest_request")]
        public class RevokeAccessToDeviceRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToDeviceRequest() { }

            public RevokeAccessToDeviceRequest(
                string userIdentityId = default,
                string deviceId = default
            )
            {
                UserIdentityId = userIdentityId;
                DeviceId = deviceId;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        public void RevokeAccessToDevice(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/revoke_access_to_device", requestOptions);
        }

        public void RevokeAccessToDevice(string userIdentityId = default, string deviceId = default)
        {
            RevokeAccessToDevice(
                new RevokeAccessToDeviceRequest(userIdentityId: userIdentityId, deviceId: deviceId)
            );
        }

        public async Task RevokeAccessToDeviceAsync(RevokeAccessToDeviceRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/user_identities/revoke_access_to_device",
                requestOptions
            );
        }

        public async Task RevokeAccessToDeviceAsync(
            string userIdentityId = default,
            string deviceId = default
        )
        {
            await RevokeAccessToDeviceAsync(
                new RevokeAccessToDeviceRequest(userIdentityId: userIdentityId, deviceId: deviceId)
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string userIdentityId = default,
                string? userIdentityKey = default,
                string? emailAddress = default,
                string? phoneNumber = default,
                string? fullName = default
            )
            {
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
                EmailAddress = emailAddress;
                PhoneNumber = phoneNumber;
                FullName = fullName;
            }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

            [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentityKey { get; set; }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

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
            _seam.Post<object>("/user_identities/update", requestOptions);
        }

        public void Update(
            string userIdentityId = default,
            string? userIdentityKey = default,
            string? emailAddress = default,
            string? phoneNumber = default,
            string? fullName = default
        )
        {
            Update(
                new UpdateRequest(
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey,
                    emailAddress: emailAddress,
                    phoneNumber: phoneNumber,
                    fullName: fullName
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/update", requestOptions);
        }

        public async Task UpdateAsync(
            string userIdentityId = default,
            string? userIdentityKey = default,
            string? emailAddress = default,
            string? phoneNumber = default,
            string? fullName = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey,
                    emailAddress: emailAddress,
                    phoneNumber: phoneNumber,
                    fullName: fullName
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
