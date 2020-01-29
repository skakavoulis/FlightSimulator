using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlightSimulator
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IApplicationUi, ConsoleUi>();
                    services.AddHostedService<LifetimeEventsHostedService>();
                });
        }
    }
}