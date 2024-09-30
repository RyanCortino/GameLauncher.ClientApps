using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Forms;

public partial class SplashView : BaseView, ISplashView
{
    public SplashView(ILogger<SplashView> logger)
        : base(logger)
    {
        InitializeComponent();
    }

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

    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        // Set the basic properties of the splash screen form
        this.FormBorderStyle = FormBorderStyle.None; // No borders for a clean look
        this.StartPosition = FormStartPosition.CenterScreen; // Center the splash screen
        this.TopMost = true; // Ensure the splash screen is always on top
        this.ShowInTaskbar = false; // Prevent showing in the taskbar
        this.Opacity = 0.95; // Optional: Set slight transparency
        this.ControlBox = false; // Disable close button
        this.MaximizeBox = false; // Disable maximize box
        this.MinimizeBox = false; // Disable minimize box

        //this.BackgroundImage = Properties.Resources.SplashImage; // Set a custom splash image
        this.BackgroundImageLayout = ImageLayout.Zoom; // Adjust the layout of the background image

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
}
