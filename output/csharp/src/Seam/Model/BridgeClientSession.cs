using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
    [DataContract(Name = "seamModel_bridgeClientSession_model")]
    public class BridgeClientSession
    {
        [JsonConstructorAttribute]
        protected BridgeClientSession() { }

        public BridgeClientSession(
            string bridgeClientMachineIdentifierKey = default,
            string bridgeClientName = default,
            string bridgeClientSessionId = default,
            string bridgeClientSessionToken = default,
            string bridgeClientTimeZone = default,
            string createdAt = default,
            List<BridgeClientSessionErrors> errors = default,
            string pairingCode = default,
            string pairingCodeExpiresAt = default,
            string? tailscaleAuthKey = default,
            string tailscaleHostname = default,
            string? telemetryToken = default,
            string? telemetryTokenExpiresAt = default,
            string? telemetryUrl = default
        )
        {
            BridgeClientMachineIdentifierKey = bridgeClientMachineIdentifierKey;
            BridgeClientName = bridgeClientName;
            BridgeClientSessionId = bridgeClientSessionId;
            BridgeClientSessionToken = bridgeClientSessionToken;
            BridgeClientTimeZone = bridgeClientTimeZone;
            CreatedAt = createdAt;
            Errors = errors;
            PairingCode = pairingCode;
            PairingCodeExpiresAt = pairingCodeExpiresAt;
            TailscaleAuthKey = tailscaleAuthKey;
            TailscaleHostname = tailscaleHostname;
            TelemetryToken = telemetryToken;
            TelemetryTokenExpiresAt = telemetryTokenExpiresAt;
            TelemetryUrl = telemetryUrl;
        }

        [JsonConverter(typeof(JsonSubtypes), "error_code")]
        [JsonSubtypes.KnownSubType(
            typeof(BridgeClientSessionErrorsNoCommunicationFromBridge),
            "no_communication_from_bridge"
        )]
        [JsonSubtypes.KnownSubType(
            typeof(BridgeClientSessionErrorsBridgeLanUnreachable),
            "bridge_lan_unreachable"
        )]
        public abstract class BridgeClientSessionErrors
        {
            public abstract string ErrorCode { get; }

            public abstract string Message { get; set; }

            public abstract override string ToString();
        }

        [DataContract(Name = "seamModel_bridgeClientSessionErrorsBridgeLanUnreachable_model")]
        public class BridgeClientSessionErrorsBridgeLanUnreachable : BridgeClientSessionErrors
        {
            [JsonConstructorAttribute]
            protected BridgeClientSessionErrorsBridgeLanUnreachable() { }

            public BridgeClientSessionErrorsBridgeLanUnreachable(
                bool? canTailscaleProxyReachBridge = default,
                bool? canTailscaleProxyReachTailscaleNetwork = default,
                string createdAt = default,
                string errorCode = default,
                bool? isBridgeSocksServerHealthy = default,
                bool? isTailscaleProxyReachable = default,
                bool? isTailscaleProxySocksServerHealthy = default,
                string message = default
            )
            {
                CanTailscaleProxyReachBridge = canTailscaleProxyReachBridge;
                CanTailscaleProxyReachTailscaleNetwork = canTailscaleProxyReachTailscaleNetwork;
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                IsBridgeSocksServerHealthy = isBridgeSocksServerHealthy;
                IsTailscaleProxyReachable = isTailscaleProxyReachable;
                IsTailscaleProxySocksServerHealthy = isTailscaleProxySocksServerHealthy;
                Message = message;
            }

            [DataMember(
                Name = "can_tailscale_proxy_reach_bridge",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? CanTailscaleProxyReachBridge { get; set; }

            [DataMember(
                Name = "can_tailscale_proxy_reach_tailscale_network",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? CanTailscaleProxyReachTailscaleNetwork { get; set; }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "bridge_lan_unreachable";

            [DataMember(
                Name = "is_bridge_socks_server_healthy",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsBridgeSocksServerHealthy { get; set; }

            [DataMember(
                Name = "is_tailscale_proxy_reachable",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsTailscaleProxyReachable { get; set; }

            [DataMember(
                Name = "is_tailscale_proxy_socks_server_healthy",
                IsRequired = false,
                EmitDefaultValue = false
            )]
            public bool? IsTailscaleProxySocksServerHealthy { get; set; }

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

        [DataContract(Name = "seamModel_bridgeClientSessionErrorsNoCommunicationFromBridge_model")]
        public class BridgeClientSessionErrorsNoCommunicationFromBridge : BridgeClientSessionErrors
        {
            [JsonConstructorAttribute]
            protected BridgeClientSessionErrorsNoCommunicationFromBridge() { }

            public BridgeClientSessionErrorsNoCommunicationFromBridge(
                string createdAt = default,
                string errorCode = default,
                string message = default
            )
            {
                CreatedAt = createdAt;
                ErrorCode = errorCode;
                Message = message;
            }

            [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
            public string CreatedAt { get; set; }

            [DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
            public override string ErrorCode { get; } = "no_communication_from_bridge";

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

        [DataMember(
            Name = "bridge_client_machine_identifier_key",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string BridgeClientMachineIdentifierKey { get; set; }

        [DataMember(Name = "bridge_client_name", IsRequired = true, EmitDefaultValue = false)]
        public string BridgeClientName { get; set; }

        [DataMember(Name = "bridge_client_session_id", IsRequired = true, EmitDefaultValue = false)]
        public string BridgeClientSessionId { get; set; }

        [DataMember(
            Name = "bridge_client_session_token",
            IsRequired = true,
            EmitDefaultValue = false
        )]
        public string BridgeClientSessionToken { get; set; }

        [DataMember(Name = "bridge_client_time_zone", IsRequired = true, EmitDefaultValue = false)]
        public string BridgeClientTimeZone { get; set; }

        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = false)]
        public List<BridgeClientSessionErrors> Errors { get; set; }

        [DataMember(Name = "pairing_code", IsRequired = true, EmitDefaultValue = false)]
        public string PairingCode { get; set; }

        [DataMember(Name = "pairing_code_expires_at", IsRequired = true, EmitDefaultValue = false)]
        public string PairingCodeExpiresAt { get; set; }

        [DataMember(Name = "tailscale_auth_key", IsRequired = false, EmitDefaultValue = false)]
        public string? TailscaleAuthKey { get; set; }

        [DataMember(Name = "tailscale_hostname", IsRequired = true, EmitDefaultValue = false)]
        public string TailscaleHostname { get; set; }

        [DataMember(Name = "telemetry_token", IsRequired = false, EmitDefaultValue = false)]
        public string? TelemetryToken { get; set; }

        [DataMember(
            Name = "telemetry_token_expires_at",
            IsRequired = false,
            EmitDefaultValue = false
        )]
        public string? TelemetryTokenExpiresAt { get; set; }

        [DataMember(Name = "telemetry_url", IsRequired = false, EmitDefaultValue = false)]
        public string? TelemetryUrl { get; set; }

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
