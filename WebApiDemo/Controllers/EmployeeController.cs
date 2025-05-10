using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Dto;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ProjectEntity context;

        public EmployeeController(ProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<Employee> emps = context.Employees.ToList();
            return Ok(emps);
        }

        [HttpGet("{id:int}", Name = "EmployeeDetailsRoute")]
        public IActionResult GetById([FromRoute]int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            return Ok(employee);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.Name == name);
            return Ok(employee);
        }

        [HttpGet("dept/{id}")]
        public IActionResult GetEmpWithDeptName(int id)
        {
            Employee emp = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            return Ok(emp);
        }

        [HttpGet("dto/{id}")]
        public IActionResult GetEmpWithDeptName2(int id)  //use this way insteed of the previous function
        {
            Employee emp = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
           
            EmployeeNameWithDepartmentNameDto EmpDto = new EmployeeNameWithDepartmentNameDto();
            EmpDto.DeptName = emp.Department.Name;
            EmpDto.EmpName = emp.Name;
            EmpDto.EmpId = emp.Id;

            return Ok(EmpDto);
        }

        [HttpPost]
        public IActionResult PostEmployee(Employee newEmp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(newEmp);
                context.SaveChanges();
                string url = Url.Link("EmployeeDetailsRoute", new { id = newEmp.Id });
                return Created(url, newEmp);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult PutEmployee([FromRoute]int id, [FromBody]Employee emp)
        {
            if(ModelState.IsValid)
            {
                Employee oldEmp = context.Employees.FirstOrDefault(e => e.Id == id);
                if(oldEmp != null)
                {
                    oldEmp.Name = emp.Name;
                    oldEmp.Address = emp.Address;
                    oldEmp.Age = emp.Age;
                    oldEmp.Salary = emp.Salary;
                    context.SaveChanges();

                    return StatusCode(StatusCodes.Status204NoContent);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEmployee(int id)
        {
            try
            {
                Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
                context.Employees.Remove(emp);
                context.SaveChanges();
                
                return StatusCode(StatusCodes.Status204NoContent);
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
