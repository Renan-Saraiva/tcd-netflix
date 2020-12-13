using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.IoC.Bootstrappers;
using System;

namespace Netflix.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddServices();
        }
    }
}
