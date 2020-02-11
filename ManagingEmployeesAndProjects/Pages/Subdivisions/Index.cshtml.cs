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
    public class IndexModel : PageModel
    {
        private readonly ManagingEmployeesAndProjects.Data.ApplicationContext _context;

        public IndexModel(ManagingEmployeesAndProjects.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Subdivision> Subdivision { get;set; }

        public async Task OnGetAsync()
        {
            Subdivision = await _context.Subdivisions.ToListAsync();
        }
    }
}
