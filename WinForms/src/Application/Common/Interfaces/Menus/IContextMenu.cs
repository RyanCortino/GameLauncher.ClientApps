namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface IContextMenu
{
    void InitializeContextMenu();

    IEnumerable<IMenuItem> Items { get; }
}
