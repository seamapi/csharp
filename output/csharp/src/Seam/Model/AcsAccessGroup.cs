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
    /// Group that defines the entrances to which a set of users has access and, in some cases, the access schedule for these entrances and users.
    ///
    /// Some access control systems use [access group](https://docs.seam.co/low-level-apis/access-systems/user-management/assigning-users-to-access-groups), which are sets of users, combined with sets of permissions. These permissions include both the set of areas or assets that the users can access and the schedule during which the users can access these areas or assets. Instead of assigning access rights individually to each access control system user, which can be time-consuming and error-prone, administrators can assign users to an access group, thereby ensuring that the users inherit all the permissions associated with the access group. Using access groups streamlines the process of managing large numbers of access control system users, especially in bigger organizations or complexes.
    ///
    /// To learn whether your access control system supports access groups, see the corresponding [system integration guide](https://docs.seam.co/device-and-system-integration-guides#access-control-systems).
    /// </summary>
    [DataContract(Name = "seamModel_acsAccessGroup_model")]
    public class AcsAccessGroup
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroup() { }

        public AcsAccessGroup(
            AcsAccessGroup.AccessGroupTypeEnum accessGroupType = default,
            string accessGroupTypeDisplayName = default,
            AcsAccessGroupAccessSchedule? accessSchedule = default,
            string acsAccessGroupId = default,
            string acsSystemId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            List<AcsAccessGroupErrors> errors = default,
            AcsAccessGroup.ExternalTypeEnum externalType = default,
            string externalTypeDisplayName = default,
            bool isManaged = default,
            string name = default,
            List<AcsAccessGroupPendingMutations> pendingMutations = default,
            List<AcsAccessGroupWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AccessGroupType = accessGroupType;
            AccessGroupTypeDisplayName = accessGroupTypeDisplayName;
            AccessSchedule = accessSchedule;
            AcsAccessGroupId = acsAccessGroupId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Errors = errors;
            ExternalType = externalType;
            ExternalTypeDisplayName = externalTypeDisplayName;
            IsManaged = isManaged;
            Name = name;
            PendingMutations = pendingMutations;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum AccessGroupTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_unit")]
            PtiUnit = 1,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 2,

            [EnumMember(Value = "salto_ks_access_group")]
            SaltoKsAccessGroup = 3,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 4,

            [EnumMember(Value = "salto_space_group")]
            SaltoSpaceGroup = 5,

            [EnumMember(Value = "dormakaba_community_access_group")]
            DormakabaCommunityAccessGroup = 6,

            [EnumMember(Value = "dormakaba_ambiance_access_group")]
            DormakabaAmbianceAccessGroup = 7,

            [EnumMember(Value = "avigilon_alta_group")]
            AvigilonAltaGroup = 8,

            [EnumMember(Value = "kisi_access_group")]
            KisiAccessGroup = 9,
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsAccessGroupErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupErrorsFailedToCreateOnAcsSystem),
            "failed_to_create_on_acs_system"
        )]
        public abstract class AcsAccessGroupErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsAccessGroupErrorsFailedToCreateOnAcsSystem_model")]
        public class AcsAccessGroupErrorsFailedToCreateOnAcsSystem : AcsAccessGroupErrors
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupErrorsFailedToCreateOnAcsSystem() { }

            public AcsAccessGroupErrorsFailedToCreateOnAcsSystem(
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

        [DataContract(Name = "seamModel_acsAccessGroupErrorsUnrecognized_model")]
        public class AcsAccessGroupErrorsUnrecognized : AcsAccessGroupErrors
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupErrorsUnrecognized() { }

            public AcsAccessGroupErrorsUnrecognized(
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
        /// Brand-specific terminology for the access group type.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ExternalTypeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "pti_unit")]
            PtiUnit = 1,

            [EnumMember(Value = "pti_access_level")]
            PtiAccessLevel = 2,

            [EnumMember(Value = "salto_ks_access_group")]
            SaltoKsAccessGroup = 3,

            [EnumMember(Value = "brivo_group")]
            BrivoGroup = 4,

            [EnumMember(Value = "salto_space_group")]
            SaltoSpaceGroup = 5,

            [EnumMember(Value = "dormakaba_community_access_group")]
            DormakabaCommunityAccessGroup = 6,

            [EnumMember(Value = "dormakaba_ambiance_access_group")]
            DormakabaAmbianceAccessGroup = 7,

            [EnumMember(Value = "avigilon_alta_group")]
            AvigilonAltaGroup = 8,

            [EnumMember(Value = "kisi_access_group")]
            KisiAccessGroup = 9,
        }

        [JsonConverter(typeof(JsonSubtypes), "mutation_code")]
        [JsonSubtypes.FallBackSubType(typeof(AcsAccessGroupPendingMutationsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate),
            "deferring_user_membership_update"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsUpdatingEntranceMembership),
            "updating_entrance_membership"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsUpdatingUserMembership),
            "updating_user_membership"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsUpdatingAccessSchedule),
            "updating_access_schedule"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsUpdatingGroupInformation),
            "updating_group_information"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(AcsAccessGroupPendingMutationsDeferringDeletion),
            "deferring_deletion"
        )]
        [JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsDeleting), "deleting")]
        [JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsCreating), "creating")]
        public abstract class AcsAccessGroupPendingMutations
        {
            public abstract string MutationCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_acsAccessGroupPendingMutationsCreating_model")]
        public class AcsAccessGroupPendingMutationsCreating : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsCreating() { }

            public AcsAccessGroupPendingMutationsCreating(
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

        [DataContract(Name = "seamModel_acsAccessGroupPendingMutationsDeleting_model")]
        public class AcsAccessGroupPendingMutationsDeleting : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsDeleting() { }

            public AcsAccessGroupPendingMutationsDeleting(
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

        [DataContract(Name = "seamModel_acsAccessGroupPendingMutationsDeferringDeletion_model")]
        public class AcsAccessGroupPendingMutationsDeferringDeletion
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsDeferringDeletion() { }

            public AcsAccessGroupPendingMutationsDeferringDeletion(
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
            public override string MutationCode { get; } = "deferring_deletion";

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformation_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingGroupInformation
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingGroupInformation() { }

            public AcsAccessGroupPendingMutationsUpdatingGroupInformation(
                string createdAt = default,
                AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsAccessGroupPendingMutationsUpdatingGroupInformationTo to = default
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
            /// Old access group information.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_group_information";

            /// <summary>
            /// New access group information.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingGroupInformationTo To { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformationFrom_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom() { }

            public AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom(
                string? name = default
            )
            {
                Name = name;
            }

            /// <summary>
            /// Name of the access group.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformationTo_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingGroupInformationTo
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingGroupInformationTo() { }

            public AcsAccessGroupPendingMutationsUpdatingGroupInformationTo(string? name = default)
            {
                Name = name;
            }

            /// <summary>
            /// Name of the access group.
            /// </summary>
            [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
            public string? Name { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessSchedule_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingAccessSchedule
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingAccessSchedule() { }

            public AcsAccessGroupPendingMutationsUpdatingAccessSchedule(
                string createdAt = default,
                AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo to = default
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
            public AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom From { get; set; }

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
            public AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo To { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessScheduleFrom_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom() { }

            public AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            /// <summary>
            /// Ending time for the access schedule.
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

        [DataContract(
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessScheduleTo_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo() { }

            public AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo(
                string? endsAt = default,
                string? startsAt = default
            )
            {
                EndsAt = endsAt;
                StartsAt = startsAt;
            }

            /// <summary>
            /// Ending time for the access schedule.
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

        [DataContract(
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembership_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingUserMembership
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingUserMembership() { }

            public AcsAccessGroupPendingMutationsUpdatingUserMembership(
                string createdAt = default,
                AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsAccessGroupPendingMutationsUpdatingUserMembershipTo to = default
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
            /// Old user membership.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_user_membership";

            /// <summary>
            /// New user membership.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingUserMembershipTo To { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembershipFrom_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom() { }

            public AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom(
                string? acsUserId = default
            )
            {
                AcsUserId = acsUserId;
            }

            /// <summary>
            /// Old user ID.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembershipTo_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingUserMembershipTo
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingUserMembershipTo() { }

            public AcsAccessGroupPendingMutationsUpdatingUserMembershipTo(
                string? acsUserId = default
            )
            {
                AcsUserId = acsUserId;
            }

            /// <summary>
            /// New user ID.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsUserId { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembership_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingEntranceMembership
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingEntranceMembership() { }

            public AcsAccessGroupPendingMutationsUpdatingEntranceMembership(
                string createdAt = default,
                AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom from = default,
                string message = default,
                string mutationCode = default,
                AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo to = default
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
            /// Old entrance membership.
            /// </summary>
            [DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom From { get; set; }

            /// <summary>
            /// Detailed description of the mutation.
            /// </summary>
            [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
            public override string Message { get; set; }

            [DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
            public override string MutationCode { get; } = "updating_entrance_membership";

            /// <summary>
            /// New entrance membership.
            /// </summary>
            [DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo To { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom() { }

            public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom(
                string? acsEntranceId = default
            )
            {
                AcsEntranceId = acsEntranceId;
            }

            /// <summary>
            /// Old entrance ID.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembershipTo_model"
        )]
        public class AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo() { }

            public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo(
                string? acsEntranceId = default
            )
            {
                AcsEntranceId = acsEntranceId;
            }

            /// <summary>
            /// New entrance ID.
            /// </summary>
            [DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
            public string? AcsEntranceId { get; set; }

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
            Name = "seamModel_acsAccessGroupPendingMutationsDeferringUserMembershipUpdate_model"
        )]
        public class AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate
            : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate() { }

            public AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate(
                string acsUserId = default,
                string createdAt = default,
                string message = default,
                string mutationCode = default,
                AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum variant =
                    default
            )
            {
                AcsUserId = acsUserId;
                CreatedAt = createdAt;
                Message = message;
                MutationCode = mutationCode;
                Variant = variant;
            }

            /// <summary>
            /// Whether the user is scheduled to be added to or removed from this access group.
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
            /// ID of the user involved in the scheduled change.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public string AcsUserId { get; set; }

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
            public override string MutationCode { get; } = "deferring_user_membership_update";

            /// <summary>
            /// Whether the user is scheduled to be added to or removed from this access group.
            /// </summary>
            [DataMember(Name = "variant", IsRequired = false, EmitDefaultValue = false)]
            public AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum Variant { get; set; }

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

        [DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUnrecognized_model")]
        public class AcsAccessGroupPendingMutationsUnrecognized : AcsAccessGroupPendingMutations
        {
            [JsonConstructorAttribute]
            protected AcsAccessGroupPendingMutationsUnrecognized() { }

            public AcsAccessGroupPendingMutationsUnrecognized(
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

        [Obsolete("Use `external_type`.")]
        [DataMember(Name = "access_group_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsAccessGroup.AccessGroupTypeEnum AccessGroupType { get; set; }

        [Obsolete("Use `external_type_display_name`.")]
        [DataMember(
            Name = "access_group_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string AccessGroupTypeDisplayName { get; set; }

        /// <summary>
        /// `starts_at` and `ends_at` timestamps for the access group&apos;s access.
        /// </summary>
        [DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
        public AcsAccessGroupAccessSchedule? AccessSchedule { get; set; }

        /// <summary>
        /// ID of the access group.
        /// </summary>
        [DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsAccessGroupId { get; set; }

        /// <summary>
        /// ID of the access control system that contains the access group.
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account that contains the access group.
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the access group was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name for the access group.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Errors associated with the `acs_access_group`.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsAccessGroupErrors> Errors { get; set; }

        /// <summary>
        /// Brand-specific terminology for the access group type.
        /// </summary>
        [DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
        public AcsAccessGroup.ExternalTypeEnum ExternalType { get; set; }

        /// <summary>
        /// Display name that corresponds to the brand-specific terminology for the access group type.
        /// </summary>
        [DataMember(
            Name = "external_type_display_name",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string ExternalTypeDisplayName { get; set; }

        /// <summary>
        /// Indicates whether Seam manages the access group.
        /// </summary>
        [DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
        public bool IsManaged { get; set; }

        /// <summary>
        /// Name of the access group.
        /// </summary>
        [DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Collection of pending mutations for the access group. Represents operations that have been requested but not yet completed on the integrated access system.
        /// </summary>
        [DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsAccessGroupPendingMutations> PendingMutations { get; set; }

        /// <summary>
        /// Warnings associated with the `acs_access_group`.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsAccessGroupWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the access group.
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

    [DataContract(Name = "seamModel_acsAccessGroupAccessSchedule_model")]
    public class AcsAccessGroupAccessSchedule
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroupAccessSchedule() { }

        public AcsAccessGroupAccessSchedule(string? endsAt = default, string startsAt = default)
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

    [DataContract(Name = "seamModel_acsAccessGroupWarnings_model")]
    public class AcsAccessGroupWarnings
    {
        [JsonConstructorAttribute]
        protected AcsAccessGroupWarnings() { }

        public AcsAccessGroupWarnings(
            string createdAt = default,
            string message = default,
            AcsAccessGroupWarnings.WarningCodeEnum warningCode = default
        )
        {
            CreatedAt = createdAt;
            Message = message;
            WarningCode = warningCode;
        }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum WarningCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "unknown_issue_with_acs_access_group")]
            UnknownIssueWithAcsAccessGroup = 1,

            [EnumMember(Value = "being_deleted")]
            BeingDeleted = 2,
        }

        /// <summary>
        /// Date and time at which Seam created the warning.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Detailed description of the warning. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier of the type of warning. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
        public AcsAccessGroupWarnings.WarningCodeEnum WarningCode { get; set; }

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
