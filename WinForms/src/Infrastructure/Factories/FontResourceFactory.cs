using System.Drawing.Text;
using System.Runtime.InteropServices;
using GameLauncher.ClientApps.Winforms.Infrastructure.Factories;

/// <summary>
/// A specialized factory class for managing and caching font resources using a PrivateFontCollection.
/// </summary>
internal class FontResourceFactory : ResourceFactory<Font>
{
    // A collection for storing and managing custom fonts
    private readonly PrivateFontCollection _fontCollection = new();

    public override int Count => _fontCollection.Families.Length;

    /// <summary>
    /// Loads a font from the specified stream and stores it with a given key.
    /// </summary>
    /// <param name="resourceStream">The stream containing the font data.</param>
    /// <param name="key">The unique key to identify the font.</param>
    /// <param name="filePath">The file path of the font resource (optional).</param>
    public override void LoadResource(Stream resourceStream, string key, string filePath)
    {
        // Read font data from stream into a byte array
        byte[] fontData;
        using (var memoryStream = new MemoryStream())
        {
            resourceStream.CopyTo(memoryStream);
            fontData = memoryStream.ToArray();
        }

        // Allocate memory for the font data and copy the byte array to unmanaged memory57
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

        try
        {
            // Track the number of existing font families before adding the new font
            int previousFamilyCount = _fontCollection.Families.Length;

            // Add the memory font to the PrivateFontCollection
            _fontCollection.AddMemoryFont(fontPtr, fontData.Length);
        }
        finally
        {
            // Free the allocated memory
            Marshal.FreeCoTaskMem(fontPtr);
        }
    }

    /// <summary>
    /// Gets the font associated with the given key.
    /// </summary>
    /// <param name="key">The unique key for the font resource.</param>
    /// <returns>The Font object if found; otherwise, null.</returns>
    public override Font? GetResource(string key) => GetResource(key, 12f, FontStyle.Regular);

    /// <summary>
    /// Gets the font associated with the given key and style.
    /// </summary>
    /// <param name="key">The unique key for the font resource.</param>
    /// <param name="fontSize">The desired font size (default is 12).</param>
    /// <param name="style">The desired font style (e.g., Regular, Bold).</param>
    /// <returns>The Font object if found; otherwise, null.</returns>
    public override Font? GetResource(
        string key,
        float fontSize = 12f,
        FontStyle style = FontStyle.Regular
    )
    {
        //var fontFamily = _fontCollection.Families[index];
        var fontFamily = _fontCollection.Families.Where((x) => x.Name == key).SingleOrDefault();

        if (fontFamily is null)
            return null;

        return new Font(fontFamily, fontSize, style);
    }

    /// <summary>
    /// Unloads the font associated with the given key.
    /// </summary>
    /// <param name="key">The unique key for the font to be unloaded.</param>
    public override void UnloadResource(string key) { }

    /// <summary>
    /// Clear all loaded fonts.
    /// </summary>
    public override void ClearAllResources()
    {
        // Dispose of the font collection and clear the dictionary
        _fontCollection.Dispose();
    }
}
