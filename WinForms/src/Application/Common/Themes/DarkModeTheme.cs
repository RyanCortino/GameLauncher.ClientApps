using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;
using GameLauncher.ClientApps.Winforms.Application.Models;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Themes;

public record DarkModeTheme : ThemeDto, IDarkModeTheme
{
    public DarkModeTheme()
    {
        BackgroundColor = "1E1E1E";
        SecondaryBackgroundColor = "#2E2E2E";
        ForegroundColor = "#FFFFFF";
        ButtonColor = "#3C3C3C";
        ButtonTextColor = "#FFFFFF";
        BorderColor = "#444444";
        HighlightColor = "#505050";
    }
}
