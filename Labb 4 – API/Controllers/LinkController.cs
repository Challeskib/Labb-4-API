using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Labb_4___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IAppRepository<Link> _context;

        public LinkController(IAppRepository<Link> context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Link>> GetPersonLinks(int id)
        {
            try
            {
                var result = await _context.GetAll();
                result = result.Where(p => p.PersonId == id).ToList();

                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Person and their interests");
            }
        }


    }
}
