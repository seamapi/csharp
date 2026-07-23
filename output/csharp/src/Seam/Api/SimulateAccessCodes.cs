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
    public class SimulateAccessCodes
    {
        private ISeamClient _seam;

        public SimulateAccessCodes(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "createUnmanagedAccessCodeRequest_request")]
        public class CreateUnmanagedAccessCodeRequest
        {
            [JsonConstructorAttribute]
            protected CreateUnmanagedAccessCodeRequest() { }

            public CreateUnmanagedAccessCodeRequest(
                string code = default,
                string deviceId = default,
                string name = default
            )
            {
                Code = code;
                DeviceId = deviceId;
                Name = name;
            }

            [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
            public string Code { get; set; }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
            public string Name { get; set; }

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

        [DataContract(Name = "createUnmanagedAccessCodeResponse_response")]
        public class CreateUnmanagedAccessCodeResponse
        {
            [JsonConstructorAttribute]
            protected CreateUnmanagedAccessCodeResponse() { }

            public CreateUnmanagedAccessCodeResponse(UnmanagedAccessCode accessCode = default)
            {
                AccessCode = accessCode;
            }

            [DataMember(Name = "access_code", IsRequired = false, EmitDefaultValue = false)]
            public UnmanagedAccessCode AccessCode { get; set; }

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

        public UnmanagedAccessCode CreateUnmanagedAccessCode(
            CreateUnmanagedAccessCodeRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<CreateUnmanagedAccessCodeResponse>(
                    "/access_codes/simulate/create_unmanaged_access_code",
                    requestOptions
                )
                .Data.AccessCode;
        }

        public UnmanagedAccessCode CreateUnmanagedAccessCode(
            string code = default,
            string deviceId = default,
            string name = default
        )
        {
            return CreateUnmanagedAccessCode(
                new CreateUnmanagedAccessCodeRequest(code: code, deviceId: deviceId, name: name)
            );
        }

        public async Task<UnmanagedAccessCode> CreateUnmanagedAccessCodeAsync(
            CreateUnmanagedAccessCodeRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<CreateUnmanagedAccessCodeResponse>(
                    "/access_codes/simulate/create_unmanaged_access_code",
                    requestOptions
                )
            )
                .Data
                .AccessCode;
        }

        public async Task<UnmanagedAccessCode> CreateUnmanagedAccessCodeAsync(
            string code = default,
            string deviceId = default,
            string name = default
        )
        {
            return (
                await CreateUnmanagedAccessCodeAsync(
                    new CreateUnmanagedAccessCodeRequest(code: code, deviceId: deviceId, name: name)
                )
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateAccessCodes SimulateAccessCodes => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateAccessCodes SimulateAccessCodes { get; }
    }
}
