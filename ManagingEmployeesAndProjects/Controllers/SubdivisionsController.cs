using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagingEmployeesAndProjects.Models;
using ManagingEmployeesAndProjects.Data;

namespace ManagingEmployeesAndProjects.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubdivisionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SubdivisionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Subdivisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subdivision>>> GetAll()
        {
            return await _context.Subdivisions
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Subdivisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subdivision>> GetById(int? id)
        {
            var subdivision = await _context.Subdivisions.FindAsync(id);

            if (subdivision == null)
            {
                return NotFound();
            }

            return subdivision;
        }

        // PUT: api/Subdivisions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Subdivision subdivision)
        {
            if (id != subdivision.Id)
            {
                return BadRequest();
            }

            //_context.Entry(subdivision).State = EntityState.Modified;
            _context.Attach(subdivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubdivisionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subdivisions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Subdivision>> Create(Subdivision newSubdivision)
        {
            //_context.Subdivisions.Add(newSubdivision);
            var entry = _context.Add(new Subdivision());
            entry.CurrentValues.SetValues(newSubdivision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubdivision", new { id = newSubdivision.Id }, newSubdivision);
        }

        // DELETE: api/Subdivisions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subdivision>> Delete(int? id)
        {
            var subdivision = await _context.Subdivisions.FindAsync(id);
            if (subdivision == null)
            {
                return NotFound();
            }

            try
            {
                _context.Subdivisions.Remove(subdivision);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index"); //subdivision;
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                        new { id, saveChangesError = true });
            }
        }

        private bool SubdivisionExists(int id)
        {
            return _context.Subdivisions.Any(e => e.Id == id);
        }
    }
}
