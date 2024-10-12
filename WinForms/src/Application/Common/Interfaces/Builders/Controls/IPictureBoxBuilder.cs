using System.Drawing;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IPictureBoxBuilder : IControlBuilder
{
    public IPictureBoxBuilder BuildSizeMode(int value);

    public IPictureBoxBuilder BuildErrorImage(Image? image);

    public IPictureBoxBuilder BuildInitialImage(Image? image);
}
