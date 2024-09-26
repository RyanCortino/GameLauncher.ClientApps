using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

public abstract class BasePresenter : IPresenter
{
    public abstract IView GetView { get; }
}
