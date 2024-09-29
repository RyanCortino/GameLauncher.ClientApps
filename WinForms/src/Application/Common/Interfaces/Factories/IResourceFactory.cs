namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;

public interface IResourceFactory<T>
{
    T? GetResource(string key);

    int Count { get; }

    void LoadResource(Stream resourceStream, string key, string filePath);

    void UnloadResource(string key);

    void ClearAllResources();
}
