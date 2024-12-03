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
    public class CredentialProvisioningAutomationsAcs
    {
        private ISeamClient _seam;

        public CredentialProvisioningAutomationsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "launchRequest_request")]
        public class LaunchRequest
        {
            [JsonConstructorAttribute]
            protected LaunchRequest() { }

            public LaunchRequest(
                string? acsCredentialPoolId = default,
                bool? createCredentialManagerUser = default,
                string credentialManagerAcsSystemId = default,
                string? credentialManagerAcsUserId = default,
                string userIdentityId = default
            )
            {
                AcsCredentialPoolId = acsCredentialPoolId;
                CreateCredentialManagerUser = createCredentialManagerUser;
                CredentialManagerAcsSystemId = credentialManagerAcsSystemId;
                CredentialManagerAcsUserId = credentialManagerAcsUserId;
                UserIdentityId = userIdentityId;
            }

            [DataMember(
                Name = "acs_credential_pool_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? AcsCredentialPoolId { get; set; }

            [DataMember(
                Name = "create_credential_manager_user",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? CreateCredentialManagerUser { get; set; }

            [DataMember(
                Name = "credential_manager_acs_system_id",
                IsRequired = true,
                EmitDefaultValue = false
            )]
            public string CredentialManagerAcsSystemId { get; set; }

            [DataMember(
                Name = "credential_manager_acs_user_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? CredentialManagerAcsUserId { get; set; }

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

        [DataContract(Name = "launchResponse_response")]
        public class LaunchResponse
        {
            [JsonConstructorAttribute]
            protected LaunchResponse() { }

            public LaunchResponse(
                AcsCredentialProvisioningAutomation acsCredentialProvisioningAutomation = default
            )
            {
                AcsCredentialProvisioningAutomation = acsCredentialProvisioningAutomation;
            }

            [DataMember(
                Name = "acs_credential_provisioning_automation",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public AcsCredentialProvisioningAutomation AcsCredentialProvisioningAutomation { get; set; }

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

        public AcsCredentialProvisioningAutomation Launch(LaunchRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<LaunchResponse>(
                    "/acs/credential_provisioning_automations/launch",
                    requestOptions
                )
                .Data.AcsCredentialProvisioningAutomation;
        }

        public AcsCredentialProvisioningAutomation Launch(
            string? acsCredentialPoolId = default,
            bool? createCredentialManagerUser = default,
            string credentialManagerAcsSystemId = default,
            string? credentialManagerAcsUserId = default,
            string userIdentityId = default
        )
        {
            return Launch(
                new LaunchRequest(
                    acsCredentialPoolId: acsCredentialPoolId,
                    createCredentialManagerUser: createCredentialManagerUser,
                    credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                    credentialManagerAcsUserId: credentialManagerAcsUserId,
                    userIdentityId: userIdentityId
                )
            );
        }

        public async Task<AcsCredentialProvisioningAutomation> LaunchAsync(LaunchRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<LaunchResponse>(
                    "/acs/credential_provisioning_automations/launch",
                    requestOptions
                )
            )
                .Data
                .AcsCredentialProvisioningAutomation;
        }

        public async Task<AcsCredentialProvisioningAutomation> LaunchAsync(
            string? acsCredentialPoolId = default,
            bool? createCredentialManagerUser = default,
            string credentialManagerAcsSystemId = default,
            string? credentialManagerAcsUserId = default,
            string userIdentityId = default
        )
        {
            return (
                await LaunchAsync(
                    new LaunchRequest(
                        acsCredentialPoolId: acsCredentialPoolId,
                        createCredentialManagerUser: createCredentialManagerUser,
                        credentialManagerAcsSystemId: credentialManagerAcsSystemId,
                        credentialManagerAcsUserId: credentialManagerAcsUserId,
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
        public Api.CredentialProvisioningAutomationsAcs CredentialProvisioningAutomationsAcs =>
            new(this);
    }

    public partial interface ISeamClient
    {
        public Api.CredentialProvisioningAutomationsAcs CredentialProvisioningAutomationsAcs { get; }
    }
}
