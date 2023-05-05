using Labb_4___API.Data;
using Labb_4___API.Models;
using Labb_4___API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IAppRepository<Hobby> _context;
        private readonly DataContext _newcontext;

        public HobbyController(IAppRepository<Hobby> context, DataContext dtocontext)
        {
            _context = context;
            _newcontext = dtocontext;
        }

        //[HttpGet("testing/{id}")]
        //public async Task<ActionResult<List<Hobby>>> Get(int id)
        //{
        //    var hobbys = await _newcontext.Hobbys
        //        .Where(h => h.Id == id)
        //        .Include(h => h.Persons)
        //        .ToListAsync();
        //    return Ok(hobbys);
        //}

        [HttpPost]
        public async Task<IActionResult> AddNewHobby(Hobby newHobby)
        {
            try
            {
                if (newHobby == null)
                {
                    return BadRequest();
                }
                var createdHobby = await _context.Add(newHobby);
                return CreatedAtAction(nameof(GetHobby), new { id = createdHobby.Id }, createdHobby);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hobby>> GetHobby(int id)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from single hobby");
            }
        }

    }
}
