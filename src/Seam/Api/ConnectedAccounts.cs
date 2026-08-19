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
    public class ConnectedAccounts
    {
        private ISeamClient _seam;

        public ConnectedAccounts(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Delete a Connected Account.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string connectedAccountId = default)
            {
                ConnectedAccountId = connectedAccountId;
            }

            /// <summary>
            /// ID of the connected account that you want to delete.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

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
        /// Deletes a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        ///
        /// Deleting a connected account triggers a `connected_account.deleted` event and removes the connected account and all data associated with the connected account from Seam, including devices, events, access codes, and so on. For every deleted resource, Seam sends a corresponding deleted event, but the resource is not deleted from the provider.
        ///
        /// For example, if you delete a connected account with a device that has an access code, Seam sends a `connected_account.deleted` event, a `device.deleted` event, and an `access_code.deleted` event, but Seam does not remove the access code from the device.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/connected_accounts/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        ///
        /// Deleting a connected account triggers a `connected_account.deleted` event and removes the connected account and all data associated with the connected account from Seam, including devices, events, access codes, and so on. For every deleted resource, Seam sends a corresponding deleted event, but the resource is not deleted from the provider.
        ///
        /// For example, if you delete a connected account with a device that has an access code, Seam sends a `connected_account.deleted` event, a `device.deleted` event, and an `access_code.deleted` event, but Seam does not remove the access code from the device.
        /// </summary>
        public void Delete(string connectedAccountId = default)
        {
            Delete(new DeleteRequest(connectedAccountId: connectedAccountId));
        }

        /// <summary>
        /// Deletes a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        ///
        /// Deleting a connected account triggers a `connected_account.deleted` event and removes the connected account and all data associated with the connected account from Seam, including devices, events, access codes, and so on. For every deleted resource, Seam sends a corresponding deleted event, but the resource is not deleted from the provider.
        ///
        /// For example, if you delete a connected account with a device that has an access code, Seam sends a `connected_account.deleted` event, a `device.deleted` event, and an `access_code.deleted` event, but Seam does not remove the access code from the device.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/connected_accounts/delete", requestOptions);
        }

        /// <summary>
        /// Deletes a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        ///
        /// Deleting a connected account triggers a `connected_account.deleted` event and removes the connected account and all data associated with the connected account from Seam, including devices, events, access codes, and so on. For every deleted resource, Seam sends a corresponding deleted event, but the resource is not deleted from the provider.
        ///
        /// For example, if you delete a connected account with a device that has an access code, Seam sends a `connected_account.deleted` event, a `device.deleted` event, and an `access_code.deleted` event, but Seam does not remove the access code from the device.
        /// </summary>
        public async Task DeleteAsync(string connectedAccountId = default)
        {
            await DeleteAsync(new DeleteRequest(connectedAccountId: connectedAccountId));
        }

        /// <summary>
        /// Request parameters for Get a Connected Account.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string? connectedAccountId = default, string? email = default)
            {
                ConnectedAccountId = connectedAccountId;
                Email = email;
            }

            /// <summary>
            /// ID of the connected account that you want to get.
            /// </summary>
            [DataMember(
                Name = "connected_account_id",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? ConnectedAccountId { get; set; }

            /// <summary>
            /// Email address associated with the connected account that you want to get.
            /// </summary>
            [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
            public string? Email { get; set; }

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

            public GetResponse(ConnectedAccount connectedAccount = default)
            {
                ConnectedAccount = connectedAccount;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "connected_account", IsRequired = false, EmitDefaultValue = false)]
            public ConnectedAccount ConnectedAccount { get; set; }

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
        /// Returns a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public ConnectedAccount Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/connected_accounts/get", requestOptions)
                .EnsureData("/connected_accounts/get")
                .ConnectedAccount;
        }

        /// <summary>
        /// Returns a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public ConnectedAccount Get(string? connectedAccountId = default, string? email = default)
        {
            return Get(new GetRequest(connectedAccountId: connectedAccountId, email: email));
        }

        /// <summary>
        /// Returns a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task<ConnectedAccount> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/connected_accounts/get", requestOptions))
                .EnsureData("/connected_accounts/get")
                .ConnectedAccount;
        }

        /// <summary>
        /// Returns a specified [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task<ConnectedAccount> GetAsync(
            string? connectedAccountId = default,
            string? email = default
        )
        {
            return (
                await GetAsync(new GetRequest(connectedAccountId: connectedAccountId, email: email))
            );
        }

        /// <summary>
        /// Request parameters for List Connected Accounts.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                object? customMetadataHas = default,
                string? customerKey = default,
                int? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? spaceId = default,
                string? userIdentifierKey = default
            )
            {
                CustomMetadataHas = customMetadataHas;
                CustomerKey = customerKey;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                SpaceId = spaceId;
                UserIdentifierKey = userIdentifierKey;
            }

            /// <summary>
            /// Custom metadata pairs by which you want to filter connected accounts. Returns connected accounts with `custom_metadata` that contains all of the provided key:value pairs. Key names cannot contain a period (.). Specify `null` to match a key that is unset. A key given an empty string is omitted from the filter.
            /// </summary>
            [DataMember(Name = "custom_metadata_has", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadataHas { get; set; }

            /// <summary>
            /// Customer key by which you want to filter connected accounts.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

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
            /// String for which to search. Filters returned connected accounts to include all records that satisfy a partial match using `connected_account_id`, `account_type`, `customer_key`, `custom_metadata`, `user_identifier.username`, `user_identifier.email` or `user_identifier.phone`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// ID of the space by which you want to filter connected accounts.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

            /// <summary>
            /// Your user ID for the user by which you want to filter connected accounts.
            /// </summary>
            [DataMember(Name = "user_identifier_key", IsRequired = false, EmitDefaultValue = false)]
            public string? UserIdentifierKey { get; set; }

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

            public ListResponse(List<ConnectedAccount> connectedAccounts = default)
            {
                ConnectedAccounts = connectedAccounts;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "connected_accounts", IsRequired = false, EmitDefaultValue = false)]
            public List<ConnectedAccount> ConnectedAccounts { get; set; }

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
        /// Returns a list of all [connected accounts](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public List<ConnectedAccount> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/connected_accounts/list", requestOptions)
                .EnsureData("/connected_accounts/list")
                .ConnectedAccounts;
        }

        /// <summary>
        /// Returns a list of all [connected accounts](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public List<ConnectedAccount> List(
            object? customMetadataHas = default,
            string? customerKey = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    customMetadataHas: customMetadataHas,
                    customerKey: customerKey,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    spaceId: spaceId,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all [connected accounts](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task<List<ConnectedAccount>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/connected_accounts/list", requestOptions))
                .EnsureData("/connected_accounts/list")
                .ConnectedAccounts;
        }

        /// <summary>
        /// Returns a list of all [connected accounts](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task<List<ConnectedAccount>> ListAsync(
            object? customMetadataHas = default,
            string? customerKey = default,
            int? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? spaceId = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        customMetadataHas: customMetadataHas,
                        customerKey: customerKey,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        spaceId: spaceId,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Sync a Connected Account.
        /// </summary>
        [DataContract(Name = "syncRequest_request")]
        public class SyncRequest
        {
            [JsonConstructorAttribute]
            protected SyncRequest() { }

            public SyncRequest(string connectedAccountId = default)
            {
                ConnectedAccountId = connectedAccountId;
            }

            /// <summary>
            /// ID of the connected account that you want to sync.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

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
        /// Request a [connected account](https://docs.seam.co/core-concepts/connected-accounts) sync attempt for the specified `connected_account_id`.
        /// </summary>
        public void Sync(SyncRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connected_accounts/sync", requestOptions);
        }

        /// <summary>
        /// Request a [connected account](https://docs.seam.co/core-concepts/connected-accounts) sync attempt for the specified `connected_account_id`.
        /// </summary>
        public void Sync(string connectedAccountId = default)
        {
            Sync(new SyncRequest(connectedAccountId: connectedAccountId));
        }

        /// <summary>
        /// Request a [connected account](https://docs.seam.co/core-concepts/connected-accounts) sync attempt for the specified `connected_account_id`.
        /// </summary>
        public async Task SyncAsync(SyncRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/connected_accounts/sync", requestOptions);
        }

        /// <summary>
        /// Request a [connected account](https://docs.seam.co/core-concepts/connected-accounts) sync attempt for the specified `connected_account_id`.
        /// </summary>
        public async Task SyncAsync(string connectedAccountId = default)
        {
            await SyncAsync(new SyncRequest(connectedAccountId: connectedAccountId));
        }

        /// <summary>
        /// Request parameters for Update a Connected Account.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
                bool? automaticallyManageNewDevices = default,
                string connectedAccountId = default,
                object? customMetadata = default,
                string? customerKey = default,
                string? displayName = default
            )
            {
                AcceptedCapabilities = acceptedCapabilities;
                AutomaticallyManageNewDevices = automaticallyManageNewDevices;
                ConnectedAccountId = connectedAccountId;
                CustomMetadata = customMetadata;
                CustomerKey = customerKey;
                DisplayName = displayName;
            }

            /// <summary>
            /// List of accepted device capabilities that restrict the types of devices that can be connected through this connected account. Valid values are `lock`, `thermostat`, `noise_sensor`, and `access_control`.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum AcceptedCapabilitiesEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "lock")]
                Lock = 1,

                [EnumMember(Value = "thermostat")]
                Thermostat = 2,

                [EnumMember(Value = "noise_sensor")]
                NoiseSensor = 3,

                [EnumMember(Value = "access_control")]
                AccessControl = 4,

                [EnumMember(Value = "camera")]
                Camera = 5,
            }

            /// <summary>
            /// List of accepted device capabilities that restrict the types of devices that can be connected through this connected account. Valid values are `lock`, `thermostat`, `noise_sensor`, and `access_control`.
            /// </summary>
            [DataMember(
                Name = "accepted_capabilities",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<UpdateRequest.AcceptedCapabilitiesEnum>? AcceptedCapabilities { get; set; }

            /// <summary>
            /// Indicates whether newly-added devices should appear as [managed devices](https://docs.seam.co/core-concepts/devices/managed-and-unmanaged-devices).
            /// </summary>
            [DataMember(
                Name = "automatically_manage_new_devices",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AutomaticallyManageNewDevices { get; set; }

            /// <summary>
            /// ID of the connected account that you want to update.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

            /// <summary>
            /// Custom metadata that you want to associate with the connected account. Entirely replaces the existing custom metadata object. If a new Connect Webview contains custom metadata and is used to reconnect a connected account, the custom metadata from the Connect Webview will entirely replace the entire custom metadata object on the connected account. Supports up to 50 JSON key:value pairs, with key names up to 40 characters long that cannot contain a period (.). [Adding custom metadata to a connected account](https://docs.seam.co/core-concepts/connected-accounts/adding-custom-metadata-to-a-connected-account) enables you to store custom information, like customer details or internal IDs from your application. Then, you can [filter connected accounts by the desired metadata](https://docs.seam.co/core-concepts/connected-accounts/filtering-connected-accounts-by-custom-metadata). Set a key to `null` or to an empty string to remove that key from the custom metadata.
            /// </summary>
            [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
            public object? CustomMetadata { get; set; }

            /// <summary>
            /// The customer key to associate with this connected account. If provided, the connected account and all resources under the connected account will be moved to this customer. May only be provided if the connected account is not already associated with a customer.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// Human-readable name for the connected account, shown in the dashboard. For example, `Booking from Airbnb House 1`.
            /// </summary>
            [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
            public string? DisplayName { get; set; }

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
        /// Updates a [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/connected_accounts/update", requestOptions);
        }

        /// <summary>
        /// Updates a [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public void Update(
            List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            bool? automaticallyManageNewDevices = default,
            string connectedAccountId = default,
            object? customMetadata = default,
            string? customerKey = default,
            string? displayName = default
        )
        {
            Update(
                new UpdateRequest(
                    acceptedCapabilities: acceptedCapabilities,
                    automaticallyManageNewDevices: automaticallyManageNewDevices,
                    connectedAccountId: connectedAccountId,
                    customMetadata: customMetadata,
                    customerKey: customerKey,
                    displayName: displayName
                )
            );
        }

        /// <summary>
        /// Updates a [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/connected_accounts/update", requestOptions);
        }

        /// <summary>
        /// Updates a [connected account](https://docs.seam.co/core-concepts/connected-accounts).
        /// </summary>
        public async Task UpdateAsync(
            List<UpdateRequest.AcceptedCapabilitiesEnum>? acceptedCapabilities = default,
            bool? automaticallyManageNewDevices = default,
            string connectedAccountId = default,
            object? customMetadata = default,
            string? customerKey = default,
            string? displayName = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    acceptedCapabilities: acceptedCapabilities,
                    automaticallyManageNewDevices: automaticallyManageNewDevices,
                    connectedAccountId: connectedAccountId,
                    customMetadata: customMetadata,
                    customerKey: customerKey,
                    displayName: displayName
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.ConnectedAccounts ConnectedAccounts => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ConnectedAccounts ConnectedAccounts { get; }
    }
}
