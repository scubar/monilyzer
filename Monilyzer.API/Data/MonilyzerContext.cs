﻿using Microsoft.EntityFrameworkCore;
using Monilyzer.Model;

namespace Monilyzer.API.Data
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

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<AlertDefinition> AlertDefinitions { get; set; }

        public DbSet<ActiveAlert> ActiveAlerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
