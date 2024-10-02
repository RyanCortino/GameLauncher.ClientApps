using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters.Controls;

internal class ControlPresenter(IUserControlView view, ILogger<BasePresenter> logger)
    : BasePresenter(view, logger)
{
    public override IUserControlView? View => _view as IUserControlView;
}
