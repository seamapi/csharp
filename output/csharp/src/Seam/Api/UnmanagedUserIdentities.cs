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
    public class UnmanagedUserIdentities
    {
        private ISeamClient _seam;

        public UnmanagedUserIdentities(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                bool isManaged = default,
                string userIdentityId = default,
                string? userIdentityKey = default
            )
            {
                IsManaged = isManaged;
                UserIdentityId = userIdentityId;
                UserIdentityKey = userIdentityKey;
            }

            [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
            public bool IsManaged { get; set; }

            [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
            public string UserIdentityId { get; set; }

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

        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/user_identities/unmanaged/update", requestOptions);
        }

        public void Update(
            bool isManaged = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            Update(
                new UpdateRequest(
                    isManaged: isManaged,
                    userIdentityId: userIdentityId,
                    userIdentityKey: userIdentityKey
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/user_identities/unmanaged/update", requestOptions);
        }

        public async Task UpdateAsync(
            bool isManaged = default,
            string userIdentityId = default,
            string? userIdentityKey = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    isManaged: isManaged,
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
        public Api.UnmanagedUserIdentities UnmanagedUserIdentities => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedUserIdentities UnmanagedUserIdentities { get; }
    }
}
