using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.DB.Repository.Movie;


namespace Netflix.Infrastructure.DB.Bootstrapper
{
    public static class DbBootstrapper
    {

        public static void AddContextMovie(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options => options.UseMySql(configuration["ConnectionString"]));
            services.AddScoped<MovieCategoryRepository>();
        }
    }
}
