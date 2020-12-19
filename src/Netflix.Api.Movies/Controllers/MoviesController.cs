using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Search(
            [FromQuery] string word, 
            [FromQuery] string category)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpPost("{id}/like")]
        public IActionResult Like([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpGet("watched")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
