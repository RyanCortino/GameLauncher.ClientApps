using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

public interface IControlBuilderFactory
{
    ILabelBuilder CreateLabelBuilder();

    IButtonBuilder CreateButtonBuilder();

    IPictureBoxBuilder CreatePictureBoxBuilder();
}
