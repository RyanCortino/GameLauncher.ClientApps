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
        _logger.LogInformation("Initializing {this}.", this.GetType().Name);

        RegisterEventHandlers();
    }

    protected virtual void RegisterEventHandlers()
    {
        // Handle double-click event on the notify icon to open the main form
        _taskbarContextMenu.OnNotifyIconDoubleClickedEventHandler += (s, e) => ShowMainForm();

        _taskbarContextMenu.OnExitClickedEventHandler += (s, e) => ExitApplication();
    }

    protected virtual void UnregisterEventHandlers()
    {
        // Handle double-click event on the notify icon to open the main form
        _taskbarContextMenu.OnNotifyIconDoubleClickedEventHandler -= (s, e) => ShowMainForm();

        _taskbarContextMenu.OnExitClickedEventHandler -= (s, e) => ExitApplication();
    }

    protected virtual void ShowMainForm()
    {
        if (MainForm is null)
            return;

        MainForm.Show();

        if (MainForm.WindowState == FormWindowState.Minimized)
            MainForm.WindowState = FormWindowState.Normal;

        MainForm.BringToFront();
        MainForm.Activate();
    }

    private void ExitApplication()
    {
        _logger.LogInformation("Exiting Application.");

        ExitThread();
    }
}
