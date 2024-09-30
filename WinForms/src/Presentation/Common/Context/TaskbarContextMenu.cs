namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context;

internal class TaskbarContextMenu : ITaskbarContextMenu
{
    public event EventHandler? OnNotifyIconDoubleClickedEventHandler;
    public event EventHandler? OnExitClickedEventHandler;

    private readonly NotifyIcon _notifyIcon;

    ~TaskbarContextMenu()
    {
        _notifyIcon?.ContextMenuStrip?.Dispose();
        _notifyIcon?.Dispose();
    }

    public TaskbarContextMenu()
    {
        _notifyIcon = MakeNotifyIcon(BuildContextMenu());

        InitializeContextMenu();
    }

    private void InitializeContextMenu()
    {
        // Handle double-click event on the notify icon to open the main form
        _notifyIcon.DoubleClick += (s, e) =>
            OnNotifyIconDoubleClickedEventHandler?.Invoke(this, EventArgs.Empty);
    }

    private ContextMenuStrip BuildContextMenu()
    {
        // Create and initialize the context menu
        var contextMenu = new ContextMenuStrip();

        contextMenu.Items.Add(
            "Exit",
            null,
            (s, e) => OnExitClickedEventHandler?.Invoke(this, EventArgs.Empty)
        );

        return contextMenu;
    }

    private static NotifyIcon MakeNotifyIcon(ContextMenuStrip contextMenuStrip)
    {
        // Initialize the NotifyIcon component
        return new NotifyIcon
        {
            Icon = Properties.Resources.Home,
            Text = "Game Launcher",
            Visible = true,
            ContextMenuStrip = contextMenuStrip,
        };
    }
}

internal interface ITaskbarContextMenu
{
    //void Intialize();
    event EventHandler? OnNotifyIconDoubleClickedEventHandler;
    event EventHandler? OnExitClickedEventHandler;
}
