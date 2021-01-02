using Microsoft.Extensions.Logging;
using Steeltoe.Messaging.RabbitMQ.Attributes;

namespace Netflix.Worker.Discovey
{
    public class Consumer
    {
        public const string QueueName = "myqueue";
        private readonly ILogger<Consumer> _logger;

        public Consumer(ILogger<Consumer> logger)
        {
            _logger = logger;
        }

        [RabbitListener(QueueName)]
        public void Listen(string input)
        {
            _logger.LogInformation(input);
        }
    }
}
