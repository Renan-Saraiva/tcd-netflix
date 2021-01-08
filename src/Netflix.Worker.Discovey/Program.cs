using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Netflix.Infrastructure.IoC;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Netflix.Worker.Discovey
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddServiceDiscovery(options => options.UseEureka())
                .AddConfigServer()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDependencies(hostContext.Configuration);
                    services.AddConsumer<Consumer>(Consumer.QueueName);
                });
    }
}
