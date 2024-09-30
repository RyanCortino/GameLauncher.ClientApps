using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class MainPresenter(
    IOptions<ApplicationOptions> applicationOptions,
    ITaskbarContextMenu taskbarContextMenu,
    IMainView view,
    ILogger<MainPresenter> logger
) : BasePresenter(view, logger), IMainPresenter
{
    private readonly ApplicationOptions _applicationOptions = applicationOptions.Value;

    private readonly ITaskbarContextMenu _taskbarContextMenu = taskbarContextMenu;

    public override IMainView? View => _view as IMainView;

    protected override void Initialize()
    {
        _logger.LogInformation("Main Presenter initializing.");
    }

    protected override void OnViewResizedEventHandler(object? sender, EventArgs e)
    {
        var form = sender as Form;

        // Check Application Options
        if (_applicationOptions.ShouldMinimizeToSystemTray)
        {
            // Check if the form is minimized
            if (form?.WindowState == FormWindowState.Minimized)
            {
                // Hide the form and show a balloon tip
                form.Hide();

                _taskbarContextMenu.ShowBalloonTip(
                    100,
                    "Application Minimized",
                    "Your app is now minimized to the tray.",
                    (int)ToolTipIcon.Info
                );

                return;
            }
        }
    }

    protected override void OnViewShownEventHandler(object? sender, EventArgs e)
    {
        // Check Security Options

        // Check Bearer Token
    }
}
