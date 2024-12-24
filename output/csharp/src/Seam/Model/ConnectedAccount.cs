using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_connectedAccount_model")]
    public class ConnectedAccount
    {
        [JsonConstructorAttribute]
        protected ConnectedAccount() { }

        public ConnectedAccount(
            string? accountType = default,
            string accountTypeDisplayName = default,
            bool automaticallyManageNewDevices = default,
            string? connectedAccountId = default,
            string? createdAt = default,
            object? customMetadata = default,
            List<ConnectedAccountErrors> errors = default,
            ConnectedAccountUserIdentifier? userIdentifier = default,
            List<JObject> warnings = default
        )
        {
            AccountType = accountType;
            AccountTypeDisplayName = accountTypeDisplayName;
            AutomaticallyManageNewDevices = automaticallyManageNewDevices;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            CustomMetadata = customMetadata;
            Errors = errors;
            UserIdentifier = userIdentifier;
            Warnings = warnings;
        }

        [DataMember(Name = "account_type", IsRequired = false, EmitDefaultValue = false)]
        public string? AccountType { get; set; }

        [DataMember(
            Name = "account_type_display_name",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string AccountTypeDisplayName { get; set; }

        [DataMember(
            Name = "automatically_manage_new_devices",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool AutomaticallyManageNewDevices { get; set; }

        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string? ConnectedAccountId { get; set; }

        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string? CreatedAt { get; set; }

        [DataMember(Name = "custom_metadata", IsRequired = true, EmitDefaultValue = false)]
        public object? CustomMetadata { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<ConnectedAccountErrors> Errors { get; set; }

        [DataMember(Name = "user_identifier", IsRequired = false, EmitDefaultValue = false)]
        public ConnectedAccountUserIdentifier? UserIdentifier { get; set; }

        [DataMember(Name = "warnings", IsRequired = true, EmitDefaultValue = false)]
        public List<JObject> Warnings { get; set; }

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

    [DataContract(Name = "seamModel_connectedAccountErrors_model")]
    public class ConnectedAccountErrors
    {
        [JsonConstructorAttribute]
        protected ConnectedAccountErrors() { }

        public ConnectedAccountErrors(
            string errorCode = default,
            bool isConnectedAccountError = default,
            string message = default
        )
        {
            ErrorCode = errorCode;
            IsConnectedAccountError = isConnectedAccountError;
            Message = message;
        }

        [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
        public string ErrorCode { get; set; }

        [DataMember(
            Name = "is_connected_account_error",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public bool IsConnectedAccountError { get; set; }

        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = false)]
        public string Message { get; set; }

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

    [DataContract(Name = "seamModel_connectedAccountUserIdentifier_model")]
    public class ConnectedAccountUserIdentifier
    {
        [JsonConstructorAttribute]
        protected ConnectedAccountUserIdentifier() { }

        public ConnectedAccountUserIdentifier(
            string? apiUrl = default,
            string? email = default,
            bool? exclusive = default,
            string? phone = default,
            string? username = default
        )
        {
            ApiUrl = apiUrl;
            Email = email;
            Exclusive = exclusive;
            Phone = phone;
            Username = username;
        }

        [DataMember(Name = "api_url", IsRequired = false, EmitDefaultValue = false)]
        public string? ApiUrl { get; set; }

        [DataMember(Name = "email", IsRequired = false, EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(Name = "exclusive", IsRequired = false, EmitDefaultValue = false)]
        public bool? Exclusive { get; set; }

        [DataMember(Name = "phone", IsRequired = false, EmitDefaultValue = false)]
        public string? Phone { get; set; }

        [DataMember(Name = "username", IsRequired = false, EmitDefaultValue = false)]
        public string? Username { get; set; }

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
