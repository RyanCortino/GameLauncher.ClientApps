namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface INavigationContextMenu : IMenu
{
    event EventHandler? OnHomeClickedEventHandler;
    event EventHandler? OnLibraryClickedEventHandler;
    event EventHandler? OnSettingsClickedEventHandler;
}
