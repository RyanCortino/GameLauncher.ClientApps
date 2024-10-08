using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

public interface IControlBuilderFactory
{
    ILabelBuilder CreateLabelBuilder();

    IButtonBuilder CreateButtonBuilder();

    IPictureBoxBuilder CreatePictureBoxBuilder();
}
