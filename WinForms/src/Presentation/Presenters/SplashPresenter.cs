using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class SplashPresenter(
    ISplashView splashView,
    IOptions<ApplicationOptions> applicationOptions,
    IResourceFactory<Image> imageFactory,
    IFontFactory fontFactory,
    ILogger<SplashPresenter> logger
) : BasePresenter(splashView, logger), ISplashPresenter
{
    private readonly ApplicationOptions _applicationOptions = applicationOptions.Value;

    private readonly IFontFactory _fontFactory = fontFactory;

    private readonly IResourceFactory<Image> _imageFactory = imageFactory;

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

        _logger.LogInformation(
            "{Images} loaded into {ImageFactory}.",
            _imageFactory.Count,
            _imageFactory
        );

        _logger.LogInformation(
            "{Fonts} loaded into {FontFactory}.",
            _fontFactory.Count,
            _fontFactory
        );

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
                LoadImages(),
                // DEMO ONLY.
                DelayWithProgressUpdate(800, "Example Resource 1 has finished loading."),
                DelayWithProgressUpdate(400, "Example Resource 2 has finished loading."),
                DelayWithProgressUpdate(1200, "Example Resource 3 has finished loading."),
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

    private Task LoadImages(string[]? imageFileNames = null)
    {
        imageFileNames ??=
        [
            "Home.png",
            "Library.png",
            "Login.png",
            "Logout.png",
            "Menu.png",
            "Settings.png",
            "ProgressActivity.png",
            "AccountCircle.png",
        ];

        return Task.Run(() =>
        {
            foreach (var imageFileName in imageFileNames)
            {
                _imageFactory.LoadResource(
                    CoreAssembly.Reference.GetManifestResourceStream(
                        $"{CoreAssembly.Reference.GetName().Name}.{imageFileName.Replace("/", ".")}"
                    )!,
                    Path.GetFileNameWithoutExtension(imageFileName),
                    imageFileName
                );

                UpdateProgress($"Loaded Image File: {imageFileName}");
            }
        });
    }

    private Task LoadFonts(string[]? fontFileNames = null)
    {
        fontFileNames ??= ["MontaguSlab.ttf", "Montserrat.ttf", "Montserrat-Italic.ttf"];

        return Task.Run(() =>
        {
            foreach (var fontFileName in fontFileNames)
            {
                _fontFactory.LoadFont(
                    fontFileName,
                    CoreAssembly.Reference.GetManifestResourceStream(
                        $"{CoreAssembly.Reference.GetName().Name}.{fontFileName.Replace("/", ".")}"
                    )!
                );

                UpdateProgress($"Loaded Font File: {fontFileName}");
            }
        });
    }

    private Task LoadLargeData()
    {
        return Task.Run(() => { });
    }

    protected override void Initialize()
    {
        _logger.LogInformation("Splash Presenter initializing.");

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
