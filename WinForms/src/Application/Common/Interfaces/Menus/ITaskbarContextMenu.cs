namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface ITaskbarContextMenu
{
    //void Intialize();
    event EventHandler? OnNotifyIconDoubleClickedEventHandler;
    event EventHandler? OnExitClickedEventHandler;

    void ShowBalloonTip(int timeout, string tipTitle, string tipText, int toolTipIconIndex = 1) { }
}
