using System.Drawing;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IButtonBuilder<TBuilder> : IBaseControlBuilder<TBuilder>
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder SetTextAlign(int contentAlignment);
    TBuilder SetImage(string resourceName);
    TBuilder SetImage(Image image);
    TBuilder SetImageAlign(int contentAlignment);
    TBuilder SetFlatStyle(int flatStyle);
    TBuilder SetFlatAppearance(
        int borderSize,
        string borderColor,
        string mouseDownBackColor,
        string mouseOverBackColor
    );
    TBuilder UseMnemonic(bool shouldUseMnemonic = true);
    TBuilder SetDialogResult(int dialogResult);
    TBuilder UseVisualStyleBackColor(bool shouldUseVisualStyleBackColor = true);
    TBuilder UseAutoEllipsis(bool shouldUseAutoElipsis = true);
    TBuilder SetImageIndex(int imageIndex);
    TBuilder SetImageList(string[] resourceNames);
}
