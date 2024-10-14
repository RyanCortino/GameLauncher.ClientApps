using GameLauncher.ClientApps.Winforms.Application.Common.Enums;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public abstract class BaseControlBuilder<TControl, TBuilder> : IBaseControlBuilder<TBuilder>
    where TControl : Control, new()
    where TBuilder : BaseControlBuilder<TControl, TBuilder>
{
    protected TControl _control = new();

    public virtual TControl Build() => _control;

    public virtual void Reset() => _control = new();

    public TBuilder SetAnchor(int anchorStyles)
    {
        _control.Anchor = (AnchorStyles)anchorStyles;
        return (TBuilder)this;
    }

    public TBuilder SetBackColor(string color)
    {
        _control.BackColor = ColorTranslator.FromHtml(color);
        return (TBuilder)this;
    }

    public TBuilder SetCursor(CursorTypes cursorType)
    {
        switch (cursorType)
        {
            case CursorTypes.Default:
                _control.Cursor = Cursors.Default;
                break;
            case CursorTypes.AppStarting:
                _control.Cursor = Cursors.AppStarting;
                break;
            case CursorTypes.Arrow:
                _control.Cursor = Cursors.AppStarting;
                break;
            case CursorTypes.Cross:
                _control.Cursor = Cursors.Cross;
                break;
            case CursorTypes.Hand:
                _control.Cursor = Cursors.Hand;
                break;
            case CursorTypes.Help:
                _control.Cursor = Cursors.Help;
                break;
            case CursorTypes.IBeam:
                _control.Cursor = Cursors.IBeam;
                break;
            case CursorTypes.No:
                _control.Cursor = Cursors.No;
                break;
            case CursorTypes.SizeAll:
                _control.Cursor = Cursors.SizeAll;
                break;
            case CursorTypes.SizeNorthEastSouthWest:
                _control.Cursor = Cursors.SizeNESW;
                break;
            case CursorTypes.SizeWestEast:
                _control.Cursor = Cursors.SizeWE;
                break;
            case CursorTypes.UpArrow:
                _control.Cursor = Cursors.UpArrow;
                break;
            case CursorTypes.Wait:
                _control.Cursor = Cursors.WaitCursor;
                break;
        }

        return (TBuilder)this;
    }

    public TBuilder SetDock(int dockStyles)
    {
        _control.Dock = (DockStyle)dockStyles;
        return (TBuilder)this;
    }

    public TBuilder IsEnabled(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return (TBuilder)this;
    }

    public TBuilder SetFont(string fontFamily, int fontSize, int fontStyle = 0)
    {
        _control.Font = new Font(fontFamily, fontSize, (FontStyle)fontStyle);
        return (TBuilder)this;
    }

    public TBuilder SetForeColor(string color)
    {
        _control.ForeColor = ColorTranslator.FromHtml(color);
        return (TBuilder)this;
    }

    public TBuilder SetLocation(int x, int y)
    {
        _control.Location = new Point(x, y);
        return (TBuilder)this;
    }

    public TBuilder SetMargin(int allEdges)
    {
        _control.Margin = new Padding(allEdges);
        return (TBuilder)this;
    }

    public TBuilder SetMargin(int left, int top, int right, int bottom)
    {
        _control.Margin = new Padding(left, top, right, bottom);
        return (TBuilder)this;
    }

    public TBuilder SetPadding(int allEdges)
    {
        _control.Padding = new Padding(allEdges);
        return (TBuilder)this;
    }

    public TBuilder SetPadding(int left, int top, int right, int bottom)
    {
        _control.Padding = new Padding(left, top, right, bottom);
        return (TBuilder)this;
    }

    public TBuilder SetSize(int width, int height)
    {
        _control.Size = new Size(width, height);
        return (TBuilder)this;
    }

    public TBuilder SetTabIndex(int index)
    {
        _control.TabIndex = index;
        return (TBuilder)this;
    }

    public TBuilder IsTabStop(bool isTabStop)
    {
        _control.TabStop = isTabStop;
        return (TBuilder)this;
    }

    public TBuilder SetText(string text)
    {
        _control.Text = text;
        return (TBuilder)this;
    }

    public TBuilder IsVisible(bool isVisible)
    {
        _control.Visible = isVisible;
        return (TBuilder)this;
    }
}
