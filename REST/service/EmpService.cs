using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST.model;
using REST.repo;


namespace REST.service
{
    public class EmpService : Iemp
    {
        private readonly AppdbContextRepository context;
        public EmpService(AppdbContextRepository context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Employee>> Add(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee> Delete(int id)
        {
            Employee? employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>?>> GetAllEmployee()
        {
            if (context.Employees == null)
            {
                return null;
            }
            return await context.Employees.ToListAsync();

        }


        public async Task<ActionResult<Employee>?> GetEmployee(int Id)
        {
            if (context.Employees == null)
            {
                return null;

            }
            var emp = await context.Employees.FindAsync(Id);

            if (emp == null)
            {
                return null;
            }
            return emp;

        }

        public async Task<Employee?> Update(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return null;
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;

        }
        private bool EmployeeExists(int id)
        {
            return (context.Employees?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }

}
