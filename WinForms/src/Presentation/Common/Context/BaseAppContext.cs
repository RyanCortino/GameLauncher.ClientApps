using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context;

internal class BaseAppContext : ApplicationContext
{
    public BaseAppContext(
        ITaskbarContextMenu taskbarContextMenu,
        IPresenter presenter,
        ILogger<SplashScreenAppContext> logger
    )
        : base(presenter.View as Form)
    {
        _taskbarContextMenu = taskbarContextMenu;
        _taskbarContextMenu.InitializeContextMenu();

        _presenter = presenter;
        _presenter.InitializePresenter();

        _logger = logger;

        Initialize();
    }

    ~BaseAppContext()
    {
        UnregisterEventHandlers();
    }

    protected readonly IPresenter _presenter;

    protected readonly ILogger _logger;

    private readonly ITaskbarContextMenu _taskbarContextMenu;

    protected virtual void Initialize()
    {
        _logger.LogInformation("Initializing AppContext: {appContextType}.", this.GetType().Name);

        RegisterEventHandlers();
    }

    protected virtual void RegisterEventHandlers()
    {
        // Handle double-click event on the notify icon to open the main form
        _taskbarContextMenu.NotifyIconDoubleClicked += OnNotifyIconDoubleClicked;

        _taskbarContextMenu.ExitClicked += OnExitClicked;
    }

    protected virtual void UnregisterEventHandlers()
    {
        // Handle double-click event on the notify icon to open the main form
        _taskbarContextMenu.NotifyIconDoubleClicked -= OnNotifyIconDoubleClicked;

        _taskbarContextMenu.ExitClicked -= OnExitClicked;
    }

    protected virtual void ShowMainForm()
    {
        if (MainForm is null)
            return;

        MainForm.Show();

        BringMainFormToFront();
    }

    private void BringMainFormToFront()
    {
        if (MainForm is null)
            return;

        if (MainForm.WindowState == FormWindowState.Minimized)
            MainForm.WindowState = FormWindowState.Normal;

        MainForm.BringToFront();
        MainForm.Activate();
    }

    private void OnExitClicked(object? sender, EventArgs e)
    {
        ExitApplication();
    }

    private void OnNotifyIconDoubleClicked(Object? sender, EventArgs e)
    {
        ShowMainForm();
    }

    private void ExitApplication()
    {
        _logger.LogInformation("Exiting Application.");

        ExitThread();
    }
}
