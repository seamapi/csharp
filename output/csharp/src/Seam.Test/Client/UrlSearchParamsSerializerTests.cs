namespace Seam.Test;

using System.Collections;
using Seam.Client;

public class UrlSearchParamsSerializerTests
{
    private static Dictionary<string, object?> Params(
        params (string Name, object? Value)[] parameters
    )
    {
        return parameters.ToDictionary(parameter => parameter.Name, parameter => parameter.Value);
    }

    private static string Serialize(params (string Name, object? Value)[] parameters)
    {
        return UrlSearchParamsSerializer.Serialize(Params(parameters));
    }

    [Fact]
    public void SerializesEmptyParams()
    {
        Assert.Equal("", Serialize());
    }

    [Fact]
    public void SerializesString()
    {
        Assert.Equal("foo=d", Serialize(("foo", "d")));
        Assert.Equal("foo=null", Serialize(("foo", "null")));
        Assert.Equal("foo=undefined", Serialize(("foo", "undefined")));
        Assert.Equal("foo=0", Serialize(("foo", "0")));
    }

    [Fact]
    public void RemovesTheEmptyString()
    {
        Assert.Equal("", Serialize(("foo", "")));
        Assert.Equal("foo=d", Serialize(("foo", "d"), ("bar", "")));
    }

    [Fact]
    public void SerializesInteger()
    {
        Assert.Equal("foo=1", Serialize(("foo", 1)));
        Assert.Equal("foo=0", Serialize(("foo", 0)));
        Assert.Equal("foo=-42", Serialize(("foo", -42)));
    }

    [Fact]
    public void SerializesLargeIntegerWithFullPrecision()
    {
        Assert.Equal("foo=9007199254740993", Serialize(("foo", 9007199254740993L)));
        Assert.Equal("foo=9223372036854775807", Serialize(("foo", long.MaxValue)));
        Assert.Equal("foo=18446744073709551615", Serialize(("foo", ulong.MaxValue)));
    }

    [Fact]
    public void SerializesDouble()
    {
        Assert.Equal("foo=23.8", Serialize(("foo", 23.8)));
        Assert.Equal("foo=-23.8", Serialize(("foo", -23.8)));
        Assert.Equal("foo=0.30000000000000004", Serialize(("foo", 0.1 + 0.2)));
    }

    [Fact]
    public void SerializesDoubleUsingTheEcmascriptNumberFormat()
    {
        Assert.Equal("foo=1", Serialize(("foo", 1.0)));
        Assert.Equal("foo=0", Serialize(("foo", -0.0)));
        Assert.Equal("foo=100", Serialize(("foo", 100.0)));
        Assert.Equal("foo=10000000000000000", Serialize(("foo", 1e16)));
        Assert.Equal("foo=100000000000000000000", Serialize(("foo", 1e20)));
        Assert.Equal("foo=1e%2B21", Serialize(("foo", 1e21)));
        Assert.Equal("foo=0.0001", Serialize(("foo", 0.0001)));
        Assert.Equal("foo=0.000001", Serialize(("foo", 1e-6)));
        Assert.Equal("foo=1e-7", Serialize(("foo", 1e-7)));
        Assert.Equal("foo=5e-324", Serialize(("foo", double.Epsilon)));
        Assert.Equal("foo=1.7976931348623157e%2B308", Serialize(("foo", double.MaxValue)));
    }

    [Fact]
    public void SerializesFloatFromItsOwnShortestRepresentation()
    {
        Assert.Equal("foo=23.8", Serialize(("foo", 23.8f)));
        Assert.Equal("foo=0.1", Serialize(("foo", 0.1f)));
        Assert.Equal("foo=-1.5", Serialize(("foo", -1.5f)));
        Assert.Equal("foo=1", Serialize(("foo", 1f)));
    }

    [Fact]
    public void SerializesDecimalFromItsOwnExactValue()
    {
        Assert.Equal("foo=1.1", Serialize(("foo", 1.10m)));
        Assert.Equal("foo=0", Serialize(("foo", 0.0m)));
        Assert.Equal("foo=-0.5", Serialize(("foo", -0.5m)));
    }

    [Fact]
    public void SerializesBool()
    {
        Assert.Equal("foo=true", Serialize(("foo", true)));
        Assert.Equal("foo=false", Serialize(("foo", false)));
        Assert.Equal("bar=false&foo=true", Serialize(("foo", true), ("bar", false)));
    }

    [Fact]
    public void RemovesNullParams()
    {
        Assert.Equal("", Serialize(("bar", null)));
        Assert.Equal("foo=1", Serialize(("foo", 1), ("bar", null)));
    }

