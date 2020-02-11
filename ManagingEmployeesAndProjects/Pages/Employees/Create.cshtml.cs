using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Controllers;

namespace ManagingEmployeesAndProjects
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly EmployeesController _employeesController;
        private readonly SubdivisionsController _subdivisionsController;

        public CreateModel(ApplicationContext context)
        {
            //_context = context;
            _employeesController = new EmployeesController(context);
            _subdivisionsController = new SubdivisionsController(context);
        }

        public IActionResult OnGet()
        {
            var selectListItems = _subdivisionsController.GetAll().Result.Value;
            ViewData["SubdivisionId"] = new SelectList(selectListItems,
                //_context.Subdivisions,
                "Id", "Name");
            var sex = Enum.GetValues(typeof(Sex)).Cast<Sex>().ToList();
            ViewData["Sex"] = new SelectList(sex);
            return Page();
        }

        [BindProperty]
        public Employee NewEmployee { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee = await _employeesController.Create(NewEmployee);
            NewEmployee = employee.Value;

            return RedirectToPage("./Index");
        }


    }
}
