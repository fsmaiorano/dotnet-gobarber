using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        AppointmentEntity GetById(Int32 id);
        IEnumerable<AppointmentEntity> GetByUserId(Int32 userId);
        IEnumerable<AppointmentEntity> GetByProviderId(Int32 providerId);

        IEnumerable<AppointmentEntity> SelectAll();

        AppointmentEntity Insert(AppointmentEntity user);

        AppointmentEntity Update(AppointmentEntity user);

        bool Delete(Int32 id);
    }
}
