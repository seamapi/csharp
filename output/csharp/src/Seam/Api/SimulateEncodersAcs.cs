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
    public class SimulateEncodersAcs
    {
        private ISeamClient _seam;

        public SimulateEncodersAcs(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "nextCredentialEncodeWillFailRequest_request")]
        public class NextCredentialEncodeWillFailRequest
        {
            [JsonConstructorAttribute]
            protected NextCredentialEncodeWillFailRequest() { }

            public NextCredentialEncodeWillFailRequest(
                string acsEncoderId = default,
                NextCredentialEncodeWillFailRequest.ErrorCodeEnum? errorCode = default,
                string? acsCredentialId = default
            )
            {
                AcsEncoderId = acsEncoderId;
                ErrorCode = errorCode;
                AcsCredentialId = acsCredentialId;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ErrorCodeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "uncategorized_error")]
                UncategorizedError = 1,

                [EnumMember(Value = "action_attempt_expired")]
                ActionAttemptExpired = 2
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
            public NextCredentialEncodeWillFailRequest.ErrorCodeEnum? ErrorCode { get; set; }

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

        public void NextCredentialEncodeWillFail(NextCredentialEncodeWillFailRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>(
                "/acs/encoders/simulate/next_credential_encode_will_fail",
                requestOptions
            );
        }

        public void NextCredentialEncodeWillFail(
            string acsEncoderId = default,
            NextCredentialEncodeWillFailRequest.ErrorCodeEnum? errorCode = default,
            string? acsCredentialId = default
        )
        {
            NextCredentialEncodeWillFail(
                new NextCredentialEncodeWillFailRequest(
                    acsEncoderId: acsEncoderId,
                    errorCode: errorCode,
                    acsCredentialId: acsCredentialId
                )
            );
        }

        public async Task NextCredentialEncodeWillFailAsync(
            NextCredentialEncodeWillFailRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/encoders/simulate/next_credential_encode_will_fail",
                requestOptions
            );
        }

        public async Task NextCredentialEncodeWillFailAsync(
            string acsEncoderId = default,
            NextCredentialEncodeWillFailRequest.ErrorCodeEnum? errorCode = default,
            string? acsCredentialId = default
        )
        {
            await NextCredentialEncodeWillFailAsync(
                new NextCredentialEncodeWillFailRequest(
                    acsEncoderId: acsEncoderId,
                    errorCode: errorCode,
                    acsCredentialId: acsCredentialId
                )
            );
        }

        [DataContract(Name = "nextCredentialEncodeWillSucceedRequest_request")]
        public class NextCredentialEncodeWillSucceedRequest
        {
            [JsonConstructorAttribute]
            protected NextCredentialEncodeWillSucceedRequest() { }

            public NextCredentialEncodeWillSucceedRequest(
                string acsEncoderId = default,
                NextCredentialEncodeWillSucceedRequest.ScenarioEnum? scenario = default
            )
            {
                AcsEncoderId = acsEncoderId;
                Scenario = scenario;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ScenarioEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "credential_is_issued")]
                CredentialIsIssued = 1
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            [DataMember(Name = "scenario", IsRequired = false, EmitDefaultValue = false)]
            public NextCredentialEncodeWillSucceedRequest.ScenarioEnum? Scenario { get; set; }

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

        public void NextCredentialEncodeWillSucceed(NextCredentialEncodeWillSucceedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>(
                "/acs/encoders/simulate/next_credential_encode_will_succeed",
                requestOptions
            );
        }

        public void NextCredentialEncodeWillSucceed(
            string acsEncoderId = default,
            NextCredentialEncodeWillSucceedRequest.ScenarioEnum? scenario = default
        )
        {
            NextCredentialEncodeWillSucceed(
                new NextCredentialEncodeWillSucceedRequest(
                    acsEncoderId: acsEncoderId,
                    scenario: scenario
                )
            );
        }

        public async Task NextCredentialEncodeWillSucceedAsync(
            NextCredentialEncodeWillSucceedRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/encoders/simulate/next_credential_encode_will_succeed",
                requestOptions
            );
        }

        public async Task NextCredentialEncodeWillSucceedAsync(
            string acsEncoderId = default,
            NextCredentialEncodeWillSucceedRequest.ScenarioEnum? scenario = default
        )
        {
            await NextCredentialEncodeWillSucceedAsync(
                new NextCredentialEncodeWillSucceedRequest(
                    acsEncoderId: acsEncoderId,
                    scenario: scenario
                )
            );
        }

        [DataContract(Name = "nextCredentialScanWillFailRequest_request")]
        public class NextCredentialScanWillFailRequest
        {
            [JsonConstructorAttribute]
            protected NextCredentialScanWillFailRequest() { }

            public NextCredentialScanWillFailRequest(
                string acsEncoderId = default,
                NextCredentialScanWillFailRequest.ErrorCodeEnum? errorCode = default,
                string? acsCredentialIdOnSeam = default
            )
            {
                AcsEncoderId = acsEncoderId;
                ErrorCode = errorCode;
                AcsCredentialIdOnSeam = acsCredentialIdOnSeam;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ErrorCodeEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "uncategorized_error")]
                UncategorizedError = 1,

                [EnumMember(Value = "action_attempt_expired")]
                ActionAttemptExpired = 2
            }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            [DataMember(Name = "error_code", IsRequired = false, EmitDefaultValue = false)]
            public NextCredentialScanWillFailRequest.ErrorCodeEnum? ErrorCode { get; set; }

            [DataMember(
                Name = "acs_credential_id_on_seam",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? AcsCredentialIdOnSeam { get; set; }

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

        public void NextCredentialScanWillFail(NextCredentialScanWillFailRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>(
                "/acs/encoders/simulate/next_credential_scan_will_fail",
                requestOptions
            );
        }

        public void NextCredentialScanWillFail(
            string acsEncoderId = default,
            NextCredentialScanWillFailRequest.ErrorCodeEnum? errorCode = default,
            string? acsCredentialIdOnSeam = default
        )
        {
            NextCredentialScanWillFail(
                new NextCredentialScanWillFailRequest(
                    acsEncoderId: acsEncoderId,
                    errorCode: errorCode,
                    acsCredentialIdOnSeam: acsCredentialIdOnSeam
                )
            );
        }

        public async Task NextCredentialScanWillFailAsync(NextCredentialScanWillFailRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/encoders/simulate/next_credential_scan_will_fail",
                requestOptions
            );
        }

        public async Task NextCredentialScanWillFailAsync(
            string acsEncoderId = default,
            NextCredentialScanWillFailRequest.ErrorCodeEnum? errorCode = default,
            string? acsCredentialIdOnSeam = default
        )
        {
            await NextCredentialScanWillFailAsync(
                new NextCredentialScanWillFailRequest(
                    acsEncoderId: acsEncoderId,
                    errorCode: errorCode,
                    acsCredentialIdOnSeam: acsCredentialIdOnSeam
                )
            );
        }

        [DataContract(Name = "nextCredentialScanWillSucceedRequest_request")]
        public class NextCredentialScanWillSucceedRequest
        {
            [JsonConstructorAttribute]
            protected NextCredentialScanWillSucceedRequest() { }

            public NextCredentialScanWillSucceedRequest(
                string? acsCredentialIdOnSeam = default,
                string acsEncoderId = default,
                NextCredentialScanWillSucceedRequest.ScenarioEnum? scenario = default
            )
            {
                AcsCredentialIdOnSeam = acsCredentialIdOnSeam;
                AcsEncoderId = acsEncoderId;
                Scenario = scenario;
            }

            [JsonConverter(typeof(SafeStringEnumConverter))]
            public enum ScenarioEnum
            {
                [EnumMember(Value = "unrecognized")]
                Unrecognized = 0,

                [EnumMember(Value = "credential_on_encoder_is_empty")]
                CredentialOnEncoderIsEmpty = 1
            }

            [DataMember(
                Name = "acs_credential_id_on_seam",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public string? AcsCredentialIdOnSeam { get; set; }

            [DataMember(Name = "acs_encoder_id", IsRequired = true, EmitDefaultValue = false)]
            public string AcsEncoderId { get; set; }

            [DataMember(Name = "scenario", IsRequired = false, EmitDefaultValue = false)]
            public NextCredentialScanWillSucceedRequest.ScenarioEnum? Scenario { get; set; }

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

        public void NextCredentialScanWillSucceed(NextCredentialScanWillSucceedRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>(
                "/acs/encoders/simulate/next_credential_scan_will_succeed",
                requestOptions
            );
        }

        public void NextCredentialScanWillSucceed(
            string? acsCredentialIdOnSeam = default,
            string acsEncoderId = default,
            NextCredentialScanWillSucceedRequest.ScenarioEnum? scenario = default
        )
        {
            NextCredentialScanWillSucceed(
                new NextCredentialScanWillSucceedRequest(
                    acsCredentialIdOnSeam: acsCredentialIdOnSeam,
                    acsEncoderId: acsEncoderId,
                    scenario: scenario
                )
            );
        }

        public async Task NextCredentialScanWillSucceedAsync(
            NextCredentialScanWillSucceedRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/acs/encoders/simulate/next_credential_scan_will_succeed",
                requestOptions
            );
        }

        public async Task NextCredentialScanWillSucceedAsync(
            string? acsCredentialIdOnSeam = default,
            string acsEncoderId = default,
            NextCredentialScanWillSucceedRequest.ScenarioEnum? scenario = default
        )
        {
            await NextCredentialScanWillSucceedAsync(
                new NextCredentialScanWillSucceedRequest(
                    acsCredentialIdOnSeam: acsCredentialIdOnSeam,
                    acsEncoderId: acsEncoderId,
                    scenario: scenario
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateEncodersAcs SimulateEncodersAcs => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateEncodersAcs SimulateEncodersAcs { get; }
    }
}
