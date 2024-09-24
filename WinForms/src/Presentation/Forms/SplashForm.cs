namespace GameLauncher.ClientApps.Winforms.Presentation.Forms;

public partial class SplashForm : Form, ISplashView, IProgress<string>
{
    public SplashForm(ILogger<SplashForm> logger, IOptions<ApplicationOptions> appOptions)
    {
        _logger = logger;
        _logger.LogInformation("Initializing Splash Form Components.");

        _appOptions = appOptions.Value;

        InitializeComponent();
    }

    private readonly ILogger _logger;

    private readonly ApplicationOptions _appOptions;

    public void InitializeView()
    {
        VersionLabel.Text = CoreAssembly.Version.ToString();
    }

    public void Report(string value)
    {
        _logger.LogInformation("{message}", value);

        StatusLabel.Text = value;
    }

    private async void SplashView_Load(object sender, EventArgs e)
    {
        InitializeView();

        this.ProgressBar.ProgressBar.Step = 10;

        // Load Resources and close when completed.
        await Task.Run(async () =>
        {
            Report("Loading resources...");

            var loadingTasks = new[]
            {
                Task.Run(
                    () =>
                        Delay(
                            (int)(_appOptions.DefaultSplashScreenDelay * 1000),
                            "Default delay timer has expired."
                        )
                ),
                Task.Run(() => Delay(2000, "Resource 1 has finished loading.")),
                Task.Run(() => Delay(500, "Resource 2 has finished loading.")),
                Task.Run(() => Delay(4000, "Resource 3 has finished loading.")),
            };

            Task.WaitAll(loadingTasks);

            await Delay(100, "Loading complete.");
        });

        Close();
    }

    private async Task Delay(int millisecondsDelay, string message = "")
    {
        await Task.Delay(millisecondsDelay);

        if (string.IsNullOrEmpty(message))
            return;

        Report(message);
    }
}
