namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

public abstract class BasePresenter(IView view, ILogger<BasePresenter> logger) : IPresenter
{
    ~BasePresenter()
    {
        UnregisterEventHandlers();
    }

    protected readonly IView? _view = view;

    protected readonly ILogger<BasePresenter> _logger = logger;

    public virtual IView? View => _view;

    protected virtual void OnViewShown(object? sender, EventArgs e) { }

    protected virtual void OnViewResized(object? sender, EventArgs e) { }

    public virtual void InitializePresenter()
    {
        _logger.LogInformation("Initializing Presenter: {presenterType}.", GetType().Name);

        RegisterEventHandlers();
    }

    protected virtual void RegisterEventHandlers() { }

    protected virtual void UnregisterEventHandlers() { }
}
