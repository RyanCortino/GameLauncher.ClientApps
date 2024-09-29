using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters;

public interface IPresenter
{
    IView? View { get; }
}