    [Fact]
    public void SerializesTheNullSentinel()
    {
        Assert.Equal("bar=", Serialize(("bar", Null.Value)));
        Assert.Equal("bar=&foo=1", Serialize(("foo", 1), ("bar", Null.Value)));
    }

    [Fact]
    public void SerializesEmptyArray()
    {
        Assert.Equal("bar=", Serialize(("bar", new string[0])));
        Assert.Equal("bar=&foo=1", Serialize(("foo", 1), ("bar", new List<string>())));
    }

    [Fact]
    public void SerializesArrayWithOneValue()
    {
        Assert.Equal("bar=a", Serialize(("bar", new[] { "a" })));
        Assert.Equal("bar=a&foo=1", Serialize(("foo", 1), ("bar", new[] { "a" })));
    }

    [Fact]
    public void SerializesArrayWithManyValues()
    {
        Assert.Equal("bar=a&bar=2&foo=1", Serialize(("foo", 1), ("bar", new[] { "a", "2" })));
        Assert.Equal(
            "bar=null&bar=2&bar=undefined&foo=1",
            Serialize(("foo", 1), ("bar", new[] { "null", "2", "undefined" }))
        );
    }

    [Fact]
    public void SerializesArrayOfMixedValues()
    {
        Assert.Equal("bar=1&bar=a&bar=true", Serialize(("bar", new object[] { 1, "a", true })));
    }

    [Fact]
    public void SerializesDateTime()
    {
        Assert.Equal(
            "foo=1&now=2025-02-24T18%3A44%3A39.000Z",
            Serialize(("foo", 1), ("now", new DateTime(2025, 2, 24, 18, 44, 39, DateTimeKind.Utc)))
        );
    }

    [Fact]
    public void SerializesDateTimeOffsetInUtc()
    {
        Assert.Equal(
            "now=2025-02-24T18%3A44%3A39.000Z",
            Serialize(("now", new DateTimeOffset(2025, 2, 24, 13, 44, 39, TimeSpan.FromHours(-5))))
        );
    }

    [Fact]
    public void ReadsAnUnspecifiedDateTimeAsUtc()
    {
        Assert.Equal(
            "now=2025-02-24T18%3A44%3A39.000Z",
            Serialize(("now", new DateTime(2025, 2, 24, 18, 44, 39)))
        );
    }

    [Fact]
    public void TruncatesSubMillisecondPrecision()
    {
        var now = new DateTime(2025, 2, 24, 18, 44, 39, DateTimeKind.Utc).AddTicks(12_345);

        Assert.Equal("now=2025-02-24T18%3A44%3A39.001Z", Serialize(("now", now)));
    }

    [Fact]
    public void SerializesNestedObjectsToDotPaths()
    {
        Assert.Equal("bar.baz=a&foo=1", Serialize(("foo", 1), ("bar", Params(("baz", "a")))));

        Assert.Equal(
            "bar.baz.x.z=1&foo=1",
            Serialize(("foo", 1), ("bar", Params(("baz", Params(("x", Params(("z", 1))))))))
        );

        Assert.Equal(
            "bar.baz.x.z=&foo=1",
            Serialize(
                ("foo", 1),
                ("bar", Params(("baz", Params(("x", Params(("z", Null.Value)))))))
            )
        );

        Assert.Equal(
            "bar.baz=1&bar.baz=a&foo=1",
            Serialize(("foo", 1), ("bar", Params(("baz", new object[] { 1, "a" }))))
        );
    }

    [Fact]
    public void SerializesEmptyNestedObjectsToNothing()
    {
        Assert.Equal("bar=2", Serialize(("foo", Params()), ("bar", 2)));
        Assert.Equal("bar=2", Serialize(("foo", Params(("x", Params()))), ("bar", 2)));
        Assert.Equal(
            "bar.baz.x.z=",
            Serialize(
                ("foo", Params()),
                (
                    "bar",
                    Params(
                        (
                            "baz",
                            Params(
                                ("x", Params(("z", Null.Value), ("t", Params()))),
                                ("q", Params())
                            )
                        )
                    )
                )
            )
        );
    }

    [Fact]
    public void SortsParamsByUtf16CodeUnit()
    {
        Assert.Equal("A=1&_x=2&a=3&b=4", Serialize(("b", 4), ("a", 3), ("_x", 2), ("A", 1)));
    }

    [Fact]
    public void KeepsArrayElementOrderWhenSorting()
    {
        Assert.Equal("a=1&a=2&a=3&b=4", Serialize(("b", 4), ("a", new[] { "1", "2", "3" })));
    }

