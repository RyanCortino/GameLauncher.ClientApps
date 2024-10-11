using System.Drawing;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

public interface ILabelBuilder : IControlBuilder
{
    public ILabelBuilder BuildAutoSize(bool useAutoSize = true);

    public ILabelBuilder BuildTextAlign(int value);

    public ILabelBuilder BuildMaximumSize(Size size);

    public ILabelBuilder BuildMinimumSize(Size size);
}
