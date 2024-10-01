using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

internal class MenuItemWrapper(ToolStripItem item) : IMenuItem
{
    private readonly ToolStripItem _item = item;

    public string Text
    {
        get => _item?.Text ?? string.Empty;
        set => _item.Text = value;
    }

    public bool Enabled
    {
        get => _item.Enabled;
        set => _item.Enabled = value;
    }

    public Image? Image
    {
        get => _item.Image;
        set => _item.Image = value;
    }

    public void PerformClick()
    {
        if (_item is ToolStripMenuItem menuItem)
        {
            menuItem.PerformClick();
        }
    }
}
