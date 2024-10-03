namespace GameLauncher.ClientApps.Winforms.Infrastructure.Resources;

internal class IconResourceFactory : ResourceFactory<Icon>
{
    public IconResourceFactory()
        : base(IconLoader) { }

    /// <summary>
    /// Custom icon loader function for ResourceFactory.
    /// </summary>
    /// <param name="iconFileName">The file path of the icon.</param>
    /// <returns>The loaded Icon object.</returns>
    private static Icon IconLoader(string iconFileName, Stream iconStream)
    {
        return iconStream is null ? default! : new(iconStream);
    }
}
