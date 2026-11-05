namespace Seam.Test;

using System.Net;
using System.Reflection;
using Seam.Test.Support;

public class RequiredParametersTests
{
    private static SeamClient CreateSeam(RecordingHandler handler)
    {
        return new SeamClient(
            new SeamClientOptions
            {
                ApiKey = "seam_apikey1_token",
                Endpoint = "https://example.com",
                HttpMessageHandler = handler,
                MaxRetries = 0,
            }
        );
    }

    private static async Task AssertRequiresAParameterAsync(
        string path,
        Func<SeamClient, Task> request
    )
    {
        var handler = new RecordingHandler();
        using var seam = CreateSeam(handler);

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => request(seam));

        Assert.Equal($"At least one parameter is required for {path}", exception.Message);
        Assert.Equal(0, handler.AttemptCount);
    }

    [Fact]
    public Task AccessCodesListDoesNotCountLimit()
    {
        return AssertRequiresAParameterAsync(
            "/access_codes/list",
            seam => seam.AccessCodes.ListAsync(new() { Limit = 20 })
        );
    }

    [Fact]
    public Task AccessCodesListDoesNotCountPageCursor()
    {
        return AssertRequiresAParameterAsync(
            "/access_codes/list",
            seam => seam.AccessCodes.ListAsync(new() { PageCursor = "c1" })
        );
    }

    [Fact]
    public Task AccessMethodsListDoesNotCountLimitOrPageCursor()
    {
        return AssertRequiresAParameterAsync(
            "/access_methods/list",
            seam => seam.AccessMethods.ListAsync(new() { Limit = 20, PageCursor = "c1" })
        );
    }

    [Fact]
    public Task EventsListDoesNotCountLimit()
    {
        return AssertRequiresAParameterAsync(
            "/events/list",
            seam => seam.Events.ListAsync(new() { Limit = 20 })
        );
    }

    [Fact]
    public Task DevicesGetRequiresAParameter()
    {
        return AssertRequiresAParameterAsync("/devices/get", seam => seam.Devices.GetAsync(new()));
    }

    [Fact]
    public async Task AccessCodesListAcceptsAFilterWithALimit()
    {
        var handler = new RecordingHandler().RespondWith(
            HttpStatusCode.OK,
            "{\"access_codes\":[]}"
        );
        using var seam = CreateSeam(handler);

        var accessCodes = await seam.AccessCodes.ListAsync(
            new() { DeviceId = "device1", Limit = 20 }
        );

        Assert.Empty(accessCodes);
        Assert.Equal(1, handler.AttemptCount);
    }

    [Fact]
    public void NoGuardIsSatisfiedByPaginationParametersAlone()
    {
        var guardedRequests = typeof(SeamClient)
            .Assembly.GetTypes()
            .Where(type =>
                type.GetMethod("Validate", BindingFlags.Instance | BindingFlags.NonPublic) != null
            )
            .ToList();

        Assert.NotEmpty(guardedRequests);

        var checkedRequests = 0;
        foreach (var type in guardedRequests)
        {
            var validate = type.GetMethod(
                "Validate",
                BindingFlags.Instance | BindingFlags.NonPublic
            )!;

            if (type.GetProperty("Limit") is { } limit)
            {
                var request = Activator.CreateInstance(type)!;
                limit.SetValue(
                    request,
                    Convert.ChangeType(
                        20,
                        Nullable.GetUnderlyingType(limit.PropertyType) ?? limit.PropertyType
                    )
                );
                var exception = Assert.Throws<TargetInvocationException>(
                    () => validate.Invoke(request, null)
                );
                Assert.IsType<ArgumentException>(exception.InnerException);
                checkedRequests++;
            }

            if (type.GetProperty("PageCursor") is { } pageCursor)
            {
                var request = Activator.CreateInstance(type)!;
                pageCursor.SetValue(request, Optional<string>.Of("c1"));
                var exception = Assert.Throws<TargetInvocationException>(
                    () => validate.Invoke(request, null)
                );
                Assert.IsType<ArgumentException>(exception.InnerException);
                checkedRequests++;
            }
        }

        Assert.True(checkedRequests >= 5);
    }
}
