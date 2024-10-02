using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm
{
    public interface IMainView : IFormView
    {
        void CloseAll();
        void AddControl(IUserControlView? userControl);
    }
}
