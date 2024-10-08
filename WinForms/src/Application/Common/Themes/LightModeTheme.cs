using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;
using GameLauncher.ClientApps.Winforms.Application.Models;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Themes;

public record LightModeTheme : ThemeDto, ILightModeTheme
{
    public LightModeTheme()
    {
        BackgroundColor = "#FFFFFF";
        SecondaryBackgroundColor = "#F0F0F0";
        ForegroundColor = "#000000";
        ButtonColor = "#E0E0E0";
        ButtonTextColor = "#000000";
        BorderColor = "#C0C0C0";
        HighlightColor = "#D3D3D3";
    }
}
