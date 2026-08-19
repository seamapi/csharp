using System.Collections;

namespace Seam
{
    /// <summary>
    /// Serializes parameters for the Seam API: the URL search parameters standard plus
    /// <c>_strict=true</c> appended to any non-empty query, which tells the API to use strict,
    /// schema-aware parsing. A query with no serializable parameters remains empty.
    /// </summary>
    /// <remarks>
    /// The strict flag is Seam API behavior, not part of the serialization standard, so it lives
    /// here rather than in <see cref="UrlSearchParamsSerializer"/>, which stays a pure
    /// implementation of the standard.
    /// </remarks>
    public static class StrictUrlSearchParamsSerializer
    {
        /// <summary>
        /// Serializes parameters to a URL search parameter query string with strict API
        /// validation enabled, without a leading <c>?</c>.
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
        /// Updates existing URL search parameters with serialized parameters and strict API
        /// validation enabled.
        /// </summary>
        /// <exception cref="UnserializableParamError">
        /// If any parameter could not be serialized.
        /// </exception>
        public static void Update(UrlSearchParams searchParams, IDictionary parameters)
        {
            UrlSearchParamsSerializer.Update(searchParams, parameters);

            if (searchParams.Count > 0)
            {
                searchParams.Delete("_strict");
                searchParams.Append("_strict", "true");
            }
        }
    }
}
