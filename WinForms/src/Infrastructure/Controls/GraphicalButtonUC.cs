namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls;

public partial class GraphicalButtonUC : UserControl
{
    public GraphicalButtonUC()
    {
        InitializeComponent();

        SetupAppearence();

        RegisterEventHandlers();
    }

    private void RegisterEventHandlers()
    {
        // Hook up events for button-like behavior
        this.MouseEnter += UserControl_MouseEnter;
        this.MouseLeave += UserControl_MouseLeave;
        this.MouseClick += UserControl_MouseClick;
    }

    // PictureBox and Label declarations
    private readonly PictureBox? _pictureBox = new();
    private readonly Label? _label = new();

    // Property for setting the image in the PictureBox
    public Image? ButtonImage
    {
        get => _pictureBox.Image;
        set => _pictureBox.Image = value;
    }

    // Property for setting the text of the Label
    public string ButtonText
    {
        get => _label.Text;
        set => _label.Text = value;
    }

    // Event handler for mouse enter - change color to indicate hover
    private void UserControl_MouseEnter(object? sender, EventArgs e)
    {
        this.BackColor = Color.Gray; // Change to a darker color on hover
    }

    // Event handler for mouse leave - revert color
    private void UserControl_MouseLeave(object? sender, EventArgs e)
    {
        this.BackColor = Color.LightGray; // Revert to default color
    }

    // Event handler for mouse click - invoke any assigned click event handler
    private void UserControl_MouseClick(object? sender, MouseEventArgs e)
    {
        // Propagate the click event to parent controls
        this.OnClick(e);
    }

    private void SetupAppearence()
    {
        // Set default styles for the control
        this.Size = new Size(150, 42);
        this.Cursor = Cursors.Hand; // Set cursor to hand
        this.Padding = new Padding(10, 0, 0, 0);

        ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();

        this.SuspendLayout();

        //
        // pictureBox
        //

        this._pictureBox.Size = new Size(32, 32);
        this._pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        this._pictureBox.Dock = DockStyle.Left;
        this._pictureBox.MouseEnter += UserControl_MouseEnter; // Forward events to UserControl
        this._pictureBox.MouseLeave += UserControl_MouseLeave;
        this._pictureBox.MouseClick += UserControl_MouseClick;

        //
        // label
        //

        this._label.Dock = DockStyle.Fill;
        this._label.TextAlign = ContentAlignment.MiddleLeft; // Align text to the left
        this._label.Padding = new Padding(10, 0, 0, 0);
        this._label.MouseEnter += UserControl_MouseEnter; // Forward events to UserControl
        this._label.MouseLeave += UserControl_MouseLeave;
        this._label.MouseClick += UserControl_MouseClick;

        //
        // GraphicalButtonControl
        //
        this.Controls.Add(this._label);
        this.Controls.Add(this._pictureBox);
        this.Name = "GraphicalButtonControl";

        ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();

        this.ResumeLayout(false);
    }
}
