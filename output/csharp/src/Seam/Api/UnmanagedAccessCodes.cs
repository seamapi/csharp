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
    public class UnmanagedAccessCodes
    {
        private ISeamClient _seam;

        public UnmanagedAccessCodes(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Convert an Unmanaged Access Code.
        /// </summary>
        [DataContract(Name = "convertToManagedRequest_request")]
        public class ConvertToManagedRequest
        {
            [JsonConstructorAttribute]
            protected ConvertToManagedRequest() { }

            public ConvertToManagedRequest(
                string accessCodeId = default,
                bool? allowExternalModification = default,
                bool? force = default,
                bool? isExternalModificationAllowed = default
            )
            {
                AccessCodeId = accessCodeId;
                AllowExternalModification = allowExternalModification;
                Force = force;
                IsExternalModificationAllowed = isExternalModificationAllowed;
            }

            /// <summary>
            /// ID of the unmanaged access code that you want to convert to a managed access code.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the access code is allowed.
            /// </summary>
            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            /// <summary>
            /// Indicates whether to force the access code conversion. To switch management of an access code from one Seam workspace to another, set `force` to `true`.
            /// </summary>
            [DataMember(Name = "force", IsRequired = false, EmitDefaultValue = false)]
            public bool? Force { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the access code is allowed.
            /// </summary>
            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

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
        /// Converts an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) to an [access code managed through Seam](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// An unmanaged access code has a limited set of operations that you can perform on it. Once you convert an unmanaged access code to a managed access code, the full set of access code operations and lifecycle events becomes available for it.
        ///
        /// Note that not all device providers support converting an unmanaged access code to a managed access code.
        /// </summary>
        public void ConvertToManaged(ConvertToManagedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/unmanaged/convert_to_managed", requestOptions);
        }

        /// <summary>
        /// Converts an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) to an [access code managed through Seam](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// An unmanaged access code has a limited set of operations that you can perform on it. Once you convert an unmanaged access code to a managed access code, the full set of access code operations and lifecycle events becomes available for it.
        ///
        /// Note that not all device providers support converting an unmanaged access code to a managed access code.
        /// </summary>
        public void ConvertToManaged(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? isExternalModificationAllowed = default
        )
        {
            ConvertToManaged(
                new ConvertToManagedRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    isExternalModificationAllowed: isExternalModificationAllowed
                )
            );
        }

        /// <summary>
        /// Converts an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) to an [access code managed through Seam](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// An unmanaged access code has a limited set of operations that you can perform on it. Once you convert an unmanaged access code to a managed access code, the full set of access code operations and lifecycle events becomes available for it.
        ///
        /// Note that not all device providers support converting an unmanaged access code to a managed access code.
        /// </summary>
        public async Task ConvertToManagedAsync(ConvertToManagedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/access_codes/unmanaged/convert_to_managed",
                requestOptions
            );
        }

        /// <summary>
        /// Converts an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes) to an [access code managed through Seam](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// An unmanaged access code has a limited set of operations that you can perform on it. Once you convert an unmanaged access code to a managed access code, the full set of access code operations and lifecycle events becomes available for it.
        ///
        /// Note that not all device providers support converting an unmanaged access code to a managed access code.
        /// </summary>
        public async Task ConvertToManagedAsync(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? isExternalModificationAllowed = default
        )
        {
            await ConvertToManagedAsync(
                new ConvertToManagedRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    isExternalModificationAllowed: isExternalModificationAllowed
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete an Unmanaged Access Code.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessCodeId = default)
            {
                AccessCodeId = accessCodeId;
            }

            /// <summary>
            /// ID of the unmanaged access code that you want to delete.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

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
        /// Deletes an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/unmanaged/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public void Delete(string accessCodeId = default)
        {
            Delete(new DeleteRequest(accessCodeId: accessCodeId));
        }

        /// <summary>
        /// Deletes an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/unmanaged/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task DeleteAsync(string accessCodeId = default)
        {
            await DeleteAsync(new DeleteRequest(accessCodeId: accessCodeId));
        }

        /// <summary>
        /// Request parameters for Get an Unmanaged Access Code.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(
                string? accessCodeId = default,
                string? code = default,
                string? deviceId = default
            )
            {
                AccessCodeId = accessCodeId;
                Code = code;
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the unmanaged access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            /// <summary>
            /// Code of the unmanaged access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// ID of the device containing the unmanaged access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

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

            public GetResponse(UnmanagedAccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessCode AccessCode { get; set; }

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
        /// Returns a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public UnmanagedAccessCode Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/access_codes/unmanaged/get", requestOptions)
                .EnsureData("/access_codes/unmanaged/get")
                .AccessCode;
        }

        /// <summary>
        /// Returns a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public UnmanagedAccessCode Get(
            string? accessCodeId = default,
            string? code = default,
            string? deviceId = default
        )
        {
            return Get(new GetRequest(accessCodeId: accessCodeId, code: code, deviceId: deviceId));
        }

        /// <summary>
        /// Returns a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public async Task<UnmanagedAccessCode> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/access_codes/unmanaged/get", requestOptions)
            )
                .EnsureData("/access_codes/unmanaged/get")
                .AccessCode;
        }

        /// <summary>
        /// Returns a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public async Task<UnmanagedAccessCode> GetAsync(
            string? accessCodeId = default,
            string? code = default,
            string? deviceId = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(accessCodeId: accessCodeId, code: code, deviceId: deviceId)
                )
            );
        }

        /// <summary>
        /// Request parameters for List Unmanaged Access Codes.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string deviceId = default,
                float? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentifierKey = default
            )
            {
                DeviceId = deviceId;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentifierKey = userIdentifierKey;
            }

            /// <summary>
            /// ID of the device for which you want to list unmanaged access codes.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Numerical limit on the number of unmanaged access codes to return.
            /// </summary>
            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            /// <summary>
            /// Identifies the specific page of results to return, obtained from the previous page&apos;s `next_page_cursor`.
            /// </summary>
            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

            /// <summary>
            /// String for which to search. Filters returned access codes to include all records that satisfy a partial match using `name`, `code` or `access_code_id`.
            /// </summary>
            [DataMember(Name = "search", IsRequired = false, EmitDefaultValue = false)]
            public string? Search { get; set; }

            /// <summary>
            /// Your user ID for the user by which to filter unmanaged access codes.
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

            public ListResponse(List<UnmanagedAccessCode> accessCodes = default)
            {
                AccessCodes = accessCodes;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_codes", IsRequired = false, EmitDefaultValue = false)]
            public List<UnmanagedAccessCode> AccessCodes { get; set; }

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
        /// Returns a list of all [unmanaged access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public List<UnmanagedAccessCode> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_codes/unmanaged/list", requestOptions)
                .EnsureData("/access_codes/unmanaged/list")
                .AccessCodes;
        }

        /// <summary>
        /// Returns a list of all [unmanaged access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public List<UnmanagedAccessCode> List(
            string deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    deviceId: deviceId,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all [unmanaged access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task<List<UnmanagedAccessCode>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/access_codes/unmanaged/list", requestOptions)
            )
                .EnsureData("/access_codes/unmanaged/list")
                .AccessCodes;
        }

        /// <summary>
        /// Returns a list of all [unmanaged access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task<List<UnmanagedAccessCode>> ListAsync(
            string deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        deviceId: deviceId,
                        limit: limit,
                        pageCursor: pageCursor,
                        search: search,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Update an Unmanaged Access Code.
        /// </summary>
        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string accessCodeId = default,
                bool? allowExternalModification = default,
                bool? force = default,
                bool? isExternalModificationAllowed = default,
                bool isManaged = default
            )
            {
                AccessCodeId = accessCodeId;
                AllowExternalModification = allowExternalModification;
                Force = force;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                IsManaged = isManaged;
            }

            /// <summary>
            /// ID of the unmanaged access code that you want to update.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed.
            /// </summary>
            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            /// <summary>
            /// Indicates whether to force the unmanaged access code update.
            /// </summary>
            [DataMember(Name = "force", IsRequired = false, EmitDefaultValue = false)]
            public bool? Force { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed.
            /// </summary>
            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

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

        /// <summary>
        /// Updates a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public void Update(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? isExternalModificationAllowed = default,
            bool isManaged = default
        )
        {
            Update(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    isManaged: isManaged
                )
            );
        }

        /// <summary>
        /// Updates a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/unmanaged/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified [unmanaged access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/migrating-existing-access-codes).
        /// </summary>
        public async Task UpdateAsync(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? isExternalModificationAllowed = default,
            bool isManaged = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    isExternalModificationAllowed: isExternalModificationAllowed,
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
        public Api.UnmanagedAccessCodes UnmanagedAccessCodes => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.UnmanagedAccessCodes UnmanagedAccessCodes { get; }
    }
}
