using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Seam
{
    /// <summary>
    /// A mutable collection of URL search parameters.
    /// </summary>
    /// <remarks>
    /// Implements the parts of the
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/API/URLSearchParams">URLSearchParams</see>
    /// interface needed to serialize parameters to a query string. Unlike a dictionary, a name may
    /// appear more than once, which is how arrays are serialized.
    /// </remarks>
    public class UrlSearchParams : IEnumerable<KeyValuePair<string, string>>
    {
        private List<KeyValuePair<string, string>> _pairs =
            new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Creates an empty collection.
        /// </summary>
        public UrlSearchParams() { }

        /// <summary>
        /// Creates a collection from a query string, with or without a leading <c>?</c>.
        /// </summary>
        public UrlSearchParams(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return;
            }

            var pairs = query.StartsWith("?", StringComparison.Ordinal)
                ? query.Substring(1)
                : query;

            foreach (var pair in pairs.Split('&'))
            {
                if (pair.Length == 0)
                {
                    continue;
                }

                var separator = pair.IndexOf('=');
                var name = separator < 0 ? pair : pair.Substring(0, separator);
                var value = separator < 0 ? string.Empty : pair.Substring(separator + 1);

                Append(DecodeFormComponent(name), DecodeFormComponent(value));
            }
        }

        /// <summary>
        /// Creates a collection from name-value pairs, in order.
        /// </summary>
        public UrlSearchParams(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            _pairs = pairs.ToList();
        }

        /// <summary>
        /// The number of pairs in the collection.
        /// </summary>
        public int Count => _pairs.Count;

        /// <summary>
        /// Appends a name-value pair, keeping any existing pairs with this name.
        /// </summary>
        public void Append(string name, string value)
        {
            _pairs.Add(new KeyValuePair<string, string>(name, value));
        }

        /// <summary>
        /// Sets the value associated with a name.
        /// </summary>
        /// <remarks>
        /// Replaces the first pair with this name and removes any others, so the pair keeps its
        /// position. Appends a new pair if no pair with this name exists.
        /// </remarks>
        public void Set(string name, string value)
        {
            var pairs = new List<KeyValuePair<string, string>>(_pairs.Count);
            var isSet = false;

            foreach (var pair in _pairs)
            {
                if (pair.Key != name)
                {
                    pairs.Add(pair);
                    continue;
                }

                if (isSet)
                {
                    continue;
                }

                pairs.Add(new KeyValuePair<string, string>(name, value));
                isSet = true;
            }

            if (!isSet)
            {
                pairs.Add(new KeyValuePair<string, string>(name, value));
            }

            _pairs = pairs;
        }

        /// <summary>
        /// Returns the value of the first pair with this name, or null if no pair with this name
        /// exists.
        /// </summary>
        public string? Get(string name)
        {
            foreach (var pair in _pairs)
            {
                if (pair.Key == name)
                {
                    return pair.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the values of all pairs with this name, in insertion order.
        /// </summary>
        public IList<string> GetAll(string name)
        {
            return _pairs.Where(pair => pair.Key == name).Select(pair => pair.Value).ToList();
        }

        /// <summary>
        /// Returns whether a pair with this name exists.
        /// </summary>
        public bool Has(string name)
        {
            return _pairs.Any(pair => pair.Key == name);
        }

        /// <summary>
        /// Removes all pairs with this name.
        /// </summary>
        public void Delete(string name)
        {
            _pairs = _pairs.Where(pair => pair.Key != name).ToList();
        }

        /// <summary>
        /// Sorts all pairs by name, comparing UTF-16 code units.
        /// </summary>
        /// <remarks>
        /// Sorting is stable, so the relative order of pairs with the same name is preserved,
        /// which is what keeps array element order.
        /// </remarks>
        public void Sort()
        {
            _pairs = _pairs.OrderBy(pair => pair.Key, StringComparer.Ordinal).ToList();
        }

        /// <summary>
        /// Serializes all pairs to a query string, without a leading <c>?</c>.
        /// </summary>
        /// <remarks>
        /// Every pair gets an <c>=</c>, including empty values, e.g. <c>name=</c>.
        /// </remarks>
        public override string ToString()
        {
            return string.Join(
                "&",
                _pairs.Select(pair =>
                    EncodeFormComponent(pair.Key) + "=" + EncodeFormComponent(pair.Value)
                )
            );
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Percent-encodes a string with the WHATWG application/x-www-form-urlencoded serializer,
        /// applied to the UTF-8 bytes of the string.
        /// </summary>
        /// <remarks>
        /// The safe set is not the RFC 3986 unreserved set, so neither <c>Uri.EscapeDataString</c>
        /// nor <c>WebUtility.UrlEncode</c> produces it: <c>*</c> is emitted literally and <c>~</c>
        /// is escaped, the exact opposite of the former, and the latter emits lowercase hex.
        /// </remarks>
        private static string EncodeFormComponent(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var encoded = new StringBuilder(bytes.Length);

            foreach (var b in bytes)
            {
                if (IsFormSafe(b))
                {
                    encoded.Append((char)b);
                }
                else if (b == 0x20)
                {
                    encoded.Append('+');
                }
                else
                {
                    encoded.Append('%').Append(b.ToString("X2", CultureInfo.InvariantCulture));
                }
            }

            return encoded.ToString();
        }

        private static bool IsFormSafe(byte b)
        {
            return (b >= 0x30 && b <= 0x39)
                || (b >= 0x41 && b <= 0x5a)
                || (b >= 0x61 && b <= 0x7a)
                || b == (byte)'*'
                || b == (byte)'-'
                || b == (byte)'.'
                || b == (byte)'_';
        }

        private static string DecodeFormComponent(string value)
        {
            var bytes = new List<byte>(value.Length);
            var literal = new StringBuilder();

            for (var index = 0; index < value.Length; index++)
            {
                var character = value[index];

                if (
                    character == '%'
                    && index + 2 < value.Length
                    && byte.TryParse(
                        value.Substring(index + 1, 2),
                        NumberStyles.HexNumber,
                        CultureInfo.InvariantCulture,
                        out var decoded
                    )
                )
                {
                    bytes.AddRange(Encoding.UTF8.GetBytes(literal.ToString()));
                    literal.Clear();
                    bytes.Add(decoded);
                    index += 2;
                    continue;
                }

                literal.Append(character == '+' ? ' ' : character);
            }

            bytes.AddRange(Encoding.UTF8.GetBytes(literal.ToString()));

            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
}
