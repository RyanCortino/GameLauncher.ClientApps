using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

internal class PictureBoxBuilder : ControlBuilder, IPictureBoxBuilder
{
    private PictureBox? PictureBox => _control as PictureBox;

    public PictureBoxBuilder()
        : base(new PictureBox()) { }

    public IPictureBoxBuilder BuildSizeMode(int value)
    {
        PictureBox!.SizeMode = (PictureBoxSizeMode)value;
        return this;
    }

    public IPictureBoxBuilder BuildErrorImage(Image? image)
    {
        PictureBox!.ErrorImage = image;
        return this;
    }

    public IPictureBoxBuilder BuildInitialImage(Image? image)
    {
        PictureBox!.InitialImage = image;
        return this;
    }
}
