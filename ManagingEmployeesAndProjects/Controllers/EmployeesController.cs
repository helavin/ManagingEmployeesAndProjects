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
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EmployeesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return //await _context.Employees.ToListAsync();
            await _context.Employees
                .Include(e => e.Subdivision)
                .AsNoTracking()
                .ToListAsync();
        }


        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int? id)
        {
            var employee = //await _context.Employees.FindAsync(id);
                await _context.Employees
                .Include(e => e.Subdivision)
                .Include(pe => pe.ProjectEmployees)
                .ThenInclude(s => s.Project)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            //_context.Entry(employee).State = EntityState.Modified;
            _context.Attach(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee newEmployee)
        {
            var entry = _context.Add(new Employee());
            entry.CurrentValues.SetValues(newEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }

            //return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
