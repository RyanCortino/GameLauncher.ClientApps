using System.Drawing.Text;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Factories;

internal class FontFactory : IFontFactory
{
    public FontFactory()
    {
        _fontCollection = new PrivateFontCollection();
    }

    private readonly PrivateFontCollection _fontCollection;

    public int Count => _fontCollection.Families.Length;

    /// <summary>
    /// Loads a font from the specified path and stores it in a private font collection.
    /// </summary>
    /// <param name="filePath">The file path of the .ttf file.</param>
    public void LoadFont(string fontFilePath, Stream fontStream)
    {
        if (fontStream is not null)
        {
            // Create an array to hold the font data
            byte[] fontData = new byte[fontStream.Length];

            fontStream.Read(fontData, 0, (int)fontStream.Length);

            // Use unsafe context to add the font to the collection
            nint fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(
                (int)fontStream.Length
            );

            System.Runtime.InteropServices.Marshal.Copy(
                fontData,
                0,
                fontPtr,
                (int)fontStream.Length
            );

            _fontCollection.AddMemoryFont(fontPtr, (int)fontStream.Length);

            // Free the unmanaged memory
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        }
    }

    /// <summary>
    /// Gets the font associated with the given name.
    /// </summary>
    /// <param name="fontFamily">The unique name for the font family.</param>
    /// <returns>The font object if found; otherwise.</returns>
    public FontFamily? GetResource(string fontFamily)
    {
        return _fontCollection.Families.Where(x => x.Name == fontFamily).FirstOrDefault();
    }
}
