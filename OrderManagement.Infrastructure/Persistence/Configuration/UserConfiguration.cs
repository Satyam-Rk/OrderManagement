using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PasswordHash).IsRequired();

            builder.Property(x => x.RoleId).IsRequired();

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").IsRequired();
            });
        }
    }
}
