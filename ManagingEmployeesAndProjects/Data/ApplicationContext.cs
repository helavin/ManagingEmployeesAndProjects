using ManagingEmployeesAndProjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingEmployeesAndProjects.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Subdivision>().ToTable("Subdivision");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<ProjectEmployee>().ToTable("ProjectEmployee");

            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder
        //    //    .UseLazyLoadingProxies()
        //    //    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=managingdb;Trusted_Connection=True;");

        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=managingdb;Trusted_Connection=True;");
        //}
    }
}
