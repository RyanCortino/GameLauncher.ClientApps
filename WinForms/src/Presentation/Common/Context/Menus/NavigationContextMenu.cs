using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context.Menus;

internal class NavigationContextMenu(IResourceFactory<Image> imageFactory) : INavigationContextMenu
{
    ~NavigationContextMenu()
    {
        _contextMenu?.Dispose();
    }

    public event EventHandler? OnHomeClickedEventHandler;
    public event EventHandler? OnLibraryClickedEventHandler;
    public event EventHandler? OnSettingsClickedEventHandler;

    private readonly IResourceFactory<Image> _imageFactory = imageFactory;
    private readonly ContextMenuStrip? _contextMenu = new ContextMenuStrip();

    public IEnumerable<IMenuItem> Items
    {
        get
        {
            if (_contextMenu is null)
                yield break;

            foreach (ToolStripItem item in _contextMenu.Items)
            {
                yield return new MenuItemWrapper(item);
            }
        }
    }

    public void InitializeContextMenu()
    {
        if (_contextMenu is null)
            return;

        _contextMenu.Items.Add(
            "Home",
            _imageFactory.GetResource("Home"),
            (s, e) => OnHomeClickedEventHandler?.Invoke(this, e)
        );

        _contextMenu.Items.Add(
            "Library",
            _imageFactory.GetResource("Library"),
            (s, e) => OnLibraryClickedEventHandler?.Invoke(this, e)
        );

        _contextMenu.Items.Add(
            "Settings",
            _imageFactory.GetResource("Settings"),
            (s, e) => OnSettingsClickedEventHandler?.Invoke(this, e)
        );
    }
}
