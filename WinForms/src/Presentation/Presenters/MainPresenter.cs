using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class MainPresenter(IMainView mainView) : BasePresenter, IMainPresenter
{
    private readonly IMainView _mainView = mainView;

    public override IMainView GetView => _mainView;
}
