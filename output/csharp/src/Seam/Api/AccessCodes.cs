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
    public class AccessCodes
    {
        private ISeamClient _seam;

        public AccessCodes(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createRequest_request")]
        public class CreateRequest
        {
            [JsonConstructorAttribute]
            protected CreateRequest() { }

            public CreateRequest(
                string deviceId = default,
                string? name = default,
                string? startsAt = default,
                string? endsAt = default,
                string? code = default,
                bool? sync = default,
                bool? attemptForOfflineDevice = default,
                string? commonCodeKey = default,
                bool? preferNativeScheduling = default,
                bool? useBackupAccessCodePool = default,
                bool? allowExternalModification = default,
                bool? isExternalModificationAllowed = default,
                bool? useOfflineAccessCode = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default
            )
            {
                DeviceId = deviceId;
                Name = name;
                StartsAt = startsAt;
                EndsAt = endsAt;
                Code = code;
                Sync = sync;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                CommonCodeKey = commonCodeKey;
                PreferNativeScheduling = preferNativeScheduling;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                AllowExternalModification = allowExternalModification;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                UseOfflineAccessCode = useOfflineAccessCode;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "1hour")]
                _1hour = 0,

                [EnumMember(Value = "1day")]
                _1day = 1,

                [EnumMember(Value = "1h")]
                _1h = 2,

                [EnumMember(Value = "1d")]
                _1d = 3
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonCodeKey { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

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

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

            [DataMember(
                Name = "is_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsOfflineAccessCode { get; set; }

            [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOneTimeUse { get; set; }

            [DataMember(Name = "max_time_rounding", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.MaxTimeRoundingEnum? MaxTimeRounding { get; set; }

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

        [DataContract(Name = "createResponse_response")]
        public class CreateResponse
        {
            [JsonConstructorAttribute]
            protected CreateResponse() { }

            public CreateResponse(AccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
            public AccessCode AccessCode { get; set; }

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

        public AccessCode Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/access_codes/create", requestOptions)
                .Data.AccessCode;
        }

        public AccessCode Create(
            string deviceId = default,
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? sync = default,
            bool? attemptForOfflineDevice = default,
            string? commonCodeKey = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default
        )
        {
            return Create(
                new CreateRequest(
                    deviceId: deviceId,
                    name: name,
                    startsAt: startsAt,
                    endsAt: endsAt,
                    code: code,
                    sync: sync,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    commonCodeKey: commonCodeKey,
                    preferNativeScheduling: preferNativeScheduling,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    allowExternalModification: allowExternalModification,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    useOfflineAccessCode: useOfflineAccessCode,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding
                )
            );
        }

        public async Task<AccessCode> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/access_codes/create", requestOptions))
                .Data
                .AccessCode;
        }

        public async Task<AccessCode> CreateAsync(
            string deviceId = default,
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? sync = default,
            bool? attemptForOfflineDevice = default,
            string? commonCodeKey = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        deviceId: deviceId,
                        name: name,
                        startsAt: startsAt,
                        endsAt: endsAt,
                        code: code,
                        sync: sync,
                        attemptForOfflineDevice: attemptForOfflineDevice,
                        commonCodeKey: commonCodeKey,
                        preferNativeScheduling: preferNativeScheduling,
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        allowExternalModification: allowExternalModification,
                        isExternalModificationAllowed: isExternalModificationAllowed,
                        useOfflineAccessCode: useOfflineAccessCode,
                        isOfflineAccessCode: isOfflineAccessCode,
                        isOneTimeUse: isOneTimeUse,
                        maxTimeRounding: maxTimeRounding
                    )
                )
            );
        }

        [DataContract(Name = "createMultipleRequest_request")]
        public class CreateMultipleRequest
        {
            [JsonConstructorAttribute]
            protected CreateMultipleRequest() { }

            public CreateMultipleRequest(
                List<string> deviceIds = default,
                CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                    default,
                float? preferredCodeLength = default,
                string? name = default,
                string? startsAt = default,
                string? endsAt = default,
                string? code = default,
                bool? attemptForOfflineDevice = default,
                bool? preferNativeScheduling = default,
                bool? useBackupAccessCodePool = default,
                bool? allowExternalModification = default,
                bool? isExternalModificationAllowed = default,
                bool? useOfflineAccessCode = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default
            )
            {
                DeviceIds = deviceIds;
                BehaviorWhenCodeCannotBeShared = behaviorWhenCodeCannotBeShared;
                PreferredCodeLength = preferredCodeLength;
                Name = name;
                StartsAt = startsAt;
                EndsAt = endsAt;
                Code = code;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                PreferNativeScheduling = preferNativeScheduling;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                AllowExternalModification = allowExternalModification;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                UseOfflineAccessCode = useOfflineAccessCode;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum BehaviorWhenCodeCannotBeSharedEnum
            {
                [EnumMember(Value = "throw")]
                Throw = 0,

                [EnumMember(Value = "create_random_code")]
                CreateRandomCode = 1
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "1hour")]
                _1hour = 0,

                [EnumMember(Value = "1day")]
                _1day = 1,

                [EnumMember(Value = "1h")]
                _1h = 2,

                [EnumMember(Value = "1d")]
                _1d = 3
            }

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            [DataMember(
                Name = "behavior_when_code_cannot_be_shared",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? BehaviorWhenCodeCannotBeShared { get; set; }

            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

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

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

            [DataMember(
                Name = "is_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsOfflineAccessCode { get; set; }

            [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOneTimeUse { get; set; }

            [DataMember(Name = "max_time_rounding", IsRequired = false, EmitDefaultValue = false)]
            public CreateMultipleRequest.MaxTimeRoundingEnum? MaxTimeRounding { get; set; }

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

        [DataContract(Name = "createMultipleResponse_response")]
        public class CreateMultipleResponse
        {
            [JsonConstructorAttribute]
            protected CreateMultipleResponse() { }

            public CreateMultipleResponse(List<AccessCode> accessCodes = default)
            {
                AccessCodes = accessCodes;
            }

            [DataMember(Name = "access_codes", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessCode> AccessCodes { get; set; }

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

        public List<AccessCode> CreateMultiple(CreateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateMultipleResponse>("/access_codes/create_multiple", requestOptions)
                .Data.AccessCodes;
        }

        public List<AccessCode> CreateMultiple(
            List<string> deviceIds = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            float? preferredCodeLength = default,
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? attemptForOfflineDevice = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default
        )
        {
            return CreateMultiple(
                new CreateMultipleRequest(
                    deviceIds: deviceIds,
                    behaviorWhenCodeCannotBeShared: behaviorWhenCodeCannotBeShared,
                    preferredCodeLength: preferredCodeLength,
                    name: name,
                    startsAt: startsAt,
                    endsAt: endsAt,
                    code: code,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    preferNativeScheduling: preferNativeScheduling,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    allowExternalModification: allowExternalModification,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    useOfflineAccessCode: useOfflineAccessCode,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding
                )
            );
        }

        public async Task<List<AccessCode>> CreateMultipleAsync(CreateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateMultipleResponse>(
                    "/access_codes/create_multiple",
                    requestOptions
                )
            )
                .Data
                .AccessCodes;
        }

        public async Task<List<AccessCode>> CreateMultipleAsync(
            List<string> deviceIds = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            float? preferredCodeLength = default,
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? attemptForOfflineDevice = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default
        )
        {
            return (
                await CreateMultipleAsync(
                    new CreateMultipleRequest(
                        deviceIds: deviceIds,
                        behaviorWhenCodeCannotBeShared: behaviorWhenCodeCannotBeShared,
                        preferredCodeLength: preferredCodeLength,
                        name: name,
                        startsAt: startsAt,
                        endsAt: endsAt,
                        code: code,
                        attemptForOfflineDevice: attemptForOfflineDevice,
                        preferNativeScheduling: preferNativeScheduling,
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        allowExternalModification: allowExternalModification,
                        isExternalModificationAllowed: isExternalModificationAllowed,
                        useOfflineAccessCode: useOfflineAccessCode,
                        isOfflineAccessCode: isOfflineAccessCode,
                        isOneTimeUse: isOneTimeUse,
                        maxTimeRounding: maxTimeRounding
                    )
                )
            );
        }

        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(
                string? deviceId = default,
                string accessCodeId = default,
                bool? sync = default
            )
            {
                DeviceId = deviceId;
                AccessCodeId = accessCodeId;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

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
                .Post<DeleteResponse>("/access_codes/delete", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Delete(
            string? deviceId = default,
            string accessCodeId = default,
            bool? sync = default
        )
        {
            return Delete(
                new DeleteRequest(deviceId: deviceId, accessCodeId: accessCodeId, sync: sync)
            );
        }

        public async Task<ActionAttempt> DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<DeleteResponse>("/access_codes/delete", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> DeleteAsync(
            string? deviceId = default,
            string accessCodeId = default,
            bool? sync = default
        )
        {
            return (
                await DeleteAsync(
                    new DeleteRequest(deviceId: deviceId, accessCodeId: accessCodeId, sync: sync)
                )
            );
        }

        [DataContract(Name = "generateCodeRequest_request")]
        public class GenerateCodeRequest
        {
            [JsonConstructorAttribute]
            protected GenerateCodeRequest() { }

            public GenerateCodeRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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

        [DataContract(Name = "generateCodeResponse_response")]
        public class GenerateCodeResponse
        {
            [JsonConstructorAttribute]
            protected GenerateCodeResponse() { }

            public GenerateCodeResponse(AccessCode generatedCode = default)
            {
                GeneratedCode = generatedCode;
            }

            [DataMember(Name = "generated_code", IsRequired = false, EmitDefaultValue = false)]
            public AccessCode GeneratedCode { get; set; }

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

        public AccessCode GenerateCode(GenerateCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<GenerateCodeResponse>("/access_codes/generate_code", requestOptions)
                .Data.GeneratedCode;
        }

        public AccessCode GenerateCode(string deviceId = default)
        {
            return GenerateCode(new GenerateCodeRequest(deviceId: deviceId));
        }

        public async Task<AccessCode> GenerateCodeAsync(GenerateCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<GenerateCodeResponse>(
                    "/access_codes/generate_code",
                    requestOptions
                )
            )
                .Data
                .GeneratedCode;
        }

        public async Task<AccessCode> GenerateCodeAsync(string deviceId = default)
        {
            return (await GenerateCodeAsync(new GenerateCodeRequest(deviceId: deviceId)));
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

            public GetResponse(AccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
            public AccessCode AccessCode { get; set; }

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

        public AccessCode Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<GetResponse>("/access_codes/get", requestOptions).Data.AccessCode;
        }

        public AccessCode Get(
            string? deviceId = default,
            string? accessCodeId = default,
            string? code = default
        )
        {
            return Get(new GetRequest(deviceId: deviceId, accessCodeId: accessCodeId, code: code));
        }

        public async Task<AccessCode> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<GetResponse>("/access_codes/get", requestOptions))
                .Data
                .AccessCode;
        }

        public async Task<AccessCode> GetAsync(
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

            public ListRequest(
                string? deviceId = default,
                List<string>? accessCodeIds = default,
                string? userIdentifierKey = default
            )
            {
                DeviceId = deviceId;
                AccessCodeIds = accessCodeIds;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessCodeIds { get; set; }

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

            public ListResponse(List<AccessCode> accessCodes = default)
            {
                AccessCodes = accessCodes;
            }

            [DataMember(Name = "access_codes", IsRequired = false, EmitDefaultValue = false)]
            public List<AccessCode> AccessCodes { get; set; }

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

        public List<AccessCode> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam.Post<ListResponse>("/access_codes/list", requestOptions).Data.AccessCodes;
        }

        public List<AccessCode> List(
            string? deviceId = default,
            List<string>? accessCodeIds = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    deviceId: deviceId,
                    accessCodeIds: accessCodeIds,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        public async Task<List<AccessCode>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<ListResponse>("/access_codes/list", requestOptions))
                .Data
                .AccessCodes;
        }

        public async Task<List<AccessCode>> ListAsync(
            string? deviceId = default,
            List<string>? accessCodeIds = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        deviceId: deviceId,
                        accessCodeIds: accessCodeIds,
                        userIdentifierKey: userIdentifierKey
                    )
                )
            );
        }

        [DataContract(Name = "pullBackupAccessCodeRequest_request")]
        public class PullBackupAccessCodeRequest
        {
            [JsonConstructorAttribute]
            protected PullBackupAccessCodeRequest() { }

            public PullBackupAccessCodeRequest(string accessCodeId = default)
            {
                AccessCodeId = accessCodeId;
            }

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

        [DataContract(Name = "pullBackupAccessCodeResponse_response")]
        public class PullBackupAccessCodeResponse
        {
            [JsonConstructorAttribute]
            protected PullBackupAccessCodeResponse() { }

            public PullBackupAccessCodeResponse(AccessCode backupAccessCode = default)
            {
                BackupAccessCode = backupAccessCode;
            }

            [DataMember(Name = "backup_access_code", IsRequired = false, EmitDefaultValue = false)]
            public AccessCode BackupAccessCode { get; set; }

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

        public AccessCode PullBackupAccessCode(PullBackupAccessCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<PullBackupAccessCodeResponse>(
                    "/access_codes/pull_backup_access_code",
                    requestOptions
                )
                .Data.BackupAccessCode;
        }

        public AccessCode PullBackupAccessCode(string accessCodeId = default)
        {
            return PullBackupAccessCode(
                new PullBackupAccessCodeRequest(accessCodeId: accessCodeId)
            );
        }

        public async Task<AccessCode> PullBackupAccessCodeAsync(PullBackupAccessCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<PullBackupAccessCodeResponse>(
                    "/access_codes/pull_backup_access_code",
                    requestOptions
                )
            )
                .Data
                .BackupAccessCode;
        }

        public async Task<AccessCode> PullBackupAccessCodeAsync(string accessCodeId = default)
        {
            return (
                await PullBackupAccessCodeAsync(
                    new PullBackupAccessCodeRequest(accessCodeId: accessCodeId)
                )
            );
        }

        [DataContract(Name = "updateRequest_request")]
        public class UpdateRequest
        {
            [JsonConstructorAttribute]
            protected UpdateRequest() { }

            public UpdateRequest(
                string? name = default,
                string? startsAt = default,
                string? endsAt = default,
                string? code = default,
                bool? sync = default,
                bool? attemptForOfflineDevice = default,
                bool? preferNativeScheduling = default,
                bool? useBackupAccessCodePool = default,
                bool? allowExternalModification = default,
                bool? isExternalModificationAllowed = default,
                bool? useOfflineAccessCode = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
                string accessCodeId = default,
                string? deviceId = default,
                UpdateRequest.TypeEnum? type = default,
                bool? isManaged = default
            )
            {
                Name = name;
                StartsAt = startsAt;
                EndsAt = endsAt;
                Code = code;
                Sync = sync;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                PreferNativeScheduling = preferNativeScheduling;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                AllowExternalModification = allowExternalModification;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                UseOfflineAccessCode = useOfflineAccessCode;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
                AccessCodeId = accessCodeId;
                DeviceId = deviceId;
                Type = type;
                IsManaged = isManaged;
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "1hour")]
                _1hour = 0,

                [EnumMember(Value = "1day")]
                _1day = 1,

                [EnumMember(Value = "1h")]
                _1h = 2,

                [EnumMember(Value = "1d")]
                _1d = 3
            }

            [JsonConverter(typeof(StringEnumConverter))]
            public enum TypeEnum
            {
                [EnumMember(Value = "ongoing")]
                Ongoing = 0,

                [EnumMember(Value = "time_bound")]
                TimeBound = 1
            }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

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

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

            [DataMember(
                Name = "is_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsOfflineAccessCode { get; set; }

            [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOneTimeUse { get; set; }

            [DataMember(Name = "max_time_rounding", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.MaxTimeRoundingEnum? MaxTimeRounding { get; set; }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.TypeEnum? Type { get; set; }

            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

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

        [DataContract(Name = "updateResponse_response")]
        public class UpdateResponse
        {
            [JsonConstructorAttribute]
            protected UpdateResponse() { }

            public UpdateResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UpdateResponse>("/access_codes/update", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt Update(
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? sync = default,
            bool? attemptForOfflineDevice = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string accessCodeId = default,
            string? deviceId = default,
            UpdateRequest.TypeEnum? type = default,
            bool? isManaged = default
        )
        {
            return Update(
                new UpdateRequest(
                    name: name,
                    startsAt: startsAt,
                    endsAt: endsAt,
                    code: code,
                    sync: sync,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    preferNativeScheduling: preferNativeScheduling,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    allowExternalModification: allowExternalModification,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    useOfflineAccessCode: useOfflineAccessCode,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding,
                    accessCodeId: accessCodeId,
                    deviceId: deviceId,
                    type: type,
                    isManaged: isManaged
                )
            );
        }

        public async Task<ActionAttempt> UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<UpdateResponse>("/access_codes/update", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> UpdateAsync(
            string? name = default,
            string? startsAt = default,
            string? endsAt = default,
            string? code = default,
            bool? sync = default,
            bool? attemptForOfflineDevice = default,
            bool? preferNativeScheduling = default,
            bool? useBackupAccessCodePool = default,
            bool? allowExternalModification = default,
            bool? isExternalModificationAllowed = default,
            bool? useOfflineAccessCode = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string accessCodeId = default,
            string? deviceId = default,
            UpdateRequest.TypeEnum? type = default,
            bool? isManaged = default
        )
        {
            return (
                await UpdateAsync(
                    new UpdateRequest(
                        name: name,
                        startsAt: startsAt,
                        endsAt: endsAt,
                        code: code,
                        sync: sync,
                        attemptForOfflineDevice: attemptForOfflineDevice,
                        preferNativeScheduling: preferNativeScheduling,
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        allowExternalModification: allowExternalModification,
                        isExternalModificationAllowed: isExternalModificationAllowed,
                        useOfflineAccessCode: useOfflineAccessCode,
                        isOfflineAccessCode: isOfflineAccessCode,
                        isOneTimeUse: isOneTimeUse,
                        maxTimeRounding: maxTimeRounding,
                        accessCodeId: accessCodeId,
                        deviceId: deviceId,
                        type: type,
                        isManaged: isManaged
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
        public Api.AccessCodes AccessCodes => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.AccessCodes AccessCodes { get; }
    }
}
