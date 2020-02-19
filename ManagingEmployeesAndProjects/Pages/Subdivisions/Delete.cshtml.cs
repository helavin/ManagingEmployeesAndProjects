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

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly SubdivisionsController controller;

        public DeleteModel(ApplicationContext context)
        {
            //_context = context;
            controller = new SubdivisionsController(context);
        }

        [BindProperty]
        public Subdivision Subdivision { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Subdivision = await _context.Subdivisions.FirstOrDefaultAsync(m => m.Id == id);
            var subdivision = await controller.GetById(id);
            Subdivision = subdivision.Value;

            if (Subdivision == null)
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

            //Subdivision = await _context.Subdivisions.FindAsync(id);

            //if (Subdivision != null)
            //{
            //    _context.Subdivisions.Remove(Subdivision);
            //    await _context.SaveChangesAsync();
            //}

            var emp = await controller.Delete(id);

            return emp.Result;

            //return RedirectToPage("./Index");
        }
    }
}
