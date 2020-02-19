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
using ManagingEmployeesAndProjects.Controllers;

namespace ManagingEmployeesAndProjects.Pages.Subdivisions
{
    public class EditModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly SubdivisionsController controller;

        public EditModel(ApplicationContext context)
        {
            //_context = context;
            controller = new SubdivisionsController(context);
        }

        [BindProperty]
        public Subdivision Subdivision { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Subdivision = await _context.Subdivisions
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var subdivision = await controller.GetById(id);
            Subdivision = subdivision.Value;

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

            //_context.Attach(Subdivision).State = EntityState.Modified;
            await controller.Update(Subdivision.Id, Subdivision);

            return RedirectToPage("./Index");
        }

    }
}
