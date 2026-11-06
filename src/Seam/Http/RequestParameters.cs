using System;
using System.Linq;

namespace Seam.Http
{
    internal static class RequestParameters
    {
        internal static void RequireAtLeastOne(string path, params bool[] parametersGiven)
        {
            if (parametersGiven.Any(parameterGiven => parameterGiven))
                return;

            throw new ArgumentException($"At least one parameter is required for {path}");
        }
    }
}
