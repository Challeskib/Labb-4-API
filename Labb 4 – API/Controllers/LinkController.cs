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

        //[HttpPost]
        //public async Task<IActionResult> AddNewLink(CreateLinkDto newLink)
        //{
        //    try
        //    {
        //        if (newLink == null)
        //        {
        //            return BadRequest();
        //        }
        //        var createdHobby = await _context.Add(newLink);
        //        return CreatedAtAction(nameof(GetLink), new { id = createdHobby.Id }, createdHobby);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from DB");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> AddNewLink(Link newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var createdLink = await _context.Add(newLink);
                return CreatedAtAction(nameof(GetLink), new { id = createdLink.Id }, createdLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Link>> GetLink(int id)
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
