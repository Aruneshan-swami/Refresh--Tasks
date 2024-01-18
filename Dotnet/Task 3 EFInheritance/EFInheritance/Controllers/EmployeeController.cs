using System.Data.SqlClient;
using EFInheritance.Data;
using EFInheritance.Models;
using EFInheritance.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFInheritance.Controllers
{
    public class EmployeeController:ControllerBase
    {
        private readonly EFDbContext _Context;

        public EmployeeController(EFDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _Context.Employees.ToList();
        }
        [HttpGet("id")]
        public ActionResult<IEnumerable<Employee>> GetEmployees(int id)
        {
            return _Context.Employees.ToList();
        }

        [HttpPost("id")]
        public IActionResult  CreateEmployee([FromBody] Employee employee){
            if (employee  == null)
            {
                return BadRequest("Create a Employee Details");
            }

            _Context.Employees.Add(employee);
            _Context.SaveChanges();

            return CreatedAtAction(nameof (GetEmployees),new{id = employee.ID},employee);
        }


        [HttpPost]
        public ActionResult PostEmployees(Employee employee)
        {
            _Context.Employees.Add(employee);
            _Context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployees),new {id = employee.ID},employee);
        }

        [HttpPut("id")]
        public ActionResult PutEmployees(int id,Employee employee)
        {

            if (id != employee.ID)
            {
                return BadRequest();
            }
            _Context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult DeleteEmployee(int id)
        {

            var employee = _Context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            _Context.Employees.Remove(employee);
            _Context.SaveChanges();

            return NoContent();
        }
        

    }

    }