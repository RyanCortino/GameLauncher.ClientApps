namespace GameLauncher.ClientApps.Winforms.Presentation.Common.AppContext;

internal class AppContextWithSplashScreen(
    IMainPresenter mainPresenter,
    ISplashPresenter splashPresenter,
    ILogger<AppContextWithSplashScreen> logger
) : ApplicationContext(splashPresenter.View as Form)
{
    private readonly ILogger _logger = logger;

    private readonly IMainPresenter _mainPresenter = mainPresenter;

    protected override void OnMainFormClosed(object? sender, EventArgs e)
    {
        if (sender is ISplashView)
        {
            LaunchMainForm();

            return;
        }

        _logger.LogInformation("Exiting Application.");

        base.OnMainFormClosed(sender, e);
    }

    private void LaunchMainForm()
    {
        MainForm = _mainPresenter.View as Form;

        MainForm?.Show();
    }
}
