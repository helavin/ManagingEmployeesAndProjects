using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Controllers;

namespace ManagingEmployeesAndProjects
{
    public class EditModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly EmployeesController _employeesController;
        private readonly SubdivisionsController _subdivisionsController;

        public EditModel(ApplicationContext context)
        {
            //_context = context;
            _employeesController = new EmployeesController(context);
            _subdivisionsController = new SubdivisionsController(context);
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Employee = await _context.Employees
            //    .Include(e => e.Subdivision)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var employee = await _employeesController.GetById(id);
            Employee = employee.Value;

            if (Employee == null)
            {
                return NotFound();
            }

            var selectListItems = await _subdivisionsController.GetAll();
            ViewData["SubdivisionId"] = new SelectList(selectListItems.Value,
                //_context.Subdivisions,
                "Id", "Name");
            var sex = Enum.GetValues(typeof(Sex)).Cast<Sex>().ToList();
            ViewData["Sex"] = new SelectList(sex);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employeesController.Update(Employee.Id, Employee);

            return RedirectToPage("./Index");
        }

    }
}
