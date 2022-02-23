using JWTAuthentication.DAL;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = UserRoles.Admin)]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<StudentController>
        [HttpGet]
       [AllowAnonymous]

        public ActionResult<List<Student>> Get()
        {
          
            return  _context.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>>  Get(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if (student == null) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Student NotFound!" });
            return student;
        }

        // POST api/<StudentController>
      
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] Student student)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Name field required!" });
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Student created successfully!" });
        }

        // PUT api/<StudentController>/5
   
        [HttpPut("{id}")]
        public async Task<ActionResult>  Put(int id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest();
            Student dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null) return NotFound();
            dbStudent.Name = student.Name;  
            dbStudent.Surname = student.Surname;  
            dbStudent.Age = student.Age;  
            dbStudent.Address = student.Address;
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Updated!" });
        }

        // DELETE api/<StudentController>/5

        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            if(student == null) return NotFound();    
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Deleted!" });
        }

    }
}
