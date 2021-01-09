using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.DB.Repository.Movies;
using Netflix.Infrastructure.DB.Repository.Tickets;

namespace Netflix.Infrastructure.DB.Bootstrapper
{
    public static class DbBootstrapper
    {

        public static void AddContextMovie(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options => options.UseMySql(configuration["ConnectionString"], b => b.MigrationsAssembly("Netflix.Api.Movies")));
            services.AddScoped<MovieRepository>();
            services.AddScoped<MovieCategoryRepository>();
        }

        public static void AddContextTicket(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketContext>(options => options.UseMySql(configuration["ConnectionString"], b => b.MigrationsAssembly("Netflix.Api.Tickets")));
            services.AddScoped<TicketRepository>();
        }
    }
}
