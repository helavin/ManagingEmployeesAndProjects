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
    public class IndexModel : PageModel
    {
        //private readonly ApplicationContext _context;
        private readonly SubdivisionsController controller;

        public IndexModel(ApplicationContext context)
        {
            //_context = context;
            controller = new SubdivisionsController(context);
        }

        public IList<Subdivision> Subdivisions { get;set; }

        public async Task OnGetAsync()
        {
            //Subdivision = await _context.Subdivisions.ToListAsync();
            var emps = await controller.GetAll();
            Subdivisions = emps.Value.ToList();
        }
    }
}
