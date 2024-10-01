using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Navigation;
using Microsoft.Extensions.Logging;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Navigation;

public partial class NavigationViewUC : BaseViewUC, INavigationView
{
    public NavigationViewUC(INavigationContextMenu contextMenu, ILogger<NavigationViewUC> logger)
        : base(logger)
    {
        InitializeComponent();

        _contextMenu = contextMenu;
    }

    private readonly INavigationContextMenu _contextMenu;

    private FlowLayoutPanel? _buttonPanel;

    public override void InitializeView()
    {
        SetupControls();

        base.InitializeView();
    }

    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        // docking the UserControl to the left of the parent form
        this.Dock = DockStyle.Left;
        this.Margin = new Padding(10);

        this.AutoSize = true;
        this.MinimumSize = new Size(200, 100);

        this.BackColor = Color.LightGray;
    }

    private void SetupControls()
    {
        AddButtonPanel();

        GenerateButtonsFromContextMenu();
    }

    private void GenerateButtonsFromContextMenu()
    {
        if (_contextMenu is null || _buttonPanel is null)
            return;

        // Clear any existing buttons from the panel
        _buttonPanel.Controls.Clear();

        // Iterate through each ToolStripMenuItem in the ContextMenuStrip
        foreach (var menuItem in _contextMenu.Items)
        {
            var button = new Button()
            {
                Text = menuItem.Text,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Margin = new Padding(5),
            };

            // Set the same Click event as the Context Menu Item
            button.Click += (s, e) => menuItem.PerformClick();

            // Add the button to the panel
            _buttonPanel.Controls.Add(button);
        }
    }

    private void AddButtonPanel()
    {
        _buttonPanel = new FlowLayoutPanel()
        {
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoSize = true,
        };

        this.Controls.Add(_buttonPanel);
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
