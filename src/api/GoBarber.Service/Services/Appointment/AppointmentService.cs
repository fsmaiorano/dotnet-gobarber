using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Service.Services.Appointment
{
    public class AppointmentService: IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        public AppointmentService(IUnitOfWork unitOfWork)        {
            _unitOfWork = unitOfWork;
        }
    }
}
