using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class PictureBoxBuilder : AbstractControlBuilder, IPictureBoxBuilder
{
    private new PictureBox _control = new();

    public PictureBox GetResult => _control;

    public override void Reset()
    {
        _control = new PictureBox();
    }

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
}
