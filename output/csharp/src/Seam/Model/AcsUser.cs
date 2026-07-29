using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    /// <summary>
    /// Represents a [user](https://docs.seam.co/low-level-apis/access-systems/user-management) in an [access system](https://docs.seam.co/low-level-apis/access-systems).
    ///
    /// An access system user typically refers to an individual who requires access, like an employee or resident. Each user can possess multiple credentials that serve as their keys or identifiers for access. The type of credential can vary widely. For example, in the Salto system, a user can have a PIN code, a mobile app account, and a fob. In other platforms, it is not uncommon for a user to have more than one of the same credential type, such as multiple key cards. Additionally, these credentials can have a schedule or validity period.
    ///
    /// For details about how to configure users in your access system, see the corresponding [system integration guide](https://docs.seam.co/device-and-system-integration-guides#access-control-systems).
    /// </summary>
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
            List<AcsUserPendingMutations>? pendingMutations = default,
            string? phoneNumber = default,
            AcsUserSaltoKsMetadata? saltoKsMetadata = default,
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
            PendingMutations = pendingMutations;
            PhoneNumber = phoneNumber;
            SaltoKsMetadata = saltoKsMetadata;
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

            public abstract string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "deleted_externally";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "salto_ks_subscription_limit_exceeded";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_create_on_acs_system";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_update_on_acs_system";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "failed_to_delete_on_acs_system";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "latch_conflict_with_resident_user";

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            public AcsUserErrorsUnrecognized(
                string errorCode = default,
                string createdAt = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Brand-specific terminology for the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) type.
        /// </summary>
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

            [EnumMember(Value = "avigilon_alta_user")]
            AvigilonAltaUser = 8,

            [EnumMember(Value = "kisi_user")]
            KisiUser = 9,
        }

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsUserPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsUpdatingCredentialAssignment),
            "updating_credential_assignment"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserPendingMutationsDeferringGroupMembershipUpdate),
            "deferring_group_membership_update"
        )]
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

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deferring_creation";

            /// <summary>
            /// Optional: When the user creation is scheduled to occur.
            /// </summary>
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Old access system user information.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingUserInformationFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_user_information";

            /// <summary>
            /// New access system user information.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Email address of the access system user.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the access system user.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// Phone number of the access system user.
            /// </summary>
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

            /// <summary>
            /// Email address of the access system user.
            /// </summary>
            [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
            public string? EmailAddress { get; set; }

            /// <summary>
            /// Full name of the access system user.
            /// </summary>
            [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
            public string? FullName { get; set; }

            /// <summary>
            /// Phone number of the access system user.
            /// </summary>
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Old access schedule information.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingAccessScheduleFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_access_schedule";

            /// <summary>
            /// New access schedule information.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Starting time for the access schedule.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Starting time for the access schedule.
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

            /// <summary>
            /// Starting time for the access schedule.
            /// </summary>
            [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
            public string? EndsAt { get; set; }

            /// <summary>
            /// Starting time for the access schedule.
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Old user suspension state information.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingSuspensionStateFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_suspension_state";

            /// <summary>
            /// New user suspension state information.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
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

            [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Old access group membership.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingGroupMembershipFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_group_membership";

            /// <summary>
            /// New access group membership.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Old access group ID.
            /// </summary>
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

            /// <summary>
            /// New access group ID.
            /// </summary>
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
            Name = "seamModel_acsUserPendingMutationsDeferringGroupMembershipUpdate_model"
        )]
        public class AcsUserPendingMutationsDeferringGroupMembershipUpdate : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsDeferringGroupMembershipUpdate() { }

            public AcsUserPendingMutationsDeferringGroupMembershipUpdate(
                string acsAccessGroupId = default,
                string createdAt = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsDeferringGroupMembershipUpdate.VariantEnum variant = default
            )
            {
                AcsAccessGroupId = acsAccessGroupId;
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
                Variant = variant;
            }

            /// <summary>
            /// Whether the user is scheduled to be added to or removed from the access group.
            /// </summary>
            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum VariantEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "adding")]
                Adding = 1,

                [EnumMember(Value = "removing")]
                Removing = 2,
            }

            /// <summary>
            /// ID of the access group involved in the scheduled change.
            /// </summary>
            [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
            public string AcsAccessGroupId { get; set; }

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "deferring_group_membership_update";

            /// <summary>
            /// Whether the user is scheduled to be added to or removed from the access group.
            /// </summary>
            [DataMember(Name = "variant", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsDeferringGroupMembershipUpdate.VariantEnum Variant { get; set; }

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

        [DataContract(Name = "seamModel_acsUserPendingMutationsUpdatingCredentialAssignment_model")]
        public class AcsUserPendingMutationsUpdatingCredentialAssignment : AcsUserPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingCredentialAssignment() { }

            public AcsUserPendingMutationsUpdatingCredentialAssignment(
                string createdAt = default,
                AcsUserPendingMutationsUpdatingCredentialAssignmentFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsUserPendingMutationsUpdatingCredentialAssignmentTo to = default
            )
            {
                CreatedAt = createdAt;
                From = from;
                Message = message;
                MutationCode = mutationCode;
                To = to;
            }

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Previous credential assignment.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingCredentialAssignmentFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_credential_assignment";

            /// <summary>
            /// New credential assignment.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AcsUserPendingMutationsUpdatingCredentialAssignmentTo To { get; set; }

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
            Name = "seamModel_acsUserPendingMutationsUpdatingCredentialAssignmentFrom_model"
        )]
        public class AcsUserPendingMutationsUpdatingCredentialAssignmentFrom
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingCredentialAssignmentFrom() { }

            public AcsUserPendingMutationsUpdatingCredentialAssignmentFrom(
                string? acsCredentialId = default
            )
            {
                AcsCredentialId = acsCredentialId;
            }

            /// <summary>
            /// Previous credential ID.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

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
            Name = "seamModel_acsUserPendingMutationsUpdatingCredentialAssignmentTo_model"
        )]
        public class AcsUserPendingMutationsUpdatingCredentialAssignmentTo
        {
            [JsonConstructorAttribute]
            protected AcsUserPendingMutationsUpdatingCredentialAssignmentTo() { }

            public AcsUserPendingMutationsUpdatingCredentialAssignmentTo(
                string? acsCredentialId = default
            )
            {
                AcsCredentialId = acsCredentialId;
            }

            /// <summary>
            /// New credential ID.
            /// </summary>
            [DataMember(Name = "acs_credential_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsCredentialId { get; set; }

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

            public AcsUserPendingMutationsUnrecognized(
                string mutationCode = default,
                string createdAt = default,
                string message = default
            )
            {
                MutationCode = mutationCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which the mutation was created.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsUserWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(typeof(AcsUserWarningsLatchResidentUser), "latch_resident_user")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserWarningsUnknownIssueWithAcsUser),
            "unknown_issue_with_acs_user"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsUserWarningsAcsUserInactive), "acs_user_inactive")]
        [JsonSubtypes.KnownSubType(
            typeof(AcsUserWarningsSaltoKsUserNotSubscribed),
            "salto_ks_user_not_subscribed"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsUserWarningsBeingDeleted), "being_deleted")]
        public abstract class AcsUserWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

        [DataContract(Name = "seamModel_acsUserWarningsAcsUserInactive_model")]
        public class AcsUserWarningsAcsUserInactive : AcsUserWarnings
        {
            [JsonConstructorAttribute]
            protected AcsUserWarningsAcsUserInactive() { }

            public AcsUserWarningsAcsUserInactive(
                string createdAt = default,
                string message = default,
                string warningCode = default
            )
            {
                CreatedAt = createdAt;
                Message = message;
                WarningCode = warningCode;
            }

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "acs_user_inactive";

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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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
                string createdAt = default,
                string message = default
            )
            {
                WarningCode = warningCode;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "warning_code", IsRequired = true, EmitDefaultValue = false)]
            public override string WarningCode { get; } = "unrecognized";

            /// <summary>
            /// Date and time at which Seam created the warning.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            /// <summary>
            /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// `starts_at` and `ends_at` timestamps for the [access system user&apos;s](https://docs.seam.co/low-level-apis/access-systems/user-management) access.
        /// </summary>
        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserAccessSchedule? AccessSchedule { get; set; }

        /// <summary>
        /// ID of the [access system](https://docs.seam.co/low-level-apis/access-systems) that contains the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsUserId { get; set; }

        /// <summary>
        /// The ID of the connected account that is associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name for the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [Obsolete("use email_address.")]
        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        /// <summary>
        /// Email address of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Errors associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsUserErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) type.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsUser.ExternalTypeEnum? ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Full name of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        /// <summary>
        /// ID of the HID access control system associated with the user.
        /// </summary>
        [DataMember(Name = "hid_acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string? HidAcsSystemId { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the access system user.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Indicates whether the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) is currently [suspended](https://docs.seam.co/low-level-apis/access-systems/user-management/suspending-and-unsuspending-users).
        /// </summary>
        [DataMember(Name = "is_suspended", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsSuspended { get; set; }

        /// <summary>
        /// Pending mutations associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management). Seam is in the process of pushing these mutations to the integrated access system.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsUserPendingMutations>? PendingMutations { get; set; }

        /// <summary>
        /// Phone number of the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) in E.164 format (for example, `+15555550100`).
        /// </summary>
        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Salto KS-specific metadata associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "salto_ks_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserSaltoKsMetadata? SaltoKsMetadata { get; set; }

        /// <summary>
        /// Salto Space-specific metadata associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "salto_space_metadata", IsRequired = false, EmitDefaultValue = false)]
        public AcsUserSaltoSpaceMetadata? SaltoSpaceMetadata { get; set; }

        /// <summary>
        /// Email address of the user identity associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(
            Name = "user_identity_email_address",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityEmailAddress { get; set; }

        /// <summary>
        /// Full name of the user identity associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "user_identity_full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityFullName { get; set; }

        /// <summary>
        /// ID of the user identity associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityId { get; set; }

        /// <summary>
        /// Phone number of the user identity associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management) in E.164 format (for example, `+15555550100`).
        /// </summary>
        [DataMember(
            Name = "user_identity_phone_number",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? UserIdentityPhoneNumber { get; set; }

        /// <summary>
        /// Warnings associated with the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsUserWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [access system user](https://docs.seam.co/low-level-apis/access-systems/user-management).
        /// </summary>
        [DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
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

        /// <summary>
        /// Date and time at which the user&apos;s access ends, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
        public string? EndsAt { get; set; }

        /// <summary>
        /// Date and time at which the user&apos;s access starts, in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
        /// </summary>
        [DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
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

    [DataContract(Name = "seamModel_acsUserSaltoKsMetadata_model")]
    public class AcsUserSaltoKsMetadata
    {
        [JsonConstructorAttribute]
        protected AcsUserSaltoKsMetadata() { }

        public AcsUserSaltoKsMetadata(bool? isSubscribed = default)
        {
            IsSubscribed = isSubscribed;
        }

        /// <summary>
        /// Indicates whether the user holds an active subscription slot on the Salto KS site. Only subscribed users can unlock doors and count against the site&apos;s user-subscription limit. A user may not be subscribed because their access schedule has not started or has ended, the site has reached its subscription limit, or they were manually unsubscribed. This is distinct from `is_suspended`, which reflects whether the user has been explicitly blocked.
        /// </summary>
        [DataMember(Name = "is_subscribed", IsRequired = false, EmitDefaultValue = false)]
        public bool? IsSubscribed { get; set; }

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

        /// <summary>
        /// Indicates whether AuditOpenings is enabled for the user in the Salto Space access system.
        /// </summary>
        [DataMember(Name = "audit_openings", IsRequired = false, EmitDefaultValue = false)]
        public bool? AuditOpenings { get; set; }

        /// <summary>
        /// User ID in the Salto Space access system.
        /// </summary>
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
