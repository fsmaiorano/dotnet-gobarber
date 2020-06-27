﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoBarber.Application.Config;
using GoBarber.Application.Helpers;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using GoBarber.Service.Services.Appointment;
using GoBarber.Service.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GoBarber.Application.Controllers.Appointment
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class AppointmentController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IOptions<AppSettings> _appSettings;
    private readonly IAppointmentService _appointmentService;
    private readonly ILogger<AppointmentController> _logger;

    public AppointmentController(ILogger<AppointmentController> logger, IOptions<AppSettings> appSettings, IAppointmentService appointmentService, IMapper mapper)
    {
      _mapper = mapper;
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
          return null;
        }

        var appointments = _appointmentService.GetByProviderId(Convert.ToInt32(userId));
        var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentEntity>, IEnumerable<AppointmentDTO>>(appointments);


        result.Success = true;
        result.Appointments = (IEnumerable<AppointmentDTO>)appointmentsDTO.OrderBy(date => date.Date).ToList();
      }
      catch (Exception)
      {

        result.Success = false;
      }

      return result;
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
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
