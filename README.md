# Seam C#

[![GitHub Actions](https://github.com/seamapi/nextlove-sdk-csharp/actions/workflows/check.yml/badge.svg)](https://github.com/seamapi/nextlove-sdk-csharp/actions/workflows/check.yml)

Seam

## Local setup

For C# development, you will need to install `dotnet`

Download the installer [here](https://learn.microsoft.com/en-us/dotnet/core/install/macos)

Then, you may need to create a symlink

```bash
ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/
```

Finally, install csharpier

```bash
# if you don't yet have a .config/dotnet-tools.json file
dotnet new tool-manifest

dotnet tool install csharpier
```

## How to update the SDK

Once you've completed all the steps in the Local setup section, you can run the following command to update the SDK

```bash
npm run generate
```

## Installation

Use [nuget](https://www.nuget.org/packages/Seam) to install.

## Usage

```csharp
using Seam.Client;

var seam = new SeamClient(apiToken: "YOUR_API_KEY");

var myDevices = seam.Devices.List();

Console.WriteLine("First Device Name: " + myDevices[0].Properties.Name);

var accessCode = seam.AccessCodes.Create(deviceId: myDevices[0].DeviceId, code: "1234");
```
