using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST.model;
using REST.service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private Iemp _employeeService;

        public EmployeeController(Iemp employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>?>> GetEmployees()
        {
            if (await _employeeService.GetAllEmployee() == null)
            {
                return NotFound();
            }

            return await _employeeService.GetAllEmployee();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById_ActionResultOfT(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return employee == null ? NotFound() : employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }
            try
            {
                await _employeeService.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_employeeService.GetEmployee(id) == null)
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


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeService.Add(employee);
            return CreatedAtAction("GetById_ActionResultOfT", new { id = employee.EmpId }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }
    }
}
