using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Factories;

internal abstract class ControlBuilderFactory(
    IButtonBuilder buttonBuilder,
    ILabelBuilder labelBuilder,
    IPictureBoxBuilder pictureBoxBuilder
) : IControlBuilderFactory
{
    private readonly IButtonBuilder _buttonBuilder = buttonBuilder;
    private readonly ILabelBuilder _labelBuilder = labelBuilder;
    private readonly IPictureBoxBuilder _pictureBuilder = pictureBoxBuilder;

    public virtual IButtonBuilder CreateButtonBuilder() => _buttonBuilder;

    public virtual ILabelBuilder CreateLabelBuilder() => _labelBuilder;

    public virtual IPictureBoxBuilder CreatePictureBoxBuilder() => _pictureBuilder;
}
