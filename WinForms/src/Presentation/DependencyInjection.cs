﻿using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Presentation.ApiClients;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Context.Menus;
using GameLauncher.ClientApps.Winforms.Presentation.Presenters.Controls.Navigation;
using GameLauncher.ClientApps.Winforms.Presentation.Presenters.Forms.Main;
using GameLauncher.ClientApps.Winforms.Presentation.Presenters.Forms.Splash;
using GameLauncher.ClientApps.Winforms.Presentation.Views;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDesktopServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Config
        services.Configure<ApplicationOptions>(
            configuration.GetSection(nameof(ApplicationOptions))
        );

        // Api Clients
        services.AddHttpClient<IBackendApiClient, BackendApiClient>(client =>
            client.BaseAddress = new Uri(
                configuration.GetSection("BackendServiceBaseUri").Value ?? string.Empty
            )
        );

        // Context Menus
        services
            .AddSingleton<ITaskbarContextMenu, TaskbarContextMenu>()
            .AddSingleton<INavigationContextMenu, NavigationContextMenu>();

        // Form Views
        services
            .AddTransient<ISplashView, SplashView>()
            //.AddTransient<ILoginView, LoginView>();
            .AddTransient<IMainView, MainView>();

        // Form Presenters
        services
            .AddTransient<ISplashPresenter, SplashPresenter>()
            .AddTransient<IMainPresenter, MainPresenter>();

        // User Control Presenters
        services.AddTransient<INavigationPresenter, NavigationPresenter>();

        return services;
    }
}
