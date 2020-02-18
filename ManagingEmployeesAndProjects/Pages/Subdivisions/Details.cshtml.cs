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
    public class DetailsModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly SubdivisionsController controller;

        public DetailsModel(ApplicationContext context)
        {
            //_context = context;
            controller = new SubdivisionsController(context);
        }

        public Subdivision Subdivision { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
            return Page();
        }
    }
}
