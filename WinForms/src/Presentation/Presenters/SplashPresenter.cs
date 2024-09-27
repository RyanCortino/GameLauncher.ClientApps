using System.Drawing.Text;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters;

internal class SplashPresenter : BasePresenter, ISplashPresenter
{
    public SplashPresenter(
        ISplashView splashView,
        IOptions<ApplicationOptions> applicationOptions,
        ILogger<SplashPresenter> logger
    )
    {
        _splashView = splashView;

        _logger = logger;

        _applicationOptions = applicationOptions.Value;

        _fontCache = new PrivateFontCollection();

        _imageCache = [];

        Initialize();
    }

    ~SplashPresenter()
    {
        UnregisterEventHandlers();
    }

    private readonly ILogger _logger;

    private readonly ISplashView _splashView;

    private readonly ApplicationOptions _applicationOptions;

    private PrivateFontCollection _fontCache;

    private Dictionary<string, Image> _imageCache;

    public event EventHandler? OnPreloadCompleted;
    public override ISplashView GetView => _splashView;

    private static async Task Delay(int millisecondsDelay)
    {
        await Task.Delay(millisecondsDelay);
    }

    private static Stream GetFontStream(string fontResourceName)
    {
        return CoreAssembly.Reference.GetManifestResourceStream(
            $"{CoreAssembly.Reference.GetName().Name}.{fontResourceName.Replace("/", ".")}"
        )!;
    }

    private static Image? GetImageFromResource(string imageResourceName)
    {
        try
        {
            // Use reflection to access the resource stream
            var assembly = CoreAssembly.Reference;

            using Stream stream = CoreAssembly.Reference.GetManifestResourceStream(
                $"{CoreAssembly.Reference.GetName().Name}.{imageResourceName.Replace("/", ".")}"
            )!;

            if (stream != null)
                return Image.FromStream(stream);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to load image: {imageResourceName}\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        return null;
    }

    private async void OnViewLoadedEventHandler(object? sender, EventArgs e) =>
        await Task.Run(() => PreloadAsync(sender, e));

    private async void OnPreloadCompletedEventHandler(object? sender, EventArgs e) =>
        await Task.Run(() => CloseSplashView());

    private async Task CloseSplashView()
    {
        UpdateProgress("Loading complete.");

        await Delay(250);

        _splashView.CloseView();
    }

    private async Task PreloadAsync(object? sender, EventArgs e)
    {
        UpdateProgress("Loading resources...");

        await Task.Run(() =>
        {
            Task[] loadingTasks =
            [
                // Start the default delay given the provided app setting
                DelayTask((int)(_applicationOptions.DefaultSplashScreenDelay * 1000)),
                // Load fonts from the embedded resources
                LoadFonts(),
                // Load images from the embedded resources
                LoadImages(),
                // DEMO ONLY.
                DelayTask(800, "Example Resource 1 has finished loading."),
                DelayTask(400, "Example Resource 2 has finished loading."),
                DelayTask(1200, "Example Resource 3 has finished loading."),
            ];

            Task.WaitAll(loadingTasks);
        });

        OnPreloadCompleted?.Invoke(this, e);
    }

    private Task DelayTask(int delay, string? progressMessage = null)
    {
        return Task.Run(async () =>
        {
            await Delay(delay);

            if (progressMessage is not null)
                UpdateProgress(progressMessage);
        });
    }

    private Task LoadImages(string[]? imageFilenames = null)
    {
        imageFilenames ??=
        [
            "Home.png",
            "Library.png",
            "Login.png",
            "Logout.png",
            "Menu.png",
            "Settings.png",
            "ProgressActivity.png",
        ];

        return Task.Run(() =>
        {
            foreach (var imageFilename in imageFilenames)
            {
                var image = GetImageFromResource(imageFilename);

                if (image is not null)
                {
                    var imageName = Path.GetFileNameWithoutExtension(imageFilename);
                    _imageCache[imageName] = image;

                    UpdateProgress($"Loaded Image: {imageName}");
                    continue;
                }

                UpdateProgress($"Image Resource not found for {imageFilename}");
            }
        });
    }

    private Task LoadFonts(string[]? fontFilenames = null)
    {
        fontFilenames ??= ["MontaguSlab.ttf", "Montserrat.ttf", "Montserrat-Italic.ttf"];

        return Task.Run(() =>
        {
            foreach (var fontFilenames in fontFilenames)
            {
                using Stream fontStream = GetFontStream(fontFilenames);

                if (fontStream is not null)
                {
                    // Create an array to hold the font data
                    byte[] fontData = new byte[fontStream.Length];

                    fontStream.Read(fontData, 0, (int)fontStream.Length);

                    // Use unsafe context to add the font to the collection
                    IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(
                        (int)fontStream.Length
                    );

                    System.Runtime.InteropServices.Marshal.Copy(
                        fontData,
                        0,
                        fontPtr,
                        (int)fontStream.Length
                    );

                    _fontCache.AddMemoryFont(fontPtr, (int)fontStream.Length);

                    // Free the unmanaged memory
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }

                UpdateProgress($"Loaded Font File: {fontFilenames}");
            }
        });
    }

    private Task LoadLargeData()
    {
        return Task.Run(() => { });
    }

    private void Initialize()
    {
        _logger.LogInformation("Splash presenter initializing.");

        _splashView.InitializeView();

        RegisterEventHandlers();
    }

    private void RegisterEventHandlers()
    {
        OnPreloadCompleted += OnPreloadCompletedEventHandler;

        _splashView.OnViewLoaded += OnViewLoadedEventHandler;
    }

    private void UnregisterEventHandlers()
    {
        OnPreloadCompleted -= OnPreloadCompletedEventHandler;
        _splashView.OnViewLoaded -= OnViewLoadedEventHandler;
    }

    private void UpdateProgress(string message)
    {
        _logger.LogInformation("Processed: {@Message}", message);

        _splashView.Report(message);
    }
}
