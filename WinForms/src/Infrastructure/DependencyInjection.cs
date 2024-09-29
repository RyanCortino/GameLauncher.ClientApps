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
        services.AddSingleton<IResourceFactory<Image>, ImageResourceFactory>();
        services.AddSingleton<IFontFactory, FontFactory>();

        return services;
    }
}
