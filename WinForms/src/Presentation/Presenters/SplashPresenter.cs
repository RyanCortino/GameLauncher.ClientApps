using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class SplashPresenter(
    ISplashView splashView,
    IOptions<ApplicationOptions> applicationOptions,
    IResourceFactory<Image> imageFactory,
    IResourceFactory<Icon> iconFactory,
    IFontFactory fontFactory,
    ILogger<SplashPresenter> logger
) : BasePresenter(splashView, logger), ISplashPresenter
{
    private readonly ApplicationOptions _applicationOptions = applicationOptions.Value;

    private readonly IFontFactory _fontFactory = fontFactory;
    private readonly IResourceFactory<Image> _imageFactory = imageFactory;
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;

    public event EventHandler? OnPreloadCompleted;

    public override ISplashView? View => _view as ISplashView;

    protected override async void OnViewShownEventHandler(object? sender, EventArgs e) =>
        await Task.Run(() => PreloadAsync(sender, e));

    private async void OnPreloadCompletedEventHandler(object? sender, EventArgs e) =>
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
                LoadFonts(),
                // Load images from the embedded resources
                Load(_imageFactory, ["SplashImage.png"]),
                // Load icons from the embedded resources
                Load(_iconFactory, ["GameLauncher.ico", "Home.ico", "Library.ico", "Settings.ico"]),
            ];

            Task.WaitAll(loadingTasks);
        });

        OnPreloadCompleted?.Invoke(this, e);
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

    private Task Load<TType>(IResourceFactory<TType> factory, string[] resourceFilenames)
    {
        return Task.Run(() =>
        {
            foreach (var filename in resourceFilenames)
            {
                var resourceStream = CoreAssembly.Reference.GetManifestResourceStream(
                    $"{CoreAssembly.Name}.Resources.{filename.Replace("/", ".")}"
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

    private Task LoadFonts(string[]? fontFileNames = null)
    {
        fontFileNames ??= ["MontaguSlab.ttf", "Montserrat.ttf", "Montserrat-Italic.ttf"];

        return Task.Run(() =>
        {
            foreach (var fontFileName in fontFileNames)
            {
                var fontStream = CoreAssembly.Reference.GetManifestResourceStream(
                    $"{CoreAssembly.Name}.Resources.{fontFileName.Replace("/", ".")}"
                );

                if (fontStream is null)
                    continue;

                _fontFactory.LoadFont(fontFileName, fontStream);

                UpdateProgress($"Loaded font by name: {fontFileName}");
            }

            _logger.LogInformation(
                "{Count} fonts loaded into {Factory}.",
                _fontFactory.Count,
                _fontFactory.GetType().Name
            );
        });
    }

    private Task LoadLargeData()
    {
        return Task.Run(() => { });
    }

    protected override void Initialize()
    {
        base.Initialize();

        View?.InitializeView();
    }

    protected override void RegisterEventHandlers()
    {
        base.RegisterEventHandlers();

        OnPreloadCompleted += OnPreloadCompletedEventHandler;
    }

    protected override void UnregisterEventHandlers()
    {
        base.UnregisterEventHandlers();

        OnPreloadCompleted -= OnPreloadCompletedEventHandler;
    }

    private void UpdateProgress(string message)
    {
        _logger.LogInformation("Processed: {@Message}", message);

        View?.Report(message);
    }
}
