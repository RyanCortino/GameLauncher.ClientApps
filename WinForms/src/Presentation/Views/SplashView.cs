using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.SplashScreen;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Directors;
using GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class SplashView(
    ILabelBuilder labelBuilder,
    ControlsDirector controlsDirector,
    ILogger<SplashView> logger
) : BaseView(logger), ISplashView
{
    private readonly ControlsDirector _controlsDirector = controlsDirector;

    private readonly LabelBuilder _labelBuilder = (LabelBuilder)labelBuilder;

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
            if (_assemblyVersionLabel is not null)
                _assemblyVersionLabel.Location = new Point(
                    20,
                    ClientSize.Height - _assemblyVersionLabel.Height - 20
                );
        };

        // Add required controls to the splash screen form
        Controls.Add(
            new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Dock = DockStyle.Bottom,
                Height = 10,
            }
        );

        Controls.Add(_assemblyVersionLabel);

        Controls.Add(_reportProgressLabel);
    }

    private Label BuildVersionLabel()
    {
        _controlsDirector.SetBuilder(_labelBuilder);

        _controlsDirector.ApplyCurrentTheme();

        _controlsDirector.MakeSimpleControl(
            // Position the label at the bottom-right corner with padding
            startingLocation: _assemblyVersionLabel is not null
                ? new Point(
                    ClientSize.Width - _assemblyVersionLabel.Width - 20,
                    ClientSize.Height - _assemblyVersionLabel.Height - 20
                )
                : null
        );

        // Build Text Properties
        _controlsDirector.MakeTextControl(
            // Set version dynamically
            text: $"Version {CoreAssembly.Version}",
            // Set font style and Dynamic Font Resizing Based on Screen Resolution
            font: new Font("Segoe UI", ClientSize.Width / 80, FontStyle.Bold),
            // Set contrasting color
            color: ColorTranslator.FromHtml("#CCCCCC")
        );

        // Call a few build steps specific to this element
        _labelBuilder
            // Make the label background transparent
            .BuildBackColor(Color.Transparent)
            // Anchor to bottom-right of the form
            .BuildAnchorStyles((int)(AnchorStyles.Bottom | AnchorStyles.Right));

        // Produce the resulting label control
        return _labelBuilder.GetResult;
    }

    private Label BuildReportProgressLabel()
    {
        _controlsDirector.SetBuilder(_labelBuilder);

        _controlsDirector.MakeSimpleControl(
            startingLocation: _reportProgressLabel is not null
                ? new Point(20, ClientSize.Height - _reportProgressLabel.Height - 20)
                : null
        );

        _controlsDirector.MakeTextControl(
            text: $"Preloading assets..",
            font: new Font("Segoe UI", ClientSize.Width / 100, FontStyle.Regular),
            color: ColorTranslator.FromHtml("#CCCCCC")
        );

        // Call a few build steps specific to this element
        _labelBuilder
            // Make the label background transparent
            .BuildBackColor(Color.Transparent)
            // Align text to the right
            .BuildTextAlign((int)ContentAlignment.MiddleLeft)
            // Anchor to bottom-left of the form
            .BuildAnchorStyles((int)(AnchorStyles.Bottom | AnchorStyles.Left));

        return _labelBuilder.GetResult;
    }
}
