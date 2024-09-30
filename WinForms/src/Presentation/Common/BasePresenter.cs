using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common;

public abstract class BasePresenter : IPresenter
{
    protected BasePresenter(IFormView view, ILogger<BasePresenter> logger)
    {
        _logger = logger;

        _view = view;

        Initialize();

        RegisterEventHandlers();
    }

    ~BasePresenter()
    {
        UnregisterEventHandlers();
    }

    protected readonly IFormView? _view;

    protected readonly ILogger<BasePresenter> _logger;

    public virtual IFormView? View => _view;

    protected virtual void OnViewShownEventHandler(object? sender, EventArgs e) { }

    protected virtual void OnViewResizedEventHandler(object? sender, EventArgs e) { }

    protected virtual void Initialize()
    {
        _logger.LogInformation("Base presenter initializing.");
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
