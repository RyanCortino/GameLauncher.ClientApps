using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class LabelBuilder : AbstractControlBuilder, ILabelBuilder
{
    private new Label _control = new();

    public Label GetResult => _control;

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

    public ILabelBuilder BuildBorderStyle(int value)
    {
        _control.BorderStyle = (BorderStyle)value;

        return this;
    }

    public override void Reset() => _control = new Label();

    public override ILabelBuilder BuildAnchorStyles(int value)
    {
        _control.Anchor = (AnchorStyles)value;
        return this;
    }

    public override ILabelBuilder BuildBackColor(Color color)
    {
        _control.BackColor = color;
        return this;
    }

    public override ILabelBuilder BuildBackgroundImageLayout(int value)
    {
        _control.BackgroundImageLayout = (ImageLayout)value;
        return this;
    }

    public override ILabelBuilder BuildDockStyle(int value)
    {
        _control.Dock = (DockStyle)value;
        return this;
    }

    public override ILabelBuilder BuildFont(Font? font)
    {
        _control.Font = font ?? default;
        return this;
    }

    public override ILabelBuilder BuildForeColor(Color color)
    {
        _control.ForeColor = color;
        return this;
    }

    public override ILabelBuilder BuildBackgroundImage(Image image)
    {
        _control.BackgroundImage = image;
        return this;
    }

    public override ILabelBuilder BuildLocation(Point point)
    {
        _control.Location = point;
        return this;
    }

    public override ILabelBuilder BuildText(string text)
    {
        _control.Text = text;
        return this;
    }

    public override ILabelBuilder BuildSize(Size size)
    {
        _control.Size = size;
        return this;
    }

    public override ILabelBuilder BuildPadding(int all)
    {
        _control.Padding = new Padding(all);
        return this;
    }

    public override ILabelBuilder BuildPadding(int left, int top, int right, int bottom)
    {
        _control.Padding = new Padding(left, top, right, bottom);
        return this;
    }

    public override ILabelBuilder BuildMargin(int all)
    {
        _control.Margin = new Padding(all);
        return this;
    }

    public override ILabelBuilder BuildMargin(int left, int top, int right, int bottom)
    {
        _control.Margin = new Padding(left, top, right, bottom);
        return this;
    }

    public override ILabelBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return this;
    }

    public override ILabelBuilder BuildVisibleBehaviour(bool isVisible)
    {
        _control.Visible = isVisible;
        return this;
    }

    public override ILabelBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        _control.TabIndex = tabIndex;
        return this;
    }

    public override ILabelBuilder BuildClickEventHandler()
    {
        throw new NotImplementedException();
    }

    public override ILabelBuilder BuildMouseEnterEventHandler()
    {
        throw new NotImplementedException();
    }

    public override ILabelBuilder BuildMouseExitEventHandler()
    {
        throw new NotImplementedException();
    }

    public override ILabelBuilder BuildKeyUpEventHandler()
    {
        throw new NotImplementedException();
    }

    public override ILabelBuilder BuildKeyDownEventHandler()
    {
        throw new NotImplementedException();
    }
}
