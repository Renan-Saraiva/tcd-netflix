using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.Abstractions.Messaging;
using Steeltoe.Messaging.RabbitMQ.Config;
using Steeltoe.Messaging.RabbitMQ.Extensions;

namespace Netflix.Infrastructure.Messaging.Bootstrapper
{
    public static class MessagingBootstrapper
    {
        public static void AddMessaging(this IServiceCollection services)
        {
            services.AddRabbitServices();
            services.AddRabbitAdmin();
            services.AddRabbitTemplate();
            services.AddScoped<IMessageDispatcher, MessageDispatcher>();
        }

        public static void AddConsumer<T>(this IServiceCollection services, string queueName) where T : class
        {
            services.AddRabbitQueue(new Queue(queueName));
            services.AddSingleton<T>();
            services.AddRabbitListeners<T>();
        }
    }
}
