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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly EmployeesController _employeesController;

        public DeleteModel(ApplicationContext context)
        {
            _context = context;
            _employeesController = new EmployeesController(context);
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeesController.GetById(id);
            Employee = employee.Value;

            if (Employee == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Employee = await _context.Employees.FindAsync(id);
            var emp = await _employeesController.Delete(id);

            return emp.Result;
        }
    }
}
