using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context.Menus;

internal class NavigationContextMenu : INavigationContextMenu
{
    public event EventHandler? OnHomeClickedEventHandler;
    public event EventHandler? OnLibraryClickedEventHandler;
    public event EventHandler? OnSettingsClickedEventHandler;

    private readonly IResourceFactory<Image> _imageFactory;
    private readonly ContextMenuStrip? _menuStrip;

    public NavigationContextMenu(IResourceFactory<Image> imageFactory)
    {
        _imageFactory = imageFactory;
        _menuStrip = new ContextMenuStrip();

        Initialize();
    }

    ~NavigationContextMenu()
    {
        _menuStrip?.Dispose();
    }

    private void Initialize()
    {
        SetupNavigationMenu();
    }

    private void SetupNavigationMenu()
    {
        if (_menuStrip is null)
            return;

        _menuStrip.Items.Add(
            "Home",
            _imageFactory.GetResource("Home"),
            (s, e) => OnHomeClickedEventHandler?.Invoke(this, e)
        );

        _menuStrip.Items.Add(
            "Library",
            _imageFactory.GetResource("Library"),
            (s, e) => OnLibraryClickedEventHandler?.Invoke(this, e)
        );

        _menuStrip.Items.Add(
            "Settings",
            _imageFactory.GetResource("Settings"),
            (s, e) => OnSettingsClickedEventHandler?.Invoke(this, e)
        );
    }
}
