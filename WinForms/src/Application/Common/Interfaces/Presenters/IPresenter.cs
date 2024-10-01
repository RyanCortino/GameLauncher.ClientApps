using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters;

public interface IPresenter
{
    IFormView? View { get; }

    void InitializePresenter();
}
