namespace GameLauncher.ClientApps.Winforms.Infrastructure.Factories;

internal class ImageResourceFactory : ResourceFactory<Image>, IResourceFactory<Image>
{
    public ImageResourceFactory()
        : base(ImageLoader) { }

    /// <summary>
    /// Custom image loader function for ResourceFactory.
    /// </summary>
    /// <param name="imageFileName">The file path of the image.</param>
    /// <returns>The loaded Image object.</returns>
    private static Image ImageLoader(string imageFileName, Stream imageStream)
    {
        if (imageStream is null)
            return default!;

        var image = Image.FromStream(imageStream);

        if (image is not null)
        {
            var imageName = Path.GetFileNameWithoutExtension(imageFileName);

            return Image.FromFile(imageName);
        }

        return default!;
    }
}
