using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class MainView(INavigationView navigationViewUC, ILogger<MainView> logger)
    : BaseView(logger),
        IMainView
{
    private readonly INavigationView _navigationViewUC = navigationViewUC;

    public override void InitializeView()
    {
        base.InitializeView();

        _navigationViewUC.InitializeView();

        this.Controls.Add(_navigationViewUC as UserControl);
    }

    public void CloseAll()
    {
        foreach (Form childForm in MdiChildren)
        {
            childForm.Close();
        }
    }
}
