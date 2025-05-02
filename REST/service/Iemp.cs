using Microsoft.AspNetCore.Mvc;
using REST.model;

namespace REST.service
{
    
     public interface Iemp
     {
            Task<ActionResult<Employee>?> GetEmployee(int id);

            Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();

            Task<ActionResult<Employee>> Add(Employee employee);
            Task<Employee> Update(int id, Employee employeeChanges);
            Task<Employee> Delete(int id);
     }
}
