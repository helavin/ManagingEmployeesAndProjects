using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class CreateModel : PageModel
    {
        private readonly ManagingEmployeesAndProjects.Data.ApplicationContext _context;

        public CreateModel(ManagingEmployeesAndProjects.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subdivision Subdivision { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subdivisions.Add(Subdivision);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
