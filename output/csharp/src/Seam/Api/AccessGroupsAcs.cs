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
    public class AccessGroupsAcs
    {
        private ISeamClient _seam;

        public AccessGroupsAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "addUserRequest_request")]
        public class AddUserRequest
        {
            [JsonConstructorAttribute]
            protected AddUserRequest() { }

            public AddUserRequest(string acsAccessGroupId = default, string acsUserId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void AddUser(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/add_user", requestOptions);
        }

        public void AddUser(string acsAccessGroupId = default, string acsUserId = default)
        {
            AddUser(new AddUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId));
        }

        public async Task AddUserAsync(AddUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/add_user", requestOptions);
        }

        public async Task AddUserAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await AddUserAsync(
                new AddUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "removeUserRequest_request")]
        public class RemoveUserRequest
        {
            [JsonConstructorAttribute]
            protected RemoveUserRequest() { }

            public RemoveUserRequest(string acsAccessGroupId = default, string acsUserId = default)
            {
                AcsAccessGroupId = acsAccessGroupId;
                AcsUserId = acsUserId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void RemoveUser(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/access_groups/remove_user", requestOptions);
        }

        public void RemoveUser(string acsAccessGroupId = default, string acsUserId = default)
        {
            RemoveUser(
                new RemoveUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }

        public async Task RemoveUserAsync(RemoveUserRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/access_groups/remove_user", requestOptions);
        }

        public async Task RemoveUserAsync(
            string acsAccessGroupId = default,
            string acsUserId = default
        )
        {
            await RemoveUserAsync(
                new RemoveUserRequest(acsAccessGroupId: acsAccessGroupId, acsUserId: acsUserId)
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.AccessGroupsAcs AccessGroupsAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessGroupsAcs AccessGroupsAcs { get; }
    }
}
