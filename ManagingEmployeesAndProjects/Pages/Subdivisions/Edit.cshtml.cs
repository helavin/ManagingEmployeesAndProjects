using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Data;
using ManagingEmployeesAndProjects.Models;

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class EditModel : PageModel
    {
        private readonly ManagingEmployeesAndProjects.Data.ApplicationContext _context;

        public EditModel(ManagingEmployeesAndProjects.Data.ApplicationContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subdivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubdivisionExists(Subdivision.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubdivisionExists(int id)
        {
            return _context.Subdivisions.Any(e => e.Id == id);
        }
    }
}
