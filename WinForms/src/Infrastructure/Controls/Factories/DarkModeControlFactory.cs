using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Themes;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Factories;

internal class DarkModeControlFactory(
    IDarkModeTheme darkModeTheme,
    ButtonBuilder buttonBuilder,
    LabelBuilder labelBuilder,
    PictureBoxBuilder pictureBoxBuilder
) : ControlBuilderFactory(buttonBuilder, labelBuilder, pictureBoxBuilder)
{
    private readonly IGuiTheme _themeDto = darkModeTheme;

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
