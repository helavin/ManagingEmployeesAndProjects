using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Controllers;

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly SubdivisionsController controller;

        public CreateModel(ApplicationContext context)
        {
            //_context = context;
            controller = new SubdivisionsController(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subdivision NewSubdivision { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Subdivisions.Add(Subdivision);
            //await _context.SaveChangesAsync();
            var subdivision = await controller.Create(NewSubdivision);
            NewSubdivision = subdivision.Value;

            return RedirectToPage("./Index");
        }
    }
}
