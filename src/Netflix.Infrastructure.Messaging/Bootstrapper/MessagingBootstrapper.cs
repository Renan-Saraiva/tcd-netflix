using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.Abstractions.Messaging;
using Steeltoe.Messaging.RabbitMQ.Config;
using Steeltoe.Messaging.RabbitMQ.Extensions;

namespace Netflix.Infrastructure.Messaging.Bootstrapper
{
    public static class MessagingBootstrapper
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitServices();
            services.AddRabbitAdmin();
            services.AddRabbitTemplate();
            services.Configure<RabbitOptions>(options =>
            {
                options.Addresses = configuration["Addresses"];
            });
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
