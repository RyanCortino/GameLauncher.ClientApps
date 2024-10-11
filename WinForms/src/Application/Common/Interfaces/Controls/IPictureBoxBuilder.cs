using System.Drawing;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

public interface IPictureBoxBuilder : IControlBuilder
{
    public IPictureBoxBuilder BuildSizeMode(int value);

    public IPictureBoxBuilder BuildErrorImage(Image? image);

    public IPictureBoxBuilder BuildInitialImage(Image? image);
}
