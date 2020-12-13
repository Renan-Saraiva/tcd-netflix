using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Netflix.Api.Rating.Controllers
{
    [Route("api")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        [HttpGet("movies/{moveId}/ratting/stars")]
        public Task<IActionResult> GetStars([FromRoute]Guid moveId)
            => Task.FromResult<IActionResult>(Ok(4));
    }
}
