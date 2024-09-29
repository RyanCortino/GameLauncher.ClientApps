namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

public interface IFontFactory
{
    int Count { get; }

    void LoadFont(string fontFilePath, Stream fontStream);
}
