using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context.Menus;

internal class TaskbarContextMenu() : ITaskbarContextMenu
{
    ~TaskbarContextMenu()
    {
        _notifyIcon?.ContextMenuStrip?.Dispose();
        _notifyIcon?.Dispose();
    }

    public event EventHandler? NotifyIconDoubleClicked;
    public event EventHandler? ExitClicked;

    private NotifyIcon? _notifyIcon;

    public IEnumerable<IMenuItem> Items
    {
        get
        {
            if (_notifyIcon?.ContextMenuStrip is null)
                yield break;

            foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
            {
                yield return new MenuItemWrapper(item);
            }
        }
    }

    public void InitializeContextMenu()
    {
        _notifyIcon = MakeNotifyIcon(BuildContextMenu());

        // Handle double-click event on the notify icon to open the main form
        _notifyIcon.DoubleClick += (s, e) => NotifyIconDoubleClicked?.Invoke(this, EventArgs.Empty);
    }

    public void ShowBalloonTip(int timeout, string tipTitle, string tipText, int toolTipIconIndex)
    {
        _notifyIcon?.ShowBalloonTip(timeout, tipTitle, tipText, (ToolTipIcon)toolTipIconIndex);
    }

    private ContextMenuStrip BuildContextMenu()
    {
        // Create and initialize the context menu
        var contextMenu = new ContextMenuStrip();

        contextMenu.Items.Add("Exit", null, (s, e) => ExitClicked?.Invoke(this, e));

        return contextMenu;
    }

    private static NotifyIcon MakeNotifyIcon(ContextMenuStrip contextMenuStrip)
    {
        // Initialize the NotifyIcon component
        return new NotifyIcon
        {
            Icon = Properties.Resources.GameLauncher,
            Text = "Game Launcher",
            Visible = true,
            ContextMenuStrip = contextMenuStrip,
        };
    }
}
