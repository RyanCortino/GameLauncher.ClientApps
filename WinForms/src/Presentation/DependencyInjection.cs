using GameLauncher.ClientApps.Winforms.Presentation.Forms;
using GameLauncher.ClientApps.Winforms.Presentation.Presenters;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDesktopServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        //Config
        services.Configure<ApplicationOptions>(
            configuration.GetSection(nameof(ApplicationOptions))
        );

        //Views
        services.AddTransient<ISplashView, SplashForm>();
        services.AddTransient<IMainView, MainForm>();

        //Presenters
        services.AddTransient<SplashPresenter>();

        return services;
    }
}
