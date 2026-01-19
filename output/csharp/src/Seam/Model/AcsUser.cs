using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_acsUser_model")]
    public class AcsUser
    {
        [JsonConstructorAttribute]
        protected AcsUser() { }

        public AcsUser(
            AcsUserAccessSchedule? accessSchedule = default,
            string acsSystemId = default,
            string acsUserId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            string? email = default,
            string? emailAddress = default,
            List<AcsUserErrors> errors = default,
            AcsUser.ExternalTypeEnum? externalType = default,
            string? externalTypeDisplayName = default,
            string? fullName = default,
            string? hidAcsSystemId = default,
            bool isManaged = default,
            bool? isSuspended = default,
            string? lastSuccessfulSyncAt = default,
            List<AcsUserPendingMutations>? pendingMutations = default,
            string? phoneNumber = default,
            AcsUserSaltoSpaceMetadata? saltoSpaceMetadata = default,
            string? userIdentityEmailAddress = default,
            string? userIdentityFullName = default,
            string? userIdentityId = default,
            string? userIdentityPhoneNumber = default,
            List<AcsUserWarnings> warnings = default,
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
            SaltoSpaceMetadata = saltoSpaceMetadata;
            UserIdentityEmailAddress = userIdentityEmailAddress;
            UserIdentityFullName = userIdentityFullName;
            UserIdentityId = userIdentityId;
            UserIdentityPhoneNumber = userIdentityPhoneNumber;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsUserErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserErrorsLatchConflictWithResidentUser),
            "latch_conflict_with_resident_user"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserErrorsFailedToDeleteOnAcsSystem),
            "failed_to_delete_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserErrorsFailedToUpdateOnAcsSystem),
            "failed_to_update_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserErrorsFailedToCreateOnAcsSystem),
            "failed_to_create_on_acs_system"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserErrorsSaltoKsSubscriptionLimitExceeded),
            "salto_ks_subscription_limit_exceeded"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsUserErrorsDeletedExternally), "deleted_externally")]
        public abstract class AcsUserErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsUserErrorsDeletedExternally_model")]
        public class AcsUserErrorsDeletedExternally : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsDeletedExternally() { }

            public AcsUserErrorsDeletedExternally(
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

        [DataContract(Name = "seamModel_acsUserErrorsSaltoKsSubscriptionLimitExceeded_model")]
        public class AcsUserErrorsSaltoKsSubscriptionLimitExceeded : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsSaltoKsSubscriptionLimitExceeded() { }

            public AcsUserErrorsSaltoKsSubscriptionLimitExceeded(
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

        [DataContract(Name = "seamModel_acsUserErrorsFailedToCreateOnAcsSystem_model")]
        public class AcsUserErrorsFailedToCreateOnAcsSystem : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsFailedToCreateOnAcsSystem() { }

            public AcsUserErrorsFailedToCreateOnAcsSystem(
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

        [DataContract(Name = "seamModel_acsUserErrorsFailedToUpdateOnAcsSystem_model")]
        public class AcsUserErrorsFailedToUpdateOnAcsSystem : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsFailedToUpdateOnAcsSystem() { }

            public AcsUserErrorsFailedToUpdateOnAcsSystem(
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

        [DataContract(Name = "seamModel_acsUserErrorsFailedToDeleteOnAcsSystem_model")]
        public class AcsUserErrorsFailedToDeleteOnAcsSystem : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsFailedToDeleteOnAcsSystem() { }

            public AcsUserErrorsFailedToDeleteOnAcsSystem(
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

        [DataContract(Name = "seamModel_acsUserErrorsLatchConflictWithResidentUser_model")]
        public class AcsUserErrorsLatchConflictWithResidentUser : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsLatchConflictWithResidentUser() { }

            public AcsUserErrorsLatchConflictWithResidentUser(
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

        [DataContract(Name = "seamModel_acsUserErrorsUnrecognized_model")]
        public class AcsUserErrorsUnrecognized : AcsUserErrors
        {
            [JsonConstructorAttribute]
            protected AcsUserErrorsUnrecognized() { }

            public AcsUserErrorsUnrecognized(string errorCode = default, string message = default)
            {
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

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
        [JsonSubtypes.FallBackSubType(typeof(AcsUserPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsUpdatingGroupMembership),
            "updating_group_membership"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsUpdatingSuspensionState),
            "updating_suspension_state"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsUpdatingAccessSchedule),
            "updating_access_schedule"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsUpdatingUserInformation),
            "updating_user_information"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsDeferringCreation),
            "deferring_creation"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsUserPendingMutationsDeleting), "deleting")]
        [JsonSubtypes.KnownSubType(typeof(AcsUserPendingMutationsCreating), "creating")]
        public abstract class AcsUserPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsUserPendingMutationsCreating_model")]
        public class AcsUserPendingMutationsCreating : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsCreating() { }

            public AcsUserPendingMutationsCreating(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsDeleting_model")]
        public class AcsUserPendingMutationsDeleting : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsDeleting() { }

            public AcsUserPendingMutationsDeleting(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsDeferringCreation_model")]
        public class AcsUserPendingMutationsDeferringCreation : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsDeferringCreation() { }

            public AcsUserPendingMutationsDeferringCreation(
                string createdAt = default,
                string message = default,
                string mutationCode = default,
                string? scheduledAt = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
                ScheduledAt = scheduledAt;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deferring_creation";

            [DataMember(Name = "scheduled_at", IsRequired = false, EmitDefaultValue = false)]
            public string? ScheduledAt { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingUserInformation_model")]
        public class AcsUserPendingMutationsUpdatingUserInformation : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingUserInformation() { }

            public AcsUserPendingMutationsUpdatingUserInformation(
                string createdAt = default,
                AcsUserPendingMutationsUpdatingUserInformationFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsUpdatingUserInformationTo to = default
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
            public AcsUserPendingMutationsUpdatingUserInformationFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_user_information";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingUserInformationTo To { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingUserInformationFrom_model")]
        public class AcsUserPendingMutationsUpdatingUserInformationFrom
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingUserInformationFrom() { }

            public AcsUserPendingMutationsUpdatingUserInformationFrom(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingUserInformationTo_model")]
        public class AcsUserPendingMutationsUpdatingUserInformationTo
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingUserInformationTo() { }

            public AcsUserPendingMutationsUpdatingUserInformationTo(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingAccessSchedule_model")]
        public class AcsUserPendingMutationsUpdatingAccessSchedule : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingAccessSchedule() { }

            public AcsUserPendingMutationsUpdatingAccessSchedule(
                string createdAt = default,
                AcsUserPendingMutationsUpdatingAccessScheduleFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsUpdatingAccessScheduleTo to = default
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
            public AcsUserPendingMutationsUpdatingAccessScheduleFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_schedule";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingAccessScheduleTo To { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingAccessScheduleFrom_model")]
        public class AcsUserPendingMutationsUpdatingAccessScheduleFrom
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingAccessScheduleFrom() { }

            public AcsUserPendingMutationsUpdatingAccessScheduleFrom(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingAccessScheduleTo_model")]
        public class AcsUserPendingMutationsUpdatingAccessScheduleTo
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingAccessScheduleTo() { }

            public AcsUserPendingMutationsUpdatingAccessScheduleTo(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingSuspensionState_model")]
        public class AcsUserPendingMutationsUpdatingSuspensionState : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingSuspensionState() { }

            public AcsUserPendingMutationsUpdatingSuspensionState(
                string createdAt = default,
                AcsUserPendingMutationsUpdatingSuspensionStateFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsUpdatingSuspensionStateTo to = default
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
            public AcsUserPendingMutationsUpdatingSuspensionStateFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_suspension_state";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingSuspensionStateTo To { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingSuspensionStateFrom_model")]
        public class AcsUserPendingMutationsUpdatingSuspensionStateFrom
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingSuspensionStateFrom() { }

            public AcsUserPendingMutationsUpdatingSuspensionStateFrom(bool isSuspended = default)
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingSuspensionStateTo_model")]
        public class AcsUserPendingMutationsUpdatingSuspensionStateTo
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingSuspensionStateTo() { }

            public AcsUserPendingMutationsUpdatingSuspensionStateTo(bool isSuspended = default)
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingGroupMembership_model")]
        public class AcsUserPendingMutationsUpdatingGroupMembership : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingGroupMembership() { }

            public AcsUserPendingMutationsUpdatingGroupMembership(
                string createdAt = default,
                AcsUserPendingMutationsUpdatingGroupMembershipFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsUpdatingGroupMembershipTo to = default
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
            public AcsUserPendingMutationsUpdatingGroupMembershipFrom From { get; set; }

            [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
            public string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_group_membership";

            [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingGroupMembershipTo To { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingGroupMembershipFrom_model")]
        public class AcsUserPendingMutationsUpdatingGroupMembershipFrom
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingGroupMembershipFrom() { }

            public AcsUserPendingMutationsUpdatingGroupMembershipFrom(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingGroupMembershipTo_model")]
        public class AcsUserPendingMutationsUpdatingGroupMembershipTo
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingGroupMembershipTo() { }

            public AcsUserPendingMutationsUpdatingGroupMembershipTo(
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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUnrecognized_model")]
        public class AcsUserPendingMutationsUnrecognized : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUnrecognized() { }

            public AcsUserPendingMutationsUnrecognized(string mutationCode = default)
            {
                MutationCode = mutationCode;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

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
        [JsonSubtypes.FallBackSubType(typeof(AcsUserWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AcsUserWarningsLatchResidentUser), "latch_resident_user")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserWarningsUnknownIssueWithAcsUser),
            "unknown_issue_with_acs_user"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserWarningsSaltoKsUserNotSubscribed),
            "salto_ks_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsUserWarningsBeingDeleted), "being_deleted")]
        public abstract class AcsUserWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsUserWarningsBeingDeleted_model")]
        public class AcsUserWarningsBeingDeleted : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsBeingDeleted() { }

            public AcsUserWarningsBeingDeleted(
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

        [DataContract(Name = "seamModel_acsUserWarningsSaltoKsUserNotSubscribed_model")]
        public class AcsUserWarningsSaltoKsUserNotSubscribed : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsSaltoKsUserNotSubscribed() { }

            public AcsUserWarningsSaltoKsUserNotSubscribed(
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

        [DataContract(Name = "seamModel_acsUserWarningsUnknownIssueWithAcsUser_model")]
        public class AcsUserWarningsUnknownIssueWithAcsUser : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsUnknownIssueWithAcsUser() { }

            public AcsUserWarningsUnknownIssueWithAcsUser(
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

        [DataContract(Name = "seamModel_acsUserWarningsLatchResidentUser_model")]
        public class AcsUserWarningsLatchResidentUser : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsLatchResidentUser() { }

            public AcsUserWarningsLatchResidentUser(
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

        [DataContract(Name = "seamModel_acsUserWarningsUnrecognized_model")]
        public class AcsUserWarningsUnrecognized : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsUnrecognized() { }

            public AcsUserWarningsUnrecognized(
                string warningCode = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

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

        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserAccessSchedule? AccessSchedule { get; set; }

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
        public List<AcsUserErrors> Errors { get; set; }

        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsUser.ExternalTypeEnum? ExternalType { get; set; }

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
        public List<AcsUserPendingMutations>? PendingMutations { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

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
        public List<AcsUserWarnings> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_acsUserAccessSchedule_model")]
    public class AcsUserAccessSchedule
    {
        [JsonConstructorAttribute]
        protected AcsUserAccessSchedule() { }

        public AcsUserAccessSchedule(string? endsAt = default, string startsAt = default)
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

    [DataContract(Name = "seamModel_acsUserSaltoSpaceMetadata_model")]
    public class AcsUserSaltoSpaceMetadata
    {
        [JsonConstructorAttribute]
        protected AcsUserSaltoSpaceMetadata() { }

        public AcsUserSaltoSpaceMetadata(bool? auditOpenings = default, string? userId = default)
        {
            AuditOpenings = auditOpenings;
            UserId = userId;
        }

        [DataMember(Name = "audit_openings", IsRequired = false, EmitDefaultValue = false)]
        public bool? AuditOpenings { get; set; }

        [DataMember(Name = "user_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserId { get; set; }

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
