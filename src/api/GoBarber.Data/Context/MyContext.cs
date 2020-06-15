using GoBarber.Data.Mapping;
using GoBarber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoBarber.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTokenEntity> UserTokens { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UserTokenEntity>(new UserTokenMap().Configure);
            modelBuilder.Entity<AppointmentEntity>(new AppointmentMap().Configure);
        }
    }
}
