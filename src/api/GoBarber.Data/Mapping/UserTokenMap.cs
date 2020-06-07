using GoBarber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Data.Mapping
{
    public class UserTokenMap : IEntityTypeConfiguration<UserTokenEntity>
    {
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder.ToTable("user_tokens");

            builder.Property(p => p.Token).IsRequired().HasMaxLength(500).HasColumnName("token");
            builder.Property(p => p.UserId).IsRequired().HasColumnName("user_id");

            builder.HasOne(u => u.User).WithOne(t => t.Token);
        }
    }
}
