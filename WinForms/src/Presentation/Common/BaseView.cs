using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common;

public class BaseView : Form, IFormView
{
    public BaseView(ILogger<BaseView> logger)
    {
        _logger = logger;

        RegisterEventHandlers();
    }

    ~BaseView()
    {
        DeregisterEventHandlers();
    }

    public event EventHandler? ViewShown;
    public event EventHandler? ViewResized;
    public event EventHandler? ViewLoaded;

    protected readonly ILogger _logger;

    public virtual void InitializeView()
    {
        _logger.LogInformation("Initializing View: {viewType}", this.GetType().Name);

        SetSize();
        SetupAppearence();
        SetupControls();
    }

    public virtual void CloseView()
    {
        if (InvokeRequired)
        {
            Invoke(this.Close);
            return;
        }

        Close();
    }

    private void RegisterEventHandlers()
    {
        this.Load += OnViewLoad;
        this.Shown += OnViewShown;
        this.Resize += OnViewResize;
        this.FormClosing -= OnFormClosing;
    }

    private void DeregisterEventHandlers()
    {
        this.Load -= OnViewLoad;
        this.Shown -= OnViewShown;
        this.Resize -= OnViewResize;
        this.FormClosing -= OnFormClosing;
    }

    protected virtual void OnFormClosing(object? sender, EventArgs e)
    {
        try
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Exception caught: {ex.Message}");
        }
    }

    // Virtual method to handle Form Load event
    protected virtual void OnViewLoad(object? sender, EventArgs e)
    {
        _logger.LogInformation("Loaded View: {viewType}.", this.GetType().Name);
        ViewLoaded?.Invoke(this, e);
    }

    // Virtual method to handle Form Shown event
    protected virtual void OnViewShown(object? sender, EventArgs e)
    {
        ViewShown?.Invoke(this, e);
    }

    protected virtual void OnViewResize(object? sender, EventArgs e)
    {
        ViewResized?.Invoke(this, e);
    }

    protected virtual void SetupControls() { }

    protected virtual void SetupAppearence()
    {
        // Set the basic properties of the BaseForm
        this.Text = "Base Form Title";
        this.AutoScaleMode = AutoScaleMode.Dpi; // Enable High-Dpi Settings
        this.DoubleBuffered = true; // Prevent flickering
        this.ShowInTaskbar = true;
    }

    protected virtual void SetSize(
        int width = 800,
        int height = 450,
        bool disableAutoSizing = false
    )
    {
        if (Screen.PrimaryScreen is null || disableAutoSizing)
        {
            // Set the calculated size
            this.Size = new Size(width, height);

            return;
        }

        // Calculate splash screen size as a proportion of screen dimensions

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // Set the splash screen size to 30% of screen width and 20% of screen height
        int splashWidth = (int)(screenWidth * 0.3);
        int splashHeight = (int)(screenHeight * 0.2);

        // Ensure minimum size for small screens (e.g., laptops)
        splashWidth = Math.Max(splashWidth, width / 2);
        splashHeight = Math.Max(splashHeight, height / 2);

        // Set the calculated size
        this.Size = new Size(splashWidth, splashHeight);
    }
}
