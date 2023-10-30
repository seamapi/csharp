using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using Seam.Client;
using Seam.Model;

namespace Seam.Api
{
    public class Locks
    {
        private ISeamClient _seam;

        public Locks(ISeamClient seam)
        {
            _seam = seam;
        }

        [DataContract(Name = "lockDoorRequest_request")]
        public class LockDoorRequest
        {
            [JsonConstructorAttribute]
            protected LockDoorRequest() { }

            public LockDoorRequest(string deviceId = default, bool? sync = default)
            {
                DeviceId = deviceId;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "lockDoorResponse_response")]
        public class LockDoorResponse
        {
            [JsonConstructorAttribute]
            protected LockDoorResponse() { }

            public LockDoorResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt LockDoor(LockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<LockDoorResponse>("/locks/lock_door", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt LockDoor(string deviceId = default, bool? sync = default)
        {
            return LockDoor(new LockDoorRequest(deviceId: deviceId, sync: sync));
        }

        public async Task<ActionAttempt> LockDoorAsync(LockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<LockDoorResponse>("/locks/lock_door", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> LockDoorAsync(
            string deviceId = default,
            bool? sync = default
        )
        {
            return (await LockDoorAsync(new LockDoorRequest(deviceId: deviceId, sync: sync)));
        }

        [DataContract(Name = "unlockDoorRequest_request")]
        public class UnlockDoorRequest
        {
            [JsonConstructorAttribute]
            protected UnlockDoorRequest() { }

            public UnlockDoorRequest(string deviceId = default, bool? sync = default)
            {
                DeviceId = deviceId;
                Sync = sync;
            }

            [DataMember(Name = "device_id", IsRequired = true, EmitDefaultValue = false)]
            public string DeviceId { get; set; }

            [DataMember(Name = "sync", IsRequired = false, EmitDefaultValue = false)]
            public bool? Sync { get; set; }

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

        [DataContract(Name = "unlockDoorResponse_response")]
        public class UnlockDoorResponse
        {
            [JsonConstructorAttribute]
            protected UnlockDoorResponse() { }

            public UnlockDoorResponse(ActionAttempt actionAttempt = default)
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

        public ActionAttempt UnlockDoor(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return _seam
                .Post<UnlockDoorResponse>("/locks/unlock_door", requestOptions)
                .Data.ActionAttempt;
        }

        public ActionAttempt UnlockDoor(string deviceId = default, bool? sync = default)
        {
            return UnlockDoor(new UnlockDoorRequest(deviceId: deviceId, sync: sync));
        }

        public async Task<ActionAttempt> UnlockDoorAsync(UnlockDoorRequest request)
        {
            var requestOptions = new RequestOptions();
            requestOptions.Data = request;
            return (await _seam.PostAsync<UnlockDoorResponse>("/locks/unlock_door", requestOptions))
                .Data
                .ActionAttempt;
        }

        public async Task<ActionAttempt> UnlockDoorAsync(
            string deviceId = default,
            bool? sync = default
        )
        {
            return (await UnlockDoorAsync(new UnlockDoorRequest(deviceId: deviceId, sync: sync)));
        }
    }
}

namespace Seam.Client
{
    public partial class SeamClient
    {
        public Api.Locks Locks => new(this);
    }

    public partial interface ISeamClient
    {
        public Api.Locks Locks { get; }
    }
}
