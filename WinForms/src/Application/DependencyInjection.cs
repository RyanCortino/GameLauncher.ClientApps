using GameLauncher.ClientApps.Winforms.Application.Common.Options;
using GameLauncher.ClientApps.Winforms.Application.Models;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registration for GUI Themes with Factory Delegate
        services.AddTransient(serviceProvide =>
        {
            var options = serviceProvide.GetService<IOptions<ApplicationOptions>>()!.Value;

            return !options.IsDarkModeEnabled
                ? new ThemeDto() { BackgroundColor = "#FFFFFF", ForegroundColor = "#000000" }
                : new ThemeDto() { BackgroundColor = "1E1E1E", ForegroundColor = "#FFFFFF" };
        });

        return services;
    }
}
