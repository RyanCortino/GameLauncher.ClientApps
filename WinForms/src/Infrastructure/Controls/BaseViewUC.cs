using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls;

public partial class BaseViewUC : UserControl, IUserControlView
{
    public BaseViewUC(ILogger<BaseViewUC> logger)
    {
        InitializeComponent();

        _logger = logger;
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

        RegisterEventHandlers();
    }

    protected virtual void SetupAppearence() { }

    protected virtual void RegisterEventHandlers() { }

    protected virtual void UnregisterEventHandlers() { }
}
