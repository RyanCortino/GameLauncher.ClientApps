using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Navigation;
using GameLauncher.ClientApps.Winforms.Infrastructure.Factories;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Factories
        services.AddSingleton<IResourceFactory<Icon>, IconResourceFactory>();
        services.AddSingleton<IResourceFactory<Image>, ImageResourceFactory>();
        services.AddSingleton<IFontFactory, FontFactory>();

        // User Controls
        services.AddTransient<INavigationView, NavigationViewUC>();

        return services;
    }
}
