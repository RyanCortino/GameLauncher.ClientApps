using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class LabelBuilder(IResourceFactory<Image> imageFactory)
    : BaseControlBuilder<Label, LabelBuilder>,
        ILabelBuilder<LabelBuilder>
{
    private readonly IResourceFactory<Image> _imageFactory = imageFactory;

    public LabelBuilder SetBorderStyle(int borderStyle)
    {
        _control.BorderStyle = (BorderStyle)borderStyle;
        return this;
    }

    public LabelBuilder SetFlatStyle(int flatStyle)
    {
        _control.FlatStyle = (FlatStyle)flatStyle;
        return this;
    }

    public LabelBuilder SetImage(string resourceName)
    {
        _control.Image = _imageFactory.GetResource(resourceName);
        return this;
    }

    public LabelBuilder SetImageAlign(int contentAlignment)
    {
        _control.ImageAlign = (ContentAlignment)contentAlignment;
        return this;
    }

    public LabelBuilder SetTextAlign(int contentAlignment)
    {
        _control.TextAlign = (ContentAlignment)contentAlignment;
        return this;
    }

    public LabelBuilder UseAutoElipsis(bool shouldUseAutoElipsis = true)
    {
        _control.AutoEllipsis = shouldUseAutoElipsis;
        return this;
    }

    public LabelBuilder UseAutoSize(bool shouldUseAutoSize = true)
    {
        _control.AutoSize = shouldUseAutoSize;
        return this;
    }

    public LabelBuilder UseMnemonic(bool shouldUseMnemonic = true)
    {
        _control.UseMnemonic = shouldUseMnemonic;
        return this;
    }

    public LabelBuilder UseTransparentBackColor(bool shouldUseTransparentBackColor = true)
    {
        if (shouldUseTransparentBackColor)
            _control.BackColor = Color.Transparent;

        return this;
    }
}
