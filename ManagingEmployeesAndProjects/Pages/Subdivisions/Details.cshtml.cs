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
    public class DetailsModel : PageModel
    {
        private readonly ManagingEmployeesAndProjects.Data.ApplicationContext _context;

        public DetailsModel(ManagingEmployeesAndProjects.Data.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
