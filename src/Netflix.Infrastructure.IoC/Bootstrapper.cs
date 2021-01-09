using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.DB.Bootstrapper;
using Netflix.Infrastructure.Messaging.Bootstrapper;
using Netflix.Infrastructure.Services.Bootstrapper;

namespace Netflix.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddMessaging(configuration);
        }

        public static void AddContextMovies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddContextMovie(Configuration);
        }

        public static void AddContextTickets(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddContextTicket(Configuration);
        }

        public static void AddConsumer<T>(this IServiceCollection services, string queueName) where T : class
        {
            MessagingBootstrapper.AddConsumer<T>(services, queueName);
        }
    }
}
