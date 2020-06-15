using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Data.Repository
{
    public class AppointmentRepository<T> : IAppointmentRepository<T> where T : AppointmentEntity
    {
    }
}
