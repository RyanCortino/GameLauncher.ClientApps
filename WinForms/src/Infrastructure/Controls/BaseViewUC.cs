using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls;

internal class BaseViewUC : UserControl, IUserControlView
{
    public BaseViewUC(ILogger<BaseViewUC> logger)
    {
        _logger = logger;

        RegisterEventHandlers();
    }

    ~BaseViewUC()
    {
        UnregisterEventHandlers();
    }

    protected readonly ILogger _logger;

    public virtual void InitializeView()
    {
        _logger.LogInformation("Initializing UserControl {ucName}", this.GetType().Name);

        SetupAppearence();

        SetupControls();
    }

    protected virtual void SetupAppearence() { }

    protected virtual void SetupControls() { }

    protected virtual void RegisterEventHandlers() { }

    protected virtual void UnregisterEventHandlers() { }
}
