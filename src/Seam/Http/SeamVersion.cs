using System.Reflection;

namespace Seam.Http
{
    /// <summary>
    /// The SDK package version, read from the assembly so it always matches the version the
    /// package was built as.
    /// </summary>
    internal static class SeamVersion
    {
        public static string Value { get; } = Read();

        private static string Read()
        {
            var version = typeof(SeamVersion)
                .Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

            if (version == null)
                return "unknown";

            // Strip source-link build metadata, e.g. "1.2.3+abc123" -> "1.2.3".
            var metadataStart = version.IndexOf('+');

            return metadataStart < 0 ? version : version[..metadataStart];
        }
    }
}
