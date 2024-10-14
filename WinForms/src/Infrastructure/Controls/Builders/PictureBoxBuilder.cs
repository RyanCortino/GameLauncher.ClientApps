using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class PictureBoxBuilder(IResourceFactory<Image> imageFactory)
    : BaseControlBuilder<PictureBox, PictureBoxBuilder>,
        IPictureBoxBuilder<PictureBoxBuilder>
{
    private readonly IResourceFactory<Image> _imageFactory = imageFactory;

    public PictureBoxBuilder SetErrorImage(string resourceName)
    {
        _control.ErrorImage = _imageFactory.GetResource(resourceName);
        return this;
    }

    public PictureBoxBuilder SetImageLocation(string imageLocation)
    {
        _control.ImageLocation = imageLocation;
        return this;
    }

    public PictureBoxBuilder SetSizeMode(int imageSizeMode)
    {
        _control.SizeMode = (PictureBoxSizeMode)imageSizeMode;
        return this;
    }

    public PictureBoxBuilder SetInitialImage(string resourceName)
    {
        _control.InitialImage = _imageFactory.GetResource(resourceName);
        return this;
    }

    public PictureBoxBuilder ShouldWaitOnLoad(bool shouldWaitOnLoad = true)
    {
        _control.WaitOnLoad = shouldWaitOnLoad;
        return this;
    }

    public PictureBoxBuilder UseTransparentBackColor(bool shouldUseTransparentBackColor = true)
    {
        if (shouldUseTransparentBackColor)
            _control.BackColor = Color.Transparent;

        return this;
    }
}
