using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Service.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            return _unitOfWork.AppointmentRepository.Delete(id);
        }

        public AppointmentEntity GetById(int id)
        {
            return _unitOfWork.AppointmentRepository.GetById(id);
        }

        public AppointmentEntity GetByProviderId(int providerId)
        {
            return _unitOfWork.AppointmentRepository.GetByProviderId(providerId);
        }

        public AppointmentEntity GetByUserId(int userId)
        {
            return _unitOfWork.AppointmentRepository.GetByUserId(userId);
        }

        public AppointmentEntity Insert(AppointmentEntity appointment)
        {
            var createdAppointment = _unitOfWork.AppointmentRepository.Insert(appointment);
            _unitOfWork.Commit();
            return createdAppointment;
        }

        public IEnumerable<AppointmentEntity> SelectAll()
        {
            return _unitOfWork.AppointmentRepository.GetAll();
        }

        public AppointmentEntity Update(AppointmentEntity appointment)
        {
            var updatedAppointment = _unitOfWork.AppointmentRepository.Update(appointment);
            _unitOfWork.Commit();
            return updatedAppointment;
        }
    }
}
