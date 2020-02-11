using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Controllers;

namespace ManagingEmployeesAndProjects
{
    public class DetailsModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly EmployeesController _controller;

        public DetailsModel(ApplicationContext context)
        {
            //_context = context;
            _controller = new EmployeesController(context);
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _controller.GetById(id);
            Employee = employee.Value;

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
