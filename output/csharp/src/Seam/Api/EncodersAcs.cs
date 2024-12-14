using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class EncodersAcs
    {
        private ISeamClient _seam;

        public EncodersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "encodeCredentialRequest_request")]
        public class EncodeCredentialRequest
        {
            [JsonConstructorAttribute]
            protected EncodeCredentialRequest() { }

            public EncodeCredentialRequest(
                string acsCredentialId = default,
                string acsEncoderId = default
            )
            {
                AcsCredentialId = acsCredentialId;
                AcsEncoderId = acsEncoderId;
            }

            [DataMember(Name = "acs_credential_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsCredentialId { get; set; }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

        [DataContract(Name = "encodeCredentialResponse_response")]
        public class EncodeCredentialResponse
        {
            [JsonConstructorAttribute]
            protected EncodeCredentialResponse() { }

            public EncodeCredentialResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt EncodeCredential(EncodeCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<EncodeCredentialResponse>("/acs/encoders/encode_credential", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt EncodeCredential(
            string acsCredentialId = default,
            string acsEncoderId = default
        )
        {
            return EncodeCredential(
                new EncodeCredentialRequest(
                    acsCredentialId: acsCredentialId,
                    acsEncoderId: acsEncoderId
                )
            );
        }

        public async Task<ActionAttempt> EncodeCredentialAsync(EncodeCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<EncodeCredentialResponse>(
                    "/acs/encoders/encode_credential",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> EncodeCredentialAsync(
            string acsCredentialId = default,
            string acsEncoderId = default
        )
        {
            return (
                await EncodeCredentialAsync(
                    new EncodeCredentialRequest(
                        acsCredentialId: acsCredentialId,
                        acsEncoderId: acsEncoderId
                    )
                )
            );
        }

        [DataContract(Name = "scanCredentialRequest_request")]
        public class ScanCredentialRequest
        {
            [JsonConstructorAttribute]
            protected ScanCredentialRequest() { }

            public ScanCredentialRequest(string acsEncoderId = default)
            {
                AcsEncoderId = acsEncoderId;
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

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

        [DataContract(Name = "scanCredentialResponse_response")]
        public class ScanCredentialResponse
        {
            [JsonConstructorAttribute]
            protected ScanCredentialResponse() { }

            public ScanCredentialResponse(ActionAttempt actionAttempt = default)
            {
                ActionAttempt = actionAttempt;
            }

            [DataMember(Name = "action_attempt", IsRequired = false, EmitDefaultValue = false)]
            public ActionAttempt ActionAttempt { get; set; }

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

        public ActionAttempt ScanCredential(ScanCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ScanCredentialResponse>("/acs/encoders/scan_credential", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt ScanCredential(string acsEncoderId = default)
        {
            return ScanCredential(new ScanCredentialRequest(acsEncoderId: acsEncoderId));
        }

        public async Task<ActionAttempt> ScanCredentialAsync(ScanCredentialRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ScanCredentialResponse>(
                    "/acs/encoders/scan_credential",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ScanCredentialAsync(string acsEncoderId = default)
        {
            return (
                await ScanCredentialAsync(new ScanCredentialRequest(acsEncoderId: acsEncoderId))
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.EncodersAcs EncodersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.EncodersAcs EncodersAcs { get; }
    }
}
