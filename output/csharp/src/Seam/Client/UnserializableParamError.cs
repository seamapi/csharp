using System;

namespace Seam.Client
{
    /// <summary>
    /// Thrown when a request parameter could not be serialized, before any request is sent.
    /// </summary>
    public class UnserializableParamError : ArgumentException
    {
        private readonly string _paramName;

        /// <param name="paramName">
        /// The name of the parameter that could not be serialized, e.g. <c>foo.bar</c> for a
        /// nested parameter.
        /// </param>
        /// <param name="reason">Why the parameter could not be serialized.</param>
        public UnserializableParamError(string paramName, string reason)
            : base($"Could not serialize parameter: '{paramName}' {reason}")
        {
            _paramName = paramName;
        }

        public override string ParamName => _paramName;
    }
}
