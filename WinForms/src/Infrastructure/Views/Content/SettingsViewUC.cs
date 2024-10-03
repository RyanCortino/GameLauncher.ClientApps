using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Content;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Views.Content;

internal class SettingsViewUC(ILogger<BaseViewUC> logger) : BaseViewUC(logger), ISettingsView
{
    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        this.BackColor = Color.Green;
    }
}
