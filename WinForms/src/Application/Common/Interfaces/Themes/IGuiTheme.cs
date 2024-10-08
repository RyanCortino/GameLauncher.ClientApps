namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;

public interface IGuiTheme
{
    string BackgroundColor { get; }
    string SecondaryBackgroundColor { get; }
    string ForegroundColor { get; }
    string ButtonColor { get; }
    string ButtonTextColor { get; }
    string BorderColor { get; }
    string HighlightColor { get; }
}
