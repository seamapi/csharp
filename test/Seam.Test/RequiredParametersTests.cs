namespace Seam.Test;

using System.Reflection;
using Seam.Http;

public class RequiredParametersTests
{
    private static void AssertRequiresAParameter(params bool[] parametersGiven)
    {
        var exception = Assert.Throws<ArgumentException>(
            () => RequestParameters.RequireAtLeastOne("/test/list", parametersGiven)
        );

        Assert.Equal("At least one parameter is required for /test/list", exception.Message);
    }

    [Fact]
    public void EmptyRequestIsRejected()
    {
        AssertRequiresAParameter(false);
    }

    [Fact]
    public void PaginationParametersDoNotSatisfyTheRequirement()
    {
        AssertRequiresAParameter(false);
    }

    [Fact]
    public void AFilterWithPaginationSatisfiesTheRequirement()
    {
        RequestParameters.RequireAtLeastOne("/test/list", true);
    }

    [Fact]
    public void NoGeneratedGuardIsSatisfiedByPaginationParametersAlone()
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

        Assert.True(checkedRequests > 0);
    }
}
