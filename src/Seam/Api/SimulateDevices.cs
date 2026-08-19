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
    public class SimulateDevices
    {
        private ISeamClient _seam;

        public SimulateDevices(ISeamClient seam)
        {
            _seam = seam;
        }

        /// <summary>
        /// Request parameters for Simulate Device Connection.
        /// </summary>
        [DataContract(Name = "connectRequest_request")]
        public class ConnectRequest
        {
            [JsonConstructorAttribute]
            protected ConnectRequest() { }

            public ConnectRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device that you want to simulate connecting to Seam.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
        /// Simulates connecting a device to Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Connect(ConnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/connect", requestOptions);
        }

        /// <summary>
        /// Simulates connecting a device to Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Connect(string deviceId = default)
        {
            Connect(new ConnectRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates connecting a device to Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task ConnectAsync(ConnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/connect", requestOptions);
        }

        /// <summary>
        /// Simulates connecting a device to Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task ConnectAsync(string deviceId = default)
        {
            await ConnectAsync(new ConnectRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Simulate Hub Connection.
        /// </summary>
        [DataContract(Name = "connectToHubRequest_request")]
        public class ConnectToHubRequest
        {
            [JsonConstructorAttribute]
            protected ConnectToHubRequest() { }

            public ConnectToHubRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device whose hub you want to reconnect.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
        /// Simulates bringing the Wi‑Fi hub (bridge) back online for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August and TTLock locks.
        /// This will clear the `hub_disconnected` error on the device.
        /// </summary>
        public void ConnectToHub(ConnectToHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/connect_to_hub", requestOptions);
        }

        /// <summary>
        /// Simulates bringing the Wi‑Fi hub (bridge) back online for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August and TTLock locks.
        /// This will clear the `hub_disconnected` error on the device.
        /// </summary>
        public void ConnectToHub(string deviceId = default)
        {
            ConnectToHub(new ConnectToHubRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates bringing the Wi‑Fi hub (bridge) back online for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August and TTLock locks.
        /// This will clear the `hub_disconnected` error on the device.
        /// </summary>
        public async Task ConnectToHubAsync(ConnectToHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/connect_to_hub", requestOptions);
        }

        /// <summary>
        /// Simulates bringing the Wi‑Fi hub (bridge) back online for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August and TTLock locks.
        /// This will clear the `hub_disconnected` error on the device.
        /// </summary>
        public async Task ConnectToHubAsync(string deviceId = default)
        {
            await ConnectToHubAsync(new ConnectToHubRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Simulate Device Disconnection.
        /// </summary>
        [DataContract(Name = "disconnectRequest_request")]
        public class DisconnectRequest
        {
            [JsonConstructorAttribute]
            protected DisconnectRequest() { }

            public DisconnectRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device that you want to simulate disconnecting from Seam.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
        /// Simulates disconnecting a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Disconnect(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/disconnect", requestOptions);
        }

        /// <summary>
        /// Simulates disconnecting a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Disconnect(string deviceId = default)
        {
            Disconnect(new DisconnectRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates disconnecting a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task DisconnectAsync(DisconnectRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/disconnect", requestOptions);
        }

        /// <summary>
        /// Simulates disconnecting a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task DisconnectAsync(string deviceId = default)
        {
            await DisconnectAsync(new DisconnectRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Simulate Hub Disconnection.
        /// </summary>
        [DataContract(Name = "disconnectFromHubRequest_request")]
        public class DisconnectFromHubRequest
        {
            [JsonConstructorAttribute]
            protected DisconnectFromHubRequest() { }

            public DisconnectFromHubRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device whose hub you want to disconnect.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
        /// Simulates taking the Wi‑Fi hub (bridge) offline for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August, TTLock, and IglooHome devices.
        /// This will set the `hub_disconnected` error on the device, or mark the
        /// IglooHome bridge offline in sandbox.
        /// </summary>
        public void DisconnectFromHub(DisconnectFromHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/disconnect_from_hub", requestOptions);
        }

        /// <summary>
        /// Simulates taking the Wi‑Fi hub (bridge) offline for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August, TTLock, and IglooHome devices.
        /// This will set the `hub_disconnected` error on the device, or mark the
        /// IglooHome bridge offline in sandbox.
        /// </summary>
        public void DisconnectFromHub(string deviceId = default)
        {
            DisconnectFromHub(new DisconnectFromHubRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates taking the Wi‑Fi hub (bridge) offline for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August, TTLock, and IglooHome devices.
        /// This will set the `hub_disconnected` error on the device, or mark the
        /// IglooHome bridge offline in sandbox.
        /// </summary>
        public async Task DisconnectFromHubAsync(DisconnectFromHubRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/disconnect_from_hub", requestOptions);
        }

        /// <summary>
        /// Simulates taking the Wi‑Fi hub (bridge) offline for a device.
        /// Only applicable for sandbox workspaces and currently
        /// implemented for August, TTLock, and IglooHome devices.
        /// This will set the `hub_disconnected` error on the device, or mark the
        /// IglooHome bridge offline in sandbox.
        /// </summary>
        public async Task DisconnectFromHubAsync(string deviceId = default)
        {
            await DisconnectFromHubAsync(new DisconnectFromHubRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Request parameters for Simulate Paid Subscription.
        /// </summary>
        [DataContract(Name = "paidSubscriptionRequest_request")]
        public class PaidSubscriptionRequest
        {
            [JsonConstructorAttribute]
            protected PaidSubscriptionRequest() { }

            public PaidSubscriptionRequest(string deviceId = default, bool isExpired = default)
            {
                DeviceId = deviceId;
                IsExpired = isExpired;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "is_expired", IsRequired = true, EmitDefaultValue = false)]
            public bool IsExpired { get; set; }

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
        /// Toggle the simulated Nuki Smart Hosting subscription for a device (sandbox only).
        /// Send `is_expired: true` to simulate an expired subscription, or `false` to simulate an active subscription.
        /// The actual device error is created/cleared by the poller after this state change.
        /// </summary>
        public void PaidSubscription(PaidSubscriptionRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/paid_subscription", requestOptions);
        }

        /// <summary>
        /// Toggle the simulated Nuki Smart Hosting subscription for a device (sandbox only).
        /// Send `is_expired: true` to simulate an expired subscription, or `false` to simulate an active subscription.
        /// The actual device error is created/cleared by the poller after this state change.
        /// </summary>
        public void PaidSubscription(string deviceId = default, bool isExpired = default)
        {
            PaidSubscription(new PaidSubscriptionRequest(deviceId: deviceId, isExpired: isExpired));
        }

        /// <summary>
        /// Toggle the simulated Nuki Smart Hosting subscription for a device (sandbox only).
        /// Send `is_expired: true` to simulate an expired subscription, or `false` to simulate an active subscription.
        /// The actual device error is created/cleared by the poller after this state change.
        /// </summary>
        public async Task PaidSubscriptionAsync(PaidSubscriptionRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/paid_subscription", requestOptions);
        }

        /// <summary>
        /// Toggle the simulated Nuki Smart Hosting subscription for a device (sandbox only).
        /// Send `is_expired: true` to simulate an expired subscription, or `false` to simulate an active subscription.
        /// The actual device error is created/cleared by the poller after this state change.
        /// </summary>
        public async Task PaidSubscriptionAsync(string deviceId = default, bool isExpired = default)
        {
            await PaidSubscriptionAsync(
                new PaidSubscriptionRequest(deviceId: deviceId, isExpired: isExpired)
            );
        }

        /// <summary>
        /// Request parameters for Simulate Device Removal.
        /// </summary>
        [DataContract(Name = "removeRequest_request")]
        public class RemoveRequest
        {
            [JsonConstructorAttribute]
            protected RemoveRequest() { }

            public RemoveRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

            /// <summary>
            /// ID of the device that you want to simulate removing from Seam.
            /// </summary>
            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

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
        /// Simulates removing a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Remove(RemoveRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            _seam.Post<object>("/devices/simulate/remove", requestOptions);
        }

        /// <summary>
        /// Simulates removing a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public void Remove(string deviceId = default)
        {
            Remove(new RemoveRequest(deviceId: deviceId));
        }

        /// <summary>
        /// Simulates removing a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task RemoveAsync(RemoveRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            await _seam.PostAsync<object>("/devices/simulate/remove", requestOptions);
        }

        /// <summary>
        /// Simulates removing a device from Seam. Only applicable for [sandbox devices](https://docs.seam.co/core-concepts/workspaces#sandbox-workspaces). See also [Testing Your App Against Device Disconnection and Removal](https://docs.seam.co/core-concepts/devices/testing-your-app-against-device-disconnection-and-removal).
        /// </summary>
        public async Task RemoveAsync(string deviceId = default)
        {
            await RemoveAsync(new RemoveRequest(deviceId: deviceId));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateDevices SimulateDevices => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateDevices SimulateDevices { get; }
    }
}
