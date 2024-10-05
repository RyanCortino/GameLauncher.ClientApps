using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

internal abstract class ControlBuilder(Control control) : IControlBuilder
{
    protected Control _control = control;

    public virtual IControlBuilder BuildAnchorStyles(int value)
    {
        _control.Anchor = (AnchorStyles)value;
        return this;
    }

    public virtual IControlBuilder BuildBackColor(Color color)
    {
        _control.BackColor = color;
        return this;
    }

    public virtual IControlBuilder BuildBackgroundImageLayout(int value)
    {
        _control.BackgroundImageLayout = (ImageLayout)value;
        return this;
    }

    public virtual IControlBuilder BuildDockStyle(int value)
    {
        _control.Dock = (DockStyle)value;
        return this;
    }

    public virtual IControlBuilder BuildFont(Font font)
    {
        _control.Font = font;
        return this;
    }

    public virtual IControlBuilder BuildForeColor(Color color)
    {
        _control.ForeColor = color;
        return this;
    }

    public virtual IControlBuilder BuildBackgroundImage(Image image)
    {
        _control.BackgroundImage = image;
        return this;
    }

    public virtual IControlBuilder BuildLocation(Point point)
    {
        _control.Location = point;
        return this;
    }

    public void Reset()
    {
        _control = new();
    }

    public IControlBuilder BuildText(string text)
    {
        _control.Text = text;
        return this;
    }

    public IControlBuilder BuildSize(Size size)
    {
        _control.Size = size;
        return this;
    }

    public IControlBuilder BuildPadding()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildMargin()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildBorderStyle()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return this;
    }

    public IControlBuilder BuildVisibleBehaviour(bool isVisible)
    {
        _control.Visible = isVisible;
        return this;
    }

    public IControlBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        _control.TabIndex = tabIndex;
        return this;
    }

    public IControlBuilder BuildClickEventHandler()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildMouseEnterEventHandler()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildMouseExitEventHandler()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildKeyUpEventHandler()
    {
        throw new NotImplementedException();
    }

    public IControlBuilder BuildKeyDownEventHandler()
    {
        throw new NotImplementedException();
    }
}
