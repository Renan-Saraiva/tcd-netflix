using Netflix.Infrastructure.Abstractions.Messaging;
using Steeltoe.Messaging.RabbitMQ.Core;

namespace Netflix.Infrastructure.Messaging
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly RabbitTemplate _rabbitTemplate;

        public MessageDispatcher(RabbitTemplate rabbitTemplate)
        {
            _rabbitTemplate = rabbitTemplate;
        }

        public void Dispatch<T>(string queueName, T message)
        {
            _rabbitTemplate.ConvertAndSend(queueName, System.Text.Json.JsonSerializer.Serialize(message));
        }
    }
}
