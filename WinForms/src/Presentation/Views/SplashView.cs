using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class SplashView(ILogger<SplashView> logger) : BaseView(logger), ISplashView
{
    private Label? _assemblyVersionLabel;

    private Label? _reportProgressLabel;

    public string AssemblyVersion
    {
        get => _assemblyVersionLabel?.Text.Trim() ?? string.Empty;
        private set
        {
            if (_assemblyVersionLabel is null)
                return;

            if (InvokeRequired)
            {
                Invoke(() => _assemblyVersionLabel.Text = value);
                return;
            }

            _assemblyVersionLabel.Text = value;
        }
    }

    public void Report(string value)
    {
        if (_reportProgressLabel is null)
            return;

        if (InvokeRequired)
        {
            Invoke(() => _reportProgressLabel.Text = value);
            return;
        }

        _reportProgressLabel.Text = value;
    }

    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        // Set the basic properties of the splash screen form
        Text = "Splash Screen";
        FormBorderStyle = FormBorderStyle.None; // No borders for a clean look
        StartPosition = FormStartPosition.CenterScreen; // Center the splash screen
        TopMost = true; // Ensure the splash screen is always on top
        ShowInTaskbar = false; // Prevent showing in the taskbar
        Opacity = 0.95; // Optional: Set slight transparency
        ControlBox = false; // Disable close button
        MaximizeBox = false; // Disable maximize box
        MinimizeBox = false; // Disable minimize box

        Size = new Size(16, 9) * 42;

        BackgroundImage = Image.FromStream(new MemoryStream(Properties.Resources.SplashImage));
        BackgroundImageLayout = ImageLayout.Zoom; // Adjust the layout of the background image

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
            Font = new Font("Segoe UI", ClientSize.Width / 80, FontStyle.Bold), // Set font style and Dynamic Font Resizing Based on Screen Resolution
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
            ClientSize.Width - _assemblyVersionLabel.Width - 20,
            ClientSize.Height - _assemblyVersionLabel.Height - 20
        );

        // Adjust location dynamically if AutoSize changes label size
        _assemblyVersionLabel.LocationChanged += (sender, e) =>
            _assemblyVersionLabel.Location = new Point(
                ClientSize.Width - _assemblyVersionLabel.Width - 20,
                ClientSize.Height - _assemblyVersionLabel.Height - 20
            );

        // Add the label to the splash screen form controls
        Controls.Add(_assemblyVersionLabel);
    }

    private void AddReportProgressLabel()
    {
        // Create a new label to display the version number
        _reportProgressLabel = new Label
        {
            AutoSize = true,
            Text = $"Preloading assets..", // Set version dynamically
            Font = new Font("Segoe UI", ClientSize.Width / 100, FontStyle.Regular), // Set font style and Dynamic Font Resizing Based on Screen Resolution
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
            ClientSize.Height - _reportProgressLabel.Height - 20
        );

        // Adjust location dynamically if AutoSize changes label size
        _reportProgressLabel.LocationChanged += (sender, e) =>
            _reportProgressLabel.Location = new Point(
                20,
                ClientSize.Height - _reportProgressLabel.Height - 20
            );

        // Add the label to the splash screen form controls
        Controls.Add(_reportProgressLabel);
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

        Controls.Add(progressBar);
    }
}
