namespace GameLauncher.ClientApps.Winforms.Infrastructure.Factories;

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

    public override Icon? GetResource(string key, float size = 16)
    {
        var icon = base.GetResource(key);

        return icon is not null ? ResizeIcon(icon.ToBitmap(), (int)size, (int)size) : null;
    }

    // Method to resize the image
    private static Icon ResizeIcon(Image image, int width, int height)
    {
        // Create a new empty bitmap with the specified size
        var resizedBitmap = new Bitmap(width, height);

        // Create graphics from the bitmap and set high quality properties
        using (Graphics graphics = Graphics.FromImage(resizedBitmap))
        {
            graphics.InterpolationMode = System
                .Drawing
                .Drawing2D
                .InterpolationMode
                .HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(image, 0, 0, width, height);
        }

        return ConvertBitmapToIcon(resizedBitmap);
    }

    // Method to convert a Bitmap back to an Icon object
    private static Icon ConvertBitmapToIcon(Bitmap bitmap)
    {
        using MemoryStream stream = new();

        // Save the bitmap to the memory stream in .ico format
        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

        // Read the memory stream and convert it to an Icon
        stream.Seek(0, SeekOrigin.Begin); // Reset stream position

        using Bitmap iconBitmap = new(stream);

        IntPtr hIcon = iconBitmap.GetHicon(); // Get Hicon from Bitmap
        return Icon.FromHandle(hIcon); // Create and return Icon
    }
}
