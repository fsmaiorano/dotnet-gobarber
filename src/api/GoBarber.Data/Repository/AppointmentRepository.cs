using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<AppointmentEntity> GetByProviderId(int providerId)
        {
            return _dataset.Where(x => x.ProviderId.Equals(providerId)).Include(x=>x.User).Include(y=>y.Provider).ToList();
        }

        public IEnumerable<AppointmentEntity> GetByUserId(int userId)
        {
            return _dataset.Where(x => x.UserId.Equals(userId)).Include(x => x.User).Include(y => y.Provider).ToList();
        }
    }
}
