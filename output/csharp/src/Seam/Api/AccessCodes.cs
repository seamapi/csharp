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

        /// <summary>
        /// Request parameters for Create an Access Code.
        /// </summary>
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
                UseBackupAccessCodePool = useBackupAccessCodePool;
                UseOfflineAccessCode = useOfflineAccessCode;
            }

            /// <summary>
            /// Maximum rounding adjustment. To create a daily-bound [offline access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/offline-access-codes) for devices that support this feature, set this parameter to `1d`.
            /// </summary>
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
                _1d = 4,
            }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
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

            /// <summary>
            /// Code to be used for access.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// Key to identify access codes that should have the same code. Any two access codes with the same `common_code_key` are guaranteed to have the same `code`. See also [Creating and Updating Multiple Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes).
            /// </summary>
            [DataMember(Name = "common_code_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CommonCodeKey { get; set; }

            /// <summary>
            /// ID of the device for which you want to create the new access code.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            /// <summary>
            /// Indicates whether the access code is an [offline access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/offline-access-codes).
            /// </summary>
            [DataMember(
                Name = "is_offline_access_code",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsOfflineAccessCode { get; set; }

            /// <summary>
            /// Indicates whether the [offline access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/offline-access-codes) is a single-use access code.
            /// </summary>
            [DataMember(Name = "is_one_time_use", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsOneTimeUse { get; set; }

            /// <summary>
            /// Maximum rounding adjustment. To create a daily-bound [offline access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes/offline-access-codes) for devices that support this feature, set this parameter to `1d`.
            /// </summary>
            [DataMember(Name = "max_time_rounding", IsRequired = false, EmitDefaultValue = false)]
            public CreateRequest.MaxTimeRoundingEnum? MaxTimeRounding { get; set; }

            /// <summary>
            /// Name of the new access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes.
            ///
            /// Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`.
            ///
            /// To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints.
            ///
            /// To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Indicates whether [native scheduling](https://docs.seam.co/low-level-apis/smart-locks/access-codes#native-scheduling) should be used for time-bound codes when supported by the provider. Default: `true`.
            /// </summary>
            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            /// <summary>
            /// Preferred code length. Only applicable if you do not specify a `code`. If the affected device does not support the preferred code length, Seam reverts to using the shortest supported code length.
            /// </summary>
            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Indicates whether to use a [backup access code pool](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes) provided by Seam. If `true`, you can use [`/access_codes/pull_backup_access_code`](https://docs.seam.co/api/access_codes/pull_backup_access_code).
            /// </summary>
            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

            [Obsolete("Use `is_offline_access_code` instead.")]
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates a new [access code](https://docs.seam.co/low-level-apis/access-codes). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they work across both standalone smart locks and access control systems and manage the underlying codes for you. Use this low-level endpoint only when you need direct control over a code on a single device, such as setting a custom PIN value.
        /// </summary>
        public AccessCode Create(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateResponse>("/access_codes/create", requestOptions)
                .EnsureData("/access_codes/create")
                .AccessCode;
        }

        /// <summary>
        /// Creates a new [access code](https://docs.seam.co/low-level-apis/access-codes). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they work across both standalone smart locks and access control systems and manage the underlying codes for you. Use this low-level endpoint only when you need direct control over a code on a single device, such as setting a custom PIN value.
        /// </summary>
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
                    useBackupAccessCodePool: useBackupAccessCodePool,
                    useOfflineAccessCode: useOfflineAccessCode
                )
            );
        }

        /// <summary>
        /// Creates a new [access code](https://docs.seam.co/low-level-apis/access-codes). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they work across both standalone smart locks and access control systems and manage the underlying codes for you. Use this low-level endpoint only when you need direct control over a code on a single device, such as setting a custom PIN value.
        /// </summary>
        public async Task<AccessCode> CreateAsync(CreateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<CreateResponse>("/access_codes/create", requestOptions))
                .EnsureData("/access_codes/create")
                .AccessCode;
        }

        /// <summary>
        /// Creates a new [access code](https://docs.seam.co/low-level-apis/access-codes). For granting access, we recommend [Access Grants](https://docs.seam.co/use-cases/granting-access) instead: they work across both standalone smart locks and access control systems and manage the underlying codes for you. Use this low-level endpoint only when you need direct control over a code on a single device, such as setting a custom PIN value.
        /// </summary>
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
                        useBackupAccessCodePool: useBackupAccessCodePool,
                        useOfflineAccessCode: useOfflineAccessCode
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Create Multiple Linked Access Codes.
        /// </summary>
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
                string? name = default,
                bool? preferNativeScheduling = default,
                float? preferredCodeLength = default,
                string? startsAt = default,
                bool? useBackupAccessCodePool = default
            )
            {
                AllowExternalModification = allowExternalModification;
                AttemptForOfflineDevice = attemptForOfflineDevice;
                BehaviorWhenCodeCannotBeShared = behaviorWhenCodeCannotBeShared;
                Code = code;
                DeviceIds = deviceIds;
                EndsAt = endsAt;
                IsExternalModificationAllowed = isExternalModificationAllowed;
                Name = name;
                PreferNativeScheduling = preferNativeScheduling;
                PreferredCodeLength = preferredCodeLength;
                StartsAt = startsAt;
                UseBackupAccessCodePool = useBackupAccessCodePool;
            }

            /// <summary>
            /// Desired behavior if any device cannot share a code. If `throw` (default), no access codes will be created if any device cannot share a code. If `create_random_code`, a random code will be created on devices that cannot share a code.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum BehaviorWhenCodeCannotBeSharedEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "throw")]
                Throw = 1,

                [EnumMember(Value = "create_random_code")]
                CreateRandomCode = 2,
            }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
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

            /// <summary>
            /// Desired behavior if any device cannot share a code. If `throw` (default), no access codes will be created if any device cannot share a code. If `create_random_code`, a random code will be created on devices that cannot share a code.
            /// </summary>
            [DataMember(
                Name = "behavior_when_code_cannot_be_shared",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? BehaviorWhenCodeCannotBeShared { get; set; }

            /// <summary>
            /// Code to be used for access.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// IDs of the devices for which you want to create the new access codes.
            /// </summary>
            [DataMember(Name = "device_ids", IsRequired = true, EmitDefaultValue = false)]
            public List<string> DeviceIds { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            /// <summary>
            /// Name of the new access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes.
            ///
            /// Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`.
            ///
            /// To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints.
            ///
            /// To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Indicates whether [native scheduling](https://docs.seam.co/low-level-apis/smart-locks/access-codes#native-scheduling) should be used for time-bound codes when supported by the provider. Default: `true`.
            /// </summary>
            [DataMember(
                Name = "prefer_native_scheduling",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? PreferNativeScheduling { get; set; }

            /// <summary>
            /// Preferred code length. If the affected devices do not support the preferred code length, Seam reverts to using the shortest supported code length.
            /// </summary>
            [DataMember(
                Name = "preferred_code_length",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public float? PreferredCodeLength { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Indicates whether to use a [backup access code pool](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes) provided by Seam. If `true`, you can use [`/access_codes/pull_backup_access_code`](https://docs.seam.co/api/access_codes/pull_backup_access_code).
            /// </summary>
            [DataMember(
                Name = "use_backup_access_code_pool",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? UseBackupAccessCodePool { get; set; }

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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Creates new [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Users with more than one door lock in a property may want to create groups of linked access codes, all of which have the same code (PIN). For example, a short-term rental host may want to provide guests the same PIN for both a front door lock and a back door lock.
        ///
        /// If you specify a custom code, Seam assigns this custom code to each of the resulting access codes. However, in this case, Seam does not link these access codes together with a `common_code_key`. That is, `common_code_key` remains null for these access codes.
        ///
        /// If you want to change these access codes that are not linked by a `common_code_key`, you cannot use `/access_codes/update_multiple`. However, you can update each of these access codes individually, using `/access_codes/update`.
        ///
        /// See also [Creating and Updating Multiple Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes).
        ///
        /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach and work across both standalone smart locks and access systems. Use the lower-level Access Codes API directly only when you specifically need to manage individual PIN codes.
        /// </summary>
        public List<AccessCode> CreateMultiple(CreateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Put<CreateMultipleResponse>("/access_codes/create_multiple", requestOptions)
                .EnsureData("/access_codes/create_multiple")
                .AccessCodes;
        }

        /// <summary>
        /// Creates new [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Users with more than one door lock in a property may want to create groups of linked access codes, all of which have the same code (PIN). For example, a short-term rental host may want to provide guests the same PIN for both a front door lock and a back door lock.
        ///
        /// If you specify a custom code, Seam assigns this custom code to each of the resulting access codes. However, in this case, Seam does not link these access codes together with a `common_code_key`. That is, `common_code_key` remains null for these access codes.
        ///
        /// If you want to change these access codes that are not linked by a `common_code_key`, you cannot use `/access_codes/update_multiple`. However, you can update each of these access codes individually, using `/access_codes/update`.
        ///
        /// See also [Creating and Updating Multiple Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes).
        ///
        /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach and work across both standalone smart locks and access systems. Use the lower-level Access Codes API directly only when you specifically need to manage individual PIN codes.
        /// </summary>
        public List<AccessCode> CreateMultiple(
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            string? code = default,
            List<string> deviceIds = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? useBackupAccessCodePool = default
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
                    name: name,
                    preferNativeScheduling: preferNativeScheduling,
                    preferredCodeLength: preferredCodeLength,
                    startsAt: startsAt,
                    useBackupAccessCodePool: useBackupAccessCodePool
                )
            );
        }

        /// <summary>
        /// Creates new [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Users with more than one door lock in a property may want to create groups of linked access codes, all of which have the same code (PIN). For example, a short-term rental host may want to provide guests the same PIN for both a front door lock and a back door lock.
        ///
        /// If you specify a custom code, Seam assigns this custom code to each of the resulting access codes. However, in this case, Seam does not link these access codes together with a `common_code_key`. That is, `common_code_key` remains null for these access codes.
        ///
        /// If you want to change these access codes that are not linked by a `common_code_key`, you cannot use `/access_codes/update_multiple`. However, you can update each of these access codes individually, using `/access_codes/update`.
        ///
        /// See also [Creating and Updating Multiple Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes).
        ///
        /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach and work across both standalone smart locks and access systems. Use the lower-level Access Codes API directly only when you specifically need to manage individual PIN codes.
        /// </summary>
        public async Task<List<AccessCode>> CreateMultipleAsync(CreateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PutAsync<CreateMultipleResponse>(
                    "/access_codes/create_multiple",
                    requestOptions
                )
            )
                .EnsureData("/access_codes/create_multiple")
                .AccessCodes;
        }

        /// <summary>
        /// Creates new [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Users with more than one door lock in a property may want to create groups of linked access codes, all of which have the same code (PIN). For example, a short-term rental host may want to provide guests the same PIN for both a front door lock and a back door lock.
        ///
        /// If you specify a custom code, Seam assigns this custom code to each of the resulting access codes. However, in this case, Seam does not link these access codes together with a `common_code_key`. That is, `common_code_key` remains null for these access codes.
        ///
        /// If you want to change these access codes that are not linked by a `common_code_key`, you cannot use `/access_codes/update_multiple`. However, you can update each of these access codes individually, using `/access_codes/update`.
        ///
        /// See also [Creating and Updating Multiple Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes).
        ///
        /// For granting a person access to a space, [Access Grants](https://docs.seam.co/use-cases/granting-access) are the default and recommended approach and work across both standalone smart locks and access systems. Use the lower-level Access Codes API directly only when you specifically need to manage individual PIN codes.
        /// </summary>
        public async Task<List<AccessCode>> CreateMultipleAsync(
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            CreateMultipleRequest.BehaviorWhenCodeCannotBeSharedEnum? behaviorWhenCodeCannotBeShared =
                default,
            string? code = default,
            List<string> deviceIds = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            string? name = default,
            bool? preferNativeScheduling = default,
            float? preferredCodeLength = default,
            string? startsAt = default,
            bool? useBackupAccessCodePool = default
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
                        name: name,
                        preferNativeScheduling: preferNativeScheduling,
                        preferredCodeLength: preferredCodeLength,
                        startsAt: startsAt,
                        useBackupAccessCodePool: useBackupAccessCodePool
                    )
                )
            );
        }

        /// <summary>
        /// Request parameters for Delete an Access Code.
        /// </summary>
        [DataContract(Name = "deleteRequest_request")]
        public class DeleteRequest
        {
            [JsonConstructorAttribute]
            protected DeleteRequest() { }

            public DeleteRequest(string accessCodeId = default, string? deviceId = default)
            {
                AccessCodeId = accessCodeId;
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the access code that you want to delete.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            /// <summary>
            /// ID of the device for which you want to delete the access code.
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

        /// <summary>
        /// Deletes an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        public void Delete(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Delete<object>("/access_codes/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        public void Delete(string accessCodeId = default, string? deviceId = default)
        {
            Delete(new DeleteRequest(accessCodeId: accessCodeId, deviceId: deviceId));
        }

        /// <summary>
        /// Deletes an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        public async Task DeleteAsync(DeleteRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.DeleteAsync<object>("/access_codes/delete", requestOptions);
        }

        /// <summary>
        /// Deletes an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        /// </summary>
        public async Task DeleteAsync(string accessCodeId = default, string? deviceId = default)
        {
            await DeleteAsync(new DeleteRequest(accessCodeId: accessCodeId, deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Generate a Code.
        /// </summary>
        [DataContract(Name = "generateCodeRequest_request")]
        public class GenerateCodeRequest
        {
            [JsonConstructorAttribute]
            protected GenerateCodeRequest() { }

            public GenerateCodeRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device for which you want to generate a code.
            /// </summary>
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

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Generates a code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes), given a device ID.
        /// </summary>
        public AccessCode GenerateCode(GenerateCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GenerateCodeResponse>("/access_codes/generate_code", requestOptions)
                .EnsureData("/access_codes/generate_code")
                .GeneratedCode;
        }

        /// <summary>
        /// Generates a code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes), given a device ID.
        /// </summary>
        public AccessCode GenerateCode(string deviceId = default)
        {
            return GenerateCode(new GenerateCodeRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Generates a code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes), given a device ID.
        /// </summary>
        public async Task<AccessCode> GenerateCodeAsync(GenerateCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.GetAsync<GenerateCodeResponse>(
                    "/access_codes/generate_code",
                    requestOptions
                )
            )
                .EnsureData("/access_codes/generate_code")
                .GeneratedCode;
        }

        /// <summary>
        /// Generates a code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes), given a device ID.
        /// </summary>
        public async Task<AccessCode> GenerateCodeAsync(string deviceId = default)
        {
            return (await GenerateCodeAsync(new GenerateCodeRequest(deviceId: deviceId)));
        }

        /// <summary>
        /// Request parameters for Get an Access Code.
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
            /// ID of the access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessCodeId { get; set; }

            /// <summary>
            /// Code of the access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// ID of the device containing the access code that you want to get. You must specify either `access_code_id` or both `device_id` and `code`.
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

            public GetResponse(AccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a specified [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public AccessCode Get(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<GetResponse>("/access_codes/get", requestOptions)
                .EnsureData("/access_codes/get")
                .AccessCode;
        }

        /// <summary>
        /// Returns a specified [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public AccessCode Get(
            string? accessCodeId = default,
            string? code = default,
            string? deviceId = default
        )
        {
            return Get(new GetRequest(accessCodeId: accessCodeId, code: code, deviceId: deviceId));
        }

        /// <summary>
        /// Returns a specified [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
        public async Task<AccessCode> GetAsync(GetRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<GetResponse>("/access_codes/get", requestOptions))
                .EnsureData("/access_codes/get")
                .AccessCode;
        }

        /// <summary>
        /// Returns a specified [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// You must specify either `access_code_id` or both `device_id` and `code`.
        /// </summary>
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

        /// <summary>
        /// Request parameters for List Access Codes.
        /// </summary>
        [DataContract(Name = "listRequest_request")]
        public class ListRequest
        {
            [JsonConstructorAttribute]
            protected ListRequest() { }

            public ListRequest(
                List<string>? accessCodeIds = default,
                string? accessGrantId = default,
                string? accessGrantKey = default,
                string? accessMethodId = default,
                string? customerKey = default,
                string? deviceId = default,
                float? limit = default,
                string? pageCursor = default,
                string? search = default,
                string? userIdentifierKey = default
            )
            {
                AccessCodeIds = accessCodeIds;
                AccessGrantId = accessGrantId;
                AccessGrantKey = accessGrantKey;
                AccessMethodId = accessMethodId;
                CustomerKey = customerKey;
                DeviceId = deviceId;
                Limit = limit;
                PageCursor = pageCursor;
                Search = search;
                UserIdentifierKey = userIdentifierKey;
            }

            /// <summary>
            /// IDs of the access codes that you want to retrieve. Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_code_ids", IsRequired = false, EmitDefaultValue = false)]
            public List<string>? AccessCodeIds { get; set; }

            /// <summary>
            /// ID of the access grant for which you want to list access codes. Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_grant_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantId { get; set; }

            /// <summary>
            /// Key of the access grant for which you want to list access codes. Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_grant_key", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessGrantKey { get; set; }

            /// <summary>
            /// ID of the access method for which you want to list access codes. Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "access_method_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AccessMethodId { get; set; }

            /// <summary>
            /// Customer key for which you want to list access codes.
            /// </summary>
            [DataMember(Name = "customer_key", IsRequired = false, EmitDefaultValue = false)]
            public string? CustomerKey { get; set; }

            /// <summary>
            /// ID of the device for which you want to list access codes. Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Numerical limit on the number of access codes to return.
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
            /// Your user ID for the user by which to filter access codes.
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

            public ListResponse(List<AccessCode> accessCodes = default)
            {
                AccessCodes = accessCodes;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Returns a list of all [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
        /// </summary>
        public List<AccessCode> List(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Get<ListResponse>("/access_codes/list", requestOptions)
                .EnsureData("/access_codes/list")
                .AccessCodes;
        }

        /// <summary>
        /// Returns a list of all [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
        /// </summary>
        public List<AccessCode> List(
            List<string>? accessCodeIds = default,
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? accessMethodId = default,
            string? customerKey = default,
            string? deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return List(
                new ListRequest(
                    accessCodeIds: accessCodeIds,
                    accessGrantId: accessGrantId,
                    accessGrantKey: accessGrantKey,
                    accessMethodId: accessMethodId,
                    customerKey: customerKey,
                    deviceId: deviceId,
                    limit: limit,
                    pageCursor: pageCursor,
                    search: search,
                    userIdentifierKey: userIdentifierKey
                )
            );
        }

        /// <summary>
        /// Returns a list of all [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
        /// </summary>
        public async Task<List<AccessCode>> ListAsync(ListRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.GetAsync<ListResponse>("/access_codes/list", requestOptions))
                .EnsureData("/access_codes/list")
                .AccessCodes;
        }

        /// <summary>
        /// Returns a list of all [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// Specify `device_id`, `access_code_ids`, `access_method_id`, `access_grant_id`, or `access_grant_key`.
        /// </summary>
        public async Task<List<AccessCode>> ListAsync(
            List<string>? accessCodeIds = default,
            string? accessGrantId = default,
            string? accessGrantKey = default,
            string? accessMethodId = default,
            string? customerKey = default,
            string? deviceId = default,
            float? limit = default,
            string? pageCursor = default,
            string? search = default,
            string? userIdentifierKey = default
        )
        {
            return (
                await ListAsync(
                    new ListRequest(
                        accessCodeIds: accessCodeIds,
                        accessGrantId: accessGrantId,
                        accessGrantKey: accessGrantKey,
                        accessMethodId: accessMethodId,
                        customerKey: customerKey,
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
        /// Request parameters for Pull a Backup Access Code.
        /// </summary>
        [DataContract(Name = "pullBackupAccessCodeRequest_request")]
        public class PullBackupAccessCodeRequest
        {
            [JsonConstructorAttribute]
            protected PullBackupAccessCodeRequest() { }

            public PullBackupAccessCodeRequest(string accessCodeId = default)
            {
                AccessCodeId = accessCodeId;
            }

            /// <summary>
            /// ID of the access code for which you want to pull a backup access code.
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

        [DataContract(Name = "pullBackupAccessCodeResponse_response")]
        public class PullBackupAccessCodeResponse
        {
            [JsonConstructorAttribute]
            protected PullBackupAccessCodeResponse() { }

            public PullBackupAccessCodeResponse(AccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            /// <summary>
            /// OK
            /// </summary>
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

        /// <summary>
        /// Retrieves a backup access code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes). See also [Managing Backup Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes).
        ///
        /// A backup access code pool is a collection of pre-programmed access codes stored on a device, ready for use. These codes are programmed in addition to the regular access codes on Seam, serving as a safety net for any issues with the primary codes. If there&apos;s ever a complication with a primary access code—be it due to intermittent connectivity, manual removal from a device, or provider outages—a backup code can be retrieved. Its end time can then be adjusted to align with the original code, facilitating seamless and uninterrupted access.
        ///
        /// You can pull a backup access code from the pool at any time. These backup codes are guaranteed to work immediately and automatically programmed to be removed from the device after the access code ends.
        ///
        /// You can only pull backup access codes for time-bound access codes.
        ///
        /// Before pulling a backup access code, make sure that the device&apos;s `properties.supports_backup_access_code_pool` is `true`. Then, to activate the backup pool, set `use_backup_access_code_pool` to `true` when creating an access code.
        /// </summary>
        public AccessCode PullBackupAccessCode(PullBackupAccessCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<PullBackupAccessCodeResponse>(
                    "/access_codes/pull_backup_access_code",
                    requestOptions
                )
                .EnsureData("/access_codes/pull_backup_access_code")
                .AccessCode;
        }

        /// <summary>
        /// Retrieves a backup access code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes). See also [Managing Backup Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes).
        ///
        /// A backup access code pool is a collection of pre-programmed access codes stored on a device, ready for use. These codes are programmed in addition to the regular access codes on Seam, serving as a safety net for any issues with the primary codes. If there&apos;s ever a complication with a primary access code—be it due to intermittent connectivity, manual removal from a device, or provider outages—a backup code can be retrieved. Its end time can then be adjusted to align with the original code, facilitating seamless and uninterrupted access.
        ///
        /// You can pull a backup access code from the pool at any time. These backup codes are guaranteed to work immediately and automatically programmed to be removed from the device after the access code ends.
        ///
        /// You can only pull backup access codes for time-bound access codes.
        ///
        /// Before pulling a backup access code, make sure that the device&apos;s `properties.supports_backup_access_code_pool` is `true`. Then, to activate the backup pool, set `use_backup_access_code_pool` to `true` when creating an access code.
        /// </summary>
        public AccessCode PullBackupAccessCode(string accessCodeId = default)
        {
            return PullBackupAccessCode(
                new PullBackupAccessCodeRequest(accessCodeId: accessCodeId)
            );
        }

        /// <summary>
        /// Retrieves a backup access code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes). See also [Managing Backup Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes).
        ///
        /// A backup access code pool is a collection of pre-programmed access codes stored on a device, ready for use. These codes are programmed in addition to the regular access codes on Seam, serving as a safety net for any issues with the primary codes. If there&apos;s ever a complication with a primary access code—be it due to intermittent connectivity, manual removal from a device, or provider outages—a backup code can be retrieved. Its end time can then be adjusted to align with the original code, facilitating seamless and uninterrupted access.
        ///
        /// You can pull a backup access code from the pool at any time. These backup codes are guaranteed to work immediately and automatically programmed to be removed from the device after the access code ends.
        ///
        /// You can only pull backup access codes for time-bound access codes.
        ///
        /// Before pulling a backup access code, make sure that the device&apos;s `properties.supports_backup_access_code_pool` is `true`. Then, to activate the backup pool, set `use_backup_access_code_pool` to `true` when creating an access code.
        /// </summary>
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
                .EnsureData("/access_codes/pull_backup_access_code")
                .AccessCode;
        }

        /// <summary>
        /// Retrieves a backup access code for an [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes). See also [Managing Backup Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/backup-access-codes).
        ///
        /// A backup access code pool is a collection of pre-programmed access codes stored on a device, ready for use. These codes are programmed in addition to the regular access codes on Seam, serving as a safety net for any issues with the primary codes. If there&apos;s ever a complication with a primary access code—be it due to intermittent connectivity, manual removal from a device, or provider outages—a backup code can be retrieved. Its end time can then be adjusted to align with the original code, facilitating seamless and uninterrupted access.
        ///
        /// You can pull a backup access code from the pool at any time. These backup codes are guaranteed to work immediately and automatically programmed to be removed from the device after the access code ends.
        ///
        /// You can only pull backup access codes for time-bound access codes.
        ///
        /// Before pulling a backup access code, make sure that the device&apos;s `properties.supports_backup_access_code_pool` is `true`. Then, to activate the backup pool, set `use_backup_access_code_pool` to `true` when creating an access code.
        /// </summary>
        public async Task<AccessCode> PullBackupAccessCodeAsync(string accessCodeId = default)
        {
            return (
                await PullBackupAccessCodeAsync(
                    new PullBackupAccessCodeRequest(accessCodeId: accessCodeId)
                )
            );
        }

        /// <summary>
        /// Request parameters for Report Device Access Code Constraints.
        /// </summary>
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

            /// <summary>
            /// ID of the device for which you want to report constraints.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            /// <summary>
            /// Maximum supported code length as an integer between 4 and 20, inclusive. You can specify either `min_code_length`/`max_code_length` or `supported_code_lengths`.
            /// </summary>
            [DataMember(Name = "max_code_length", IsRequired = false, EmitDefaultValue = false)]
            public int? MaxCodeLength { get; set; }

            /// <summary>
            /// Minimum supported code length as an integer between 4 and 20, inclusive. You can specify either `min_code_length`/`max_code_length` or `supported_code_lengths`.
            /// </summary>
            [DataMember(Name = "min_code_length", IsRequired = false, EmitDefaultValue = false)]
            public int? MinCodeLength { get; set; }

            /// <summary>
            /// Array of supported code lengths as integers between 4 and 20, inclusive. You can specify either `supported_code_lengths` or `min_code_length`/`max_code_length`.
            /// </summary>
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

        /// <summary>
        /// Enables you to report access code-related constraints for a device. Currently, supports reporting supported code length constraints for SmartThings devices.
        ///
        /// Specify either `supported_code_lengths` or `min_code_length`/`max_code_length`.
        /// </summary>
        public void ReportDeviceConstraints(ReportDeviceConstraintsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/access_codes/report_device_constraints", requestOptions);
        }

        /// <summary>
        /// Enables you to report access code-related constraints for a device. Currently, supports reporting supported code length constraints for SmartThings devices.
        ///
        /// Specify either `supported_code_lengths` or `min_code_length`/`max_code_length`.
        /// </summary>
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

        /// <summary>
        /// Enables you to report access code-related constraints for a device. Currently, supports reporting supported code length constraints for SmartThings devices.
        ///
        /// Specify either `supported_code_lengths` or `min_code_length`/`max_code_length`.
        /// </summary>
        public async Task ReportDeviceConstraintsAsync(ReportDeviceConstraintsRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/access_codes/report_device_constraints",
                requestOptions
            );
        }

        /// <summary>
        /// Enables you to report access code-related constraints for a device. Currently, supports reporting supported code length constraints for SmartThings devices.
        ///
        /// Specify either `supported_code_lengths` or `min_code_length`/`max_code_length`.
        /// </summary>
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

        /// <summary>
        /// Request parameters for Update an Access Code.
        /// </summary>
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
                string? name = default,
                string? startsAt = default,
                UpdateRequest.TypeEnum? type = default
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
                Name = name;
                StartsAt = startsAt;
                Type = type;
            }

            /// <summary>
            /// Type to which you want to convert the access code. To convert a time-bound access code to an ongoing access code, set `type` to `ongoing`. See also [Changing a time-bound access code to permanent access](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes#special-case-2-changing-a-time-bound-access-code-to-permanent-access).
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum TypeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "ongoing")]
                Ongoing = 1,

                [EnumMember(Value = "time_bound")]
                TimeBound = 2,
            }

            /// <summary>
            /// ID of the access code that you want to update.
            /// </summary>
            [DataMember(Name = "access_code_id", IsRequired = true, EmitDefaultValue = false)]
            public string AccessCodeId { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
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

            /// <summary>
            /// Code to be used for access.
            /// </summary>
            [DataMember(Name = "code", IsRequired = false, EmitDefaultValue = false)]
            public string? Code { get; set; }

            /// <summary>
            /// ID of the device containing the access code that you want to update.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = false, EmitDefaultValue = false)]
            public string? DeviceId { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Indicates whether [external modification](https://docs.seam.co/low-level-apis/smart-locks/access-codes#external-modification) of the code is allowed. Default: `false`.
            /// </summary>
            [DataMember(
                Name = "is_external_modification_allowed",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsExternalModificationAllowed { get; set; }

            /// <summary>
            /// Indicates whether the access code is managed through Seam. Note that to convert an unmanaged access code into a managed access code, use `/access_codes/unmanaged/convert_to_managed`.
            /// </summary>
            [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
            public bool? IsManaged { get; set; }

            /// <summary>
            /// Name of the new access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes.
            ///
            /// Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`.
            ///
            /// To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints.
            ///
            /// To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
            [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
            public string? StartsAt { get; set; }

            /// <summary>
            /// Type to which you want to convert the access code. To convert a time-bound access code to an ongoing access code, set `type` to `ongoing`. See also [Changing a time-bound access code to permanent access](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes#special-case-2-changing-a-time-bound-access-code-to-permanent-access).
            /// </summary>
            [DataMember(Name = "type", IsRequired = false, EmitDefaultValue = false)]
            public UpdateRequest.TypeEnum? Type { get; set; }

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
        /// Updates a specified active or upcoming [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// See also [Modifying Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes).
        /// </summary>
        public void Update(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Put<object>("/access_codes/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified active or upcoming [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// See also [Modifying Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes).
        /// </summary>
        public void Update(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isManaged = default,
            string? name = default,
            string? startsAt = default,
            UpdateRequest.TypeEnum? type = default
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
                    name: name,
                    startsAt: startsAt,
                    type: type
                )
            );
        }

        /// <summary>
        /// Updates a specified active or upcoming [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// See also [Modifying Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes).
        /// </summary>
        public async Task UpdateAsync(UpdateRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PutAsync<object>("/access_codes/update", requestOptions);
        }

        /// <summary>
        /// Updates a specified active or upcoming [access code](https://docs.seam.co/low-level-apis/smart-locks/access-codes).
        ///
        /// See also [Modifying Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/modifying-access-codes).
        /// </summary>
        public async Task UpdateAsync(
            string accessCodeId = default,
            bool? allowExternalModification = default,
            bool? attemptForOfflineDevice = default,
            string? code = default,
            string? deviceId = default,
            string? endsAt = default,
            bool? isExternalModificationAllowed = default,
            bool? isManaged = default,
            string? name = default,
            string? startsAt = default,
            UpdateRequest.TypeEnum? type = default
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
                    name: name,
                    startsAt: startsAt,
                    type: type
                )
            );
        }

        /// <summary>
        /// Request parameters for Update Multiple Linked Access Codes.
        /// </summary>
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

            /// <summary>
            /// Key that links the group of access codes, assigned on creation by `/access_codes/create_multiple`.
            /// </summary>
            [DataMember(Name = "common_code_key", IsRequired = true, EmitDefaultValue = false)]
            public string CommonCodeKey { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Must be a time in the future and after `starts_at`.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Name of the new access code. Enables administrators and users to identify the access code easily, especially when there are numerous access codes.
            ///
            /// Note that the name provided on Seam is used to identify the code on Seam and is not necessarily the name that will appear in the lock provider&apos;s app or on the device. This is because lock providers may have constraints on names, such as length, uniqueness, or characters that can be used. In addition, some lock providers may break down names into components such as `first_name` and `last_name`.
            ///
            /// To provide a consistent experience, Seam identifies the code on Seam by its name but may modify the name that appears on the lock provider&apos;s app or on the device. For example, Seam may add additional characters or truncate the name to meet provider constraints.
            ///
            /// To help your users identify codes set by Seam, Seam provides the name exactly as it appears on the lock provider&apos;s app or on the device as a separate property called `appearance`. This is an object with a `name` property and, optionally, `first_name` and `last_name` properties (for providers that break down a name into components).
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

            /// <summary>
            /// Date and time at which the validity of the new access code starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            /// </summary>
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

        /// <summary>
        /// Updates [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Specify the `common_code_key` to identify the set of access codes that you want to update.
        ///
        /// See also [Update Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes#update-linked-access-codes).
        /// </summary>
        public void UpdateMultiple(UpdateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Patch<object>("/access_codes/update_multiple", requestOptions);
        }

        /// <summary>
        /// Updates [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Specify the `common_code_key` to identify the set of access codes that you want to update.
        ///
        /// See also [Update Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes#update-linked-access-codes).
        /// </summary>
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

        /// <summary>
        /// Updates [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Specify the `common_code_key` to identify the set of access codes that you want to update.
        ///
        /// See also [Update Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes#update-linked-access-codes).
        /// </summary>
        public async Task UpdateMultipleAsync(UpdateMultipleRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PatchAsync<object>("/access_codes/update_multiple", requestOptions);
        }

        /// <summary>
        /// Updates [access codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes) that share a common code across multiple devices.
        ///
        /// Specify the `common_code_key` to identify the set of access codes that you want to update.
        ///
        /// See also [Update Linked Access Codes](https://docs.seam.co/low-level-apis/smart-locks/access-codes/creating-and-updating-multiple-linked-access-codes#update-linked-access-codes).
        /// </summary>
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
