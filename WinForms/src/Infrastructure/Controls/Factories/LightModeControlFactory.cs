using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Factories;

internal class LightModeControlFactory(
    ILightModeTheme lightModeTheme,
    IButtonBuilder buttonBuilder,
    ILabelBuilder labelBuilder,
    IPictureBoxBuilder pictureBoxBuilder
) : ControlBuilderFactory(buttonBuilder, labelBuilder, pictureBoxBuilder)
{
    private readonly IGuiTheme _themeDto = lightModeTheme;

    public override IButtonBuilder CreateButtonBuilder()
    {
        var builder = base.CreateButtonBuilder();

        builder.BuildBackColor(ColorTranslator.FromHtml(_themeDto.BackgroundColor));

        return builder;
    }

    public override ILabelBuilder CreateLabelBuilder()
    {
        var builder = base.CreateLabelBuilder();

        builder.BuildBackColor(ColorTranslator.FromHtml(_themeDto.BackgroundColor));

        return builder;
    }

    public override IPictureBoxBuilder CreatePictureBoxBuilder()
    {
        var builder = base.CreatePictureBoxBuilder();

        builder.BuildBackColor(ColorTranslator.FromHtml(_themeDto.BackgroundColor));

        return builder;
    }
}
