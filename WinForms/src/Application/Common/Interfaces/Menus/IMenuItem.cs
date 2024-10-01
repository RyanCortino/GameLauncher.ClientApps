namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

public interface IMenuItem
{
    string Text { get; set; }
    bool Enabled { get; set; }

    void PerformClick();
}
