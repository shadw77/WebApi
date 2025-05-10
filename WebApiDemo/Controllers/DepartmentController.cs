using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Dto;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getDept(int id)
        {
            ProjectEntity context = new ProjectEntity();
            Department deptModel = context.Department.Include(d => d.Employees).FirstOrDefault(d => d.Id == id);
            
            //map model to Dto
            DepartmentWithEmployeesDto deptDto = new DepartmentWithEmployeesDto();
            deptDto.Name = deptModel.Name;
            deptDto.Id = deptModel.Id;
            foreach(var item in deptModel.Employees)
            {
                deptDto.EmpNames.Add(new EmployeeDto {Name = item.Name,Id = item.Id});
            }
            return Ok(deptDto);
        }
    }
}
