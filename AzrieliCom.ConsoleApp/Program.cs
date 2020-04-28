using AzrieliCom.Utility;
using AzrieliCom.Utility.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace AzrieliCom.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            // Configuration
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var serviceProvider = ConfigureServices(config).BuildServiceProvider();

            //var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("App Start");


            var presenter = serviceProvider.GetRequiredService<Presenter>();
            var appSettings = config.GetSection(nameof(AppSettings)).Get<AppSettings>();
            presenter.Handle(appSettings);
        }



        private static IServiceCollection ConfigureServices(IConfiguration config)
        {

            var services = new ServiceCollection()
                .AddLogging(logging =>
                {
                    logging.AddConfiguration(config.GetSection("Logging"));
                    logging.AddConsole();

                });

            // Add the config to our DI container for later use
            services.AddSingleton(config);

            services.AddTransient<IUtility, UtilityService>();
            services.AddTransient<Presenter>();
            return services;

        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject.ToString();
            Console.WriteLine(exception);
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
