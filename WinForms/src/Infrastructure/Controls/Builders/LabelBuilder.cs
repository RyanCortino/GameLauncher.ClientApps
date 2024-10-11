using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class LabelBuilder : AbstractControlBuilder, ILabelBuilder
{
    private new Label _control = new();

    public Label GetResult => _control;

    public override void Reset() => _control = new Label();

    public ILabelBuilder BuildAutoSize(bool useAutoSize = true)
    {
        _control.AutoSize = useAutoSize;
        return this;
    }

    public ILabelBuilder BuildTextAlign(int value)
    {
        _control.TextAlign = (ContentAlignment)value;
        return this;
    }

    public ILabelBuilder BuildMaximumSize(Size size)
    {
        _control.MaximumSize = size;
        return this;
    }

    public ILabelBuilder BuildMinimumSize(Size size)
    {
        _control.MinimumSize = size;
        return this;
    }

    public override ILabelBuilder BuildAnchorStyles(int value)
    {
        base.BuildAnchorStyles(value);
        return this;
    }

    public override ILabelBuilder BuildBackColor(Color color)
    {
        _control.BackColor = color;
        return this;
    }

    public override ILabelBuilder BuildBackgroundImageLayout(int value)
    {
        base.BuildBackgroundImageLayout(value);
        return this;
    }

    public override ILabelBuilder BuildDockStyle(int value)
    {
        base.BuildDockStyle(value);
        return this;
    }

    public override ILabelBuilder BuildFont(Font? font)
    {
        base.BuildFont(font);
        return this;
    }

    public override ILabelBuilder BuildForeColor(Color color)
    {
        base.BuildForeColor(color);
        return this;
    }

    public override ILabelBuilder BuildBackgroundImage(Image image)
    {
        base.BuildBackgroundImage(image);
        return this;
    }

    public override ILabelBuilder BuildLocation(Point point)
    {
        base.BuildLocation(point);
        return this;
    }

    public override ILabelBuilder BuildText(string text)
    {
        base.BuildText(text);
        return this;
    }

    public override ILabelBuilder BuildSize(Size size)
    {
        base.BuildSize(size);
        return this;
    }

    public override ILabelBuilder BuildPadding()
    {
        base.BuildPadding();
        return this;
    }

    public override ILabelBuilder BuildMargin()
    {
        base.BuildMargin();
        return this;
    }

    public override ILabelBuilder BuildBorderStyle()
    {
        base.BuildBorderStyle();
        return this;
    }

    public override ILabelBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        base.BuildEnabledBehaviour(isEnabled);
        return this;
    }

    public override ILabelBuilder BuildVisibleBehaviour(bool isVisible)
    {
        base.BuildVisibleBehaviour(isVisible);
        return this;
    }

    public override ILabelBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        base.BuildTabIndexBehaviour(tabIndex);
        return this;
    }

    public override ILabelBuilder BuildClickEventHandler()
    {
        base.BuildClickEventHandler();
        return this;
    }

    public override ILabelBuilder BuildMouseEnterEventHandler()
    {
        base.BuildMouseEnterEventHandler();
        return this;
    }

    public override ILabelBuilder BuildMouseExitEventHandler()
    {
        base.BuildMouseExitEventHandler();
        return this;
    }

    public override ILabelBuilder BuildKeyUpEventHandler()
    {
        base.BuildKeyUpEventHandler();
        return this;
    }

    public override ILabelBuilder BuildKeyDownEventHandler()
    {
        base.BuildKeyDownEventHandler();
        return this;
    }
}
