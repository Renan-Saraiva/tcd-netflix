using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;
using Netflix.Infrastructure.DB.Repository.Movies;
using Netflix.Infrastructure.DB.Repository.Tickets;

namespace Netflix.Infrastructure.DB.Bootstrapper
{
    public static class DbBootstrapper
    {

        public static void AddContextMovie(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options => options.UseMySql(configuration["ConnectionString"], b => b.MigrationsAssembly("Netflix.Api.Movies")));
            services.AddScoped<IRepository<Movie>, MovieRepository>();
            services.AddScoped<IRepository<MovieCategory>, MovieCategoryRepository>();
        }

        public static void AddContextTicket(this IServiceCollection services, IConfiguration configuration, bool isWorker)
        {
            if (isWorker)
            {
                services.AddDbContext<TicketContext>(
                    options => options.UseMySql(
                        configuration["ConnectionString"]
                    ),
                    ServiceLifetime.Singleton,
                    ServiceLifetime.Singleton
                );
                services.AddSingleton<IRepository<Ticket>, TicketRepository>();
                return;
            }
                                
            services.AddDbContext<TicketContext>(options => options.UseMySql(configuration["ConnectionString"], b => b.MigrationsAssembly("Netflix.Api.Tickets")));
            services.AddScoped<IRepository<Ticket>, TicketRepository>();
        }
    }
}
