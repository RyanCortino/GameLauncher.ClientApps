﻿using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Context.Menus;

internal class NavigationContextMenu(IResourceFactory<Icon> iconFactory) : INavigationContextMenu
{
    ~NavigationContextMenu()
    {
        _contextMenu?.Dispose();
    }

    public event EventHandler? OnHomeClickedEventHandler;
    public event EventHandler? OnLibraryClickedEventHandler;
    public event EventHandler? OnSettingsClickedEventHandler;

    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;
    private readonly ContextMenuStrip? _contextMenu = new();

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
            _iconFactory.GetResource("Home")?.ToBitmap(),
            (s, e) => OnHomeClickedEventHandler?.Invoke(this, e)
        );

        _contextMenu.Items.Add(
            "Library",
            _iconFactory.GetResource("Library")?.ToBitmap(),
            (s, e) => OnLibraryClickedEventHandler?.Invoke(this, e)
        );

        _contextMenu.Items.Add(
            "Settings",
            _iconFactory.GetResource("Settings")?.ToBitmap(),
            (s, e) => OnSettingsClickedEventHandler?.Invoke(this, e)
        );
    }
}
