using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _config;
        public MoviesController(IConfiguration config)
        {
            _config = config;
        }

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
            var val1 = _config["Value1"];
            var val2 = _config["Value2"];
            return Ok(new string[] { val1, val2 });
        }
    }
}
