using GoBarber.DTO.Appointment;
using GoBarber.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Services
{
  public static class AppointmentService
  {
    public static async Task<AppointmentResult> GetAppointments(string token = "")
    {
      return (AppointmentResult)await HttpHelper.HttpGetAsync<AppointmentResult>(ApiConstants.AppointmentUrl, token);
    }

    public static async Task<AppointmentResult> GetAppointmentsByDate(DateTime date, string token = "")
    {
        var url = ApiConstants.AppointmentUrl+ '/' + date.ToString("dd-MM-yyyy");
      return (AppointmentResult)await HttpHelper.HttpGetAsync<AppointmentResult>(url, token);
    }
  }
}
