using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;

namespace GameLauncher.ClientApps.Winforms.Application.Models;

public record ThemeDto : IGuiTheme
{
    public required string BackgroundColor;
    public required string SecondaryBackgroundColor;
    public required string ForegroundColor;
    public required string ButtonColor;
    public required string ButtonTextColor;
    public required string BorderColor;
    public required string HighlightColor;

    string IGuiTheme.BackgroundColor => BackgroundColor;

    string IGuiTheme.SecondaryBackgroundColor => SecondaryBackgroundColor;

    string IGuiTheme.ForegroundColor => ForegroundColor;

    string IGuiTheme.ButtonColor => ButtonColor;

    string IGuiTheme.ButtonTextColor => ButtonTextColor;

    string IGuiTheme.BorderColor => BorderColor;

    string IGuiTheme.HighlightColor => HighlightColor;
}
