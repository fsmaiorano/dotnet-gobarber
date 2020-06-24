using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        IEnumerable<AppointmentEntity> GetByUserId(int userId);
        IEnumerable<AppointmentEntity> GetByProviderId(int providerId);
    }
}

