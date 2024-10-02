using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Controls;

public interface IUserControlPresenter : IPresenter
{
    public new abstract IUserControlView? View { get; }
}
