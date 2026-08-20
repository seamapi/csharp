namespace Seam.Test;

public class StrictUrlSearchParamsSerializerTests
{
    private static string Serialize(params (string Name, object? Value)[] parameters)
    {
        return StrictUrlSearchParamsSerializer.Serialize(
            parameters.ToDictionary(parameter => parameter.Name, parameter => parameter.Value)
        );
    }

    [Fact]
    public void AddsTheStrictFlagToANonEmptyQuery()
    {
        Assert.Equal("foo=d&_strict=true", Serialize(("foo", "d")));
    }

    [Fact]
    public void AddsTheStrictFlagAfterTheSortedParams()
    {
        Assert.Equal("bar=2&foo=d&_strict=true", Serialize(("foo", "d"), ("bar", 2)));
    }

    [Fact]
    public void LeavesAnEmptyQueryEmpty()
    {
        Assert.Equal("", Serialize());
        Assert.Equal("", Serialize(("foo", null)));
        Assert.Equal("", Serialize(("foo", "")));
    }

    [Fact]
    public void ReplacesACallerSuppliedStrictParam()
    {
        Assert.Equal("foo=d&_strict=true", Serialize(("foo", "d"), ("_strict", "false")));
        Assert.Equal("_strict=true", Serialize(("_strict", "false")));
    }

    [Fact]
    public void UpdatesExistingSearchParams()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Set("foo", "bar");

        StrictUrlSearchParamsSerializer.Update(
            searchParams,
            new Dictionary<string, object?> { ["name"] = "Dax" }
        );

        Assert.Equal("foo=bar&name=Dax&_strict=true", searchParams.ToString());
    }

    [Fact]
    public void LeavesTheBaseSerializerWithoutTheStrictFlag()
    {
        Assert.Equal(
            "foo=d",
            UrlSearchParamsSerializer.Serialize(new Dictionary<string, object?> { ["foo"] = "d" })
        );
    }
}
