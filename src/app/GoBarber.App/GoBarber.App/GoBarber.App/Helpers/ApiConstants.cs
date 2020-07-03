using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.App.Helpers
{
    public static class ApiConstants
    {
        public static string ApiHost = "https://localhost:5001";
        public static string SignInUrl = $"{ApiHost}/api/Authentication";
        public static string SignUpUrl = $"{ApiHost}/api/User";
        public static string AppointmentUrl = $"{ApiHost}/api/Appointment";
    }
}
