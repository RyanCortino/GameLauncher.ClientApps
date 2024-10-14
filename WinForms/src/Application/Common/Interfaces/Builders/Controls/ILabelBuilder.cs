namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface ILabelBuilder<TBuilder> : IBaseControlBuilder<TBuilder>
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder UseAutoSize(bool shouldUseAutoSize = true);
    TBuilder SetTextAlign(int contentAlignment);
    TBuilder SetImage(string resourceName);
    TBuilder SetImageAlign(int contentAlignment);
    TBuilder UseMnemonic(bool shouldUseMnemonic = true);
    TBuilder SetBorderStyle(int borderStyle);
    TBuilder SetFlatStyle(int flatStyle);
    TBuilder UseAutoElipsis(bool shouldUseAutoElipsis = true);
    TBuilder UseTransparentBackColor(bool shouldUseTransparentBackColor = true);
}
