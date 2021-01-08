using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Netflix.Infrastructure.Abstractions.Messaging;

namespace Netflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMessageDispatcher _messageDispatcher;

        public MoviesController(IConfiguration config, IMessageDispatcher messageDispatcher)
        {
            _config = config;
            _messageDispatcher = messageDispatcher;
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
            _messageDispatcher.Dispatch<string>("myqueue", _config["Value1"]);
            return Ok(new string[] { _config["Value1"], _config["Value2"]});
        }
    }
}
