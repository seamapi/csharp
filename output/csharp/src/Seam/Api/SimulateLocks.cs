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
    public class SimulateLocks
    {
        private ISeamClient _seam;

        public SimulateLocks(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "keypadCodeEntryRequest_request")]
        public class KeypadCodeEntryRequest
        {
            [JsonConstructorAttribute]
            protected KeypadCodeEntryRequest() { }

            public KeypadCodeEntryRequest(string code = default, string deviceId = default)
            {
                Code = code;
                DeviceId = deviceId;
            }

            [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
            public string Code { get; set; }

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

        [DataContract(Name = "keypadCodeEntryResponse_response")]
        public class KeypadCodeEntryResponse
        {
            [JsonConstructorAttribute]
            protected KeypadCodeEntryResponse() { }

            public KeypadCodeEntryResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt KeypadCodeEntry(KeypadCodeEntryRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<KeypadCodeEntryResponse>("/locks/simulate/keypad_code_entry", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt KeypadCodeEntry(string code = default, string deviceId = default)
        {
            return KeypadCodeEntry(new KeypadCodeEntryRequest(code: code, deviceId: deviceId));
        }

        public async Task<ActionAttempt> KeypadCodeEntryAsync(KeypadCodeEntryRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<KeypadCodeEntryResponse>(
                    "/locks/simulate/keypad_code_entry",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> KeypadCodeEntryAsync(
            string code = default,
            string deviceId = default
        )
        {
            return (
                await KeypadCodeEntryAsync(
                    new KeypadCodeEntryRequest(code: code, deviceId: deviceId)
                )
            );
        }

        [DataContract(Name = "manualLockViaKeypadRequest_request")]
        public class ManualLockViaKeypadRequest
        {
            [JsonConstructorAttribute]
            protected ManualLockViaKeypadRequest() { }

            public ManualLockViaKeypadRequest(string deviceId = default)
            {
                DeviceId = deviceId;
            }

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

        [DataContract(Name = "manualLockViaKeypadResponse_response")]
        public class ManualLockViaKeypadResponse
        {
            [JsonConstructorAttribute]
            protected ManualLockViaKeypadResponse() { }

            public ManualLockViaKeypadResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt ManualLockViaKeypad(ManualLockViaKeypadRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<ManualLockViaKeypadResponse>(
                    "/locks/simulate/manual_lock_via_keypad",
                    requestOptions
                )
                .Data.ActionAttempt;
        }

        public ActionAttempt ManualLockViaKeypad(string deviceId = default)
        {
            return ManualLockViaKeypad(new ManualLockViaKeypadRequest(deviceId: deviceId));
        }

        public async Task<ActionAttempt> ManualLockViaKeypadAsync(
            ManualLockViaKeypadRequest request
        )
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (
                await _seam.PostAsync<ManualLockViaKeypadResponse>(
                    "/locks/simulate/manual_lock_via_keypad",
                    requestOptions
                )
            )
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> ManualLockViaKeypadAsync(string deviceId = default)
        {
            return (
                await ManualLockViaKeypadAsync(new ManualLockViaKeypadRequest(deviceId: deviceId))
            );
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.SimulateLocks SimulateLocks => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.SimulateLocks SimulateLocks { get; }
    }
}
