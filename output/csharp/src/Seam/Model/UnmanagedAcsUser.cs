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
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? email = default,
            string? emailAddress = default,
            List<UnmanagedAcsUserErrors> errors = default,
            UnmanagedAcsUser.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            bool isManaged = default,
            bool? isSuspended = default,
            string? lastSuccessfulSyncAt = default,
            List<UnmanagedAcsUserPendingMutations>? pendingMutations = default,
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
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Email = email;
            EmailAddress = emailAddress;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            FullName = fullName;
            HidAcsSystemId = hidAcsSystemId;
            IsManaged = isManaged;
            IsSuspended = isSuspended;
            LastSuccessfulSyncAt = lastSuccessfulSyncAt;
            PendingMutations = pendingMutations;
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
            typeof(UnmanagedAcsUserErrorsLatchConflictWithResidentUser),
            "latch_conflict_with_resident_user"
        )]
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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserErrorsLatchConflictWithResidentUser_model")]
        public class UnmanagedAcsUserErrorsLatchConflictWithResidentUser : UnmanagedAcsUserErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserErrorsLatchConflictWithResidentUser() { }

            public UnmanagedAcsUserErrorsLatchConflictWithResidentUser(
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
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "latch_conflict_with_resident_user";

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

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingMutationsUpdatingGroupMembership),
            "updating_group_membership"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingMutationsUpdatingSuspensionState),
            "updating_suspension_state"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingMutationsUpdatingAccessSchedule),
            "updating_access_schedule"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedAcsUserPendingMutationsUpdatingUserInformation),
            "updating_user_information"
        )]
        [JsonSubtypes.KnownSubType(typeof(UnmanagedAcsUserPendingMutationsDeleting), "deleting")]
        [JsonSubtypes.KnownSubType(typeof(UnmanagedAcsUserPendingMutationsCreating), "creating")]
        public abstract class UnmanagedAcsUserPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedAcsUserPendingMutationsCreating_model")]
        public class UnmanagedAcsUserPendingMutationsCreating : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsCreating() { }

            public UnmanagedAcsUserPendingMutationsCreating(
                string createdAt = default,
                string message = default,
                string mutationCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "creating";

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

        [DataContract(Name = "seamModel_unmanagedAcsUserPendingMutationsDeleting_model")]
        public class UnmanagedAcsUserPendingMutationsDeleting : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsDeleting() { }

            public UnmanagedAcsUserPendingMutationsDeleting(
                string createdAt = default,
                string message = default,
                string mutationCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deleting";

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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingUserInformation_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingUserInformation
            : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingUserInformation() { }

            public UnmanagedAcsUserPendingMutationsUpdatingUserInformation(
                string createdAt = default,
                UnmanagedAcsUserPendingMutationsUpdatingUserInformationFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAcsUserPendingMutationsUpdatingUserInformationTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingUserInformationFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_user_information";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingUserInformationTo To { get; set; }

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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingUserInformationFrom_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingUserInformationFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingUserInformationFrom() { }

            public UnmanagedAcsUserPendingMutationsUpdatingUserInformationFrom(
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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingUserInformationTo_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingUserInformationTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingUserInformationTo() { }

            public UnmanagedAcsUserPendingMutationsUpdatingUserInformationTo(
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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingAccessSchedule_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingAccessSchedule
            : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingAccessSchedule() { }

            public UnmanagedAcsUserPendingMutationsUpdatingAccessSchedule(
                string createdAt = default,
                UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_schedule";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo To { get; set; }

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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom() { }

            public UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleFrom(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo() { }

            public UnmanagedAcsUserPendingMutationsUpdatingAccessScheduleTo(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

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

        [DataContract(
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingSuspensionState_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingSuspensionState
            : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingSuspensionState() { }

            public UnmanagedAcsUserPendingMutationsUpdatingSuspensionState(
                string createdAt = default,
                UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_suspension_state";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo To { get; set; }

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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom() { }

            public UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateFrom(
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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo() { }

            public UnmanagedAcsUserPendingMutationsUpdatingSuspensionStateTo(
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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingGroupMembership_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingGroupMembership
            : UnmanagedAcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingGroupMembership() { }

            public UnmanagedAcsUserPendingMutationsUpdatingGroupMembership(
                string createdAt = default,
                UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom from = default,
                string message = default,
                string mutationCode = default,
                UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_group_membership";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo To { get; set; }

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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom() { }

            public UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipFrom(
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
            Name = "seamModel_unmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo_model"
        )]
        public class UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo() { }

            public UnmanagedAcsUserPendingMutationsUpdatingGroupMembershipTo(
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
            typeof(UnmanagedAcsUserWarningsLatchResidentUser),
            "latch_resident_user"
        )]
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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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
            public string CreatedAt { get; set; }

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

        [DataContract(Name = "seamModel_unmanagedAcsUserWarningsLatchResidentUser_model")]
        public class UnmanagedAcsUserWarningsLatchResidentUser : UnmanagedAcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedAcsUserWarningsLatchResidentUser() { }

            public UnmanagedAcsUserWarningsLatchResidentUser(
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
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "latch_resident_user";

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

        [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

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

        [DataMember(Name = "is_managed", IsRequired = true, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsSuspended { get; set; }

        [DataMember(Name = "last_successful_sync_at", IsRequired = false, EmitDefaultValue = false)]
        public string? LastSuccessfulSyncAt { get; set; }

        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedAcsUserPendingMutations>? PendingMutations { get; set; }

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
