using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Netflix.Infrastructure.IoC;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Netflix.Worker.TicketsProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddConfigServer()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = ReturnEnvironment(config);
                    config.SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile($"appsettings.{(string.IsNullOrEmpty(env) ? "Development" : env)}.json", optional: true, reloadOnChange: true)
                          .AddEnvironmentVariables()
                          .AddConfigServer(env);
                })
                .AddServiceDiscovery(options => options.UseEureka())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDependencies(hostContext.Configuration);
                    services.AddContextTickets(hostContext.Configuration, true);
                    services.AddConsumer<Consumer>(Consumer.QueueName);
                });


        private static string ReturnEnvironment(IConfigurationBuilder configBuilder)
            => configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build()
                .GetSection("Environment")?.Value;
    }
}
