using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IAppRepository<Hobby> _context;

        public HobbyController(IAppRepository<Hobby> context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHobby(Hobby newHobby)
        {
            try
            {
                if (newHobby == null)
                {
                    return BadRequest();
                }
                var CreatedOrder = await _context.Add(newHobby);
                return CreatedAtAction(nameof(GetOrder), new { id = CreatedOrder.Id }, CreatedOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hobby>> GetOrder(int id)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from single order");
            }
        }

    }
}
