using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.Abstractions.Services;
using Netflix.Infrastructure.Services;
using Steeltoe.Common.Http.Discovery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Infrastructure.IoC.Bootstrappers
{
    internal static class ServiceBootstrapper
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services
                .AddHttpClient("RatingService")
                .AddServiceDiscovery()
                .AddTypedClient<IRatingService, RatingService>();
        }
    }
}
