using GameLauncher.ClientApps.Winforms.Presentation.Common.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GameLauncher.ClientApps.Winforms.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Setup application Host
            IHost host = CreateHostBuilder().Build();

            using IServiceScope serviceScope = host.Services.CreateScope();

            ServiceProvider = serviceScope.ServiceProvider;

            // Setup application config
            Log.Logger.Information("Application Starting.");

            ApplicationConfiguration.Initialize();

            // Run the registered application context
            var appContext = host.Services.GetRequiredService<ApplicationContext>();

            System.Windows.Forms.Application.Run(appContext);
        }

        public static IServiceProvider? ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                // Setup App Settings
                .ConfigureAppConfiguration(BuildConfig)
                // Register the (required) app contexts
                .ConfigureServices(
                    (services) =>
                        services.AddTransient<ApplicationContext, SplashScreenAppContext>()
                )
                // Registers project services
                .ConfigureServices(
                    (context, services) =>
                    {
                        services.AddDesktopServices(context.Configuration);
                        services.AddInfrastructureServices(context.Configuration);
                        services.AddApplicationServices();
                    }
                )
                //Setup Serilog Logging
                .UseSerilog(
                    (ctx, lc) =>
                        lc
                            .ReadFrom.Configuration(ctx.Configuration)
                            .Enrich.FromLogContext()
                            .WriteTo.Debug()
                );

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                    optional: true
                )
                .AddEnvironmentVariables();
        }
    }
}
