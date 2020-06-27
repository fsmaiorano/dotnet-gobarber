using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using GoBarber.Web.Helpers;
using GoBarber.Web.Services;
using GoBarber.Web.ViewModels.Appointment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.ViewComponents
{
    [ViewComponent(Name = "AppointmentViewComponent")]
    public class AppointmentViewComponent : ViewComponent
    {
        private IMemoryCache _cache;
        public AppointmentViewComponent(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = (UserDTO)_cache.Get(CacheConstants.User);

            var appointments = await AppointmentService.GetAppointmentsByDate(DateTime.Now.Date ,user.Token);

            var vm = new List<AppointmentViewModel>();

            foreach (var appointment in appointments.Appointments)
            {
                var ap = new AppointmentViewModel
                {
                    UserId = appointment.UserId,
                    User = appointment.User,
                    ProviderId = appointment.ProviderId,
                    Date = appointment.Date
                };

                vm.Add(ap);
            }

            return View("_AppointmentViewComponent", vm);
        }

        public void SelectMonth(){
            var x = 1;
        }
    }
}
