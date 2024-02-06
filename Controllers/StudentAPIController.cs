using CRUDWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentAPIController(StudentDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Studentss>>> GetStudent() {
            var data = await context.Studentsses.ToListAsync();
            return Ok(data);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studentss>> GetStudentById(int id)
        {
            var student = await context.Studentsses.FindAsync(id);
            if(student == null)
            {
                return NotFound();

            }
            return Ok(student);

        }
        [HttpPost]

        public async Task<ActionResult<Studentss>> CreateStudent(Studentss std)
        {
            await context.Studentsses.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Studentss>> UpdateStudent(int id, Studentss std)
        {
            if(id!=std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studentss>> DeleteStudent(int id)
        {
            var std = await context.Studentsses.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }

             context.Studentsses.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }



    }
}
