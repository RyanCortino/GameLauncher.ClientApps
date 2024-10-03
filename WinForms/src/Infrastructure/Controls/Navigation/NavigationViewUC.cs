namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Navigation;

internal class NavigationViewUC(
    IResourceFactory<Font> fontFactory,
    IResourceFactory<Icon> iconFactory,
    ILogger<NavigationViewUC> logger
) : BaseViewUC(logger), INavigationView
{
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;
    private readonly IResourceFactory<Font> _fontFactory = fontFactory;

    private FlowLayoutPanel? _headerPanel;
    private FlowLayoutPanel? _bodyPanel;
    private FlowLayoutPanel? _footerPanel;

    public override void InitializeView()
    {
        // Setup Appearance called from base view
        base.InitializeView();
    }

    protected override void SetupAppearence()
    {
        // docking the UserControl to the left of the parent form
        this.Dock = DockStyle.Left;
        this.Margin = new Padding(10);
        this.AutoSize = false;
        this.MinimumSize = new Size(250, 400);
        this.BackColor = Color.LightGray;

        AddFlowPanels();

        AddHeader();

        AddFooter();
    }

    private void AddHeader()
    {
        PictureBox logoImage =
            new()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = _iconFactory.GetResource("GameLauncher")?.ToBitmap(),
            };

        Label titleLabel =
            new()
            {
                Text = "Game\nLauncher",
                UseCompatibleTextRendering = true,
                Font = _fontFactory.GetResource("Montagu Slab 144pt", 12f, FontStyle.Regular),
                AutoSize = true,
                Padding = new Padding(3),
                TextAlign = ContentAlignment.BottomLeft,
            };

        _headerPanel?.Controls.Add(logoImage);
        _headerPanel?.Controls.Add(titleLabel);
    }

    private void AddFooter() { }

    private void AddFlowPanels()
    {
        _headerPanel = new FlowLayoutPanel()
        {
            Dock = DockStyle.Top,
            FlowDirection = FlowDirection.LeftToRight,
            Height = 60,
            BackColor = Color.Transparent,
        };

        _bodyPanel = new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill, // Fill the UserControl
            FlowDirection = FlowDirection.TopDown, // Stack buttons vertically
            WrapContents = false, // Prevent wrapping to next column
            AutoScroll = true, // Enable scroll if needed
            Padding = new Padding(0), // Remove any padding
            Margin = new Padding(0), // Remove any margin
            BackColor = Color.Transparent,
        };

        _footerPanel = new FlowLayoutPanel()
        {
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.LeftToRight,
            Height = 30,
            WrapContents = false,
            BackColor = Color.Transparent,
        };

        // Control order affects the docking behavior. The body panel should be
        // added first to avoid issues with fill size.
        this.Controls.Add(_bodyPanel);
        this.Controls.Add(_headerPanel);
        this.Controls.Add(_footerPanel);
    }

    public void ClearAllButtons()
    {
        // Clear any existing buttons from the panel
        _bodyPanel?.Controls.Clear();
    }

    public void AddButtonFrom(IMenuItem menuItem)
    {
        if (_bodyPanel is null)
            return;

        var button = new Button()
        {
            Text = menuItem.Text,
            Image = menuItem.Image,
            AutoSize = false, // Disable AutoSize for the button
            Width = _bodyPanel.ClientSize.Width, // Set width to match panel width
            Height = 42, // Fixed height for the button
            TextAlign = ContentAlignment.MiddleCenter,
            ImageAlign = ContentAlignment.MiddleLeft,
            Margin = new Padding(0), // Remove margin to prevent gaps
        };

        // Handle the flowPanel resizing event to update button widths dynamically
        _bodyPanel.SizeChanged += (s, e) => button.Width = _bodyPanel.ClientSize.Width;

        // Set the same Click event as the Context Menu Item
        button.Click += (s, e) => menuItem.PerformClick();

        // Add the button to the panel
        _bodyPanel.Controls.Add(button);
    }
}
