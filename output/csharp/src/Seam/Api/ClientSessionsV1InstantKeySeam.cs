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
    public class ClientSessionsV1InstantKeySeam
    {
        private ISeamClient _seam;

        public ClientSessionsV1InstantKeySeam(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "exchangeShortCodeRequest_request")]
        public class ExchangeShortCodeRequest
        {
            [JsonConstructorAttribute]
            protected ExchangeShortCodeRequest() { }

            public ExchangeShortCodeRequest(string shortCode = default)
            {
                ShortCode = shortCode;
            }

            [DataMember(Name = "short_code", IsRequired = true, EmitDefaultValue = false)]
            public string ShortCode { get; set; }

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

        [DataContract(Name = "exchangeShortCodeResponse_response")]
        public class ExchangeShortCodeResponse
        {
            [JsonConstructorAttribute]
            protected ExchangeShortCodeResponse() { }

            public ExchangeShortCodeResponse(ClientSession clientSession = default)
            {
                ClientSession = clientSession;
            }

            [DataMember(Name = "client_session", IsRequired = false, EmitDefaultValue = false)]
            public ClientSession ClientSession { get; set; }

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

        public ClientSession ExchangeShortCode(ExchangeShortCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ExchangeShortCodeResponse>(
                    "/seam/instant_key/v1/client_sessions/exchange_short_code",
                    requestOptions
                )
                .Data.ClientSession;
        }

        public ClientSession ExchangeShortCode(string shortCode = default)
        {
            return ExchangeShortCode(new ExchangeShortCodeRequest(shortCode: shortCode));
        }

        public async Task<ClientSession> ExchangeShortCodeAsync(ExchangeShortCodeRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ExchangeShortCodeResponse>(
                    "/seam/instant_key/v1/client_sessions/exchange_short_code",
                    requestOptions
                )
            )
                .Data
                .ClientSession;
        }

        public async Task<ClientSession> ExchangeShortCodeAsync(string shortCode = default)
        {
            return (
                await ExchangeShortCodeAsync(new ExchangeShortCodeRequest(shortCode: shortCode))
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.ClientSessionsV1InstantKeySeam ClientSessionsV1InstantKeySeam => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.ClientSessionsV1InstantKeySeam ClientSessionsV1InstantKeySeam { get; }
    }
}
