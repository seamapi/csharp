using System.Collections.Generic;
using Co.Seam.Client;

namespace Co.Seam.Client
{
    /// <summary>
    /// <see cref="GlobalConfiguration"/> provides a compile-time extension point for globally configuring
    /// API Clients.
    /// </summary>
    /// <remarks>
    /// A customized implementation via partial class may reside in another file and may
    /// be excluded from automatic generation via a .openapi-generator-ignore file.
    /// </remarks>
    public partial class GlobalSeamRequestConfiguration : SeamRequestConfiguration
    {
        #region Private Members

        private static readonly object GlobalConfigSync = new { };
        private static IReadableSeamRequestConfiguration _globalConfiguration;

        #endregion Private Members

        #region Constructors

        /// <inheritdoc />
        private GlobalSeamRequestConfiguration() { }

        /// <inheritdoc />
        public GlobalSeamRequestConfiguration(
            IDictionary<string, string> defaultHeader,
            // IDictionary<string, string> apiKey,
            // IDictionary<string, string> apiKeyPrefix,
            string basePath = "https://connect.getseam.com"
        )
            : base(defaultHeader, basePath) { }

        static GlobalSeamRequestConfiguration()
        {
            Instance = new GlobalSeamRequestConfiguration();
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the default Configuration.
        /// </summary>
        /// <value>Configuration.</value>
        public static IReadableSeamRequestConfiguration Instance
        {
            get { return _globalConfiguration; }
            set
            {
                lock (GlobalConfigSync)
                {
                    _globalConfiguration = value;
                }
            }
        }
    }
}
