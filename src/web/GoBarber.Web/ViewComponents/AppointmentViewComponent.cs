using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using GoBarber.Web.Helpers;
using GoBarber.Web.Services;
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

            var appointments = await AppointmentService.GetAppointments(user.Token);

            return View("_AppointmentViewComponent", appointments);
        }
    }
}
