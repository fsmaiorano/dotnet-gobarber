using GoBarber.Domain.Entities;
using GoBarber.DTO.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        AppointmentResult Delete(Int32 id);
        AppointmentResult Insert(AppointmentEntity user);
        AppointmentResult Update(AppointmentEntity user);
        AppointmentResult GetById(Int32 id);
        AppointmentResult GetByUserId(Int32 userId);
        AppointmentResult GetByProviderId(Int32 providerId);
        AppointmentResult GetByProviderIdAndDate(Int32 providerId, DateTime date);
    }
}
