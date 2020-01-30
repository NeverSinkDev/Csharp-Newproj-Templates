using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = ResourceFacade.GetInstance();

            CreateHostBuilder(args).Build().Run();
            Console.WriteLine("Hello Service World!");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<AzureResourceSearchWorker>()
                        .Configure<EventLogSettings>(config =>
                        {
                            config.LogName = "Service Helper";
                            config.SourceName = "Service Helper Source";
                        });
                }).UseWindowsService();
    }

    public class AzureResourceSearchWorker : BackgroundService
    {
        private readonly ILogger<AzureResourceSearchWorker> _logger;

        public AzureResourceSearchWorker(ILogger<AzureResourceSearchWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // perform custom action here.
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
