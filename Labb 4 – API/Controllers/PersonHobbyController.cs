using Labb_4___API.Data;
using Labb_4___API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Labb_4___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonHobbyController : ControllerBase
    {

        private readonly DataContext _context;
        public PersonHobbyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get(int id)
        {
            var persons = await _context.Persons
                .Where(p => p.Id == id)
                .Include(p => p.Hobbys)
                .ToListAsync();
            return Ok(persons);

        }

        [HttpPost("hobby")]
        public async Task<ActionResult<Person>> AddPersonHobby(AddPersonHobbyDto request)
        {
            var person = await _context.Persons
                .Where(p => p.Id == request.PersonId)
                .Include(p => p.Hobbys)
                .FirstOrDefaultAsync();
            if (person == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbys.FindAsync(request.HobbyId);
            if (hobby == null)
            {
                return NotFound();
            }

            person.Hobbys.Add(hobby);
            await _context.SaveChangesAsync();
            return person;

        }

    }
}
