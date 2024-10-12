using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Factories;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls;

namespace GameLauncher.ClientApps.Winforms.Presentation.Views;

internal class MainView(
    IResourceFactory<Icon> iconFactory,
    IPictureBoxBuilder pictureBoxBuilder,
    ILogger<MainView> logger
) : BaseView(logger), IMainView
{
    private readonly IResourceFactory<Icon> _iconFactory = iconFactory;

    private readonly IPictureBoxBuilder _pictureBoxBuilder = pictureBoxBuilder;

    private TableLayoutPanel _tableLayoutPanel = new();
    private StatusStrip _statusStrip = new();

    public void AddUserControl(IUserControlView? userControl)
    {
        if (userControl is null)
            return;

        _tableLayoutPanel.Controls.Add(userControl as UserControl, 0, 0);
    }

    protected override void SetupAppearence()
    {
        base.SetupAppearence();

        this.Text = "Game Launcher";
        this.Icon = _iconFactory.GetResource("GameLauncher");
        this.Size = new Size(1280, 720);
        this.MinimumSize = new Size(640, 360);
    }

    protected override void SetupControls()
    {
        base.SetupControls();

        BuildLayout();

        BuildStatusStrip();
    }

    private void BuildLayout()
    {
        // Set the panel to dock to the entire form
        _tableLayoutPanel.Dock = DockStyle.Fill;

        // Define the layout: 2 row and 2 columns
        _tableLayoutPanel.ColumnCount = 2;
        _tableLayoutPanel.RowCount = 2;

        // Set column widths: 200px for the left column, remaining for the right
        _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // fixed width for left
        _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // remaining for main content

        // Set row heights: main area gets 100%, status bar gets auto height
        _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Main area
        _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Status bar

        // Add the TableLayoutPanel to the form
        this.Controls.Add(_tableLayoutPanel);
    }

    private void BuildStatusStrip()
    {
        // Create a label for the status bar
        var toolStripStatusLabel = new ToolStripStatusLabel
        {
            Text = "Ready",
            BorderSides = ToolStripStatusLabelBorderSides.All,
            BorderStyle = Border3DStyle.Sunken,
        };

        // Create a progress bar for the status bar
        var toolStripProgressBar = new ToolStripProgressBar
        {
            Value = 0,
            Minimum = 0,
            Maximum = 100,
            Width = 100,
        };

        // Add controls to the StatusStrip
        _statusStrip.Items.Add(toolStripStatusLabel);
        _statusStrip.Items.Add(toolStripProgressBar);

        // Dock the statusStrip at the bottom of the form
        _statusStrip.Dock = DockStyle.Bottom;

        // Add the StatusStrip to the form's Controls
        _tableLayoutPanel.SetColumnSpan(_statusStrip, 2);
        _tableLayoutPanel.Controls.Add(_statusStrip);
    }

    public void CloseAll()
    {
        foreach (Form childForm in MdiChildren)
        {
            childForm.Close();
        }
    }
}
