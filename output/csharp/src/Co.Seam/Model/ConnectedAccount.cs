using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;

namespace Co.Seam.Model
{
    [DataContract(Name = "coSeamModel_connectedAccount_model")]
    public class ConnectedAccount
    {
        [JsonConstructorAttribute]
        protected ConnectedAccount() { }

        public ConnectedAccount(
            string? connectedAccountId = default,
            string? createdAt = default,
            ConnectedAccountUserIdentifier? userIdentifier = default,
            string? accountType = default,
            string accountTypeDisplayName = default,
            Object errors = default,
            Object warnings = default,
            object? customMetadata = default
        )
        {
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            UserIdentifier = userIdentifier;
            AccountType = accountType;
            AccountTypeDisplayName = accountTypeDisplayName;
            Errors = errors;
            Warnings = warnings;
            CustomMetadata = customMetadata;
        }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "user_identifier", IsRequired = false, EmitDefaultValue = false)]
        public ConnectedAccountUserIdentifier? UserIdentifier { get; set; }

        [DataMember(Name = "account_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccountType { get; set; }

        [DataMember(
            Name = "account_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AccountTypeDisplayName { get; set; }

        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public Object Errors { get; set; }

        [DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
        public Object Warnings { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = false, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }
    }

    [DataContract(Name = "coSeamModel_connectedAccountUserIdentifier_model")]
    public class ConnectedAccountUserIdentifier
    {
        [JsonConstructorAttribute]
        protected ConnectedAccountUserIdentifier() { }

        public ConnectedAccountUserIdentifier(
            string? username = default,
            string? apiUrl = default,
            string? email = default,
            string? phone = default,
            bool? exclusive = default
        )
        {
            Username = username;
            ApiUrl = apiUrl;
            Email = email;
            Phone = phone;
            Exclusive = exclusive;
        }

        [DataMember(Name = "username", IsRequired = false, EmitDefaultValue = false)]
        public string? Username { get; set; }

        [DataMember(Name = "api_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ApiUrl { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
        public string? Phone { get; set; }

        [DataMember(Name = "exclusive", IsRequired = false, EmitDefaultValue = false)]
        public bool? Exclusive { get; set; }
    }
}
