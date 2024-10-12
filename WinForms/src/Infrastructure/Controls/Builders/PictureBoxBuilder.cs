using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class PictureBoxBuilder : AbstractControlBuilder, IPictureBoxBuilder
{
    private new PictureBox _control = new();

    public PictureBox GetResult => _control;

    public IPictureBoxBuilder BuildSizeMode(int value)
    {
        _control.SizeMode = (PictureBoxSizeMode)value;
        return this;
    }

    public IPictureBoxBuilder BuildErrorImage(Image? image)
    {
        _control.ErrorImage = image;
        return this;
    }

    public IPictureBoxBuilder BuildInitialImage(Image? image)
    {
        _control.InitialImage = image;
        return this;
    }

    public override void Reset() => _control = new PictureBox();

    public override IPictureBoxBuilder BuildAnchorStyles(int value)
    {
        _control.Anchor = (AnchorStyles)value;
        return this;
    }

    public override IPictureBoxBuilder BuildBackColor(Color color)
    {
        _control.BackColor = color;
        return this;
    }

    public override IPictureBoxBuilder BuildBackgroundImageLayout(int value)
    {
        _control.BackgroundImageLayout = (ImageLayout)value;
        return this;
    }

    public override IPictureBoxBuilder BuildDockStyle(int value)
    {
        _control.Dock = (DockStyle)value;
        return this;
    }

    public override IPictureBoxBuilder BuildFont(Font? font)
    {
        _control.Font = font ?? default;
        return this;
    }

    public override IPictureBoxBuilder BuildForeColor(Color color)
    {
        _control.ForeColor = color;
        return this;
    }

    public override IPictureBoxBuilder BuildBackgroundImage(Image image)
    {
        _control.BackgroundImage = image;
        return this;
    }

    public override IPictureBoxBuilder BuildLocation(Point point)
    {
        _control.Location = point;
        return this;
    }

    public override IPictureBoxBuilder BuildText(string text)
    {
        _control.Text = text;
        return this;
    }

    public override IPictureBoxBuilder BuildSize(Size size)
    {
        _control.Size = size;
        return this;
    }

    public override IPictureBoxBuilder BuildPadding(int all)
    {
        _control.Padding = new Padding(all);
        return this;
    }

    public override IPictureBoxBuilder BuildPadding(int left, int top, int right, int bottom)
    {
        _control.Padding = new Padding(left, top, right, bottom);
        return this;
    }

    public override IPictureBoxBuilder BuildMargin(int all)
    {
        _control.Margin = new Padding(all);
        return this;
    }

    public override IPictureBoxBuilder BuildMargin(int left, int top, int right, int bottom)
    {
        _control.Margin = new Padding(left, top, right, bottom);
        return this;
    }

    public override IPictureBoxBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return this;
    }

    public override IPictureBoxBuilder BuildVisibleBehaviour(bool isVisible)
    {
        _control.Visible = isVisible;
        return this;
    }

    public override IPictureBoxBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        _control.TabIndex = tabIndex;
        return this;
    }

    public override IPictureBoxBuilder BuildClickEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IPictureBoxBuilder BuildMouseEnterEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IPictureBoxBuilder BuildMouseExitEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IPictureBoxBuilder BuildKeyUpEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IPictureBoxBuilder BuildKeyDownEventHandler()
    {
        throw new NotImplementedException();
    }
}
