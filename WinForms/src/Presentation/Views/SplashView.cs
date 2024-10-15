using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class SplashView(
    ILabelBuilder<LabelBuilder> labelBuilder,
    IProgressBarBuilder<ProgressBarBuilder> progressBuilder,
    ILogger<SplashView> logger
) : BaseView(logger), ISplashView
{
    private readonly ILabelBuilder<LabelBuilder> _labelBuilder = labelBuilder;

    private readonly IProgressBarBuilder<ProgressBarBuilder> _progressBarBuilder = progressBuilder;

    private Label? _assemblyVersionLabel = new();

    private Label? _reportProgressLabel = new();

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
    }

    protected override void SetupControls()
    {
        // Build custom controls
        _assemblyVersionLabel = BuildVersionLabel();

        _assemblyVersionLabel.LocationChanged += (sender, e) =>
        {
            if (_assemblyVersionLabel is not null)
                _assemblyVersionLabel.Location = new Point(
                    ClientSize.Width - _assemblyVersionLabel.Width - 20,
                    ClientSize.Height - _assemblyVersionLabel.Height - 20
                );
        };

        _reportProgressLabel = BuildReportProgressLabel();

        _reportProgressLabel.LocationChanged += (sender, e) =>
        {
            if (_reportProgressLabel is not null)
                _reportProgressLabel.Location = new Point(
                    20,
                    ClientSize.Height - _reportProgressLabel.Height - 20
                );
        };

        // Add required controls to the splash screen form
        Controls.Add(BuildProgressBar());

        Controls.Add(_assemblyVersionLabel);

        Controls.Add(_reportProgressLabel);
    }

    private Label BuildVersionLabel()
    {
        _labelBuilder.Reset();

        _labelBuilder
            .SetLocation(
                ClientSize.Width - _assemblyVersionLabel!.Width - 20,
                ClientSize.Height - _assemblyVersionLabel.Height - 20
            )
            .UseAutoSize()
            .SetFont("Segoe UI", ClientSize.Width / 80, (int)FontStyle.Bold)
            .SetText($"Version {CoreAssembly.Version}")
            .SetForeColor("#000000")
            .UseTransparentBackColor()
            .SetAnchor((int)(AnchorStyles.Bottom | AnchorStyles.Right));

        return (_labelBuilder as LabelBuilder)!.Build();
    }

    private Label BuildReportProgressLabel()
    {
        _labelBuilder.Reset();

        _labelBuilder
            .SetLocation(20, ClientSize.Height - _reportProgressLabel!.Height - 20)
            .UseAutoSize()
            .SetFont("Segoe UI", ClientSize.Width / 80, (int)FontStyle.Regular)
            .SetText($"Preloading assets..")
            .SetForeColor("#808080")
            .UseTransparentBackColor()
            .SetTextAlign((int)ContentAlignment.MiddleLeft)
            .SetAnchor((int)(AnchorStyles.Bottom | AnchorStyles.Left));

        return (_labelBuilder as LabelBuilder)!.Build();
    }

    private ProgressBar BuildProgressBar()
    {
        _progressBarBuilder.Reset();

        _progressBarBuilder.UseMargueeStyle().SetDock((int)DockStyle.Bottom).SetHeight(10);

        return (_progressBarBuilder as ProgressBarBuilder)!.Build();
    }
}
