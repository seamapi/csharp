namespace Seam.Test;

using System.Text.Json;
using Seam.Models;

public class SerializationTests
{
    private static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, SeamJson.Options)!;
    }

    [Fact]
    public void UnknownEnumValueDeserializesToUnrecognized()
    {
        var device = Deserialize<Device>(
            """{"device_id":"device1","device_type":"not_a_real_device_type"}"""
        );

        Assert.Equal(Device.DeviceTypeEnum.Unrecognized, device.DeviceType);
    }

    [Fact]
    public void KnownEnumValueRoundTrips()
    {
        var device = Deserialize<Device>("""{"device_id":"device1","device_type":"august_lock"}""");

        Assert.Equal(Device.DeviceTypeEnum.AugustLock, device.DeviceType);
        Assert.Contains(
            "\"device_type\":\"august_lock\"",
            JsonSerializer.Serialize(device, SeamJson.Options)
        );
    }

    [Fact]
    public void UnknownActionTypeDeserializesToUnrecognizedVariant()
    {
        var actionAttempt = Deserialize<ActionAttempt>(
            """
            {"action_type":"BRAND_NEW_ACTION","action_attempt_id":"attempt1","status":"pending","extra":{"a":1}}
            """
        );

        var unrecognized = Assert.IsType<ActionAttemptUnrecognized>(actionAttempt);
        Assert.Equal("unrecognized", unrecognized.ActionType);
        Assert.Equal("attempt1", unrecognized.ActionAttemptId);
        Assert.Equal(ActionAttemptStatus.Pending, unrecognized.Status);

        // The raw payload of an unrecognized variant is preserved, not discarded.
        Assert.Equal(
            "BRAND_NEW_ACTION",
            unrecognized.RawJson.GetProperty("action_type").GetString()
        );
        Assert.Equal(1, unrecognized.RawJson.GetProperty("extra").GetProperty("a").GetInt32());
    }

    [Fact]
    public void KnownActionTypeDeserializesToItsVariant()
    {
        var actionAttempt = Deserialize<ActionAttempt>(
            """
            {"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"success","result":{}}
            """
        );

        Assert.IsType<ActionAttemptUnlockDoor>(actionAttempt);
        Assert.Equal(ActionAttemptStatus.Success, actionAttempt.Status);
        Assert.Equal("UNLOCK_DOOR", actionAttempt.ActionType);
    }

    [Fact]
    public void UnknownEventTypeDeserializesToUnrecognizedVariant()
    {
        var seamEvent = Deserialize<Event>(
            """
            {"event_type":"brand.new_event","event_id":"event1","workspace_id":"workspace1"}
            """
        );

        var unrecognized = Assert.IsType<EventUnrecognized>(seamEvent);
        Assert.Equal("event1", unrecognized.EventId);
        Assert.Equal("brand.new_event", unrecognized.RawJson.GetProperty("event_type").GetString());
    }

    [Fact]
    public void KnownEventTypeDeserializesToItsVariant()
    {
        var seamEvent = Deserialize<Event>(
            """
            {"event_type":"device.connected","event_id":"event1","workspace_id":"workspace1","device_id":"device1"}
            """
        );

        Assert.Equal("device.connected", seamEvent.EventType);
        Assert.Equal("event1", seamEvent.EventId);
    }

    [Fact]
    public void UnknownActionAttemptStatusDeserializesToUnrecognized()
    {
        var actionAttempt = Deserialize<ActionAttempt>(
            """
            {"action_type":"UNLOCK_DOOR","action_attempt_id":"attempt1","status":"not_a_status"}
            """
        );

        Assert.Equal(ActionAttemptStatus.Unrecognized, actionAttempt.Status);
    }

    [Fact]
    public void PendingActionAttemptDeserializesWithNullResultAndError()
    {
        var actionAttempt = Deserialize<ActionAttempt>(
            """
            {"action_type":"LOCK_DOOR","action_attempt_id":"attempt1","status":"pending","result":null,"error":null}
            """
        );

        var lockDoor = Assert.IsType<ActionAttemptLockDoor>(actionAttempt);
        Assert.Equal(ActionAttemptStatus.Pending, lockDoor.Status);
        Assert.Null(lockDoor.Result);
        Assert.Null(lockDoor.Error);
    }

    [Fact]
    public void SuccessfulActionAttemptDeserializesWithResult()
    {
        var actionAttempt = Deserialize<ActionAttempt>(
            """
            {"action_type":"LOCK_DOOR","action_attempt_id":"attempt1","status":"success","error":null,"result":{"was_confirmed_by_device":true}}
            """
        );

        var lockDoor = Assert.IsType<ActionAttemptLockDoor>(actionAttempt);
        Assert.Equal(ActionAttemptStatus.Success, lockDoor.Status);
        Assert.NotNull(lockDoor.Result);
        Assert.True(lockDoor.Result.WasConfirmedByDevice);
    }

    [Fact]
    public void UnsetOptionalParametersAreOmitted()
    {
        var json = JsonSerializer.Serialize(
            new Routes.ConnectedAccounts.ListRequest(),
            SeamJson.Options
        );

        Assert.Equal("{}", json);
    }

    [Fact]
    public void OptionalParametersSerializeTheirValue()
    {
        var json = JsonSerializer.Serialize(
            new Routes.ConnectedAccounts.ListRequest { PageCursor = "cursor1" },
            SeamJson.Options
        );

        Assert.Contains("\"page_cursor\":\"cursor1\"", json);
    }

    [Fact]
    public void OptionalParametersSerializeAnExplicitNull()
    {
        var json = JsonSerializer.Serialize(
            new Routes.ConnectedAccounts.ListRequest { PageCursor = Null.Value },
            SeamJson.Options
        );

        Assert.Contains("\"page_cursor\":null", json);
    }

    [Fact]
    public void NullOptionalParametersAreOmitted()
    {
        var json = JsonSerializer.Serialize(new Routes.Devices.ListRequest(), SeamJson.Options);

        Assert.Equal("{}", json);
    }
}
