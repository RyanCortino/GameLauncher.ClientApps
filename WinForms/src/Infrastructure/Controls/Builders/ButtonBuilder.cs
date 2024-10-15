using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class ButtonBuilder(IResourceFactory<Image> imageFactory)
    : BaseControlBuilder<Button, ButtonBuilder>,
        IButtonBuilder<ButtonBuilder>
{
    private readonly IResourceFactory<Image> _imageFactory = imageFactory;

    public ButtonBuilder SetDialogResult(int dialogResult)
    {
        _control.DialogResult = (DialogResult)dialogResult;
        return this;
    }

    public ButtonBuilder SetFlatAppearance(
        int borderSize,
        string borderColor,
        string mouseDownBackColor,
        string mouseOverBackColor
    )
    {
        _control.FlatAppearance.BorderSize = borderSize;
        _control.FlatAppearance.BorderColor = ColorTranslator.FromHtml(borderColor);
        _control.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(mouseDownBackColor);
        _control.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(mouseOverBackColor);

        return this;
    }

    public ButtonBuilder SetFlatStyle(int flatStyle)
    {
        _control.FlatStyle = (FlatStyle)flatStyle;
        return this;
    }

    public ButtonBuilder SetImage(string resourceName)
    {
        var image = _imageFactory.GetResource(resourceName);

        return image is null ? this : SetImage(image);
    }

    public ButtonBuilder SetImage(Image image)
    {
        _control.Image = image;
        return this;
    }

    public ButtonBuilder SetImageAlign(int contentAlignment)
    {
        _control.ImageAlign = (ContentAlignment)contentAlignment;
        return this;
    }

    public ButtonBuilder SetImageIndex(int imageIndex)
    {
        _control.ImageIndex = imageIndex;
        return this;
    }

    public ButtonBuilder SetImageList(string[] resourceNames)
    {
        var imageList = new ImageList();

        foreach (string resourceName in resourceNames)
        {
            var img = _imageFactory.GetResource(resourceName);

            if (img is null)
                continue;

            imageList.Images.Add(img);
        }

        _control.ImageList = imageList;

        return this;
    }

    public ButtonBuilder SetTextAlign(int contentAlignment)
    {
        _control.TextAlign = (ContentAlignment)contentAlignment;
        return this;
    }

    public ButtonBuilder UseAutoEllipsis(bool shouldUseAutoElipsis = true)
    {
        _control.AutoEllipsis = shouldUseAutoElipsis;
        return this;
    }

    public ButtonBuilder UseMnemonic(bool shouldUseMnemonic = true)
    {
        _control.UseMnemonic = shouldUseMnemonic;
        return this;
    }

    public ButtonBuilder UseVisualStyleBackColor(bool shouldUseVisualStyleBackColor = true)
    {
        _control.UseVisualStyleBackColor = shouldUseVisualStyleBackColor;
        return this;
    }
}
