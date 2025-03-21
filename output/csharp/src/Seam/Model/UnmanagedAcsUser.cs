using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_unmanagedAcsUser_model")]
    public class UnmanagedAcsUser
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsUser() { }

        public UnmanagedAcsUser(
            UnmanagedAcsUserAccessSchedule? accessSchedule = default,
            string acsSystemId = default,
            string acsUserId = default,
            string createdAt = default,
            string displayName = default,
            string? email = default,
            string? emailAddress = default,
            List<UnmanagedAcsUserErrors> errors = default,
            UnmanagedAcsUser.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            bool? isLatestDesiredStateSyncedWithProvider = default,
            bool isManaged = default,
            bool? isSuspended = default,
            string? latestDesiredStateSyncedWithProviderAt = default,
            List<UnmanagedAcsUserPendingModifications>? pendingModifications = default,
            string? phoneNumber = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityFullName = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default,
            List<UnmanagedAcsUserWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessSchedule = accessSchedule;
            AcsSystemId = acsSystemId;
            AcsUserId = acsUserId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Email = email;
            EmailAddress = emailAddress;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            FullName = fullName;
            HidAcsSystemId = hidAcsSystemId;
            IsLatestDesiredStateSyncedWithProvider = isLatestDesiredStateSyncedWithProvider;
            IsManaged = isManaged;
            IsSuspended = isSuspended;
            LatestDesiredStateSyncedWithProviderAt = latestDesiredStateSyncedWithProviderAt;
            PendingModifications = pendingModifications;
            PhoneNumber = phoneNumber;
            UserIdentityEmailAddress = userIdentityEmailAddress;
            UserIdentityFullName = userIdentityFullName;
            UserIdentityId = userIdentityId;
            UserIdentityPhoneNumber = userIdentityPhoneNumber;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserErrorsFailedToDeleteOnAcsSystem),
            "failed_to_delete_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserErrorsFailedToUpdateOnAcsSystem),
            "failed_to_update_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserErrorsFailedToCreateOnAcsSystem),
            "failed_to_create_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserErrorsDeletedExternally),
            "deleted_externally"
        )]
        public abstract class UnmanagedAcsUserErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAcsUserErrorsDeletedExternally_model")]
        public class UnmanagedAcsUserErrorsDeletedExternally : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsDeletedExternally() { }

            public UnmanagedAcsUserErrorsDeletedExternally(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "deleted_externally";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserErrorsSaltoKsSubscriptionLimitExceeded_model"
        )]
        public class UnmanagedAcsUserErrorsSaltoKsSubscriptionLimitExceeded : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsSaltoKsSubscriptionLimitExceeded() { }

            public UnmanagedAcsUserErrorsSaltoKsSubscriptionLimitExceeded(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserErrorsFailedToCreateOnAcsSystem_model")]
        public class UnmanagedAcsUserErrorsFailedToCreateOnAcsSystem : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsFailedToCreateOnAcsSystem() { }

            public UnmanagedAcsUserErrorsFailedToCreateOnAcsSystem(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_create_on_acs_system";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserErrorsFailedToUpdateOnAcsSystem_model")]
        public class UnmanagedAcsUserErrorsFailedToUpdateOnAcsSystem : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsFailedToUpdateOnAcsSystem() { }

            public UnmanagedAcsUserErrorsFailedToUpdateOnAcsSystem(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_update_on_acs_system";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserErrorsFailedToDeleteOnAcsSystem_model")]
        public class UnmanagedAcsUserErrorsFailedToDeleteOnAcsSystem : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsFailedToDeleteOnAcsSystem() { }

            public UnmanagedAcsUserErrorsFailedToDeleteOnAcsSystem(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_delete_on_acs_system";

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_user")]
            PtiUser = 1,

            [EnumMember(Value = "brivo_user")]
            BrivoUser = 2,

            [EnumMember(Value = "hid_credential_manager_user")]
            HidCredentialManagerUser = 3,

            [EnumMember(Value = "salto_site_user")]
            SaltoSiteUser = 4,

            [EnumMember(Value = "latch_user")]
            LatchUser = 5,

            [EnumMember(Value = "dormakaba_community_user")]
            DormakabaCommunityUser = 6,

            [EnumMember(Value = "salto_space_user")]
            SaltoSpaceUser = 7,
        }

        [JsonConverter(typeof(JsonSubtypes), "modification_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingModificationsAcsAccessGroupMembership),
            "acs_access_group_membership"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingModificationsSuspensionState),
            "suspension_state"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingModificationsAccessSchedule),
            "access_schedule"
        )]
        [JsonSubtypes.KnownSubType(typeof(UnmanagedAcsUserPendingModificationsProfile), "profile")]
        public abstract class UnmanagedAcsUserPendingModifications
        {
            public abstract string ModificationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract object ModifiedFrom { get; set; }

            public abstract object ModifiedTo { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAcsUserPendingModificationsProfile_model")]
        public class UnmanagedAcsUserPendingModificationsProfile
            : UnmanagedAcsUserPendingModifications
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsProfile() { }

            public UnmanagedAcsUserPendingModificationsProfile(
                string createdAt = default,
                string modificationCode = default,
                UnmanagedAcsUserPendingModificationsProfileModifiedFrom modifiedFrom = default,
                UnmanagedAcsUserPendingModificationsProfileModifiedTo modifiedTo = default
            )
            {
                CreatedAt = createdAt;
                ModificationCode = modificationCode;
                ModifiedFrom = modifiedFrom;
                ModifiedTo = modifiedTo;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "modification_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ModificationCode { get; } = "profile";

            [DataMember(Name = "modified_from", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsProfileModifiedFrom ModifiedFrom { get; set; }

            [DataMember(Name = "modified_to", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsProfileModifiedTo ModifiedTo { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsProfileModifiedFrom_model"
        )]
        public class UnmanagedAcsUserPendingModificationsProfileModifiedFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsProfileModifiedFrom() { }

            public UnmanagedAcsUserPendingModificationsProfileModifiedFrom(
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsProfileModifiedTo_model"
        )]
        public class UnmanagedAcsUserPendingModificationsProfileModifiedTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsProfileModifiedTo() { }

            public UnmanagedAcsUserPendingModificationsProfileModifiedTo(
                string? emailAddress = default,
                string? fullName = default,
                string? phoneNumber = default
            )
            {
                EmailAddress = emailAddress;
                FullName = fullName;
                PhoneNumber = phoneNumber;
            }

            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
            public string? PhoneNumber { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserPendingModificationsAccessSchedule_model")]
        public class UnmanagedAcsUserPendingModificationsAccessSchedule
            : UnmanagedAcsUserPendingModifications
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAccessSchedule() { }

            public UnmanagedAcsUserPendingModificationsAccessSchedule(
                string createdAt = default,
                string modificationCode = default,
                UnmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom modifiedFrom =
                    default,
                UnmanagedAcsUserPendingModificationsAccessScheduleModifiedTo modifiedTo = default
            )
            {
                CreatedAt = createdAt;
                ModificationCode = modificationCode;
                ModifiedFrom = modifiedFrom;
                ModifiedTo = modifiedTo;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "modification_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ModificationCode { get; } = "access_schedule";

            [DataMember(Name = "modified_from", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom ModifiedFrom { get; set; }

            [DataMember(Name = "modified_to", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsAccessScheduleModifiedTo ModifiedTo { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom_model"
        )]
        public class UnmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom() { }

            public UnmanagedAcsUserPendingModificationsAccessScheduleModifiedFrom(
                string? endsAt = default,
                string startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAt { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsAccessScheduleModifiedTo_model"
        )]
        public class UnmanagedAcsUserPendingModificationsAccessScheduleModifiedTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAccessScheduleModifiedTo() { }

            public UnmanagedAcsUserPendingModificationsAccessScheduleModifiedTo(
                string? endsAt = default,
                string startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
            public string StartsAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserPendingModificationsSuspensionState_model")]
        public class UnmanagedAcsUserPendingModificationsSuspensionState
            : UnmanagedAcsUserPendingModifications
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsSuspensionState() { }

            public UnmanagedAcsUserPendingModificationsSuspensionState(
                string createdAt = default,
                string modificationCode = default,
                UnmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom modifiedFrom =
                    default,
                UnmanagedAcsUserPendingModificationsSuspensionStateModifiedTo modifiedTo = default
            )
            {
                CreatedAt = createdAt;
                ModificationCode = modificationCode;
                ModifiedFrom = modifiedFrom;
                ModifiedTo = modifiedTo;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "modification_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ModificationCode { get; } = "suspension_state";

            [DataMember(Name = "modified_from", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom ModifiedFrom { get; set; }

            [DataMember(Name = "modified_to", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsSuspensionStateModifiedTo ModifiedTo { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom_model"
        )]
        public class UnmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom() { }

            public UnmanagedAcsUserPendingModificationsSuspensionStateModifiedFrom(
                bool isSuspended = default
            )
            {
                IsSuspended = isSuspended;
            }

            [DataMember(Name = "is_suspended", IsRequired = true, EmitDefaultValue = false)]
            public bool IsSuspended { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsSuspensionStateModifiedTo_model"
        )]
        public class UnmanagedAcsUserPendingModificationsSuspensionStateModifiedTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsSuspensionStateModifiedTo() { }

            public UnmanagedAcsUserPendingModificationsSuspensionStateModifiedTo(
                bool isSuspended = default
            )
            {
                IsSuspended = isSuspended;
            }

            [DataMember(Name = "is_suspended", IsRequired = true, EmitDefaultValue = false)]
            public bool IsSuspended { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsAcsAccessGroupMembership_model"
        )]
        public class UnmanagedAcsUserPendingModificationsAcsAccessGroupMembership
            : UnmanagedAcsUserPendingModifications
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAcsAccessGroupMembership() { }

            public UnmanagedAcsUserPendingModificationsAcsAccessGroupMembership(
                string createdAt = default,
                string modificationCode = default,
                UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom modifiedFrom =
                    default,
                UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo modifiedTo =
                    default
            )
            {
                CreatedAt = createdAt;
                ModificationCode = modificationCode;
                ModifiedFrom = modifiedFrom;
                ModifiedTo = modifiedTo;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "modification_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ModificationCode { get; } = "acs_access_group_membership";

            [DataMember(Name = "modified_from", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom ModifiedFrom { get; set; }

            [DataMember(Name = "modified_to", IsRequired = true, EmitDefaultValue = false)]
            public override UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo ModifiedTo { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom_model"
        )]
        public class UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom() { }

            public UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedFrom(
                string? acsAccessGroupId = default
            )
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsAccessGroupId { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo_model"
        )]
        public class UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo() { }

            public UnmanagedAcsUserPendingModificationsAcsAccessGroupMembershipModifiedTo(
                string? acsAccessGroupId = default
            )
            {
                AcsAccessGroupId = acsAccessGroupId;
            }

            [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsAccessGroupId { get; set; }

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserWarningsUnknownIssueWithAcsUser),
            "unknown_issue_with_acs_user"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserWarningsSaltoKsUserNotSubscribed),
            "salto_ks_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(typeof(UnmanagedAcsUserWarningsBeingDeleted), "being_deleted")]
        public abstract class UnmanagedAcsUserWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAcsUserWarningsBeingDeleted_model")]
        public class UnmanagedAcsUserWarningsBeingDeleted : UnmanagedAcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserWarningsBeingDeleted() { }

            public UnmanagedAcsUserWarningsBeingDeleted(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "being_deleted";

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

        [DataContract(Name = "seamModel_unmanagedAcsUserWarningsSaltoKsUserNotSubscribed_model")]
        public class UnmanagedAcsUserWarningsSaltoKsUserNotSubscribed : UnmanagedAcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserWarningsSaltoKsUserNotSubscribed() { }

            public UnmanagedAcsUserWarningsSaltoKsUserNotSubscribed(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "salto_ks_user_not_subscribed";

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

        [DataContract(Name = "seamModel_unmanagedAcsUserWarningsUnknownIssueWithAcsUser_model")]
        public class UnmanagedAcsUserWarningsUnknownIssueWithAcsUser : UnmanagedAcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserWarningsUnknownIssueWithAcsUser() { }

            public UnmanagedAcsUserWarningsUnknownIssueWithAcsUser(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unknown_issue_with_acs_user";

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

        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAcsUserAccessSchedule? AccessSchedule { get; set; }

        [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAcsUserErrors> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public UnmanagedAcsUser.ExternalTypeEnum? ExternalType { get; set; }

        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HidAcsSystemId { get; set; }

        [DataMember(
            Name = "is_latest_desired_state_synced_with_provider",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public bool? IsLatestDesiredStateSyncedWithProvider { get; set; }

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsSuspended { get; set; }

        [DataMember(
            Name = "latest_desired_state_synced_with_provider_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? LatestDesiredStateSyncedWithProviderAt { get; set; }

        [DataMember(Name = "pending_modifications", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAcsUserPendingModifications>? PendingModifications { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(
            Name = "user_identity_email_address",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityEmailAddress { get; set; }

        [DataMember(Name = "user_identity_full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityFullName { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        [DataMember(
            Name = "user_identity_phone_number",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityPhoneNumber { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UnmanagedAcsUserWarnings> Warnings { get; set; }

        [DataMember(Name = "workspace_id", IsRequired = true, EmitDefaultValue = false)]
        public string WorkspaceId { get; set; }

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

    [DataContract(Name = "seamModel_unmanagedAcsUserAccessSchedule_model")]
    public class UnmanagedAcsUserAccessSchedule
    {
        [JsonConstructorAttribute]
        protected UnmanagedAcsUserAccessSchedule() { }

        public UnmanagedAcsUserAccessSchedule(string? endsAt = default, string startsAt = default)
        {
            EndsAt = endsAt;
            StartsAt = startsAt;
        }

        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        [DataMember(Name = "starts_at", IsRequired = true, EmitDefaultValue = false)]
        public string StartsAt { get; set; }

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
}
