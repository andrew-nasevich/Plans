using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plans.DomainModel.Plans;
using Plans.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Repositories.DbContexts
{
    public class PlansDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users { get; set; }

        public DbSet<Plan> Plans { get; set; }

        public DbSet<PlanPeriod> PlanPeriods { get; set; }


        public PlansDbContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Plans"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlanPeriod>()
                .HasOne(pp => pp.Plan)
                .WithMany(p => p.PlanPeriods)
                .HasForeignKey(pp => pp.PlanId);

            modelBuilder.Entity<Plan>()
                 .HasOne(p => p.User)
                 .WithMany(u => u.Plans)
                 .HasForeignKey(p => p.UserId);
        }
    }
}