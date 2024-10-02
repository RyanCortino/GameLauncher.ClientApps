using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class MainView(IResourceFactory<Icon> iconFactory, ILogger<MainView> logger)
    : BaseView(logger),
        IMainView
{
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;

    public void AddControl(IUserControlView? userControl)
    {
        if (userControl is null)
            return;

        this.Controls.Add(userControl as UserControl);
    }

    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        this.Icon = _iconFactory.GetResource("GameLauncher");
        this.Size = new Size(1280, 720);
        this.MinimumSize = new Size(640, 360);
    }

    public void CloseAll()
    {
        foreach (Form childForm in MdiChildren)
        {
            childForm.Close();
        }
    }
}
