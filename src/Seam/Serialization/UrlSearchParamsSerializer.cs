using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Seam
{
    /// <summary>
    /// Serializes values to URL search parameters.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is a C# port of the
    /// <see href="https://github.com/seamapi/url-search-params-serializer">@seamapi/url-search-params-serializer</see>
    /// reference implementation, which defines the standard for how the Seam SDKs and other Seam
    /// API consumers serialize objects to URL search parameters in HTTP GET requests. The Seam API
    /// parses them with the corresponding
    /// <see href="https://github.com/seamapi/url-search-params-parser">parser</see>.
    /// </para>
    /// <para>
    /// Output is byte-for-byte identical to the reference implementation: values are encoded with
    /// the application/x-www-form-urlencoded serializer, parameters are sorted by name, and
    /// numbers are formatted using the ECMAScript Number::toString algorithm.
    /// </para>
    /// <para>
    /// Type mapping between the reference implementation and this port:
    /// </para>
    /// <list type="bullet">
    /// <item>JavaScript <c>undefined</c> is <c>null</c>, or simply an absent key.</item>
    /// <item>
    /// JavaScript <c>null</c> is <see cref="Null.Value"/>. C# has a single absence value, so
    /// <c>null</c> means the safe option of omitting the parameter and sending null is always
    /// explicit.
    /// </item>
    /// <item>JavaScript <c>string</c> is <c>string</c> and <c>boolean</c> is <c>bool</c>.</item>
    /// <item>
    /// JavaScript <c>number</c> is <c>float</c> or <c>double</c>, each formatted from its own
    /// shortest round-tripping representation, and <c>bigint</c> is any integral type, which is
    /// always serialized in full without exponent notation. A <c>decimal</c> is serialized from
    /// its own exact value rather than the nearest <c>double</c>.
    /// </item>
    /// <item>
    /// JavaScript <c>Date</c> and <c>Temporal.Instant</c> are <see cref="DateTime"/> and
    /// <see cref="DateTimeOffset"/>. Since <c>Date</c> has millisecond precision, sub-millisecond
    /// precision is truncated. A <see cref="DateTime"/> with an unspecified kind is read as UTC,
    /// so serialization never depends on the local time zone.
    /// </item>
    /// <item>A JavaScript plain object is an <see cref="IDictionary"/> with string keys.</item>
    /// <item>
    /// A JavaScript <c>Array</c> is any other <see cref="IEnumerable"/>, e.g. an array or a
    /// <c>List</c>.
    /// </item>
    /// </list>
    /// </remarks>
    public static class UrlSearchParamsSerializer
    {
        /// <summary>
        /// Serializes parameters to a URL search parameter query string, without a leading
        /// <c>?</c>.
        /// </summary>
        /// <exception cref="UnserializableParamError">
        /// If any parameter could not be serialized.
        /// </exception>
        public static string Serialize(IDictionary parameters)
        {
            var searchParams = new UrlSearchParams();
            Update(searchParams, parameters);

            return searchParams.ToString();
        }

        /// <summary>
        /// Updates existing URL search parameters with serialized parameters.
        /// </summary>
        /// <remarks>
        /// Existing parameters are preserved unless overwritten by a serialized parameter. All
        /// parameters are sorted by name.
        /// </remarks>
        /// <exception cref="UnserializableParamError">
        /// If any parameter could not be serialized.
        /// </exception>
        public static void Update(UrlSearchParams searchParams, IDictionary parameters)
        {
            NestedUpdate(searchParams, parameters, new List<string>());
            searchParams.Sort();
        }

        private static void NestedUpdate(
            UrlSearchParams searchParams,
            IDictionary parameters,
            IList<string> path
        )
        {
            foreach (DictionaryEntry entry in parameters)
            {
                if (!(entry.Key is string key))
                {
                    throw new UnserializableParamError(
                        Convert.ToString(entry.Key, CultureInfo.InvariantCulture) ?? "",
                        "has a name that is not a string which is unsupported"
                    );
                }

                if (key.Contains('.'))
                {
                    throw new UnserializableParamError(
                        key,
                        "contains one or more dots \".\" in its name which is unsupported"
                    );
                }

                var currentPath = new List<string>(path) { key };
                var value = entry.Value;

                if (value is IDictionary nested)
                {
                    NestedUpdate(searchParams, nested, currentPath);
                    continue;
                }

                var name = string.Join(".", currentPath);

                if (value == null)
                {
                    continue;
                }

                if (value is string text && text.Length == 0)
                {
                    continue;
                }

                if (!(value is string) && value is IEnumerable values)
                {
                    UpdateFromEnumerable(searchParams, name, values);
                    continue;
                }

                searchParams.Set(name, SerializeValue(name, value));
            }
        }

        private static void UpdateFromEnumerable(
            UrlSearchParams searchParams,
            string name,
            IEnumerable values
        )
        {
            var items = values.Cast<object>().ToList();

            if (items.Count == 0)
            {
                // The one case where an empty value is meaningful: the parser reads `name=` as
                // the empty array.
                searchParams.Set(name, "");
                return;
            }

            if (items.Count == 1 && IsEmptyString(items[0]))
            {
                throw new UnserializableParamError(
                    name,
                    "is a single element array containing the empty string which is unsupported"
                );
            }

            if (items.Any(IsEmptyString))
            {
                throw new UnserializableParamError(
                    name,
                    "is an array containing the empty string which is unsupported"
                );
            }

            if (items.Any(item => item == null || item is Null))
            {
                throw new UnserializableParamError(
                    name,
                    "is an array containing null or undefined values which is unsupported"
                );
            }

            foreach (var item in items)
            {
                searchParams.Append(name, SerializeValue(name, item));
            }
        }

        private static bool IsEmptyString(object value)
        {
            return value is string text && text.Length == 0;
        }

        private static string SerializeValue(string name, object value)
        {
            if (value is Null)
            {
                return "";
            }

            if (value is string text)
            {
                return text;
            }

            if (value is bool flag)
            {
                return flag ? "true" : "false";
            }

            if (
                value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
            )
            {
                return Convert.ToString(value, CultureInfo.InvariantCulture)!;
            }

            if (value is float single)
            {
                return SerializeSingle(name, single);
            }

            if (value is double number)
            {
                return SerializeDouble(name, number);
            }

            if (value is decimal fixedPoint)
            {
                return SerializeDecimal(fixedPoint);
            }

            if (value is DateTimeOffset dateTimeOffset)
            {
                return SerializeDateTime(dateTimeOffset.UtcDateTime);
            }

            if (value is DateTime dateTime)
            {
                return SerializeDateTime(
                    dateTime.Kind == DateTimeKind.Local ? dateTime.ToUniversalTime() : dateTime
                );
            }

            throw new UnserializableParamError(name, $"is a {value.GetType().Name}");
        }

        private static string SerializeSingle(string name, float value)
        {
            if (float.IsNaN(value))
            {
                throw new UnserializableParamError(name, "is NaN");
            }

            if (float.IsInfinity(value))
            {
                throw new UnserializableParamError(
                    name,
                    value > 0 ? "is Infinity" : "is -Infinity"
                );
            }

            if (value == 0f)
            {
                return "0";
            }

            var formatted = FormatShortestDigits(
                Math.Abs(value).ToString("R", CultureInfo.InvariantCulture)
            );

            return value < 0 ? "-" + formatted : formatted;
        }

        private static string SerializeDouble(string name, double value)
        {
            if (double.IsNaN(value))
            {
                throw new UnserializableParamError(name, "is NaN");
            }

            if (double.IsInfinity(value))
            {
                throw new UnserializableParamError(
                    name,
                    value > 0 ? "is Infinity" : "is -Infinity"
                );
            }

            if (value == 0d)
            {
                return "0";
            }

            var formatted = FormatShortestDigits(
                Math.Abs(value).ToString("R", CultureInfo.InvariantCulture)
            );

            return value < 0 ? "-" + formatted : formatted;
        }

        private static string SerializeDecimal(decimal value)
        {
            if (value == 0m)
            {
                return "0";
            }

            var formatted = FormatShortestDigits(
                Math.Abs(value).ToString(CultureInfo.InvariantCulture)
            );

            return value < 0 ? "-" + formatted : formatted;
        }

        // The shortest round-tripping representation of a positive number, as .NET writes it:
        // significant digits, an optional fraction, and an optional exponent.
        private static readonly Regex NumberPattern = new Regex(
            @"^(\d+)(?:\.(\d+))?(?:E([+-]?\d+))?$",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant
        );

        /// <summary>
        /// Reformats the shortest round-tripping representation of a positive number as the
        /// ECMAScript Number::toString algorithm renders it.
        /// </summary>
        /// <remarks>
        /// .NET writes the same digits but renders them differently: the exponent thresholds are
        /// not at 1e21 and 1e-7, and an exponent is spelled <c>E+16</c> or <c>E-07</c> rather than
        /// <c>e+16</c> or <c>e-7</c>.
        /// </remarks>
        private static string FormatShortestDigits(string representation)
        {
            var match = NumberPattern.Match(representation);

            if (!match.Success)
            {
                throw new InvalidOperationException(
                    $"Could not parse the number representation: {representation}"
                );
            }

            var digits = match.Groups[1].Value + match.Groups[2].Value;
            var point =
                match.Groups[1].Value.Length
                + (
                    match.Groups[3].Success
                        ? int.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture)
                        : 0
                );

            var stripped = digits.TrimStart('0');
            point -= digits.Length - stripped.Length;

            return FormatDigits(stripped.TrimEnd('0'), point);
        }

        /// <summary>
        /// Formats digits and a decimal point position per ECMAScript Number::toString.
        /// </summary>
        /// <param name="digits">Significant digits, without leading or trailing zeros.</param>
        /// <param name="point">Position of the decimal point relative to the digits.</param>
        /// <remarks>
        /// The four branches and the constants 21 and -6 are the specification.
        /// </remarks>
        private static string FormatDigits(string digits, int point)
        {
            var count = digits.Length;

            if (count <= point && point <= 21)
            {
                return digits + new string('0', point - count);
            }

            if (0 < point && point <= 21)
            {
                return digits.Substring(0, point) + "." + digits.Substring(point);
            }

            if (-6 < point && point <= 0)
            {
                return "0." + new string('0', -point) + digits;
            }

            var exponent = point - 1;
            var mantissa = count == 1 ? digits : digits.Substring(0, 1) + "." + digits.Substring(1);

            return mantissa
                + "e"
                + (exponent >= 0 ? "+" : "-")
                + Math.Abs(exponent).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats an instant as JavaScript's Date.prototype.toISOString does: always UTC, always
        /// exactly three fractional digits, always a literal <c>Z</c>.
        /// </summary>
        private static string SerializeDateTime(DateTime value)
        {
            return value.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
        }
    }
}
