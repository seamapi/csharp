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
    /// Represents an unmanaged user identity. Unmanaged user identities do not have keys.
    /// </summary>
    [DataContract(Name = "seamModel_unmanagedUserIdentity_model")]
    public class UnmanagedUserIdentity
    {
        [JsonConstructorAttribute]
        protected UnmanagedUserIdentity() { }

        public UnmanagedUserIdentity(
            List<string> acsUserIds = default,
            string createdAt = default,
            string displayName = default,
            string? emailAddress = default,
            List<UnmanagedUserIdentityErrors> errors = default,
            string? fullName = default,
            List<string> mergedUserIdentityIds = default,
            List<string> mergedUserIdentityKeys = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            List<UnmanagedUserIdentityWarnings> warnings = default,
            string workspaceId = default
        )
        {
            AcsUserIds = acsUserIds;
            CreatedAt = createdAt;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            Errors = errors;
            FullName = fullName;
            MergedUserIdentityIds = mergedUserIdentityIds;
            MergedUserIdentityKeys = mergedUserIdentityKeys;
            PhoneNumber = phoneNumber;
            UserIdentityId = userIdentityId;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedUserIdentityErrorsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedUserIdentityErrorsIssueWithAcsUser),
            "issue_with_acs_user"
        )]
        public abstract class UnmanagedUserIdentityErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string AcsSystemId { get; set; }

            public abstract string AcsUserId { get; set; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedUserIdentityErrorsIssueWithAcsUser_model")]
        public class UnmanagedUserIdentityErrorsIssueWithAcsUser : UnmanagedUserIdentityErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedUserIdentityErrorsIssueWithAcsUser() { }

            public UnmanagedUserIdentityErrorsIssueWithAcsUser(
                string acsSystemId = default,
                string acsUserId = default,
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            /// <summary>
            /// ID of the access system that the user identity is associated with.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public override string AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that has an issue.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public override string AcsUserId { get; set; }

            /// <summary>
            /// Date and time at which Seam created the error.
            /// </summary>
            [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "issue_with_acs_user";

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

        [DataContract(Name = "seamModel_unmanagedUserIdentityErrorsUnrecognized_model")]
        public class UnmanagedUserIdentityErrorsUnrecognized : UnmanagedUserIdentityErrors
        {
            [JsonConstructorAttribute]
            protected UnmanagedUserIdentityErrorsUnrecognized() { }

            public UnmanagedUserIdentityErrorsUnrecognized(
                string errorCode = default,
                string acsSystemId = default,
                string acsUserId = default,
                string createdAt = default,
                string message = default
            )
            {
                ErrorCode = errorCode;
                AcsSystemId = acsSystemId;
                AcsUserId = acsUserId;
                CreatedAt = createdAt;
                Message = message;
            }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "unrecognized";

            /// <summary>
            /// ID of the access system that the user identity is associated with.
            /// </summary>
            [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
            public override string AcsSystemId { get; set; }

            /// <summary>
            /// ID of the access system user that has an issue.
            /// </summary>
            [DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
            public override string AcsUserId { get; set; }

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.FallBackSubType(typeof(UnmanagedUserIdentityWarningsUnrecognized))]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity),
            "acs_user_profile_does_not_match_user_identity"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(UnmanagedUserIdentityWarningsBeingDeleted),
            "being_deleted"
        )]
        public abstract class UnmanagedUserIdentityWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_unmanagedUserIdentityWarningsBeingDeleted_model")]
        public class UnmanagedUserIdentityWarningsBeingDeleted : UnmanagedUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedUserIdentityWarningsBeingDeleted() { }

            public UnmanagedUserIdentityWarningsBeingDeleted(
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

        [DataContract(
            Name = "seamModel_unmanagedUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity_model"
        )]
        public class UnmanagedUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity
            : UnmanagedUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity() { }

            public UnmanagedUserIdentityWarningsAcsUserProfileDoesNotMatchUserIdentity(
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
            public override string WarningCode { get; } =
                "acs_user_profile_does_not_match_user_identity";

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

        [DataContract(Name = "seamModel_unmanagedUserIdentityWarningsUnrecognized_model")]
        public class UnmanagedUserIdentityWarningsUnrecognized : UnmanagedUserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected UnmanagedUserIdentityWarningsUnrecognized() { }

            public UnmanagedUserIdentityWarningsUnrecognized(
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
        /// Array of access system user IDs associated with the user identity.
        /// </summary>
        [DataMember(Name = "acs_user_ids", IsRequired = false, EmitDefaultValue = false)]
        public List<string> AcsUserIds { get; set; }

        /// <summary>
        /// Date and time at which the user identity was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name for the user identity.
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Unique email address for the user identity.
        /// </summary>
        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Array of errors associated with the user identity. Each error object within the array contains fields like &quot;error_code&quot; and &quot;message.&quot; &quot;error_code&quot; is a string that uniquely identifies the type of error, enabling quick recognition and categorization of the issue. &quot;message&quot; provides a more detailed description of the error, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedUserIdentityErrors> Errors { get; set; }

        /// <summary>
        /// Full name of the user associated with the user identity.
        /// </summary>
        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        /// <summary>
        /// IDs that other user identities used to have before they were merged into this user identity. Looking up any of them returns this user identity.
        /// </summary>
        [DataMember(
            Name = "merged_user_identity_ids",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string> MergedUserIdentityIds { get; set; }

        /// <summary>
        /// Keys that other user identities used to have before they were merged into this user identity. Looking up any of them returns this user identity.
        /// </summary>
        [DataMember(
            Name = "merged_user_identity_keys",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public List<string> MergedUserIdentityKeys { get; set; }

        /// <summary>
        /// Unique phone number for the user identity in [E.164 format](https://www.itu.int/rec/T-REC-E.164/en) (for example, +15555550100).
        /// </summary>
        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// ID of the user identity.
        /// </summary>
        [DataMember(Name = "user_identity_id", IsRequired = false, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        /// <summary>
        /// Array of warnings associated with the user identity. Each warning object within the array contains two fields: &quot;warning_code&quot; and &quot;message.&quot; &quot;warning_code&quot; is a string that uniquely identifies the type of warning, enabling quick recognition and categorization of the issue. &quot;message&quot; provides a more detailed description of the warning, offering insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public List<UnmanagedUserIdentityWarnings> Warnings { get; set; }

        /// <summary>
        /// ID of the workspace that contains the user identity.
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
}
