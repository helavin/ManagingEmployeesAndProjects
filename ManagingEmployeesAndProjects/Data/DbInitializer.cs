using ManagingEmployeesAndProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingEmployeesAndProjects.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Subdivisions.
            if (context.Subdivisions.Any())
            {
                return;   // DB has been seeded
            }
            var subdivisions = new Subdivision[]
            {
                new Subdivision { Name = "Subdivision1"},
                new Subdivision { Name = "Subdivision2"},
                new Subdivision { Name = "Subdivision3"}
            };
            foreach (Subdivision s in subdivisions)
            {
                context.Subdivisions.Add(s);
            }
            context.SaveChanges();

            // Look for any Employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }
            var employees = new Employee[]
            {
                new Employee { FirstName = "Joe", LastName = "Satriani", Sex = Sex.Male, SubdivisionId = 1 },
                new Employee { FirstName = "John", Sex = Sex.Male, SubdivisionId = 1 },
                new Employee { FirstName = "Alice", LastName = "Cooper", Sex = Sex.Male, SubdivisionId = 2 },
                new Employee { FirstName = "Slash", Sex = Sex.Male, SubdivisionId = 3 },
                new Employee { FirstName = "Johnny", LastName = "Depp", Sex = Sex.Male, SubdivisionId = 2 },
                new Employee { FirstName = "Lady", LastName = "Gaga", Sex = Sex.Female, SubdivisionId = 3 }
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            if (context.Projects.Any())
            {
                return;
            }
            var projects = new Project[]
            {
                new Project { Name = "Project1" },
                new Project { Name = "Project2" },
                new Project { Name = "Project3" }
            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var projectEmployees = new ProjectEmployee[]
            {
                new ProjectEmployee { ProjectId = 1, EmployeeId = 1 },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 2 },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 6 },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 2 },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 3 },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 4 },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 5 },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 3 }
            };
            foreach(var pe in projectEmployees)
            {
                context.ProjectEmployees.Add(pe);
            }
            context.SaveChanges();
        }
    }
}
