using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Netflix.Api.Rating.Controllers
{
    [Route("api")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        [HttpGet("movies/{moveId}/ratting/stars")]
        public Task<IActionResult> GetStars([FromRoute] Guid moveId)
            ///=> Task.FromResult<IActionResult>(Ok(4));
            => throw new Exception();
    }
}
