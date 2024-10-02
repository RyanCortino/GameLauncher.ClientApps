using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Controls;

public interface INavigationPresenter : IUserControlPresenter
{
    INavigationContextMenu ContextMenu { get; }

    public void Collapse();
    public void Expand();
}
