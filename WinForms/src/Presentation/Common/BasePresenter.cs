using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common;

public abstract class BasePresenter(IFormView view, ILogger<BasePresenter> logger) : IPresenter
{
    ~BasePresenter()
    {
        UnregisterEventHandlers();
    }

    protected readonly IFormView? _view = view;

    protected readonly ILogger<BasePresenter> _logger = logger;

    public virtual IFormView? View => _view;

    protected virtual void OnViewShownEventHandler(object? sender, EventArgs e) { }

    protected virtual void OnViewResizedEventHandler(object? sender, EventArgs e) { }

    public virtual void InitializePresenter()
    {
        _logger.LogInformation("Initializing Presenter: {presenterType}.", this.GetType().Name);

        RegisterEventHandlers();
    }

    protected virtual void RegisterEventHandlers()
    {
        if (View is null)
            return;

        View.OnViewShown += OnViewShownEventHandler;
        View.OnViewResized += OnViewResizedEventHandler;
    }

    protected virtual void UnregisterEventHandlers()
    {
        if (View is null)
            return;

        View.OnViewShown -= OnViewShownEventHandler;
        View.OnViewResized -= OnViewResizedEventHandler;
    }
}
