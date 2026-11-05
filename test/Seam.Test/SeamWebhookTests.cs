namespace Seam.Test;

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Svix.Exceptions;

public class SeamWebhookTests
{
    private const string Secret = "whsec_MfKQ9r8GKYqrTwjUPD8ILPZIo2LaLaSw";

    private const string Payload = """
        {"event_id":"8d7e0b26-5e6c-4a1f-9b3d-1b0f0e5a9c11","event_type":"device.connected","workspace_id":"398d80b7-3f96-47c2-b85a-6f8ba21d07be","device_id":"054765c8-a2fc-4599-b486-14c19f462c45","created_at":"2024-01-01T00:00:00.000Z","occurred_at":"2024-01-01T00:00:00.000Z"}
        """;

    // Signs the payload the way Svix does: v1,base64(hmac_sha256(key, "{id}.{timestamp}.{payload}")).
    private static Dictionary<string, string> SignedHeaders(
        string payload,
        DateTimeOffset? signedAt = null
    )
    {
        var id = "msg_test";
        var timestamp = (signedAt ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds().ToString();

        var key = Convert.FromBase64String(Secret["whsec_".Length..]);
        using var hmac = new HMACSHA256(key);
        var signature = Convert.ToBase64String(
            hmac.ComputeHash(Encoding.UTF8.GetBytes($"{id}.{timestamp}.{payload}"))
        );

        return new Dictionary<string, string>
        {
            ["svix-id"] = id,
            ["svix-timestamp"] = timestamp,
            ["svix-signature"] = $"v1,{signature}",
        };
    }

    [Fact]
    public void VerifyReturnsTheEvent()
    {
        var seamEvent = new SeamWebhook(Secret).Verify(Payload, SignedHeaders(Payload));

        Assert.Equal("device.connected", seamEvent.EventType);
        Assert.Equal("8d7e0b26-5e6c-4a1f-9b3d-1b0f0e5a9c11", seamEvent.EventId);
    }

    [Fact]
    public void VerifyAcceptsHeadersInAnyCase()
    {
        var headers = SignedHeaders(Payload)
            .ToDictionary(pair => pair.Key.ToUpperInvariant(), pair => pair.Value);

        var seamEvent = new SeamWebhook(Secret).Verify(Payload, headers);

        Assert.Equal("device.connected", seamEvent.EventType);
    }

    [Fact]
    public void VerifyRejectsATamperedPayload()
    {
        var headers = SignedHeaders(Payload);
        var tampered = Payload.Replace("device.connected", "device.disconnected");

        Assert.Throws<WebhookVerificationException>(
            () => new SeamWebhook(Secret).Verify(tampered, headers)
        );
    }

    [Fact]
    public void VerifyRejectsTheWrongSecret()
    {
        var headers = SignedHeaders(Payload);

        Assert.Throws<WebhookVerificationException>(
            () =>
                new SeamWebhook("whsec_AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=").Verify(
                    Payload,
                    headers
                )
        );
    }

    [Fact]
    public void VerifyRejectsAMissingHeader()
    {
        var headers = SignedHeaders(Payload);
        headers.Remove("svix-signature");

        Assert.Throws<WebhookVerificationException>(
            () => new SeamWebhook(Secret).Verify(Payload, headers)
        );
    }

    [Fact]
    public void VerifyRejectsAnExpiredTimestamp()
    {
        var headers = SignedHeaders(Payload, DateTimeOffset.UtcNow.AddMinutes(-10));

        Assert.Throws<WebhookVerificationException>(
            () => new SeamWebhook(Secret).Verify(Payload, headers)
        );
    }

    [Fact]
    public void VerifyRaisesAPayloadExceptionForASignedPayloadThatIsNotJson()
    {
        var payload = "not json at all";

        var exception = Assert.Throws<SeamInvalidWebhookPayloadException>(
            () => new SeamWebhook(Secret).Verify(payload, SignedHeaders(payload))
        );

        Assert.Equal("The verified webhook payload is not valid JSON", exception.Message);
        Assert.IsAssignableFrom<JsonException>(exception.InnerException);
        Assert.IsAssignableFrom<SeamException>(exception);
    }

    [Theory]
    [InlineData("null")]
    [InlineData("[]")]
    [InlineData("\"device.connected\"")]
    [InlineData("{}")]
    [InlineData("{\"event_id\":\"8d7e0b26-5e6c-4a1f-9b3d-1b0f0e5a9c11\"}")]
    [InlineData("{\"event_id\":1,\"event_type\":\"device.connected\"}")]
    [InlineData("{\"event_id\":\"8d7e0b26-5e6c-4a1f-9b3d-1b0f0e5a9c11\",\"event_type\":null}")]
    public void VerifyRaisesAPayloadExceptionForASignedPayloadThatIsNotAnEvent(string payload)
    {
        var exception = Assert.Throws<SeamInvalidWebhookPayloadException>(
            () => new SeamWebhook(Secret).Verify(payload, SignedHeaders(payload))
        );

        Assert.Equal(
            "The verified webhook payload did not contain a Seam event",
            exception.Message
        );
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void VerifyRaisesAPayloadExceptionForAnEventWithAMalformedField()
    {
        var payload = Payload.Replace(
            "\"device_id\":\"054765c8-a2fc-4599-b486-14c19f462c45\"",
            "\"device_id\":5"
        );

        var exception = Assert.Throws<SeamInvalidWebhookPayloadException>(
            () => new SeamWebhook(Secret).Verify(payload, SignedHeaders(payload))
        );

        Assert.Equal(
            "The verified webhook payload could not be read as a Seam event",
            exception.Message
        );
        Assert.IsAssignableFrom<JsonException>(exception.InnerException);
    }

    [Fact]
    public void VerifyReturnsAnUnrecognizedEventForAnUnknownEventType()
    {
        var payload = Payload.Replace("device.connected", "device.teleported");

        var seamEvent = new SeamWebhook(Secret).Verify(payload, SignedHeaders(payload));

        var unrecognized = Assert.IsType<Seam.Models.EventUnrecognized>(seamEvent);
        Assert.Equal(
            "device.teleported",
            unrecognized.RawJson.GetProperty("event_type").GetString()
        );
        Assert.Equal("8d7e0b26-5e6c-4a1f-9b3d-1b0f0e5a9c11", unrecognized.EventId);
    }
}
