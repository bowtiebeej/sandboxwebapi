using System;
using System.Collections.Specialized;
using static System.Configuration.ConfigurationManager;

namespace WebApiSandbox.Repository
{
    internal static class ConnectionString
    {
        public static string Get()
        {
            return ConnectionStrings["SandboxApiConn"].ConnectionString;
        }
    }
}
