using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;

public interface INavigationView : IUserControlView
{
    void ClearAllButtons();

    void AddButtonFrom(IMenuItem menuItem);
}
