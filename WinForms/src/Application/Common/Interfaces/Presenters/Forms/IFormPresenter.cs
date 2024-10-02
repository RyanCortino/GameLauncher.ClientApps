using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Forms;

internal interface IFormPresenter : IPresenter
{
    public new abstract IFormView? View { get; }
}
