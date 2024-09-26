namespace GameLauncher.ClientApps.Winforms.Presentation.Forms;

public partial class SplashView : Form, ISplashView
{
    public SplashView(ILogger<SplashView> logger, IOptions<ApplicationOptions> appOptions)
    {
        InitializeComponent();

        _logger = logger;
        _appOptions = appOptions.Value;
    }

    private readonly ApplicationOptions _appOptions;

    private readonly ILogger _logger;

    public event EventHandler? OnViewLoaded;

    public string AssemblyVersion { get; private set; } = string.Empty;

    private void SplashView_Load(object sender, EventArgs e)
    {
        OnViewLoaded?.Invoke(this, e);
    }

    public void InitializeView()
    {
        SetAppearance();
    }

    private delegate void BlankDelegate();

    public void CloseView()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new BlankDelegate(this.CloseView));
        }
        else
        {
            this.Close();
        }
    }

    public Task SetAssemblyVersion(string version)
    {
        AssemblyVersion = version;

        return Task.CompletedTask;
    }

    public void Report(string value)
    {
        StatusLabel.Text = value;
    }

    private void SetAppearance()
    {
        VersionLabel.Text = string.Empty;

        ProgressBar.Minimum = 0;
        ProgressBar.Maximum = 100;
        ProgressBar.Step = 10;
        ProgressBar.Value = 1;
    }
}
