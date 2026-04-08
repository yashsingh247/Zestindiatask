using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentManagementPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET api/students
        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            _service.Add(value);
            return Ok("Student Added");
        }
        [HttpPost]
        public IActionResult Update([FromBody] Student value)
        {
            _service.Update(value);
            return Ok("Student Update");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _service.DeleteSt(id);
            return Ok("Student delete");


        }
    }
}