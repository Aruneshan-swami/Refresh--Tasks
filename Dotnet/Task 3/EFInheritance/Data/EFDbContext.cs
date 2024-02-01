using EFInheritance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFInheritance.Data
{
    public class EFDbContext: DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees{get;set;}   
        public DbSet<Manager> Managers  {get;set;}
        public DbSet<Developer> Developers{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("Default"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Heirarchy
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Manager>().Property(m => m.Department).HasMaxLength(50);
            modelBuilder.Entity<Developer>().Property(m => m.softWare).HasMaxLength(50);
        }
    }
}