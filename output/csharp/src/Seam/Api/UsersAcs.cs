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
    public class UsersAcs
    {
        private ISeamClient _seam;

        public UsersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "addToAccessGroupRequest_request")]
        public class AddToAccessGroupRequest
        {
            [JsonConstructorAttribute]
            protected AddToAccessGroupRequest() { }

            public AddToAccessGroupRequest(
                string acsUserId = default,
                string acsAccessGroupId = default
            )
            {
                AcsUserId = acsUserId;
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void AddToAccessGroup(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/add_to_access_group", requestOptions);
        }

        public void AddToAccessGroup(string acsUserId = default, string acsAccessGroupId = default)
        {
            AddToAccessGroup(
                new AddToAccessGroupRequest(
                    acsUserId: acsUserId,
                    acsAccessGroupId: acsAccessGroupId
                )
            );
        }

        public async Task AddToAccessGroupAsync(AddToAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/add_to_access_group", requestOptions);
        }

        public async Task AddToAccessGroupAsync(
            string acsUserId = default,
            string acsAccessGroupId = default
        )
        {
            await AddToAccessGroupAsync(
                new AddToAccessGroupRequest(
                    acsUserId: acsUserId,
                    acsAccessGroupId: acsAccessGroupId
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string acsUserId = default)
            {
                AcsUserId = acsUserId;
            }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/delete", requestOptions);
        }

        public void Delete(string acsUserId = default)
        {
            Delete(new DeleteRequest(acsUserId: acsUserId));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/delete", requestOptions);
        }

        public async Task DeleteAsync(string acsUserId = default)
        {
            await DeleteAsync(new DeleteRequest(acsUserId: acsUserId));
        }

        [DataContract(Name = "removeFromAccessGroupRequest_request")]
        public class RemoveFromAccessGroupRequest
        {
            [JsonConstructorAttribute]
            protected RemoveFromAccessGroupRequest() { }

            public RemoveFromAccessGroupRequest(
                string acsUserId = default,
                string acsAccessGroupId = default
            )
            {
                AcsUserId = acsUserId;
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(Name = "acs_access_group_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

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

        public void RemoveFromAccessGroup(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        public void RemoveFromAccessGroup(
            string acsUserId = default,
            string acsAccessGroupId = default
        )
        {
            RemoveFromAccessGroup(
                new RemoveFromAccessGroupRequest(
                    acsUserId: acsUserId,
                    acsAccessGroupId: acsAccessGroupId
                )
            );
        }

        public async Task RemoveFromAccessGroupAsync(RemoveFromAccessGroupRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/remove_from_access_group", requestOptions);
        }

        public async Task RemoveFromAccessGroupAsync(
            string acsUserId = default,
            string acsAccessGroupId = default
        )
        {
            await RemoveFromAccessGroupAsync(
                new RemoveFromAccessGroupRequest(
                    acsUserId: acsUserId,
                    acsAccessGroupId: acsAccessGroupId
                )
            );
        }

        [DataContract(Name = "revokeAccessToAllEntrancesRequest_request")]
        public class RevokeAccessToAllEntrancesRequest
        {
            [JsonConstructorAttribute]
            protected RevokeAccessToAllEntrancesRequest() { }

            public RevokeAccessToAllEntrancesRequest(string acsUserId = default)
            {
                AcsUserId = acsUserId;
            }

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

        public void RevokeAccessToAllEntrances(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/revoke_access_to_all_entrances", requestOptions);
        }

        public void RevokeAccessToAllEntrances(string acsUserId = default)
        {
            RevokeAccessToAllEntrances(new RevokeAccessToAllEntrancesRequest(acsUserId: acsUserId));
        }

        public async Task RevokeAccessToAllEntrancesAsync(RevokeAccessToAllEntrancesRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/users/revoke_access_to_all_entrances",
                requestOptions
            );
        }

        public async Task RevokeAccessToAllEntrancesAsync(string acsUserId = default)
        {
            await RevokeAccessToAllEntrancesAsync(
                new RevokeAccessToAllEntrancesRequest(acsUserId: acsUserId)
            );
        }

        [DataContract(Name = "suspendRequest_request")]
        public class SuspendRequest
        {
            [JsonConstructorAttribute]
            protected SuspendRequest() { }

            public SuspendRequest(string acsUserId = default)
            {
                AcsUserId = acsUserId;
            }

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

        public void Suspend(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/suspend", requestOptions);
        }

        public void Suspend(string acsUserId = default)
        {
            Suspend(new SuspendRequest(acsUserId: acsUserId));
        }

        public async Task SuspendAsync(SuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/suspend", requestOptions);
        }

        public async Task SuspendAsync(string acsUserId = default)
        {
            await SuspendAsync(new SuspendRequest(acsUserId: acsUserId));
        }

        [DataContract(Name = "unsuspendRequest_request")]
        public class UnsuspendRequest
        {
            [JsonConstructorAttribute]
            protected UnsuspendRequest() { }

            public UnsuspendRequest(string acsUserId = default)
            {
                AcsUserId = acsUserId;
            }

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

        public void Unsuspend(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/acs/users/unsuspend", requestOptions);
        }

        public void Unsuspend(string acsUserId = default)
        {
            Unsuspend(new UnsuspendRequest(acsUserId: acsUserId));
        }

        public async Task UnsuspendAsync(UnsuspendRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/unsuspend", requestOptions);
        }

        public async Task UnsuspendAsync(string acsUserId = default)
        {
            await UnsuspendAsync(new UnsuspendRequest(acsUserId: acsUserId));
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                UpdateRequestAccessSchedule? accessSchedule = default,
                string acsUserId = default,
                string? fullName = default,
                string? email = default,
                string? phoneNumber = default,
                string? emailAddress = default,
                string? hidAcsSystemId = default
            )
            {
                AccessSchedule = accessSchedule;
                AcsUserId = acsUserId;
                FullName = fullName;
                Email = email;
                PhoneNumber = phoneNumber;
                EmailAddress = emailAddress;
                HidAcsSystemId = hidAcsSystemId;
            }

            [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequestAccessSchedule? AccessSchedule { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public string? HidAcsSystemId { get; set; }

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

        [DataContract(Name = "updateRequestAccessSchedule_model")]
        public class UpdateRequestAccessSchedule
        {
            [JsonConstructorAttribute]
            protected UpdateRequestAccessSchedule() { }

            public UpdateRequestAccessSchedule(string startsAt = default, string endsAt = default)
            {
                StartsAt = startsAt;
                EndsAt = endsAt;
            }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAt { get; set; }

            [DataMember(Name = "ends_at", IsRequired = true, EmitDefaultValue = false)]
            public string EndsAt { get; set; }

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
            _seam.Post<object>("/acs/users/update", requestOptions);
        }

        public void Update(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string acsUserId = default,
            string? fullName = default,
            string? email = default,
            string? phoneNumber = default,
            string? emailAddress = default,
            string? hidAcsSystemId = default
        )
        {
            Update(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsUserId: acsUserId,
                    fullName: fullName,
                    email: email,
                    phoneNumber: phoneNumber,
                    emailAddress: emailAddress,
                    hidAcsSystemId: hidAcsSystemId
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/acs/users/update", requestOptions);
        }

        public async Task UpdateAsync(
            UpdateRequestAccessSchedule? accessSchedule = default,
            string acsUserId = default,
            string? fullName = default,
            string? email = default,
            string? phoneNumber = default,
            string? emailAddress = default,
            string? hidAcsSystemId = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessSchedule: accessSchedule,
                    acsUserId: acsUserId,
                    fullName: fullName,
                    email: email,
                    phoneNumber: phoneNumber,
                    emailAddress: emailAddress,
                    hidAcsSystemId: hidAcsSystemId
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.UsersAcs UsersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UsersAcs UsersAcs { get; }
    }
}
