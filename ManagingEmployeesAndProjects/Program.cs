using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ManagingEmployeesAndProjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region add data
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    //Subdivision subdiv1 = new Subdivision { Name = "Subdivision1" };
            //    //Subdivision subdiv2 = new Subdivision { Name = "Subdivision2" };
            //    //db.Subdivisions.Add(subdiv1);
            //    //db.Subdivisions.Add(subdiv2);
            //    //db.SaveChanges();

            //    //Employee emp1 = new Employee { FirstName = "Tom", Subdivision = subdiv1 };
            //    //Employee emp2 = new Employee { FirstName = "Alice", Subdivision = subdiv2 };
            //    //Employee emp3 = new Employee { FirstName = "Bob", Subdivision = new Subdivision { Name = "Subdivision3" } };
            //    //db.Employees.AddRange(new List<Employee> { emp1, emp2, emp3 });

            //    //Project proj1 = new Project { Name = "Project1" };
            //    //Project proj2 = new Project { Name = "Project2" };
            //    //db.Projects.AddRange(new List<Project> { proj1, proj2 });

            //    //db.SaveChanges();

            //    ////добавляем к Employee Project
            //    //emp1.ProjectEmployees.Add(new ProjectEmployee { ProjectId = proj1.Id, EmployeeId = emp1.Id });
            //    //emp2.ProjectEmployees.Add(new ProjectEmployee { ProjectId = proj1.Id, EmployeeId = emp2.Id });
            //    //emp2.ProjectEmployees.Add(new ProjectEmployee { ProjectId = proj2.Id, EmployeeId = emp2.Id });
            //    //db.SaveChanges();


            //    // вывод Employees
            //    var employees1 = db.Employees.Include(e => e.Subdivision).ToList();
            //    foreach (Employee e in employees1)
            //        Debug.WriteLine($"{e.FirstName} - {e.Subdivision?.Name}");

            //    // вывод Subdivisions
            //    var subdivisions1 = db.Subdivisions.Include(c => c.Employees).ToList();
            //    foreach (Subdivision s in subdivisions1)
            //    {
            //        Debug.WriteLine($"\n Подразделение: {s.Name}");
            //        foreach (Employee e in s.Employees)
            //        {
            //            Debug.WriteLine($"{e.FirstName}");
            //        }
            //    }

            //    var projects = db.Projects.Include(p => p.ProjectEmployees).ThenInclude(pe => pe.Employee).ToList();
            //    // выводим все Projects
            //    foreach (var p in projects)
            //    {
            //        Debug.WriteLine($"\n Project: {p.Name}");
            //        // выводим всех Employees для данного Project
            //        var employees2 = p.ProjectEmployees.Select(pe => pe.Employee).ToList();
            //        foreach (Employee e in employees2)
            //            Debug.WriteLine($"{e.FirstName}");
            //    }
            //    //Console.ReadKey();
            //}
            #endregion

            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    //context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
