using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Navigation;

internal class NavigationViewUC(
    INavigationContextMenu contextMenu,
    ILogger<NavigationViewUC> logger
) : BaseViewUC(logger), INavigationView
{
    private readonly INavigationContextMenu _contextMenu = contextMenu;

    private FlowLayoutPanel? _flowPanel;

    public override void InitializeView()
    {
        // Setup Appearance called from base view
        base.InitializeView();

        _contextMenu.InitializeContextMenu();

        SetupControls();
    }

    protected override void SetupAppearence()
    {
        // docking the UserControl to the left of the parent form
        this.Dock = DockStyle.Left;
        this.Margin = new Padding(10);
        this.AutoSize = false;
        this.MinimumSize = new Size(250, 100);
        this.BackColor = Color.LightGray;
    }

    private void SetupControls()
    {
        AddFlowPanel();

        GenerateButtonsFromContextMenu();
    }

    private void AddFlowPanel()
    {
        // Create and configure a FlowLayoutPanel
        _flowPanel = new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill, // Fill the UserControl
            FlowDirection = FlowDirection.TopDown, // Stack buttons vertically
            WrapContents = false, // Prevent wrapping to next column
            AutoScroll = true, // Enable scroll if needed
            Padding = new Padding(0), // Remove any padding
            Margin = new Padding(0), // Remove any margin
            BackColor = Color.Transparent,
        };

        this.Controls.Add(_flowPanel);
    }

    private void GenerateButtonsFromContextMenu()
    {
        if (_contextMenu is null || _flowPanel is null)
            return;

        // Clear any existing buttons from the panel
        _flowPanel.Controls.Clear();

        // Iterate through each ToolStripMenuItem in the ContextMenuStrip
        foreach (var menuItem in _contextMenu.Items)
        {
            var button = new Button()
            {
                Text = menuItem.Text,
                Image = menuItem.Image,
                AutoSize = false, // Disable AutoSize for the button
                Width = _flowPanel.ClientSize.Width, // Set width to match panel width
                Height = 42, // Fixed height for the button
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0), // Remove margin to prevent gaps
            };

            // Handle the flowPanel resizing event to update button widths dynamically
            _flowPanel.SizeChanged += (s, e) => button.Width = _flowPanel.ClientSize.Width;

            // Set the same Click event as the Context Menu Item
            button.Click += (s, e) => menuItem.PerformClick();

            // Add the button to the panel
            _flowPanel.Controls.Add(button);
        }
    }

    protected override void RegisterEventHandlers()
    {
        _contextMenu.OnHomeClickedEventHandler += OnHomeClicked;
    }

    protected override void UnregisterEventHandlers() { }

    public void OnHomeClicked(object? sender, EventArgs e)
    {
        _logger.LogInformation("Navigation link for Home was clicked.");
    }
}
