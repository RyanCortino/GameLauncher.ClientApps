using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public abstract class AbstractControlBuilder : IControlBuilder
{
    protected Control _control = new();

    public virtual void Reset() { }

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

    public virtual IControlBuilder BuildFont(Font? font)
    {
        if (font is not null)
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

    public virtual IControlBuilder BuildText(string text)
    {
        _control.Text = text;
        return this;
    }

    public virtual IControlBuilder BuildSize(Size size)
    {
        _control.Size = size;
        return this;
    }

    public virtual IControlBuilder BuildPadding()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildMargin()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildBorderStyle()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return this;
    }

    public virtual IControlBuilder BuildVisibleBehaviour(bool isVisible)
    {
        _control.Visible = isVisible;
        return this;
    }

    public virtual IControlBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        _control.TabIndex = tabIndex;
        return this;
    }

    public virtual IControlBuilder BuildClickEventHandler()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildMouseEnterEventHandler()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildMouseExitEventHandler()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildKeyUpEventHandler()
    {
        throw new NotImplementedException();
    }

    public virtual IControlBuilder BuildKeyDownEventHandler()
    {
        throw new NotImplementedException();
    }
}
