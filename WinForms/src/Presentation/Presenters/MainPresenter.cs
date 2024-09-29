namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class MainPresenter(IMainView mainView, ILogger<MainPresenter> logger)
    : BasePresenter(mainView, logger),
        IMainPresenter
{
    public override IMainView? View => _view as IMainView;

    protected override void Initialize()
    {
        _logger.LogInformation("Main Presenter initializing.");
    }

    protected override void OnViewShownEventHandler(object? sender, EventArgs e)
    {
        // Check Security Options

        // Check Bearer Token
    }
}
