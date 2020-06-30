using AutoMapper;
using GoBarber.Application.Config;
using GoBarber.Application.Helpers;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoBarber.Application.Controllers.Appointment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger, IOptions<AppSettings> appSettings, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appSettings = appSettings;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public AppointmentResult Get()
        {
            var result = new AppointmentResult();

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                var userId = TokenHelper.GetUserIdByToken(token);

                if (string.IsNullOrEmpty(userId))
                {
                    result.Success = false;
                }
                else
                {
                    var response = _appointmentService.GetByProviderId(Convert.ToInt32(userId));

                    if (response.Success)
                    {
                        result.Appointments = response.Appointments;
                        result.Success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpGet("{date}")]
        public AppointmentResult Get(string date)
        {
            var result = new AppointmentResult();

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString();
                var userId = TokenHelper.GetUserIdByToken(token);

                if (string.IsNullOrEmpty(userId))
                {
                    result.Success = false;
                }
                else
                {
                    var response = _appointmentService.GetByProviderId(Convert.ToInt32(userId));

                    if (response.Success)
                    {
                        var formattedDate = DateTime.Parse(date.ToString());
                        result.Appointments = response.Appointments.Where(x => x.Date.Date.Equals(formattedDate)).ToList();
                        result.Success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPost]

        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
