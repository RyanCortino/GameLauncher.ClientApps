using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;
using GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Navigation;

internal class NavigationViewUC(
    ILabelBuilder<LabelBuilder> labelBuilder,
    IButtonBuilder<ButtonBuilder> buttonBuilder,
    IPictureBoxBuilder<PictureBoxBuilder> pictureBoxBuilder,
    IResourceFactory<Font> fontFactory,
    IResourceFactory<Icon> iconFactory,
    ILogger<NavigationViewUC> logger
) : BaseViewUC(logger), INavigationView
{
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;
    private readonly IResourceFactory<Font> _fontFactory = fontFactory;

    private readonly ILabelBuilder<LabelBuilder> _labelBuilder = labelBuilder;
    private readonly IButtonBuilder<ButtonBuilder> _buttonBuilder = buttonBuilder;
    private readonly IPictureBoxBuilder<PictureBoxBuilder> _pictureBoxBuilder = pictureBoxBuilder;

    private FlowLayoutPanel? _bodyPanel;

    protected override void SetupAppearence()
    {
        // docking the UserControl to the left of the parent form
        this.Dock = DockStyle.Fill;
        this.Margin = new Padding(10);
        this.AutoSize = false;
        this.MinimumSize = new Size(250, 400);
        this.BackColor = Color.LightGray;
    }

    protected override void SetupControls()
    {
        _bodyPanel = BuildFlowPanel();
        _bodyPanel.Controls.Add(BuildLogoImage());
        _bodyPanel.Controls.Add(BuildTitleLabel());

        // Control order affects the docking behavior. The body panel should be
        // added first to avoid issues with fill size.
        this.Controls.Add(_bodyPanel);
    }

    //private void AddHeader()
    //{
    //    PictureBox logoImage =
    //        new()
    //        {
    //            SizeMode = PictureBoxSizeMode.Zoom,
    //            Image = _iconFactory.GetResource("GameLauncher")?.ToBitmap(),
    //        };


    //    _headerPanel?.Controls.Add(logoImage);
    //    _headerPanel?.Controls.Add(titleLabel);
    //}

    public void ClearAllButtons()
    {
        // Clear any existing buttons from the panel
        _bodyPanel?.Controls.Clear();
    }

    public void AddButtonFrom(IMenuItem menuItem)
    {
        if (_bodyPanel is null)
            return;

        // Add the button to the panel
        _bodyPanel.Controls.Add(BuildNavButton(menuItem));
    }

    private FlowLayoutPanel BuildFlowPanel()
    {
        return new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill, // Fill the UserControl
            FlowDirection = FlowDirection.TopDown, // Stack buttons vertically
            WrapContents = false, // Prevent wrapping to next column
            AutoScroll = true, // Enable scroll if needed
            Padding = new Padding(0), // Remove any padding
            Margin = new Padding(0), // Remove any margin
            BackColor = Color.Transparent,
        };
    }

    private Button BuildNavButton(IMenuItem menuItem)
    {
        _buttonBuilder.Reset();

        _buttonBuilder
            .SetText(menuItem.Text)
            .SetSize(width: _bodyPanel!.ClientSize.Width, height: 42)
            .SetImageAlign((int)ContentAlignment.MiddleLeft)
            .SetTextAlign((int)ContentAlignment.MiddleCenter)
            .SetMargin(0);

        if (menuItem.Image is not null)
            _buttonBuilder.SetImage(menuItem.Image);

        var button = (_buttonBuilder as ButtonBuilder)!.Build();

        // Handle the flowPanel resizing event to update button widths dynamically
        _bodyPanel.SizeChanged += (s, e) => button.Width = _bodyPanel.ClientSize.Width;

        // Set the same Click event as the Context Menu Item
        button.Click += (s, e) => menuItem.PerformClick();

        return button;
    }

    private Label BuildTitleLabel()
    {
        _labelBuilder.Reset();

        _labelBuilder
            .SetText("Game\nLauncher")
            .SetFont("Montagu Slab 144pt", 12, (int)FontStyle.Regular)
            .UseAutoSize()
            .SetPadding(3)
            .SetMargin((int)ContentAlignment.BottomLeft);

        return (_labelBuilder as LabelBuilder)!.Build();
    }

    private PictureBox BuildLogoImage()
    {
        _pictureBoxBuilder.Reset();

        _pictureBoxBuilder
            .SetSizeMode((int)PictureBoxSizeMode.Zoom)
            .SetInitialImage("GameLauncher");

        return (_pictureBoxBuilder as PictureBoxBuilder)!.Build();
    }
}
