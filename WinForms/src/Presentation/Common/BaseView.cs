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

    public event EventHandler? OnViewShown;
    public event EventHandler? OnViewResized;

    protected readonly ILogger _logger;

    public virtual void InitializeView()
    {
        _logger.LogInformation("Initializing View: {viewType}", this.GetType().Name);

        SetSize();
        SetupAppearence();
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
        this.Load += View_Load;
        this.Shown += View_Shown;
        this.Resize += View_Resized;
    }

    private void DeregisterEventHandlers()
    {
        this.Load -= View_Load;
        this.Shown -= View_Shown;
        this.Resize -= View_Resized;
    }

    // Virtual method to handle Form Load event
    protected virtual void View_Load(object? sender, EventArgs e)
    {
        _logger.LogInformation("Loaded View: {viewType}.", this.GetType().Name);
    }

    // Virtual method to handle Form Shown event
    protected virtual void View_Shown(object? sender, EventArgs e)
    {
        OnViewShown?.Invoke(this, e);
    }

    protected virtual void View_Resized(object? sender, EventArgs e)
    {
        OnViewResized?.Invoke(this, e);
    }

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
