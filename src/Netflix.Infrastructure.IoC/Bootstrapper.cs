using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.Messaging.Bootstrapper;
using Netflix.Infrastructure.Services.Bootstrapper;

namespace Netflix.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddServices();
            services.AddMessaging();
        }

        public static void AddConsumer<T>(this IServiceCollection services, string queueName) where T : class
        {
            MessagingBootstrapper.AddConsumer<T>(services, queueName);
        }
    }
}
