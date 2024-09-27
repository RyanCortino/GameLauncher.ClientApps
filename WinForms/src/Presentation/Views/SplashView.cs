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

    private Label? _assemblyVersionLabel;

    private Label? _reportProgressLabel;

    public string AssemblyVersion
    {
        get => _assemblyVersionLabel?.Text.Trim() ?? string.Empty;
        private set
        {
            if (_assemblyVersionLabel is null)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(() => _assemblyVersionLabel.Text = value);
                return;
            }

            _assemblyVersionLabel.Text = value;
        }
    }

    private void SplashView_Load(object sender, EventArgs e)
    {
        OnViewLoaded?.Invoke(this, e);
    }

    public void InitializeView()
    {
        SetupSplashScreen();
    }

    public void CloseView()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(this.Close);
            return;
        }

        this.Close();
    }

    public void Report(string value)
    {
        if (_reportProgressLabel is null)
            return;

        if (this.InvokeRequired)
        {
            this.Invoke(() => _reportProgressLabel.Text = value);
            return;
        }

        _reportProgressLabel.Text = value;
    }

    private void SetupSplashScreen()
    {
        // Set the basic properties of the splash screen form
        this.FormBorderStyle = FormBorderStyle.None; // No borders for a clean look
        this.StartPosition = FormStartPosition.CenterScreen; // Center the splash screen
        this.TopMost = true; // Ensure the splash screen is always on top
        this.ShowInTaskbar = false; // Prevent showing in the taskbar
        this.Opacity = 0.95; // Optional: Set slight transparency
        this.ControlBox = false; // Disable close button
        this.MaximizeBox = false; // Disable maximize box
        this.MinimizeBox = false; // Disable minimize box
        this.DoubleBuffered = true; // Prevent flickering
        this.AutoScaleMode = AutoScaleMode.Dpi; // Enable High-Dpi Settings

        //this.BackgroundImage = Properties.Resources.SplashImage; // Set a custom splash image
        this.BackgroundImageLayout = ImageLayout.Zoom; // Adjust the layout of the background image

        SetSplashScreenSize();

        AddProgressBar();

        AddVersionLabel();

        AddReportProgressLabel();
    }

    private void AddVersionLabel()
    {
        // Create a new label to display the version number
        _assemblyVersionLabel = new Label
        {
            AutoSize = true,
            Text = $"Version {CoreAssembly.Version}", // Set version dynamically
            Font = new Font("Segoe UI", this.ClientSize.Width / 80, FontStyle.Bold), // Set font style and Dynamic Font Resizing Based on Screen Resolution
            ForeColor = Color.FromArgb(50, 50, 50), // Set font color for good contrast
            BackColor = Color.Transparent, // Make the label background transparent
            TextAlign = ContentAlignment.MiddleRight, // Align text to the right
            Anchor =
                AnchorStyles.Bottom
                | AnchorStyles.Right // Anchor to bottom-right of the form
            ,
        };

        // Position the label at the bottom-right corner with padding
        _assemblyVersionLabel.Location = new Point(
            this.ClientSize.Width - _assemblyVersionLabel.Width - 20,
            this.ClientSize.Height - _assemblyVersionLabel.Height - 20
        );

        // Adjust location dynamically if AutoSize changes label size
        _assemblyVersionLabel.LocationChanged += (sender, e) =>
            _assemblyVersionLabel.Location = new Point(
                this.ClientSize.Width - _assemblyVersionLabel.Width - 20,
                this.ClientSize.Height - _assemblyVersionLabel.Height - 20
            );

        // Add the label to the splash screen form controls
        this.Controls.Add(_assemblyVersionLabel);
    }

    private void AddReportProgressLabel()
    {
        // Create a new label to display the version number
        _reportProgressLabel = new Label
        {
            AutoSize = true,
            Text = $"Preloading assets..", // Set version dynamically
            Font = new Font("Segoe UI", this.ClientSize.Width / 100, FontStyle.Regular), // Set font style and Dynamic Font Resizing Based on Screen Resolution
            ForeColor = Color.FromArgb(50, 50, 50), // Set font color for good contrast
            BackColor = Color.Transparent, // Make the label background transparent
            TextAlign = ContentAlignment.MiddleLeft, // Align text to the right
            Anchor =
                AnchorStyles.Bottom
                | AnchorStyles.Left // Anchor to bottom-left of the form
            ,
        };

        // Position the label at the bottom-letft corner with padding
        _reportProgressLabel.Location = new Point(
            20,
            this.ClientSize.Height - _reportProgressLabel.Height - 20
        );

        // Adjust location dynamically if AutoSize changes label size
        _reportProgressLabel.LocationChanged += (sender, e) =>
            _reportProgressLabel.Location = new Point(
                20,
                this.ClientSize.Height - _reportProgressLabel.Height - 20
            );

        // Add the label to the splash screen form controls
        this.Controls.Add(_reportProgressLabel);
    }

    private void AddProgressBar()
    {
        // add a progress bar
        var progressBar = new ProgressBar
        {
            Style = ProgressBarStyle.Marquee,
            Dock = DockStyle.Bottom,
            Height = 10,
        };

        this.Controls.Add(progressBar);
    }

    private void SetSplashScreenSize()
    {
        // Calculate splash screen size as a proportion of screen dimensions
        int screenWidth = Screen.PrimaryScreen?.Bounds.Width ?? 450;
        int screenHeight = Screen.PrimaryScreen?.Bounds.Height ?? 800;

        // Set the splash screen size to 30% of screen width and 20% of screen height
        int splashWidth = (int)(screenWidth * 0.3);
        int splashHeight = (int)(screenHeight * 0.2);

        // Ensure minimum size for small screens (e.g., laptops)
        splashWidth = Math.Max(splashWidth, 400); // Minimum width 400px
        splashHeight = Math.Max(splashHeight, 300); // Minimum height 300px

        // Set the calculated size
        this.Size = new Size(splashWidth, splashHeight);
    }
}
