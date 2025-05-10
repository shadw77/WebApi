using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {
        [HttpGet("{id:int}/{name:alpha}")]
        public IActionResult Get1(string name, int id)
        {
            return Ok();
        }

        [HttpGet("{name}/{address}/{salary}")]
        public IActionResult Get2([FromRoute] Employee emp)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Employee emp, string name)
        {
            return Ok();
        }

        [HttpPost("body/{id:int}")]
        public IActionResult Post2(string name, int id)
        {
            return Ok();
        }
    }
}
