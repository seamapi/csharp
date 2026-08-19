namespace Seam.Test;

using Seam.Client;

public class UrlSearchParamsTests
{
    [Fact]
    public void StartsEmpty()
    {
        var searchParams = new UrlSearchParams();

        Assert.Equal(0, searchParams.Count);
        Assert.Equal("", searchParams.ToString());
        Assert.Null(searchParams.Get("foo"));
        Assert.False(searchParams.Has("foo"));
    }

    [Fact]
    public void AppendsPairsWithTheSameName()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("foo", "a");
        searchParams.Append("foo", "b");

        Assert.Equal(2, searchParams.Count);
        Assert.Equal("a", searchParams.Get("foo"));
        Assert.Equal(new[] { "a", "b" }, searchParams.GetAll("foo"));
        Assert.Equal("foo=a&foo=b", searchParams.ToString());
    }

    [Fact]
    public void SetKeepsThePositionOfTheFirstPairAndRemovesTheRest()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("foo", "a");
        searchParams.Append("bar", "b");
        searchParams.Append("foo", "c");

        searchParams.Set("foo", "d");

        Assert.Equal("foo=d&bar=b", searchParams.ToString());
    }

    [Fact]
    public void SetAppendsWhenNoPairWithTheNameExists()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("foo", "a");

        searchParams.Set("bar", "b");

        Assert.Equal("foo=a&bar=b", searchParams.ToString());
    }

    [Fact]
    public void DeletesEveryPairWithTheName()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("foo", "a");
        searchParams.Append("bar", "b");
        searchParams.Append("foo", "c");

        searchParams.Delete("foo");

        Assert.Equal("bar=b", searchParams.ToString());
        Assert.False(searchParams.Has("foo"));
    }

    [Fact]
    public void SortsByNameKeepingTheOrderOfPairsWithTheSameName()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("foo", "1");
        searchParams.Append("bar", "a");
        searchParams.Append("foo", "2");
        searchParams.Append("Baz", "c");

        searchParams.Sort();

        Assert.Equal("Baz=c&bar=a&foo=1&foo=2", searchParams.ToString());
    }

    [Fact]
    public void EncodesEveryPairIncludingEmptyValues()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("a name", "");
        searchParams.Append("foo", "a b*~");

        Assert.Equal("a+name=&foo=a+b*%7E", searchParams.ToString());
    }

    [Fact]
    public void ParsesAQueryString()
    {
        var searchParams = new UrlSearchParams("?foo=a+b*%7E&foo=2&bar=&baz");

        Assert.Equal(new[] { "a b*~", "2" }, searchParams.GetAll("foo"));
        Assert.Equal("", searchParams.Get("bar"));
        Assert.Equal("", searchParams.Get("baz"));
        Assert.Equal("foo=a+b*%7E&foo=2&bar=&baz=", searchParams.ToString());
    }

    [Fact]
    public void RoundTripsNonAsciiValues()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Append("emoji", "\U0001F600");
        searchParams.Append("kanji", "\u4E2D");

        var parsed = new UrlSearchParams(searchParams.ToString());

        Assert.Equal("\U0001F600", parsed.Get("emoji"));
        Assert.Equal("\u4E2D", parsed.Get("kanji"));
    }

    [Fact]
    public void EnumeratesPairsInOrder()
    {
        var searchParams = new UrlSearchParams(
            new[]
            {
                new KeyValuePair<string, string>("foo", "a"),
                new KeyValuePair<string, string>("bar", "b"),
            }
        );

        Assert.Equal(new[] { "foo", "bar" }, searchParams.Select(pair => pair.Key));
        Assert.Equal(new[] { "a", "b" }, searchParams.Select(pair => pair.Value));
    }
}
