using Labb_4___API.Data;
using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IAppRepository<Person> _context;
        
        public PersonController(IAppRepository<Person> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _context.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPersonInterests(int id)
        {
            try
            {
                var result = await _context.GetSingle(id);
               
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Person and their interests");
            }
        }


        

    }
}
