using System;

namespace Seam.Http
{
    /// <summary>
    /// Resolves the API endpoint and validates mutually exclusive authentication options.
    /// </summary>
    internal static class Options
    {
        public const string DefaultEndpoint = "https://connect.getseam.com";

        public static string GetEndpoint(string? endpoint = null) =>
            endpoint ?? GetEnv("SEAM_ENDPOINT") ?? DefaultEndpoint;

        public static bool IsSeamOptionsWithApiKey(string? apiKey, string? personalAccessToken)
        {
            if (apiKey == null)
                return false;

            if (personalAccessToken != null)
                throw new SeamInvalidOptionsException(
                    "The PersonalAccessToken option cannot be used with the ApiKey option"
                );

            return true;
        }

        public static bool IsSeamOptionsWithPersonalAccessToken(
            string? personalAccessToken,
            string? apiKey,
            string? workspaceId
        )
        {
            if (personalAccessToken == null)
                return false;

            if (apiKey != null)
                throw new SeamInvalidOptionsException(
                    "The ApiKey option cannot be used with the PersonalAccessToken option"
                );

            if (workspaceId == null)
                throw new SeamInvalidOptionsException(
                    "Must pass a WorkspaceId when using a PersonalAccessToken"
                );

            return true;
        }

        /// <summary>
        /// A preconfigured client carries its own endpoint and authorization, so an option that
        /// would configure one is a mistake to combine with it, and is rejected rather than
        /// silently ignored.
        /// </summary>
        /// <param name="httpClient">The preconfigured client, or null when not given.</param>
        /// <param name="options">The other options by name, where null means not given.</param>
        public static void CheckHttpClientOptions(
            object? httpClient,
            params (string Name, object? Value)[] options
        )
        {
            if (httpClient == null)
                return;

            foreach (var (name, value) in options)
            {
                if (value != null)
                    throw new SeamInvalidOptionsException(
                        $"The {name} option cannot be used with the HttpClient option"
                    );
            }
        }

        /// <summary>
        /// Reads an environment variable, treating an empty value as unset so that an
        /// exported-but-blank variable does not override the default.
        /// </summary>
        public static string? GetEnv(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);

            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
