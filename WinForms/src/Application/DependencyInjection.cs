using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;
using GameLauncher.ClientApps.Winforms.Application.Common.Themes;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IDarkModeTheme, DarkModeTheme>();
        services.AddTransient<ILightModeTheme, LightModeTheme>();

        return services;
    }
}
