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
    public class EntrancesAcs
    {
        private ISeamClient _seam;

        public EntrancesAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "grantAccessRequest_request")]
        public class GrantAccessRequest
        {
            [JsonConstructorAttribute]
            protected GrantAccessRequest() { }

            public GrantAccessRequest(string acsEntranceId = default, string acsUserId = default)
            {
                AcsEntranceId = acsEntranceId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

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

        public void GrantAccess(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/entrances/grant_access", requestOptions);
        }

        public void GrantAccess(string acsEntranceId = default, string acsUserId = default)
        {
            GrantAccess(new GrantAccessRequest(acsEntranceId: acsEntranceId, acsUserId: acsUserId));
        }

        public async Task GrantAccessAsync(GrantAccessRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/entrances/grant_access", requestOptions);
        }

        public async Task GrantAccessAsync(
            string acsEntranceId = default,
            string acsUserId = default
        )
        {
            await GrantAccessAsync(
                new GrantAccessRequest(acsEntranceId: acsEntranceId, acsUserId: acsUserId)
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.EntrancesAcs EntrancesAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EntrancesAcs EntrancesAcs { get; }
    }
}
