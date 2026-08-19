using System.Collections.Generic;

namespace Seam.Http
{
    /// <summary>
    /// Builds the authorization headers for a Seam client.
    /// </summary>
    /// <remarks>
    /// Two authentication methods are supported: an API key, which is scoped to a single
    /// workspace, and a personal access token, which is scoped to a Seam Console user and must
    /// name the workspace it acts on.
    /// </remarks>
    internal static class Auth
    {
        public static Dictionary<string, string> GetAuthHeaders(
            string? apiKey,
            string? personalAccessToken,
            string? workspaceId
        )
        {
            // The environment is only consulted when no credential was passed at all, so an
            // explicit personal access token is not second guessed by a stray SEAM_API_KEY.
            if (apiKey == null && personalAccessToken == null)
            {
                apiKey = Options.GetEnv("SEAM_API_KEY");
                personalAccessToken = Options.GetEnv("SEAM_PERSONAL_ACCESS_TOKEN");

                if (apiKey != null && personalAccessToken != null)
                    throw new SeamInvalidOptionsException(
                        "Both SEAM_API_KEY and SEAM_PERSONAL_ACCESS_TOKEN environment variables are defined. "
                            + "Please use only one authentication method."
                    );
            }

            workspaceId ??= Options.GetEnv("SEAM_WORKSPACE_ID");

            if (Options.IsSeamOptionsWithApiKey(apiKey, personalAccessToken))
                return GetAuthHeadersForApiKey(apiKey!);

            if (
                Options.IsSeamOptionsWithPersonalAccessToken(
                    personalAccessToken,
                    apiKey,
                    workspaceId
                )
            )
            {
                return GetAuthHeadersForPersonalAccessToken(personalAccessToken!, workspaceId!);
            }

            throw new SeamInvalidOptionsException(
                "Must specify an ApiKey or PersonalAccessToken. "
                    + "Attempted reading configuration from the environment, but neither the "
                    + "SEAM_API_KEY nor the SEAM_PERSONAL_ACCESS_TOKEN environment variable is set."
            );
        }

        /// <summary>
        /// Builds the headers for a client that is not scoped to a workspace, falling back to
        /// the environment when no token is given.
        /// </summary>
        public static Dictionary<string, string> GetAuthHeadersWithoutWorkspace(
            string? personalAccessToken
        )
        {
            personalAccessToken ??= Options.GetEnv("SEAM_PERSONAL_ACCESS_TOKEN");

            if (personalAccessToken == null)
                throw new SeamInvalidOptionsException(
                    "Must specify a PersonalAccessToken. "
                        + "Attempted reading configuration from the environment, "
                        + "but the environment variable SEAM_PERSONAL_ACCESS_TOKEN is not set."
                );

            AssertPersonalAccessToken(personalAccessToken);

            return new Dictionary<string, string>
            {
                ["authorization"] = $"Bearer {personalAccessToken}",
            };
        }

        public static Dictionary<string, string> GetAuthHeadersForApiKey(string apiKey)
        {
            if (Token.IsClientSessionToken(apiKey))
                throw new SeamInvalidTokenException(
                    "A Client Session Token cannot be used as an ApiKey"
                );

            if (Token.IsJwt(apiKey))
                throw new SeamInvalidTokenException("A JWT cannot be used as an ApiKey");

            if (Token.IsAccessToken(apiKey))
                throw new SeamInvalidTokenException("An Access Token cannot be used as an ApiKey");

            if (Token.IsPublishableKey(apiKey))
                throw new SeamInvalidTokenException(
                    "A Publishable Key cannot be used as an ApiKey"
                );

            if (!Token.IsSeamToken(apiKey))
                throw new SeamInvalidTokenException("Unknown or invalid ApiKey format");

            return new Dictionary<string, string> { ["authorization"] = $"Bearer {apiKey}" };
        }

        public static Dictionary<string, string> GetAuthHeadersForPersonalAccessToken(
            string personalAccessToken,
            string workspaceId
        )
        {
            AssertPersonalAccessToken(personalAccessToken);

            return new Dictionary<string, string>
            {
                ["authorization"] = $"Bearer {personalAccessToken}",
                ["seam-workspace"] = workspaceId,
            };
        }

        private static void AssertPersonalAccessToken(string token)
        {
            if (Token.IsClientSessionToken(token))
                throw new SeamInvalidTokenException(
                    "A Client Session Token cannot be used as a PersonalAccessToken"
                );

            if (Token.IsJwt(token))
                throw new SeamInvalidTokenException(
                    "A JWT cannot be used as a PersonalAccessToken"
                );

            if (Token.IsPublishableKey(token))
                throw new SeamInvalidTokenException(
                    "A Publishable Key cannot be used as a PersonalAccessToken"
                );

            if (!Token.IsAccessToken(token))
                throw new SeamInvalidTokenException(
                    "Unknown or invalid PersonalAccessToken format"
                );
        }
    }
}
