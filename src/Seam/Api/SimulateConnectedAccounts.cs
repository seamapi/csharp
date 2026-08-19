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
    public class SimulateConnectedAccounts
    {
        private ISeamClient _seam;

        public SimulateConnectedAccounts(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Simulate Connected Account Disconnection.
        /// </summary>
        [DataContract(Name = "disconnectRequest_request")]
        public class DisconnectRequest
        {
            [JsonConstructorAttribute]
            protected DisconnectRequest() { }

            public DisconnectRequest(string connectedAccountId = default)
            {
                ConnectedAccountId = connectedAccountId;
            }

            /// <summary>
            /// ID of the connected account you want to simulate as disconnected.
            /// </summary>
            [DataMember(Name = "connected_account_id", IsRequired = true, EmitDefaultValue = false)]
            public string ConnectedAccountId { get; set; }

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
        /// Simulates a connected account becoming disconnected from Seam. Only applicable for [sandbox workspaces](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public void Disconnect(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/connected_accounts/simulate/disconnect", requestOptions);
        }

        /// <summary>
        /// Simulates a connected account becoming disconnected from Seam. Only applicable for [sandbox workspaces](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public void Disconnect(string connectedAccountId = default)
        {
            Disconnect(new DisconnectRequest(connectedAccountId: connectedAccountId));
        }

        /// <summary>
        /// Simulates a connected account becoming disconnected from Seam. Only applicable for [sandbox workspaces](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public async Task DisconnectAsync(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>(
                "/connected_accounts/simulate/disconnect",
                requestOptions
            );
        }

        /// <summary>
        /// Simulates a connected account becoming disconnected from Seam. Only applicable for [sandbox workspaces](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces).
        /// </summary>
        public async Task DisconnectAsync(string connectedAccountId = default)
        {
            await DisconnectAsync(new DisconnectRequest(connectedAccountId: connectedAccountId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateConnectedAccounts SimulateConnectedAccounts => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateConnectedAccounts SimulateConnectedAccounts { get; }
    }
}
