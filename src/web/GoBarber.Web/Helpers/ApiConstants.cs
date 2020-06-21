using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Helpers
{
    public static class ApiConstants
    {
        public static string ApiHost = "https://localhost:5001";
        public static string SignInUrl = $"{ApiHost}/api/Authentication";
        public static string SignUpUrl = $"{ApiHost}/api/Authentication";
    }
}
