using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context;

internal class SplashScreenAppContext(
    ISplashPresenter splashPresenter,
    ITaskbarContextMenu taskbarContextMenu,
    IMainPresenter mainPresenter,
    ILogger<SplashScreenAppContext> logger
) : BaseAppContext(taskbarContextMenu, splashPresenter, logger)
{
    private readonly IMainPresenter _mainPresenter = mainPresenter;

    protected override void OnMainFormClosed(object? sender, EventArgs e)
    {
        if (sender is ISplashView)
        {
            _logger.LogInformation("Splash View closed. Launching Main View.");

            LaunchMainForm();

            return;
        }

        base.OnMainFormClosed(sender, e);
    }

    private void LaunchMainForm()
    {
        MainForm = _mainPresenter.View as Form;

        ShowMainForm();
    }
}
