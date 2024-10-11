using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Directors;

public class ControlsDirector()
{
    private IControlBuilder? _builder;

    public void SetBuilder(IControlBuilder builder)
    {
        _builder = builder;
        _builder.Reset();
    }

    public void MakeSimpleControl(Point? startingLocation = null)
    {
        if (_builder is not IControlBuilder builder)
            return;

        builder.BuildLocation(startingLocation ?? Point.Empty);
    }

    public void MakeTextControl(Font font, Color color, string text = "", bool autoSize = true)
    {
        if (_builder is not ILabelBuilder builder)
            return;

        builder.BuildAutoSize(autoSize);

        builder.BuildFont(font);

        builder.BuildText(text);

        builder.BuildForeColor(color);

        _builder = builder;
    }
}
