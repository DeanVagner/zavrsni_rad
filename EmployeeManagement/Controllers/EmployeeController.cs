using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    /// <summary>
    /// API kontroler za upravljanje zaposlenicima.
    /// </summary>
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        /// <summary>
        /// Inicijalizira novi primjerak <see cref="EmployeesController"/> klase.
        /// </summary>
        /// <param name="context">Baza podataka za korištenje.</param>
        public EmployeesController(EmployeeManagementContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dohvaća sve zaposlenike.
        /// </summary>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        /// <summary>
        /// Dohvaća zaposlenika prema ID-u.
        /// </summary>
        /// <param name="id">ID zaposlenika.</param>
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Dodaje novog zaposlenika.
        /// </summary>
        /// <param name="employee">Podaci zaposlenika.</param>
        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        /// <summary>
        /// Ažurira postojećeg zaposlenika.
        /// </summary>
        /// <param name="id">ID zaposlenika.</param>
        /// <param name="employee">Ažurirani podaci zaposlenika.</param>
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Briše zaposlenika prema ID-u.
        /// </summary>
        /// <param name="id">ID zaposlenika.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
