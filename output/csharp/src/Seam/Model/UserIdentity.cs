using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_userIdentity_model")]
    public class UserIdentity
    {
        [JsonConstructorAttribute]
        protected UserIdentity() { }

        public UserIdentity(
            string createdAt = default,
            string displayName = default,
            string? emailAddress = default,
            List<UserIdentityErrors> errors = default,
            string? fullName = default,
            string? phoneNumber = default,
            string userIdentityId = default,
            string? userIdentityKey = default,
            List<UserIdentityWarnings> warnings = default,
            string workspaceId = default
        )
        {
            CreatedAt = createdAt;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            Errors = errors;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            UserIdentityId = userIdentityId;
            UserIdentityKey = userIdentityKey;
            Warnings = warnings;
            WorkspaceId = workspaceId;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(UserIdentityErrorsIssueWithAcsUser),
            "issue_with_acs_user"
        )]
        public abstract class UserIdentityErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string AcsSystemId { get; set; }

            public abstract string AcsUserId { get; set; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_userIdentityErrorsIssueWithAcsUser_model")]
        public class UserIdentityErrorsIssueWithAcsUser : UserIdentityErrors
        {
            [JsonConstructorAttribute]
            protected UserIdentityErrorsIssueWithAcsUser() { }

            public UserIdentityErrorsIssueWithAcsUser(
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

            [DataMember(Name = "acs_system_id", IsRequired = true, EmitDefaultValue = false)]
            public override string AcsSystemId { get; set; }

            [DataMember(Name = "acs_user_id", IsRequired = true, EmitDefaultValue = false)]
            public override string AcsUserId { get; set; }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public override string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "issue_with_acs_user";

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

        [JsonConverter(typeof(JsonSubtypes), "warning_code")]
        [JsonSubtypes.KnownSubType(typeof(UserIdentityWarningsBeingDeleted), "being_deleted")]
        public abstract class UserIdentityWarnings
        {
            public abstract string WarningCode { get; }

            public abstract string CreatedAt { get; set; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_userIdentityWarningsBeingDeleted_model")]
        public class UserIdentityWarningsBeingDeleted : UserIdentityWarnings
        {
            [JsonConstructorAttribute]
            protected UserIdentityWarningsBeingDeleted() { }

            public UserIdentityWarningsBeingDeleted(
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

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "display_name", IsRequired = true, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        [DataMember(Name = "email_address", IsRequired = false, EmitDefaultValue = false)]
        public string? EmailAddress { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<UserIdentityErrors> Errors { get; set; }

        [DataMember(Name = "full_name", IsRequired = false, EmitDefaultValue = false)]
        public string? FullName { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false, EmitDefaultValue = false)]
        public string? PhoneNumber { get; set; }

        [DataMember(Name = "user_identity_id", IsRequired = true, EmitDefaultValue = false)]
        public string UserIdentityId { get; set; }

        [DataMember(Name = "user_identity_key", IsRequired = false, EmitDefaultValue = false)]
        public string? UserIdentityKey { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<UserIdentityWarnings> Warnings { get; set; }

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
}
