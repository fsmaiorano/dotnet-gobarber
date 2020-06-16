using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GoBarber.Data.Repository
{
    public class AppointmentRepository : Repository<AppointmentEntity>, IAppointmentRepository
    {
        private readonly DbSet<AppointmentEntity> _dataset;

        public AppointmentRepository(MyContext context) : base(context)
        {
            _dataset = _context.Set<AppointmentEntity>();
        }

        public AppointmentEntity GetByProviderId(int providerId)
        {
            return _dataset.SingleOrDefault(x => x.ProviderId.Equals(providerId));
        }

        public AppointmentEntity GetByUserId(int userId)
        {
            return _dataset.SingleOrDefault(x => x.UserId.Equals(userId));
        }
    }
}
