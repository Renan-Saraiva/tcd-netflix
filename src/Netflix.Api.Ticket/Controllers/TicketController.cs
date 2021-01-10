using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;
using Netflix.Infrastructure.Abstractions.Messaging;

namespace Netflix.Api.Tickets.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : BaseController<Ticket, ITicketRepository>
    {
        const string TicketsProcessorQueueName = "tickets-to-processor";
        private readonly IMessageDispatcher _messageDispatcher;        

        public TicketController(IMessageDispatcher messageDispatcher, 
                                ITicketRepository ticketRepository) : base(ticketRepository)
        {
            _messageDispatcher = messageDispatcher;
        }

        [HttpPost]
        public override async Task<ActionResult<Ticket>> Post(Ticket ticket)
        {
            _messageDispatcher.Dispatch<Ticket>(TicketsProcessorQueueName, ticket);
            return await Task.FromResult<ActionResult>(Accepted());
        }
    }
}
