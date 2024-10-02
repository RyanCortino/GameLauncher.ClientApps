using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters.Controls.Navigation
{
    internal class NavigationPresenter(
        INavigationView view,
        INavigationContextMenu contextMenu,
        ILogger<NavigationPresenter> logger
    ) : ControlPresenter(view, logger), INavigationPresenter
    {
        public INavigationContextMenu ContextMenu { get; } = contextMenu;

        public new IUserControlView? View => base.View;

        public override void InitializePresenter()
        {
            base.InitializePresenter();

            ContextMenu.InitializeContextMenu();

            View?.InitializeView();

            SetupNavigationButtons();
        }

        private void SetupNavigationButtons()
        {
            var navView = View as INavigationView;

            navView?.ClearAllButtons();

            foreach (var item in ContextMenu.Items)
            {
                navView?.AddButtonFrom(item);
            }
        }

        public void Collapse() { }

        public void Expand() { }
    }
}
