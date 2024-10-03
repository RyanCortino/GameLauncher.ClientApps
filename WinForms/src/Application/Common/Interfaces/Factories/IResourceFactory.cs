using System.Drawing;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

public interface IResourceFactory<T>
{
    T? GetResource(string key);
    T? GetResource(string key, float fontSize = 12, FontStyle style = FontStyle.Regular);

    int Count { get; }

    void LoadResource(Stream resourceStream, string key, string filePath);

    void UnloadResource(string key);

    void ClearAllResources();
}
