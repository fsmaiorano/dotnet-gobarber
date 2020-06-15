using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoBarber.Data.Repository
{
    public class AppointmentRepository : Repository<AppointmentEntity>, IAppointmentRepository
    {
        private DbSet<AppointmentEntity> _dataset;

        public AppointmentRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<AppointmentEntity>();
        }
    }
}
