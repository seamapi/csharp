# Seam C#

[![GitHub Actions](https://github.com/seamapi/nextlove-sdk-csharp/actions/workflows/check.yml/badge.svg)](https://github.com/seamapi/nextlove-sdk-csharp/actions/workflows/check.yml)

Seam

## Installation

Use [nuget](https://www.nuget.org/packages/Seam) to install.

## Usage

```csharp
var seam = new Seam.Client.Seam(apiToken: "YOUR_API_KEY");

var myDevices = seam.Devices.List();

Console.WriteLine("First Device Name: " + myDevices[0].Properties.Name);

var accessCode = seam.AccessCodes.Create(deviceId: myDevices[0].DeviceId, code: "1234");
```
