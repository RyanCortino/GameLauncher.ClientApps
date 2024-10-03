using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Views;

internal class BaseViewUC(ILogger<BaseViewUC> logger) : UserControl, IUserControlView
{
    ~BaseViewUC()
    {
        UnregisterEventHandlers();
    }

    protected readonly ILogger _logger = logger;

    public virtual void InitializeView()
    {
        _logger.LogInformation("Initializing UserControl {ucName}", GetType().Name);

        SetupAppearence();

        RegisterEventHandlers();
    }

    protected virtual void SetupAppearence() { }

    protected virtual void RegisterEventHandlers() { }

    protected virtual void UnregisterEventHandlers() { }
}
