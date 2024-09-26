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

        Initialize();
    }

    ~SplashPresenter()
    {
        UnregisterEventHandlers();
    }

    private readonly ILogger _logger;

    private readonly ISplashView _splashView;

    private readonly ApplicationOptions _applicationOptions;

    public event EventHandler? OnPreloadCompleted;
    public override ISplashView GetView => _splashView;

    private static async Task Delay(int millisecondsDelay)
    {
        await Task.Delay(millisecondsDelay);
    }

    private async void OnViewLoadedEventHandler(object? sender, EventArgs e) =>
        await Task.Run(() => Preload(sender, e));

    private async void OnPreloadCompletedEventHandler(object? sender, EventArgs e) =>
        await Task.Run(() => CloseSplashView());

    private async Task CloseSplashView()
    {
        UpdateProgress("Loading complete.");

        await Delay(100);

        _splashView.CloseView();
    }

    private async Task Preload(object? sender, EventArgs e)
    {
        await _splashView.SetAssemblyVersion(CoreAssembly.Version.ToString());

        await Task.Run(() =>
        {
            UpdateProgress("Loading resources...");

            Task[] loadingTasks =
            [
                GetDelayTask(
                    (int)(_applicationOptions.DefaultSplashScreenDelay * 1000),
                    "Default delay timer has expired."
                ),
                GetDelayTask(200, "Example Resource 1 has finished loading."),
                GetDelayTask(50, "Example Resource 2 has finished loading."),
                GetDelayTask(400, "Example Resource 3 has finished loading."),
            ];

            Task.WaitAll(loadingTasks);
        });

        OnPreloadCompleted?.Invoke(this, e);
    }

    private Task GetDelayTask(int delay, string progressMessage)
    {
        return Task.Run(async () =>
        {
            await Delay(delay);
            UpdateProgress(progressMessage);
        });
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
