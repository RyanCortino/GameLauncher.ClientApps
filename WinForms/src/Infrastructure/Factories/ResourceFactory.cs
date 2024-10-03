namespace GameLauncher.ClientApps.Winforms.Infrastructure.Factories;

/// <summary>
/// A generic factory class for managing and caching resources.
/// </summary>
/// <typeparam name="T">The type of resource to be managed (e.g., Image, Font, Icon).</typeparam>
internal class ResourceFactory<T>(Func<string, Stream, T>? streamLoader = null)
    : IResourceFactory<T>
{
    // Dictionary to store resources with their keys (e.g., filenames or custom names)
    private readonly Dictionary<string, T> _resources = [];

    // A delegate to specify how to load resources, allowing custom loaders
    private readonly Func<string, Stream, T>? _streamLoader = streamLoader;

    public virtual int Count => _resources.Count;

    /// <summary>
    /// Loads a resource from the specified path and stores it with a given key.
    /// </summary>
    /// <param name="key">The unique key to identify the resource.</param>
    /// <param name="filePath">The file path of the resource.</param>
    public virtual void LoadResource(Stream resourceStream, string key, string filePath)
    {
        if (_streamLoader is null)
            return;

        if (_resources.ContainsKey(key))
            return;

        _resources[key] = _streamLoader(filePath, resourceStream);
    }

    /// <summary>
    /// Gets the resource associated with the given key.
    /// </summary>
    /// <param name="key">The unique key for the resource.</param>
    /// <returns>The resource object if found; otherwise, default value of T.</returns>
    public virtual T? GetResource(string key)
    {
        return _resources.TryGetValue(key, out T? value) ? value : default;
    }

    public virtual T? GetResource(string key, float size = 16)
    {
        return GetResource(key);
    }

    public virtual T? GetResource(string key, float size = 12, FontStyle style = FontStyle.Regular)
    {
        return GetResource(key);
    }

    /// <summary>
    /// Unloads the resource associated with the given key.
    /// </summary>
    /// <param name="key">The unique key for the resource to be unloaded.</param>
    public virtual void UnloadResource(string key)
    {
        if (_resources.TryGetValue(key, out T? value) && value is IDisposable disposable)
        {
            disposable.Dispose();

            _resources.Remove(key);
        }
    }

    /// <summary>
    /// Clear all loaded resources and dispose of them if they are IDisposable.
    /// </summary>
    public virtual void ClearAllResources()
    {
        foreach (var resource in _resources.Values)
        {
            if (resource is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        _resources.Clear();
    }
}
