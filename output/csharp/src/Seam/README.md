# Seam C#

## Usage

```csharp
using Seam.Client;

var seam = new SeamClient(apiToken: "YOUR_API_KEY");

var myDevices = seam.Devices.List();

Console.WriteLine("First Device Name: " + myDevices[0].Properties.Name);

var accessCode = seam.AccessCodes.Create(deviceId: myDevices[0].DeviceId, code: "1234");
```

## Advanced Usage

### Setting the request timeout

Requests time out after 30 seconds by default.
Pass the `timeout` option, in milliseconds, to override this:

```csharp
var seam = new SeamClient(apiToken: "YOUR_API_KEY", timeout: 60000);
```

The default may also be changed for every client at once:

```csharp
GlobalSeamRequestConfiguration.Instance.Timeout = 60000;
```
