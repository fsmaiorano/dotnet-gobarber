using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces
{
    public interface IAppointmentRepository: IRepository<AppointmentEntity>
    {
    }
}
