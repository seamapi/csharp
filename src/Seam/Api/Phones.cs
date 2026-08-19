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
    public class Phones
    {
        private ISeamClient _seam;

        public Phones(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Deactivate a Phone.
        /// </summary>
        [DataContract(Name = "deactivateRequest_request")]
        public class DeactivateRequest
        {
            [JsonConstructorAttribute]
            protected DeactivateRequest() { }

            public DeactivateRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// Device ID of the phone that you want to deactivate.
            /// </summary>
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

        /// <summary>
        /// Deactivates a phone, which is useful, for example, if a user has lost their phone. For more information, see [App User Lost Phone Process](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity#app-user-lost-phone-process).
        /// </summary>
        public void Deactivate(DeactivateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/phones/deactivate", requestOptions);
        }

        /// <summary>
        /// Deactivates a phone, which is useful, for example, if a user has lost their phone. For more information, see [App User Lost Phone Process](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity#app-user-lost-phone-process).
        /// </summary>
        public void Deactivate(string deviceId = default)
        {
            Deactivate(new DeactivateRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Deactivates a phone, which is useful, for example, if a user has lost their phone. For more information, see [App User Lost Phone Process](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity#app-user-lost-phone-process).
        /// </summary>
        public async Task DeactivateAsync(DeactivateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/phones/deactivate", requestOptions);
        }

        /// <summary>
        /// Deactivates a phone, which is useful, for example, if a user has lost their phone. For more information, see [App User Lost Phone Process](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity#app-user-lost-phone-process).
        /// </summary>
        public async Task DeactivateAsync(string deviceId = default)
        {
            await DeactivateAsync(new DeactivateRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Get a Phone.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// Device ID of the phone that you want to get.
            /// </summary>
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

        [DataContract(Name = "getResponse_response")]
        public class GetResponse
        {
            [JsonConstructorAttribute]
            protected GetResponse() { }

            public GetResponse(Phone phone = default)
            {
                Phone = phone;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
            public Phone Phone { get; set; }

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
        /// Returns a specified [phone](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity).
        /// </summary>
        public Phone Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/phones/get", requestOptions)
                .EnsureData("/phones/get")
                .Phone;
        }

        /// <summary>
        /// Returns a specified [phone](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity).
        /// </summary>
        public Phone Get(string deviceId = default)
        {
            return Get(new GetRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Returns a specified [phone](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity).
        /// </summary>
        public async Task<Phone> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/phones/get", requestOptions))
                .EnsureData("/phones/get")
                .Phone;
        }

        /// <summary>
        /// Returns a specified [phone](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity).
        /// </summary>
        public async Task<Phone> GetAsync(string deviceId = default)
        {
            return (await GetAsync(new GetRequest(deviceId: deviceId)));
        }

        /// <summary>
        /// Request parameters for List Phones.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? acsCredentialId = default,
                string? ownerUserIdentityId = default
            )
            {
                AcsCredentialId = acsCredentialId;
                OwnerUserIdentityId = ownerUserIdentityId;
            }

            /// <summary>
            /// ID of the [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) by which you want to filter the list of returned phones.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

            /// <summary>
            /// ID of the user identity that represents the owner by which you want to filter the list of returned phones.
            /// </summary>
            [DataMember(
                Name = "owner_user_identity_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? OwnerUserIdentityId { get; set; }

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

            public ListResponse(List<Phone> phones = default)
            {
                Phones = phones;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "phones", IsRequired = false, EmitDefaultValue = false)]
            public List<Phone> Phones { get; set; }

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
        /// Returns a list of all [phones](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity). To filter the list of returned phones by a specific owner user identity or credential, include the `owner_user_identity_id` or `acs_credential_id`, respectively, in the request body.
        /// </summary>
        public List<Phone> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/phones/list", requestOptions)
                .EnsureData("/phones/list")
                .Phones;
        }

        /// <summary>
        /// Returns a list of all [phones](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity). To filter the list of returned phones by a specific owner user identity or credential, include the `owner_user_identity_id` or `acs_credential_id`, respectively, in the request body.
        /// </summary>
        public List<Phone> List(
            string? acsCredentialId = default,
            string? ownerUserIdentityId = default
        )
        {
            return List(
                new ListRequest(
                    acsCredentialId: acsCredentialId,
                    ownerUserIdentityId: ownerUserIdentityId
                )
            );
        }

        /// <summary>
        /// Returns a list of all [phones](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity). To filter the list of returned phones by a specific owner user identity or credential, include the `owner_user_identity_id` or `acs_credential_id`, respectively, in the request body.
        /// </summary>
        public async Task<List<Phone>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/phones/list", requestOptions))
                .EnsureData("/phones/list")
                .Phones;
        }

        /// <summary>
        /// Returns a list of all [phones](https://docs.seam.co/capability-guides/mobile-access/managing-phones-for-a-user-identity). To filter the list of returned phones by a specific owner user identity or credential, include the `owner_user_identity_id` or `acs_credential_id`, respectively, in the request body.
        /// </summary>
        public async Task<List<Phone>> ListAsync(
            string? acsCredentialId = default,
            string? ownerUserIdentityId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        acsCredentialId: acsCredentialId,
                        ownerUserIdentityId: ownerUserIdentityId
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
        public Api.Phones Phones => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Phones Phones { get; }
    }
}
