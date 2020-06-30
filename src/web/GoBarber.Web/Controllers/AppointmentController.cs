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

        public async Task<PartialViewResult> AppointmentsList(string date)
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

            return PartialView("_AppointmentsList", vm);
        }


        [HttpGet("AppointmentDetail/{id}")]
        public async Task<PartialViewResult> AppointmentDetail(AppointmentViewModel vm)
        {
            var user = (UserDTO)_cache.Get(CacheConstants.User);

            var appointments = await AppointmentService.GetAppointmentsById(vm.Id, user.Token);

            //var vm = new List<AppointmentViewModel>();

            //foreach (var appointment in appointments.Appointments)
            //{
            //    var ap = new AppointmentViewModel
            //    {
            //        UserId = appointment.UserId,
            //        User = appointment.User,
            //        ProviderId = appointment.ProviderId,
            //        Date = appointment.Date
            //    };

            //    vm.Add(ap);
            //}

            return PartialView("_AppointmentsDetail");
        }
    }
}