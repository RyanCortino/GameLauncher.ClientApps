namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface ITaskbarContextMenu : IContextMenu
{
    //void Intialize();
    event EventHandler? NotifyIconDoubleClicked;
    event EventHandler? ExitClicked;

    void ShowBalloonTip(int timeout, string tipTitle, string tipText, int toolTipIconIndex = 1) { }
}
