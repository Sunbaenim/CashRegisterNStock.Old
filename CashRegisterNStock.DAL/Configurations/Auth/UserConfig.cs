using CashRegisterNStock.DAL.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterNStock.DAL.Configurations.Auth
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired();

            builder.Property(u => u.Salt)
                .IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Salt).IsUnique();
        }
    }
}
