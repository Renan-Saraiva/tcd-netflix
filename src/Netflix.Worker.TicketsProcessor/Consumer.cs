using System;
using Microsoft.Extensions.Logging;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;
using Steeltoe.Messaging.RabbitMQ.Attributes;

namespace Netflix.Worker.TicketsProcessor
{
    public class Consumer
    {
        public const string QueueName = "tickets-to-processor";
        private readonly ILogger<Consumer> _logger;
        private readonly ITicketRepository _ticketRepository;

        public Consumer(
            ILogger<Consumer> logger,
            ITicketRepository ticketRepository)
        {
            _logger = logger;
            _ticketRepository = ticketRepository;
        }

        [RabbitListener(QueueName)]
        public void Listen(string json)
        {
            var ticket = ConvertToTicket(json);
            ticket.Protocol = GenerateProtocol();
            _ticketRepository.Add(ticket);
        }

        private string GenerateProtocol()
        {
            return DateTime.Now.ToString("ddMMyyyyhhmmss");
        }

        public Ticket ConvertToTicket(string json)
            => System.Text.Json.JsonSerializer.Deserialize<Ticket>(json);
    }
}
