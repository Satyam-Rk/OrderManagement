using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).IsRequired().HasMaxLength(100);

                entity.Property(x => x.PasswordHash).IsRequired();

                entity.Property(x => x.RoleId).IsRequired();

                entity.OwnsOne(x => x.Email, email =>
                {
                    email.Property(e => e.Value).HasColumnName("Email").IsRequired();
                });
            });
        }
    }
}
