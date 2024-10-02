﻿using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Content;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Content;
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
        services.AddScoped<IResourceFactory<Icon>, IconResourceFactory>();
        services.AddScoped<IResourceFactory<Image>, ImageResourceFactory>();
        services.AddScoped<IFontFactory, FontFactory>();

        // User Controls
        services.AddTransient<INavigationView, NavigationViewUC>();
        services.AddTransient<IHomeView, HomeViewUC>();
        services.AddTransient<ILibraryView, LibraryViewUC>();
        services.AddTransient<ISettingsView, SettingsViewUC>();

        return services;
    }
}
