using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class DeleteModel : PageModel
    {
        private readonly ManagingEmployeesAndProjects.Data.ApplicationContext _context;

        public DeleteModel(ManagingEmployeesAndProjects.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subdivision Subdivision { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subdivision = await _context.Subdivisions.FirstOrDefaultAsync(m => m.Id == id);

            if (Subdivision == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subdivision = await _context.Subdivisions.FindAsync(id);

            if (Subdivision != null)
            {
                _context.Subdivisions.Remove(Subdivision);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
