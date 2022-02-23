using JWTAuthentication.DAL;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
  
   // [Authorize(Roles = UserRoles.Admin)]
  //  [CustomAuthorize(UserRoles.Admin, UserRoles.User)]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<BookController>
        
        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Roles = UserRoles.Admin)]
        //[Authorize(Roles = UserRoles.User)]
        public  ActionResult<List<Book>> Get()
        {
            return _context.Books.ToList();
        }

        // GET api/<BookController>/5
     
        [HttpGet("{id}")]
       [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Book NotFound!" });
            return book;
        }

        // POST api/<BookController>
        
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Name field required!" });
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Book created successfully!" });
        }

        // PUT api/<BookController>/5
      
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id) return BadRequest();
            Book dbbook = await _context.Books.FindAsync(id);
            if (dbbook == null) return NotFound();
            dbbook.Name = book.Name;
            dbbook.Author = book.Author;
            
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Updated!" });
        }

        // DELETE api/<BookController>/5
       
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Manager)]
        public async Task<ActionResult> Delete(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Deleted!" });
        }
    }
}
