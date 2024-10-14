using GameLauncher.ClientApps.Winforms.Application.Common.Enums;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IBaseControlBuilder<TBuilder> : IBuilder
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder SetText(string text);
    TBuilder SetSize(int width, int height);
    TBuilder SetLocation(int x, int y);
    TBuilder SetBackColor(string color);
    TBuilder SetForeColor(string color);
    TBuilder IsEnabled(bool isEnabled = true);
    TBuilder IsVisible(bool isVisible = true);
    TBuilder SetAnchor(int anchorStyles);
    TBuilder SetDock(int dockStyles);
    TBuilder SetFont(string fontFamily, int fontSize, int fontStyle = 0);
    TBuilder SetCursor(CursorTypes cursorStyleType);
    TBuilder SetPadding(int allEdges);
    TBuilder SetPadding(int left, int top, int right, int bottom);
    TBuilder SetMargin(int allEdges);
    TBuilder SetMargin(int left, int top, int right, int bottom);
    TBuilder SetTabIndex(int index);
    TBuilder IsTabStop(bool isTabStop = true);
}
