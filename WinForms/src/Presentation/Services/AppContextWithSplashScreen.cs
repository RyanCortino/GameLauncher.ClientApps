namespace GameLauncher.ClientApps.Winforms.Presentation.Services;

internal class AppContextWithSplashScreen(
    IMainPresenter mainPresenter,
    ISplashPresenter splashPresenter,
    ILogger<AppContextWithSplashScreen> logger
) : ApplicationContext(splashPresenter.GetView as Form)
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

        //var response = MessageBox.Show("Are you sure you want to quit?");

        //if (response != DialogResult.Yes)
        //    return;

        _logger.LogInformation("Exiting Application.");

        base.OnMainFormClosed(sender, e);
    }

    private void LaunchMainForm()
    {
        MainForm = _mainPresenter.GetView as Form;

        MainForm?.Show();
    }
}
