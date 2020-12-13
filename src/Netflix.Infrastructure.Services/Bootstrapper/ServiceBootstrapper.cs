using Microsoft.Extensions.DependencyInjection;
using Netflix.Infrastructure.Abstractions.Services;
using Polly;
using Polly.Extensions.Http;
using Steeltoe.Common.Http.Discovery;
using System;
using System.Net.Http;

namespace Netflix.Infrastructure.Services.Bootstrapper
{
    public static class ServiceBootstrapper
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddService<IRatingService, RatingService>("RatingService");
        }

        private static void AddService<TService, TImplementation>(this IServiceCollection services, string serviceName)
            where TService : class
            where TImplementation : class, TService
        {
            services
                .AddHttpClient(serviceName)
                .AddServiceDiscovery()
                .AddTypedClient<TService, TImplementation>()
                .AddPolicies();
        }

        private static void AddPolicies(this IHttpClientBuilder httpClientBuilder)
        {
            httpClientBuilder
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            => HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
            => HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .CircuitBreakerAsync(4, TimeSpan.FromSeconds(30));
    }
}
