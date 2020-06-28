using AutoMapper;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBarber.Service.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AppointmentResult Delete(int id)
        {
            var result = new AppointmentResult();

            try
            {
                var isDeleted = _unitOfWork.AppointmentRepository.Delete(id);

                if (isDeleted)
                    result.Success = true;
                else
                    result.Success = false;
            }
            catch (Exception)
            {

                result.Success = false;
            }

            return result;
        }

        public AppointmentResult GetById(int id)
        {
            var result = new AppointmentResult();

            try
            {
                var appointment = _unitOfWork.AppointmentRepository.GetById(id);
                var appointmentsDTO = _mapper.Map<AppointmentEntity, AppointmentDTO>(appointment);

                if (appointment != null)
                {
                    result.Success = true;
                    result.Appointment = appointmentsDTO;
                }
                else
                    result.Success = false;
            }
            catch (Exception)
            {

                result.Success = false;
            }

            return result;
        }

        public AppointmentResult GetByProviderId(int providerId)
        {
            var result = new AppointmentResult();

            try
            {
                var appointments = _unitOfWork.AppointmentRepository.GetByProviderId(providerId);
                var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentEntity>, IEnumerable<AppointmentDTO>>(appointments);

                if (appointmentsDTO.Count() > 0)
                {
                    result.Appointments = (IEnumerable<AppointmentDTO>)appointmentsDTO.OrderBy(date => date.Date).ToList();
                }

                result.Success = true;

                return result;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public AppointmentResult GetByProviderIdAndDate(int providerId, DateTime date)
        {
            var result = new AppointmentResult();

            try
            {
                var appointments = _unitOfWork.AppointmentRepository.GetByProviderId(providerId);
                var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentEntity>, IEnumerable<AppointmentDTO>>(appointments);

                var orderedAppointments = appointmentsDTO.Where(x => x.Date.Date.Equals(date.Date)).ToList();

                result.Appointments = orderedAppointments;
                result.Success = true;

            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public AppointmentResult GetByUserId(int userId)
        {
            var result = new AppointmentResult();

            try
            {
                var appointments = _unitOfWork.AppointmentRepository.GetByUserId(userId);
                var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentEntity>, IEnumerable<AppointmentDTO>>(appointments);

                if (appointmentsDTO.Count() > 0)
                {
                    result.Appointments = (IEnumerable<AppointmentDTO>)appointmentsDTO.OrderBy(date => date.Date).ToList();
                }

                result.Success = true;

                return result;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public AppointmentResult Insert(AppointmentEntity appointment)
        {
            var result = new AppointmentResult();

            try
            {
                var createdAppointment = _unitOfWork.AppointmentRepository.Insert(appointment);

                if (createdAppointment != null)
                {
                    _unitOfWork.Commit();
                    var appointmentsDTO = _mapper.Map<AppointmentEntity, AppointmentDTO>(createdAppointment);
                    result.Success = true;
                    result.Appointment = appointmentsDTO;
                }
                else
                {
                    result.Success = false;
                }
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        public AppointmentResult Update(AppointmentEntity appointment)
        {
            var result = new AppointmentResult();

            try
            {
                var updatedAppointment = _unitOfWork.AppointmentRepository.Update(appointment);

                if (updatedAppointment != null)
                {
                    _unitOfWork.Commit();
                    var appointmentsDTO = _mapper.Map<AppointmentEntity, AppointmentDTO>(updatedAppointment);
                    result.Success = true;
                    result.Appointment = appointmentsDTO;
                }
                else
                {
                    result.Success = false;
                }
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }
    }
}
