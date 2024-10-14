using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;
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
        services.AddScoped<IResourceFactory<Icon>, IconResourceFactory>();
        services.AddScoped<IResourceFactory<Image>, ImageResourceFactory>();
        services.AddScoped<IResourceFactory<Font>, FontResourceFactory>();

        // User Controls
        services.AddTransient<INavigationView, NavigationViewUC>();
        services.AddTransient<IHomeView, HomeViewUC>();
        services.AddTransient<ILibraryView, LibraryViewUC>();
        services.AddTransient<ISettingsView, SettingsViewUC>();

        // Builders
        services.AddTransient<ILabelBuilder<LabelBuilder>, LabelBuilder>();
        services.AddTransient<IButtonBuilder<ButtonBuilder>, ButtonBuilder>();
        services.AddTransient<IPictureBoxBuilder<PictureBoxBuilder>, PictureBoxBuilder>();

        return services;
    }
}
