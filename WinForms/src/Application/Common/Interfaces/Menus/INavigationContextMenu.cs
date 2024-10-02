using System.Drawing;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface INavigationContextMenu : IContextMenu
{
    event EventHandler? HomeClicked;
    event EventHandler? LibraryClicked;
    event EventHandler? SettingsClicked;
}
