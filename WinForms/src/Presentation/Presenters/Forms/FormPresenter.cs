using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters.Forms;

internal class FormPresenter(IFormView view, ILogger<BasePresenter> logger)
    : BasePresenter(view, logger)
{
    public override IFormView? View => _view as IFormView;

    protected override void RegisterEventHandlers()
    {
        base.RegisterEventHandlers();

        if (View is null)
            return;

        View.ViewShown += OnViewShown;
        View.ViewResized += OnViewResized;
    }

    protected override void UnregisterEventHandlers()
    {
        base.UnregisterEventHandlers();

        if (View is null)
            return;

        View.ViewShown -= OnViewShown;
        View.ViewResized -= OnViewResized;
    }
}
