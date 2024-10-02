using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Content;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Content;

internal class HomeViewUC(ILogger<BaseViewUC> logger) : BaseViewUC(logger), IHomeView
{
    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        this.BackColor = Color.Blue;
    }
}
