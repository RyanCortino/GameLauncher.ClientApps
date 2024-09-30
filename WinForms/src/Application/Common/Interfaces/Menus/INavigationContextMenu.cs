namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface INavigationContextMenu
{
    event EventHandler? OnHomeClickedEventHandler;
    event EventHandler? OnLibraryClickedEventHandler;
    event EventHandler? OnSettingsClickedEventHandler;
}
