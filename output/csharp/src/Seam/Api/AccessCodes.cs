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
                bool? allowExternalModification = default,
                bool? attemptForOfflineDevice = default,
                string? code = default,
                string? commonCodeKey = default,
                string deviceId = default,
                string? endsAt = default,
                bool? isExternalModificationAllowed = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
                string? name = default,
                bool? preferNativeScheduling = default,
                float? preferredCodeLength = default,
                string? startsAt = default,
                bool? sync = default,
                bool? useBackupAccessCodePool = default,
                bool? useOfflineAccessCode = default
            )
            {
                AllowExternalModification = allowExternalModification;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                Code = code;
                CommonCodeKey = commonCodeKey;
                DeviceId = deviceId;
                EndsAt = endsAt;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
                Name = name;
                PreferNativeScheduling = preferNativeScheduling;
                PreferredCodeLength = preferredCodeLength;
                StartsAt = startsAt;
                Sync = sync;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                UseOfflineAccessCode = useOfflineAccessCode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "1hour")]
                _1hour = 1,

                [EnumMember(Value = "1day")]
                _1day = 2,

                [EnumMember(Value = "1h")]
                _1h = 3,

                [EnumMember(Value = "1d")]
                _1d = 4
            }

            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonCodeKey { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

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
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? commonCodeKey = default,
            string deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? sync = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            return Create(
                new CreateRequest(
                    allowExternalModification: allowExternalModification,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    code: code,
                    commonCodeKey: commonCodeKey,
                    deviceId: deviceId,
                    endsAt: endsAt,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding,
                    name: name,
                    preferNativeScheduling: preferNativeScheduling,
                    preferredCodeLength: preferredCodeLength,
                    startsAt: startsAt,
                    sync: sync,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    useOfflineAccessCode: useOfflineAccessCode
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
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? commonCodeKey = default,
            string deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? sync = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            return (
                await CreateAsync(
                    new CreateRequest(
                        allowExternalModification: allowExternalModification,
                        attemptForOfflineDevice: attemptForOfflineDevice,
                        code: code,
                        commonCodeKey: commonCodeKey,
                        deviceId: deviceId,
                        endsAt: endsAt,
                        isExternalModificationAllowed: isExternalModificationAllowed,
                        isOfflineAccessCode: isOfflineAccessCode,
                        isOneTimeUse: isOneTimeUse,
                        maxTimeRounding: maxTimeRounding,
                        name: name,
                        preferNativeScheduling: preferNativeScheduling,
                        preferredCodeLength: preferredCodeLength,
                        startsAt: startsAt,
                        sync: sync,
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        useOfflineAccessCode: useOfflineAccessCode
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
                bool? allowExternalModification = default,
                bool? attemptForOfflineDevice = default,
                CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                    default,
                string? code = default,
                List<string> deviceIds = default,
                string? endsAt = default,
                bool? isExternalModificationAllowed = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
                string? name = default,
                bool? preferNativeScheduling = default,
                float? preferredCodeLength = default,
                string? startsAt = default,
                bool? useBackupAccessCodePool = default,
                bool? useOfflineAccessCode = default
            )
            {
                AllowExternalModification = allowExternalModification;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                BehaviorWhenCodeCannotBeShared = behaviorWhenCodeCannotBeShared;
                Code = code;
                DeviceIds = deviceIds;
                EndsAt = endsAt;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
                Name = name;
                PreferNativeScheduling = preferNativeScheduling;
                PreferredCodeLength = preferredCodeLength;
                StartsAt = startsAt;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                UseOfflineAccessCode = useOfflineAccessCode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum BehaviorWhenCodeCannotBeSharedEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "throw")]
                Throw = 1,

                [EnumMember(Value = "create_random_code")]
                CreateRandomCode = 2
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "1hour")]
                _1hour = 1,

                [EnumMember(Value = "1day")]
                _1day = 2,

                [EnumMember(Value = "1h")]
                _1h = 3,

                [EnumMember(Value = "1d")]
                _1d = 4
            }

            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(
                Name = "behavior_when_code_cannot_be_shared",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? BehaviorWhenCodeCannotBeShared { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

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
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            string? code = default,
            List<string> deviceIds = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            return CreateMultiple(
                new CreateMultipleRequest(
                    allowExternalModification: allowExternalModification,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    behaviorWhenCodeCannotBeShared: behaviorWhenCodeCannotBeShared,
                    code: code,
                    deviceIds: deviceIds,
                    endsAt: endsAt,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding,
                    name: name,
                    preferNativeScheduling: preferNativeScheduling,
                    preferredCodeLength: preferredCodeLength,
                    startsAt: startsAt,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    useOfflineAccessCode: useOfflineAccessCode
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
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            string? code = default,
            List<string> deviceIds = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            CreateMultipleRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            return (
                await CreateMultipleAsync(
                    new CreateMultipleRequest(
                        allowExternalModification: allowExternalModification,
                        attemptForOfflineDevice: attemptForOfflineDevice,
                        behaviorWhenCodeCannotBeShared: behaviorWhenCodeCannotBeShared,
                        code: code,
                        deviceIds: deviceIds,
                        endsAt: endsAt,
                        isExternalModificationAllowed: isExternalModificationAllowed,
                        isOfflineAccessCode: isOfflineAccessCode,
                        isOneTimeUse: isOneTimeUse,
                        maxTimeRounding: maxTimeRounding,
                        name: name,
                        preferNativeScheduling: preferNativeScheduling,
                        preferredCodeLength: preferredCodeLength,
                        startsAt: startsAt,
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        useOfflineAccessCode: useOfflineAccessCode
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
                string accessCodeId = default,
                string? deviceId = default,
                bool? sync = default
            )
            {
                AccessCodeId = accessCodeId;
                DeviceId = deviceId;
                Sync = sync;
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

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

        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/delete", requestOptions);
        }

        public void Delete(
            string accessCodeId = default,
            string? deviceId = default,
            bool? sync = default
        )
        {
            Delete(new DeleteRequest(accessCodeId: accessCodeId, deviceId: deviceId, sync: sync));
        }

        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/delete", requestOptions);
        }

        public async Task DeleteAsync(
            string accessCodeId = default,
            string? deviceId = default,
            bool? sync = default
        )
        {
            await DeleteAsync(
                new DeleteRequest(accessCodeId: accessCodeId, deviceId: deviceId, sync: sync)
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
                string? accessCodeId = default,
                string? code = default,
                string? deviceId = default
            )
            {
                AccessCodeId = accessCodeId;
                Code = code;
                DeviceId = deviceId;
            }

            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

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
            string? accessCodeId = default,
            string? code = default,
            string? deviceId = default
        )
        {
            return Get(new GetRequest(accessCodeId: accessCodeId, code: code, deviceId: deviceId));
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

        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                List<string>? accessCodeIds = default,
                string? customerKey = default,
                string? deviceId = default,
                float? limit = default,
                string? pageCursor = default,
                string? userIdentifierKey = default
            )
            {
                AccessCodeIds = accessCodeIds;
                CustomerKey = customerKey;
                DeviceId = deviceId;
                Limit = limit;
                PageCursor = pageCursor;
                UserIdentifierKey = userIdentifierKey;
            }

            [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessCodeIds { get; set; }

            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "limit", IsRequired = false, EmitDefaultValue = false)]
            public float? Limit { get; set; }

            [DataMember(Name = "page_cursor", IsRequired = false, EmitDefaultValue = false)]
            public string? PageCursor { get; set; }

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
            List<string>? accessCodeIds = default,
            string? customerKey = default,
            string? deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    accessCodeIds: accessCodeIds,
                    customerKey: customerKey,
                    deviceId: deviceId,
                    limit: limit,
                    pageCursor: pageCursor,
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
            List<string>? accessCodeIds = default,
            string? customerKey = default,
            string? deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessCodeIds: accessCodeIds,
                        customerKey: customerKey,
                        deviceId: deviceId,
                        limit: limit,
                        pageCursor: pageCursor,
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

            public PullBackupAccessCodeResponse(AccessCode accessCode = default)
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

        public AccessCode PullBackupAccessCode(PullBackupAccessCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<PullBackupAccessCodeResponse>(
                    "/access_codes/pull_backup_access_code",
                    requestOptions
                )
                .Data.AccessCode;
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
                .AccessCode;
        }

        public async Task<AccessCode> PullBackupAccessCodeAsync(string accessCodeId = default)
        {
            return (
                await PullBackupAccessCodeAsync(
                    new PullBackupAccessCodeRequest(accessCodeId: accessCodeId)
                )
            );
        }

        [DataContract(Name = "reportDeviceConstraintsRequest_request")]
        public class ReportDeviceConstraintsRequest
        {
            [JsonConstructorAttribute]
            protected ReportDeviceConstraintsRequest() { }

            public ReportDeviceConstraintsRequest(
                string deviceId = default,
                int? maxCodeLength = default,
                int? minCodeLength = default,
                List<int>? supportedCodeLengths = default
            )
            {
                DeviceId = deviceId;
                MaxCodeLength = maxCodeLength;
                MinCodeLength = minCodeLength;
                SupportedCodeLengths = supportedCodeLengths;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "max_code_length", IsRequired = false, EmitDefaultValue = false)]
            public int? MaxCodeLength { get; set; }

            [DataMember(Name = "min_code_length", IsRequired = false, EmitDefaultValue = false)]
            public int? MinCodeLength { get; set; }

            [DataMember(
                Name = "supported_code_lengths",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public List<int>? SupportedCodeLengths { get; set; }

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

        public void ReportDeviceConstraints(ReportDeviceConstraintsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/report_device_constraints", requestOptions);
        }

        public void ReportDeviceConstraints(
            string deviceId = default,
            int? maxCodeLength = default,
            int? minCodeLength = default,
            List<int>? supportedCodeLengths = default
        )
        {
            ReportDeviceConstraints(
                new ReportDeviceConstraintsRequest(
                    deviceId: deviceId,
                    maxCodeLength: maxCodeLength,
                    minCodeLength: minCodeLength,
                    supportedCodeLengths: supportedCodeLengths
                )
            );
        }

        public async Task ReportDeviceConstraintsAsync(ReportDeviceConstraintsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/access_codes/report_device_constraints",
                requestOptions
            );
        }

        public async Task ReportDeviceConstraintsAsync(
            string deviceId = default,
            int? maxCodeLength = default,
            int? minCodeLength = default,
            List<int>? supportedCodeLengths = default
        )
        {
            await ReportDeviceConstraintsAsync(
                new ReportDeviceConstraintsRequest(
                    deviceId: deviceId,
                    maxCodeLength: maxCodeLength,
                    minCodeLength: minCodeLength,
                    supportedCodeLengths: supportedCodeLengths
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
                bool? allowExternalModification = default,
                bool? attemptForOfflineDevice = default,
                string? code = default,
                string? deviceId = default,
                string? endsAt = default,
                bool? isExternalModificationAllowed = default,
                bool? isManaged = default,
                bool? isOfflineAccessCode = default,
                bool? isOneTimeUse = default,
                UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
                string? name = default,
                bool? preferNativeScheduling = default,
                float? preferredCodeLength = default,
                string? startsAt = default,
                bool? sync = default,
                UpdateRequest.TypeEnum? type = default,
                bool? useBackupAccessCodePool = default,
                bool? useOfflineAccessCode = default
            )
            {
                AccessCodeId = accessCodeId;
                AllowExternalModification = allowExternalModification;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                Code = code;
                DeviceId = deviceId;
                EndsAt = endsAt;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                IsManaged = isManaged;
                IsOfflineAccessCode = isOfflineAccessCode;
                IsOneTimeUse = isOneTimeUse;
                MaxTimeRounding = maxTimeRounding;
                Name = name;
                PreferNativeScheduling = preferNativeScheduling;
                PreferredCodeLength = preferredCodeLength;
                StartsAt = startsAt;
                Sync = sync;
                Type = type;
                UseBackupAccessCodePool = useBackupAccessCodePool;
                UseOfflineAccessCode = useOfflineAccessCode;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum MaxTimeRoundingEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "1hour")]
                _1hour = 1,

                [EnumMember(Value = "1day")]
                _1day = 2,

                [EnumMember(Value = "1h")]
                _1h = 3,

                [EnumMember(Value = "1d")]
                _1d = 4
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum TypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "ongoing")]
                Ongoing = 1,

                [EnumMember(Value = "time_bound")]
                TimeBound = 2
            }

            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            [DataMember(
                Name = "allow_external_modification",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AllowExternalModification { get; set; }

            [DataMember(
                Name = "attempt_for_offline_device",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? AttemptForOfflineDevice { get; set; }

            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

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

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

            [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.TypeEnum? Type { get; set; }

            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

            [DataMember(
                Name = "use_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseOfflineAccessCode { get; set; }

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
            _seam.Post<object>("/access_codes/update", requestOptions);
        }

        public void Update(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isManaged = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? sync = default,
            UpdateRequest.TypeEnum? type = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            Update(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    code: code,
                    deviceId: deviceId,
                    endsAt: endsAt,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    isManaged: isManaged,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding,
                    name: name,
                    preferNativeScheduling: preferNativeScheduling,
                    preferredCodeLength: preferredCodeLength,
                    startsAt: startsAt,
                    sync: sync,
                    type: type,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    useOfflineAccessCode: useOfflineAccessCode
                )
            );
        }

        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/update", requestOptions);
        }

        public async Task UpdateAsync(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isManaged = default,
            bool? isOfflineAccessCode = default,
            bool? isOneTimeUse = default,
            UpdateRequest.MaxTimeRoundingEnum? maxTimeRounding = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? sync = default,
            UpdateRequest.TypeEnum? type = default,
            bool? useBackupAccessCodePool = default,
            bool? useOfflineAccessCode = default
        )
        {
            await UpdateAsync(
                new UpdateRequest(
                    accessCodeId: accessCodeId,
                    allowExternalModification: allowExternalModification,
                    attemptForOfflineDevice: attemptForOfflineDevice,
                    code: code,
                    deviceId: deviceId,
                    endsAt: endsAt,
                    isExternalModificationAllowed: isExternalModificationAllowed,
                    isManaged: isManaged,
                    isOfflineAccessCode: isOfflineAccessCode,
                    isOneTimeUse: isOneTimeUse,
                    maxTimeRounding: maxTimeRounding,
                    name: name,
                    preferNativeScheduling: preferNativeScheduling,
                    preferredCodeLength: preferredCodeLength,
                    startsAt: startsAt,
                    sync: sync,
                    type: type,
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    useOfflineAccessCode: useOfflineAccessCode
                )
            );
        }

        [DataContract(Name = "updateMultipleRequest_request")]
        public class UpdateMultipleRequest
        {
            [JsonConstructorAttribute]
            protected UpdateMultipleRequest() { }

            public UpdateMultipleRequest(
                string commonCodeKey = default,
                string? endsAt = default,
                string? name = default,
                string? startsAt = default
            )
            {
                CommonCodeKey = commonCodeKey;
                EndsAt = endsAt;
                Name = name;
                StartsAt = startsAt;
            }

            [DataMember(Name = "common_code_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonCodeKey { get; set; }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

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

        public void UpdateMultiple(UpdateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/update_multiple", requestOptions);
        }

        public void UpdateMultiple(
            string commonCodeKey = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            UpdateMultiple(
                new UpdateMultipleRequest(
                    commonCodeKey: commonCodeKey,
                    endsAt: endsAt,
                    name: name,
                    startsAt: startsAt
                )
            );
        }

        public async Task UpdateMultipleAsync(UpdateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/access_codes/update_multiple", requestOptions);
        }

        public async Task UpdateMultipleAsync(
            string commonCodeKey = default,
            string? endsAt = default,
            string? name = default,
            string? startsAt = default
        )
        {
            await UpdateMultipleAsync(
                new UpdateMultipleRequest(
                    commonCodeKey: commonCodeKey,
                    endsAt: endsAt,
                    name: name,
                    startsAt: startsAt
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
