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
    /// Represents a hardware device that encodes [credential](https://docs.seam.co/low-level-apis/access-systems/managing-credentials) data onto physical cards within an [access control system](https://docs.seam.co/low-level-apis/access-systems).
    ///
    /// Some access control systems require credentials to be encoded onto plastic key cards using a card encoder. This process involves the following two key steps:
    ///
    /// 1. Credential creation
    ///    Configure the access parameters for the credential.
    /// 2. Card encoding
    ///    Write the credential data onto the card using a compatible card encoder.
    ///
    /// Separately, the Seam API also supports card scanning, which enables you to scan and read the encoded data on a card. You can use this action to confirm consistency with access control system records or diagnose discrepancies if needed.
    ///
    /// See [Working with Card Encoders and Scanners](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
    ///
    /// To verify if your access control system requires a card encoder, see the corresponding [system integration guide](https://docs.seam.co/device-and-system-integration-guides#access-control-systems).
    /// </summary>
    [DataContract(Name = "seamModel_acsEncoder_model")]
    public class AcsEncoder
    {
        [JsonConstructorAttribute]
        protected AcsEncoder() { }

        public AcsEncoder(
            string acsEncoderId = default,
            string acsSystemId = default,
            string connectedAccountId = default,
            string createdAt = default,
            string displayName = default,
            List<AcsEncoderErrors> errors = default,
            string workspaceId = default
        )
        {
            AcsEncoderId = acsEncoderId;
            AcsSystemId = acsSystemId;
            ConnectedAccountId = connectedAccountId;
            CreatedAt = createdAt;
            DisplayName = displayName;
            Errors = errors;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// ID of the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        [DataMember(Name = "acs_encoder_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsEncoderId { get; set; }

        /// <summary>
        /// ID of the [access control system](https://docs.seam.co/low-level-apis/access-systems) that contains the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        [DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
        public string AcsSystemId { get; set; }

        /// <summary>
        /// ID of the connected account that contains the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        [DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
        public string ConnectedAccountId { get; set; }

        /// <summary>
        /// Date and time at which the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners) was created.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Display name for the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        [DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Errors associated with the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
        /// </summary>
        [DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
        public List<AcsEncoderErrors> Errors { get; set; }

        /// <summary>
        /// ID of the workspace that contains the [encoder](https://docs.seam.co/low-level-apis/access-systems/working-with-card-encoders-and-scanners).
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

    [DataContract(Name = "seamModel_acsEncoderErrors_model")]
    public class AcsEncoderErrors
    {
        [JsonConstructorAttribute]
        protected AcsEncoderErrors() { }

        public AcsEncoderErrors(
            string createdAt = default,
            AcsEncoderErrors.ErrorCodeEnum errorCode = default,
            string message = default
        )
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [JsonConverter(typeof(SafeStringEnumConverter))]
        public enum ErrorCodeEnum
        {
            [EnumMember(Value = "unrecognized")]
            Unrecognized = 0,

            [EnumMember(Value = "acs_encoder_removed")]
            AcsEncoderRemoved = 1,
        }

        /// <summary>
        /// Date and time at which Seam created the error.
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the type of error. Enables quick recognition and categorization of the issue.
        /// </summary>
        [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
        public AcsEncoderErrors.ErrorCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// Detailed description of the error. Provides insights into the issue and potentially how to rectify it.
        /// </summary>
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
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
}
