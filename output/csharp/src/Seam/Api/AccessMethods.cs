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
    public class AccessMethods
    {
        private ISeamClient _seam;

        public AccessMethods(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Assign a Card Credential to an Access Method.
        /// </summary>
        [DataContract(Name = "assignCardRequest_request")]
        public class AssignCardRequest
        {
            [JsonConstructorAttribute]
            protected AssignCardRequest() { }

            public AssignCardRequest(string accessMethodId = default, string cardNumber = default)
            {
                AccessMethodId = accessMethodId;
                CardNumber = cardNumber;
            }

            /// <summary>
            /// ID of the `access_method` to assign the credential to.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

            /// <summary>
            /// Card number of the credential to assign.
            /// </summary>
            [DataMember(Name = "card_number", IsRequired = true, EmitDefaultValue = false)]
            public string CardNumber { get; set; }

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

        [DataContract(Name = "assignCardResponse_response")]
        public class AssignCardResponse
        {
            [JsonConstructorAttribute]
            protected AssignCardResponse() { }

            public AssignCardResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Assigns a pre-registered card credential, identified by `card_number`, to a card-mode access method. Use this endpoint for access systems that use pre-registered cards, where a physical card must be associated with an access method before it can be used for access. Assigning a card credential also triggers issuance of the access method.
        /// </summary>
        public ActionAttempt AssignCard(AssignCardRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<AssignCardResponse>("/access_methods/assign_card", requestOptions)
                .EnsureData("/access_methods/assign_card")
                .ActionAttempt;
        }

        /// <summary>
        /// Assigns a pre-registered card credential, identified by `card_number`, to a card-mode access method. Use this endpoint for access systems that use pre-registered cards, where a physical card must be associated with an access method before it can be used for access. Assigning a card credential also triggers issuance of the access method.
        /// </summary>
        public ActionAttempt AssignCard(
            string accessMethodId = default,
            string cardNumber = default
        )
        {
            return AssignCard(
                new AssignCardRequest(accessMethodId: accessMethodId, cardNumber: cardNumber)
            );
        }

        /// <summary>
        /// Assigns a pre-registered card credential, identified by `card_number`, to a card-mode access method. Use this endpoint for access systems that use pre-registered cards, where a physical card must be associated with an access method before it can be used for access. Assigning a card credential also triggers issuance of the access method.
        /// </summary>
        public async Task<ActionAttempt> AssignCardAsync(AssignCardRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<AssignCardResponse>(
                    "/access_methods/assign_card",
                    requestOptions
                )
            )
                .EnsureData("/access_methods/assign_card")
                .ActionAttempt;
        }

        /// <summary>
        /// Assigns a pre-registered card credential, identified by `card_number`, to a card-mode access method. Use this endpoint for access systems that use pre-registered cards, where a physical card must be associated with an access method before it can be used for access. Assigning a card credential also triggers issuance of the access method.
        /// </summary>
        public async Task<ActionAttempt> AssignCardAsync(
            string accessMethodId = default,
            string cardNumber = default
        )
        {
            return (
                await AssignCardAsync(
                    new AssignCardRequest(accessMethodId: accessMethodId, cardNumber: cardNumber)
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete an Access Method.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(
                string? accessMethodId = default,
                string? accessGrantId = default,
                string? reservationKey = default
            )
            {
                AccessMethodId = accessMethodId;
                AccessGrantId = accessGrantId;
                ReservationKey = reservationKey;
            }

            /// <summary>
            /// ID of access method to delete.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            /// <summary>
            /// ID of access grant whose access methods should be deleted.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// Reservation key of the access grant whose access methods should be deleted.
            /// </summary>
            [DataMember(Name = "reservation_key", IsRequired = false, EmitDefaultValue = false)]
            public string? ReservationKey { get; set; }

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
        /// Deletes an access method.
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/access_methods/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an access method.
        /// </summary>
        public void Delete(
            string? accessMethodId = default,
            string? accessGrantId = default,
            string? reservationKey = default
        )
        {
            Delete(
                new DeleteRequest(
                    accessMethodId: accessMethodId,
                    accessGrantId: accessGrantId,
                    reservationKey: reservationKey
                )
            );
        }

        /// <summary>
        /// Deletes an access method.
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/access_methods/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an access method.
        /// </summary>
        public async Task DeleteAsync(
            string? accessMethodId = default,
            string? accessGrantId = default,
            string? reservationKey = default
        )
        {
            await DeleteAsync(
                new DeleteRequest(
                    accessMethodId: accessMethodId,
                    accessGrantId: accessGrantId,
                    reservationKey: reservationKey
                )
            );
        }

        /// <summary>
        /// Request parameters for Encode an Access Method.
        /// </summary>
        [DataContract(Name = "encodeRequest_request")]
        public class EncodeRequest
        {
            [JsonConstructorAttribute]
            protected EncodeRequest() { }

            public EncodeRequest(string accessMethodId = default, string acsEncoderId = default)
            {
                AccessMethodId = accessMethodId;
                AcsEncoderId = acsEncoderId;
            }

            /// <summary>
            /// ID of the `access_method` to encode onto a card.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

            /// <summary>
            /// ID of the `acs_encoder` to use to encode the `access_method`.
            /// </summary>
            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

        [DataContract(Name = "encodeResponse_response")]
        public class EncodeResponse
        {
            [JsonConstructorAttribute]
            protected EncodeResponse() { }

            public EncodeResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Encodes an existing access method onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public ActionAttempt Encode(EncodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<EncodeResponse>("/access_methods/encode", requestOptions)
                .EnsureData("/access_methods/encode")
                .ActionAttempt;
        }

        /// <summary>
        /// Encodes an existing access method onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public ActionAttempt Encode(string accessMethodId = default, string acsEncoderId = default)
        {
            return Encode(
                new EncodeRequest(accessMethodId: accessMethodId, acsEncoderId: acsEncoderId)
            );
        }

        /// <summary>
        /// Encodes an existing access method onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<ActionAttempt> EncodeAsync(EncodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<EncodeResponse>("/access_methods/encode", requestOptions))
                .EnsureData("/access_methods/encode")
                .ActionAttempt;
        }

        /// <summary>
        /// Encodes an existing access method onto a plastic card placed on the specified [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        public async Task<ActionAttempt> EncodeAsync(
            string accessMethodId = default,
            string acsEncoderId = default
        )
        {
            return (
                await EncodeAsync(
                    new EncodeRequest(accessMethodId: accessMethodId, acsEncoderId: acsEncoderId)
                )
            );
        }

        /// <summary>
        /// Request parameters for Get an Access Method.
        /// </summary>
        [DataContract(Name = "getRequest_request")]
        public class GetRequest
        {
            [JsonConstructorAttribute]
            protected GetRequest() { }

            public GetRequest(string accessMethodId = default)
            {
                AccessMethodId = accessMethodId;
            }

            /// <summary>
            /// ID of access method to get.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

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

            public GetResponse(AccessMethod accessMethod = default)
            {
                AccessMethod = accessMethod;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_method", IsRequired = false, EmitDefaultValue = false)]
            public AccessMethod AccessMethod { get; set; }

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
        /// Gets an access method.
        /// </summary>
        public AccessMethod Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetResponse>("/access_methods/get", requestOptions)
                .EnsureData("/access_methods/get")
                .AccessMethod;
        }

        /// <summary>
        /// Gets an access method.
        /// </summary>
        public AccessMethod Get(string accessMethodId = default)
        {
            return Get(new GetRequest(accessMethodId: accessMethodId));
        }

        /// <summary>
        /// Gets an access method.
        /// </summary>
        public async Task<AccessMethod> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/access_methods/get", requestOptions))
                .EnsureData("/access_methods/get")
                .AccessMethod;
        }

        /// <summary>
        /// Gets an access method.
        /// </summary>
        public async Task<AccessMethod> GetAsync(string accessMethodId = default)
        {
            return (await GetAsync(new GetRequest(accessMethodId: accessMethodId)));
        }

        /// <summary>
        /// Request parameters for Get related Access Method resources.
        /// </summary>
        [DataContract(Name = "getRelatedRequest_request")]
        public class GetRelatedRequest
        {
            [JsonConstructorAttribute]
            protected GetRelatedRequest() { }

            public GetRelatedRequest(
                List<string> accessMethodIds = default,
                List<GetRelatedRequest.ExcludeEnum>? exclude = default,
                List<GetRelatedRequest.IncludeEnum>? include = default
            )
            {
                AccessMethodIds = accessMethodIds;
                Exclude = exclude;
                Include = include;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ExcludeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "spaces")]
                Spaces = 1,

                [EnumMember(Value = "devices")]
                Devices = 2,

                [EnumMember(Value = "acs_entrances")]
                AcsEntrances = 3,

                [EnumMember(Value = "access_grants")]
                AccessGrants = 4,

                [EnumMember(Value = "access_methods")]
                AccessMethods = 5,

                [EnumMember(Value = "instant_keys")]
                InstantKeys = 6,

                [EnumMember(Value = "client_sessions")]
                ClientSessions = 7,

                [EnumMember(Value = "acs_credentials")]
                AcsCredentials = 8,
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum IncludeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "spaces")]
                Spaces = 1,

                [EnumMember(Value = "devices")]
                Devices = 2,

                [EnumMember(Value = "acs_entrances")]
                AcsEntrances = 3,

                [EnumMember(Value = "access_grants")]
                AccessGrants = 4,

                [EnumMember(Value = "access_methods")]
                AccessMethods = 5,

                [EnumMember(Value = "instant_keys")]
                InstantKeys = 6,

                [EnumMember(Value = "client_sessions")]
                ClientSessions = 7,

                [EnumMember(Value = "acs_credentials")]
                AcsCredentials = 8,
            }

            /// <summary>
            /// IDs of the access methods that you want to get along with their related resources.
            /// </summary>
            [DataMember(Name = "access_method_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> AccessMethodIds { get; set; }

            [DataMember(Name = "exclude", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.ExcludeEnum>? Exclude { get; set; }

            [DataMember(Name = "include", IsRequired = false, EmitDefaultValue = false)]
            public List<GetRelatedRequest.IncludeEnum>? Include { get; set; }

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

        [DataContract(Name = "getRelatedResponse_response")]
        public class GetRelatedResponse
        {
            [JsonConstructorAttribute]
            protected GetRelatedResponse() { }

            public GetRelatedResponse(Batch batch = default)
            {
                Batch = batch;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "batch", IsRequired = false, EmitDefaultValue = false)]
            public Batch Batch { get; set; }

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
        /// Gets all related resources for one or more Access Methods.
        /// </summary>
        public Batch GetRelated(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GetRelatedResponse>("/access_methods/get_related", requestOptions)
                .EnsureData("/access_methods/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Access Methods.
        /// </summary>
        public Batch GetRelated(
            List<string> accessMethodIds = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return GetRelated(
                new GetRelatedRequest(
                    accessMethodIds: accessMethodIds,
                    exclude: exclude,
                    include: include
                )
            );
        }

        /// <summary>
        /// Gets all related resources for one or more Access Methods.
        /// </summary>
        public async Task<Batch> GetRelatedAsync(GetRelatedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GetRelatedResponse>(
                    "/access_methods/get_related",
                    requestOptions
                )
            )
                .EnsureData("/access_methods/get_related")
                .Batch;
        }

        /// <summary>
        /// Gets all related resources for one or more Access Methods.
        /// </summary>
        public async Task<Batch> GetRelatedAsync(
            List<string> accessMethodIds = default,
            List<GetRelatedRequest.ExcludeEnum>? exclude = default,
            List<GetRelatedRequest.IncludeEnum>? include = default
        )
        {
            return (
                await GetRelatedAsync(
                    new GetRelatedRequest(
                        accessMethodIds: accessMethodIds,
                        exclude: exclude,
                        include: include
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for List Access Methods.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                string? accessCodeId = default,
                string? accessGrantId = default,
                string? accessGrantKey = default,
                string? acsEntranceId = default,
                string? deviceId = default,
                string? spaceId = default
            )
            {
                AccessCodeId = accessCodeId;
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
                AcsEntranceId = acsEntranceId;
                DeviceId = deviceId;
                SpaceId = spaceId;
            }

            /// <summary>
            /// ID of the access code for which you want to retrieve all access methods.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            /// <summary>
            /// ID of Access Grant to list access methods for.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// Key of Access Grant to list access methods for.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// ID of the entrance for which you want to retrieve all access methods.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

            /// <summary>
            /// ID of the device for which you want to retrieve all access methods.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// ID of the space for which you want to retrieve all access methods.
            /// </summary>
            [DataMember(Name = "space_id", IsRequired = false, EmitDefaultValue = false)]
            public string? SpaceId { get; set; }

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

            public ListResponse(List<AccessMethod> accessMethods = default)
            {
                AccessMethods = accessMethods;
            }

            /// <summary>
            /// OK
            /// </summary>
            [DataMember(Name = "access_methods", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessMethod> AccessMethods { get; set; }

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
        /// Lists all access methods, usually filtered by Access Grant.
        /// </summary>
        public List<AccessMethod> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ListResponse>("/access_methods/list", requestOptions)
                .EnsureData("/access_methods/list")
                .AccessMethods;
        }

        /// <summary>
        /// Lists all access methods, usually filtered by Access Grant.
        /// </summary>
        public List<AccessMethod> List(
            string? accessCodeId = default,
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? deviceId = default,
            string? spaceId = default
        )
        {
            return List(
                new ListRequest(
                    accessCodeId: accessCodeId,
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    acsEntranceId: acsEntranceId,
                    deviceId: deviceId,
                    spaceId: spaceId
                )
            );
        }

        /// <summary>
        /// Lists all access methods, usually filtered by Access Grant.
        /// </summary>
        public async Task<List<AccessMethod>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/access_methods/list", requestOptions))
                .EnsureData("/access_methods/list")
                .AccessMethods;
        }

        /// <summary>
        /// Lists all access methods, usually filtered by Access Grant.
        /// </summary>
        public async Task<List<AccessMethod>> ListAsync(
            string? accessCodeId = default,
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? acsEntranceId = default,
            string? deviceId = default,
            string? spaceId = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessCodeId: accessCodeId,
                        accessGrantId: accessGrantId,
                        accessGrantKey: accessGrantKey,
                        acsEntranceId: acsEntranceId,
                        deviceId: deviceId,
                        spaceId: spaceId
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Unlock a Door with an Access Method.
        /// </summary>
        [DataContract(Name = "unlockDoorRequest_request")]
        public class UnlockDoorRequest
        {
            [JsonConstructorAttribute]
            protected UnlockDoorRequest() { }

            public UnlockDoorRequest(
                string accessMethodId = default,
                string acsEntranceId = default
            )
            {
                AccessMethodId = accessMethodId;
                AcsEntranceId = acsEntranceId;
            }

            /// <summary>
            /// ID of the cloud_key `access_method` to use for the unlock operation.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessMethodId { get; set; }

            /// <summary>
            /// ID of the entrance to unlock.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEntranceId { get; set; }

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

        [DataContract(Name = "unlockDoorResponse_response")]
        public class UnlockDoorResponse
        {
            [JsonConstructorAttribute]
            protected UnlockDoorResponse() { }

            public UnlockDoorResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using the cloud key credential associated with an access method. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public ActionAttempt UnlockDoor(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UnlockDoorResponse>("/access_methods/unlock_door", requestOptions)
                .EnsureData("/access_methods/unlock_door")
                .ActionAttempt;
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using the cloud key credential associated with an access method. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public ActionAttempt UnlockDoor(
            string accessMethodId = default,
            string acsEntranceId = default
        )
        {
            return UnlockDoor(
                new UnlockDoorRequest(accessMethodId: accessMethodId, acsEntranceId: acsEntranceId)
            );
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using the cloud key credential associated with an access method. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public async Task<ActionAttempt> UnlockDoorAsync(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<UnlockDoorResponse>(
                    "/access_methods/unlock_door",
                    requestOptions
                )
            )
                .EnsureData("/access_methods/unlock_door")
                .ActionAttempt;
        }

        /// <summary>
        /// Remotely unlocks a specified [entrance](https://docs.seam.co/low-level-apis/access-systems/retrieving-entrance-details) using the cloud key credential associated with an access method. Returns an action attempt that tracks the progress of the unlock operation.
        /// </summary>
        public async Task<ActionAttempt> UnlockDoorAsync(
            string accessMethodId = default,
            string acsEntranceId = default
        )
        {
            return (
                await UnlockDoorAsync(
                    new UnlockDoorRequest(
                        accessMethodId: accessMethodId,
                        acsEntranceId: acsEntranceId
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
        public Api.AccessMethods AccessMethods => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessMethods AccessMethods { get; }
    }
}
