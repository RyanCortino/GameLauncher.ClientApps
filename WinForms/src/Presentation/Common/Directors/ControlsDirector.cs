using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;
using GameLauncher.ClientApps.Winforms.Application.Models;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Directors;

public class ControlsDirector(ThemeDto themeDto)
{
    private readonly ThemeDto _themeDto = themeDto;

    private IControlBuilder? _builder;

    public void SetBuilder(IControlBuilder builder)
    {
        _builder = builder;
        _builder.Reset();
    }

    public void ApplyCurrentTheme()
    {
        if (_builder is not IControlBuilder builder)
            return;

        builder.BuildBackColor(ColorTranslator.FromHtml(_themeDto.BackgroundColor));

        builder.BuildForeColor(ColorTranslator.FromHtml(_themeDto.ForegroundColor));

        _builder = builder;
    }

    public void MakeSimpleControl(Point? startingLocation = null)
    {
        if (_builder is not IControlBuilder builder)
            return;

        builder.BuildLocation(startingLocation ?? Point.Empty);

        _builder = builder;
    }

    public void MakeTextControl(
        Font font,
        Color? color = null,
        string text = "",
        bool autoSize = true
    )
    {
        if (_builder is not ILabelBuilder builder)
            return;

        builder.BuildAutoSize(autoSize);

        builder.BuildFont(font);

        builder.BuildText(text);

        builder.BuildForeColor(color ?? Color.Black);

        _builder = builder;
    }
}
