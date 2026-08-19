namespace Seam.Http
{
    /// <summary>
    /// Predicates for recognizing the kinds of token the Seam API issues.
    /// </summary>
    /// <remarks>
    /// Only API keys and personal access tokens authenticate this SDK. The other kinds are
    /// recognized so that passing one produces a specific error instead of an opaque 401 from
    /// the server.
    /// </remarks>
    internal static class Token
    {
        public const string TokenPrefix = "seam_";

        public const string AccessTokenPrefix = "seam_at";

        public const string ClientSessionTokenPrefix = "seam_cst";

        public const string PublishableKeyPrefix = "seam_pk";

        public const string JwtPrefix = "ey";

        public static bool IsSeamToken(string token) => token.StartsWith(TokenPrefix);

        public static bool IsAccessToken(string token) => token.StartsWith(AccessTokenPrefix);

        public static bool IsClientSessionToken(string token) =>
            token.StartsWith(ClientSessionTokenPrefix);

        public static bool IsPublishableKey(string token) => token.StartsWith(PublishableKeyPrefix);

        public static bool IsJwt(string token) => token.StartsWith(JwtPrefix);

        public static bool IsConsoleSessionToken(string token) => IsJwt(token);

        public static bool IsPersonalAccessToken(string token) => IsAccessToken(token);

        public static bool IsApiKey(string token) =>
            !IsClientSessionToken(token)
            && !IsJwt(token)
            && !IsAccessToken(token)
            && !IsPublishableKey(token)
            && IsSeamToken(token);
    }
}
