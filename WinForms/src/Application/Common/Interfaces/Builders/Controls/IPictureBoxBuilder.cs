namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IPictureBoxBuilder<TBuilder> : IBaseControlBuilder<TBuilder>
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder SetSizeMode(int imageSizeMode);
    TBuilder SetImageLocation(string imageLocation);
    TBuilder ShouldWaitOnLoad(bool shouldWaitOnLoad = true);
    TBuilder SetErrorImage(string resourceName);
    TBuilder SetInitialImage(string resourceName);
    TBuilder UseTransparentBackColor(bool shouldUseTransparentBackColor = true);
}
