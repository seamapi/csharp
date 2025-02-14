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
