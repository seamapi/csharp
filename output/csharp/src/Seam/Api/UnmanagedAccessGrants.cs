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
    public class UnmanagedAccessGrants
    {
        private ISeamClient _seam;

        public UnmanagedAccessGrants(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string accessGrantId = default,
                string? accessGrantKey = default,
                bool isManaged = default
            )
            {
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
                IsManaged = isManaged;
            }

            [DataMember(Name = "access_grant_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessGrantId { get; set; }

            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
            public bool IsManaged { get; set; }

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
            _seam.Post<object>("/access_grants/unmanaged/update", requestOptions);
        }

        public void Update(
            string accessGrantId = default,
            string? accessGrantKey = default,
            bool isManaged = default
        )
        {
            Update(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    isManaged: isManaged
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_grants/unmanaged/update", requestOptions);
        }

        public async Task UpdateAsync(
            string accessGrantId = default,
            string? accessGrantKey = default,
            bool isManaged = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    isManaged: isManaged
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UnmanagedAccessGrants UnmanagedAccessGrants => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessGrants UnmanagedAccessGrants { get; }
    }
}
