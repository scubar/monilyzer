using System;
using Microsoft.EntityFrameworkCore;
using Monilyzer.Model;

namespace Monilyzer.Data
{
    public class MonilyzerContext : DbContext
    {
        public MonilyzerContext(DbContextOptions<MonilyzerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Node> Nodes { get; set; }

        public DbSet<Volume> Volumes { get; set; }

        public DbSet<Interface> Interfaces { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserGuid, t.RoleGuid });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserGuid);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleGuid);
        }
    }
}
