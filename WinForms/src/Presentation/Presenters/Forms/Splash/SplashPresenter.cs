using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters.Forms.Splash;

internal class SplashPresenter(
    ISplashView splashView,
    IOptions<ApplicationOptions> applicationOptions,
    IResourceFactory<Image> imageFactory,
    IResourceFactory<Icon> iconFactory,
    IResourceFactory<Font> fontFactory,
    ILogger<SplashPresenter> logger
) : FormPresenter(splashView, logger), ISplashPresenter
{
    private readonly ApplicationOptions _applicationOptions = applicationOptions.Value;

    private readonly IResourceFactory<Font> _fontFactory = fontFactory;
    private readonly IResourceFactory<Image> _imageFactory = imageFactory;
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;

    public event EventHandler? PreloadCompleted;

    public override ISplashView? View => _view as ISplashView;

    protected override async void OnViewShown(object? sender, EventArgs e)
    {
        base.OnViewShown(sender, e);

        await Task.Run(() => PreloadAsync(sender, e));
    }

    private async void OnPreloadCompleted(object? sender, EventArgs e) =>
        await Task.Run(() => PreloadCompletedAsync(sender, e));

    private static async Task Delay(int millisecondsDelay)
    {
        await Task.Delay(millisecondsDelay);
    }

    private async Task PreloadCompletedAsync(object? sender, EventArgs e)
    {
        UpdateProgress("Loading complete.");

        await Delay(250);

        View?.CloseView();
    }

    private async Task PreloadAsync(object? sender, EventArgs e)
    {
        UpdateProgress("Loading resources...");

        await Task.Run(() =>
        {
            Task[] loadingTasks =
            [
                // Start the default delay given the provided app setting
                DelayWithProgressUpdate((int)(_applicationOptions.DefaultSplashScreenDelay * 1000)),
                // Load fonts from the embedded resources
                Load(_fontFactory, ["Montserrat-Variable.ttf", "MontaguSlab-Variable.ttf"]),
                // Load images from the embedded resources
                Load(_imageFactory, []),
                // Load icons from the embedded resources
                Load(_iconFactory, ["GameLauncher.ico", "Home.ico", "Library.ico", "Settings.ico"]),
            ];

            Task.WaitAll(loadingTasks);
        });

        PreloadCompleted?.Invoke(this, e);
    }

    private Task DelayWithProgressUpdate(int delay, string? progressMessage = null)
    {
        return Task.Run(async () =>
        {
            await Delay(delay);

            if (progressMessage is not null)
                UpdateProgress(progressMessage);
        });
    }

    private Task Load<TType>(
        IResourceFactory<TType> factory,
        string[] resourceFilenames,
        string? manifestBaseOverride = null
    )
    {
        return Task.Run(() =>
        {
            foreach (var filename in resourceFilenames)
            {
                var manifestBase = manifestBaseOverride is null
                    ? $"{CoreAssembly.Name}.Resources."
                    : manifestBaseOverride;

                var resourceStream = CoreAssembly.Reference.GetManifestResourceStream(
                    manifestBase + $"{filename.Replace("/", ".")}"
                );

                if (resourceStream is null)
                    continue;

                factory.LoadResource(
                    resourceStream,
                    Path.GetFileNameWithoutExtension(filename),
                    filename
                );

                UpdateProgress($"Loaded resource by name: {filename}");
            }

            _logger.LogInformation(
                "{Count} resources loaded into {Factory}.",
                factory.Count,
                factory.GetType().Name
            );
        });
    }

    private Task LoadLargeData()
    {
        return Task.Run(() => { });
    }

    public override void InitializePresenter()
    {
        base.InitializePresenter();

        View?.InitializeView();
    }

    protected override void RegisterEventHandlers()
    {
        base.RegisterEventHandlers();

        PreloadCompleted += OnPreloadCompleted;
    }

    protected override void UnregisterEventHandlers()
    {
        base.UnregisterEventHandlers();

        PreloadCompleted -= OnPreloadCompleted;
    }

    private void UpdateProgress(string message)
    {
        _logger.LogInformation("Processed: {@Message}", message);

        View?.Report(message);
    }
}
