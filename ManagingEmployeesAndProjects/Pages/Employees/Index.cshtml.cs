using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Controllers;


namespace ManagingEmployeesAndProjects
{
    public class IndexModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly EmployeesController _controller;

        public IndexModel(ApplicationContext context)
        {
            //_context = context;
            _controller = new EmployeesController(context);
        }

        public IList<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        //public async Task<IActionResult> OnGetAsync()
        {
            //Employees = //await _context.Employees.Include(e => e.Subdivision).ToListAsync();

            /*var emps = new EmployeesController(_context);
            var res = await emps.GetEmployees();
            Employees = res.Value.ToList();*/

            var emps = await _controller.GetAll();
            Employees = emps.Value.ToList();
            
            //return Page();
        }
    }
}
