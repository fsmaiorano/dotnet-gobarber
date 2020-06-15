using GoBarber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace GoBarber.Data.Mapping
{
    public class AppointmentMap : IEntityTypeConfiguration<AppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            builder.ToTable("appointments");

            builder.HasOne(u => u.Provider).WithMany().HasForeignKey(u => u.ProviderId).IsRequired(true).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(u => u.User).WithMany().HasForeignKey(u => u.UserId).IsRequired(true).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
