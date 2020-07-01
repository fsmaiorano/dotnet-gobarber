using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using GoBarber.Web.Helpers;
using GoBarber.Web.Services;
using GoBarber.Web.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Controllers
{
    [Route("appointment")]
    public class AppointmentController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger, IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _logger = logger;
        }

        [HttpGet("AppointmentList")]

        public async Task<PartialViewResult> AppointmentList(string date)
        {
            var user = (UserDTO)_cache.Get(CacheConstants.User);

            var appointments = await AppointmentService.GetAppointmentsByDate(date, user.Token);

            var vm = new List<AppointmentViewModel>();

            foreach (var appointment in appointments.Appointments)
            {
                var ap = new AppointmentViewModel
                {
                    Id = appointment.Id,
                    UserId = appointment.UserId,
                    User = appointment.User,
                    ProviderId = appointment.ProviderId,
                    Date = appointment.Date
                };

                vm.Add(ap);
            }

            _cache.Set<List<AppointmentViewModel>>(CacheConstants.Daily, vm);

            return PartialView("_AppointmentList", vm);
        }


        [HttpGet("AppointmentDetail/{id}")]
        public PartialViewResult AppointmentDetail(AppointmentViewModel vm)
        {
            var user = (UserDTO)_cache.Get(CacheConstants.User);
            var appointments = _cache.Get<List<AppointmentViewModel>>(CacheConstants.Daily);

            var appointment = appointments.Where(x => x.Id.Equals(vm.Id)).FirstOrDefault();

            vm.UserId = appointment.UserId;
            vm.User = appointment.User;
            vm.ProviderId = appointment.ProviderId;
            vm.Date = appointment.Date;

            return PartialView("_AppointmentDetail", vm);
        }
    }
}