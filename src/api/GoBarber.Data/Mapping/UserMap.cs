using GoBarber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>  
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60).HasColumnName("name");
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100).HasColumnName("password");
            builder.Property(p => p.Avatar).HasMaxLength(500).HasColumnName("avatar");
        }
    }
}
