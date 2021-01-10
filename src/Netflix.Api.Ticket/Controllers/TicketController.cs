using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.Messaging;

namespace Netflix.Api.Tickets.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        const string TicketsProcessorQueueName = "tickets-to-processor";
        private readonly IMessageDispatcher _messageDispatcher;        

        public TicketController(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            _messageDispatcher.Dispatch<Ticket>(TicketsProcessorQueueName, ticket);
            return Accepted();
        }
    }
}
