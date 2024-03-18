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
    public class UnmanagedAccessCodes
    {
        private ISeamClient _seam;

        public UnmanagedAccessCodes(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "convertToManagedRequest_request")]
        public class ConvertToManagedRequest
        {
            [JsonConstructorAttribute]
            protected ConvertToManagedRequest() { }

            public ConvertToManagedRequest(
                string accessCodeId = default,
                bool? isExternalModificationAllowed = default,
                bool? allowExternalModification = default,
                bool? force = default,
                bool? sync = default
            )
            {
                AccessCodeId = accessCodeId;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                AllowExternalModification = allowExternalModification;
                Force = force;
                Sync = sync;
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            [DataMember(Name = "force", IsRequired = false, EmitDefaultValue = false)]
            public bool? Force { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        public void ConvertToManaged(ConvertToManagedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/unmanaged/convert_to_managed", requestOptions);
        }

        public void ConvertToManaged(
            string accessCodeId = default,
            bool? isExternalModificationAllowed = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? sync = default
        )
        {
            ConvertToManaged(
                new ConvertToManagedRequest(
                    accessCodeId: accessCodeId,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    sync: sync
                )
            );
        }

        public async Task ConvertToManagedAsync(ConvertToManagedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/access_codes/unmanaged/convert_to_managed",
                requestOptions
            );
        }

        public async Task ConvertToManagedAsync(
            string accessCodeId = default,
            bool? isExternalModificationAllowed = default,
            bool? allowExternalModification = default,
            bool? force = default,
            bool? sync = default
        )
        {
            await ConvertToManagedAsync(
                new ConvertToManagedRequest(
                    accessCodeId: accessCodeId,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    allowExternalModification: allowExternalModification,
                    force: force,
                    sync: sync
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessCodeId = default, bool? sync = default)
            {
                AccessCodeId = accessCodeId;
                Sync = sync;
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "deleteResponse_response")]
        public class DeleteResponse
        {
            [JsonConstructorAttribute]
            protected DeleteResponse() { }

            public DeleteResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<DeleteResponse>("/access_codes/unmanaged/delete", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Delete(string accessCodeId = default, bool? sync = default)
        {
            return Delete(new DeleteRequest(accessCodeId: accessCodeId, sync: sync));
        }

        public async Task<ActionAttempt> DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<DeleteResponse>(
                    "/access_codes/unmanaged/delete",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> DeleteAsync(
            string accessCodeId = default,
            bool? sync = default
        )
        {
            return (await DeleteAsync(new DeleteRequest(accessCodeId: accessCodeId, sync: sync)));
        }

        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(
                string? deviceId = default,
                string? accessCodeId = default,
                string? code = default
            )
            {
                DeviceId = deviceId;
                AccessCodeId = accessCodeId;
                Code = code;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

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

        public UnmanagedAccessCode Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/access_codes/unmanaged/get", requestOptions)
                .Data.AccessCode;
        }

        public UnmanagedAccessCode Get(
            string? deviceId = default,
            string? accessCodeId = default,
            string? code = default
        )
        {
            return Get(new GetRequest(deviceId: deviceId, accessCodeId: accessCodeId, code: code));
        }

        public async Task<UnmanagedAccessCode> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetResponse>("/access_codes/unmanaged/get", requestOptions)
            )
                .Data
                .AccessCode;
        }

        public async Task<UnmanagedAccessCode> GetAsync(
            string? deviceId = default,
            string? accessCodeId = default,
            string? code = default
        )
        {
            return (
                await GetAsync(
                    new GetRequest(deviceId: deviceId, accessCodeId: accessCodeId, code: code)
                )
            );
        }

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(string deviceId = default, string? userIdentifierKey = default)
            {
                DeviceId = deviceId;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        public List<UnmanagedAccessCode> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_codes/unmanaged/list", requestOptions)
                .Data.AccessCodes;
        }

        public List<UnmanagedAccessCode> List(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return List(new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey));
        }

        public async Task<List<UnmanagedAccessCode>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ListResponse>("/access_codes/unmanaged/list", requestOptions)
            )
                .Data
                .AccessCodes;
        }

        public async Task<List<UnmanagedAccessCode>> ListAsync(
            string deviceId = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(deviceId: deviceId, userIdentifierKey: userIdentifierKey)
                )
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string accessCodeId = default,
                bool isManaged = default,
                bool? allowExternalModification = default,
                bool? isExternalModificationAllowed = default,
                bool? force = default
            )
            {
                AccessCodeId = accessCodeId;
                IsManaged = isManaged;
                AllowExternalModification = allowExternalModification;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                Force = force;
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
            public bool IsManaged { get; set; }

            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            [DataMember(Name = "force", IsRequired = false, EmitDefaultValue = false)]
            public bool? Force { get; set; }

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
            _seam.Post<object>("/access_codes/unmanaged/update", requestOptions);
        }

        public void Update(
            string accessCodeId = default,
            bool isManaged = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? force = default
        )
        {
            Update(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    isManaged: isManaged,
                    allowExternalModification: allowExternalModification,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    force: force
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/unmanaged/update", requestOptions);
        }

        public async Task UpdateAsync(
            string accessCodeId = default,
            bool isManaged = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? force = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    isManaged: isManaged,
                    allowExternalModification: allowExternalModification,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    force: force
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