    [Fact]
    public void EncodesWithTheFormUrlencodedSerializer()
    {
        Assert.Equal("foo=a+b*%7E%21%C3%A9%E4%B8%AD", Serialize(("foo", "a b*~!\u00E9\u4E2D")));
        Assert.Equal("a+name=x%2Fy%3Fz%3D1%262", Serialize(("a name", "x/y?z=1&2")));
        Assert.Equal("emoji=%F0%9F%98%80", Serialize(("emoji", "\U0001F600")));
    }

    [Fact]
    public void CannotSerializeKeysContainingADot()
    {
        var error = Assert.Throws<UnserializableParamError>(() => Serialize(("foo.bar", 1)));

        Assert.Equal("foo.bar", error.ParamName);
        Assert.Equal(
            "Could not serialize parameter: 'foo.bar' contains one or more dots \".\" in its name which is unsupported",
            error.Message
        );

        Assert.Throws<UnserializableParamError>(() => Serialize(("foo", Params(("bar.baz", 1)))));
    }

    [Fact]
    public void CannotSerializeKeysThatAreNotStrings()
    {
        var parameters = new Dictionary<object, object?> { [1] = "a" };

        Assert.Throws<UnserializableParamError>(
            () => UrlSearchParamsSerializer.Serialize(parameters)
        );
    }

    [Fact]
    public void CannotSerializeNumberPointers()
    {
        Assert.Equal(
            "Could not serialize parameter: 'foo' is Infinity",
            Assert
                .Throws<UnserializableParamError>(() => Serialize(("foo", double.PositiveInfinity)))
                .Message
        );
        Assert.Equal(
            "Could not serialize parameter: 'foo' is -Infinity",
            Assert
                .Throws<UnserializableParamError>(() => Serialize(("foo", double.NegativeInfinity)))
                .Message
        );
        Assert.Equal(
            "Could not serialize parameter: 'foo' is NaN",
            Assert.Throws<UnserializableParamError>(() => Serialize(("foo", double.NaN))).Message
        );
        Assert.Throws<UnserializableParamError>(() => Serialize(("foo", float.NaN)));
        Assert.Throws<UnserializableParamError>(() => Serialize(("foo", float.PositiveInfinity)));
    }

    [Fact]
    public void CannotSerializeOtherObjects()
    {
        Assert.Equal(
            "Could not serialize parameter: 'foo' is a Uri",
            Assert
                .Throws<UnserializableParamError>(
                    () => Serialize(("foo", new Uri("https://example.com")))
                )
                .Message
        );
    }

    [Fact]
    public void CannotSerializeArraysWithUnserializableValues()
    {
        Assert.Equal(
            "Could not serialize parameter: 'foo' is a single element array containing the empty string which is unsupported",
            Assert.Throws<UnserializableParamError>(() => Serialize(("foo", new[] { "" }))).Message
        );

        Assert.Equal(
            "Could not serialize parameter: 'bar' is an array containing the empty string which is unsupported",
            Assert
                .Throws<UnserializableParamError>(() => Serialize(("bar", new[] { "a", "" })))
                .Message
        );

        Assert.Equal(
            "Could not serialize parameter: 'bar' is an array containing null or undefined values which is unsupported",
            Assert
                .Throws<UnserializableParamError>(
                    () => Serialize(("bar", new object?[] { "a", null }))
                )
                .Message
        );

        Assert.Throws<UnserializableParamError>(
            () => Serialize(("bar", new object?[] { "a", Null.Value }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("bar", new object[] { "a", new[] { "s" } }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("bar", new object[] { "a", new string[0] }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("bar", new object[] { "a", Params() }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("bar", new object[] { "a", Params(("x", 2)) }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("foo", 1), ("bar", new[] { "", "a", "" }))
        );
        Assert.Throws<UnserializableParamError>(
            () => Serialize(("foo", 1), ("bar", new[] { "", "", "" }))
        );
    }

    [Fact]
    public void UpdatesExistingSearchParams()
    {
        var searchParams = new UrlSearchParams();
        searchParams.Set("foo", "bar");

        UrlSearchParamsSerializer.Update(
            searchParams,
            Params(("name", "Dax"), ("age", 27), ("tags", new[] { "cars", "planes" }))
        );

        Assert.Equal("age=27&foo=bar&name=Dax&tags=cars&tags=planes", searchParams.ToString());
    }

    [Fact]
    public void SerializesTheReadmeExample()
    {
        IDictionary parameters = new Dictionary<string, object>
        {
            ["name"] = "Dax",
            ["age"] = 27,
            ["isAdmin"] = true,
            ["tags"] = new[] { "cars", "planes" },
        };

        Assert.Equal(
            "age=27&isAdmin=true&name=Dax&tags=cars&tags=planes",
            UrlSearchParamsSerializer.Serialize(parameters)
        );
    }
}
