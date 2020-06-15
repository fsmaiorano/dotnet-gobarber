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
        private IRepository<AppointmentEntity> _repository;
        private IUserRepository<AppointmentEntity> _appointmentRepository;
        private IUnitOfWork _unitOfWork;
        public AppointmentService(IRepository<AppointmentEntity> repository, IUserRepository<AppointmentEntity> appointmentRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
