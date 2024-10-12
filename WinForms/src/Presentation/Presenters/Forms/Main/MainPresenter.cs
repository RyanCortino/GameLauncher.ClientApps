using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Menus;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Presenters.Controls;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms.MainMdiForm;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.UserControls.Content;

namespace GameLauncher.ClientApps.Winforms.Presentation.Presenters.Forms.Main;

internal class MainPresenter(
    IOptions<ApplicationOptions> applicationOptions,
    ITaskbarContextMenu taskbarContextMenu,
    INavigationPresenter navigationPresenter,
    IMainView view,
    IHomeView homeViewUC,
    ILibraryView libraryViewUC,
    ISettingsView settingsViewUC,
    ILogger<MainPresenter> logger
) : FormPresenter(view, logger), IMainPresenter
{
    private readonly ApplicationOptions _applicationOptions = applicationOptions.Value;
    private readonly ITaskbarContextMenu _taskbarContextMenu = taskbarContextMenu;
    private readonly INavigationPresenter _navigationPresenter = navigationPresenter;

    private readonly IHomeView _homeView = homeViewUC;
    private readonly ILibraryView _libraryView = libraryViewUC;
    private readonly ISettingsView _settingsView = settingsViewUC;

    public override IMainView? View => _view as IMainView;

    public override void InitializePresenter()
    {
        base.InitializePresenter();

        if (View is null)
            return;

        _navigationPresenter.InitializePresenter();

        View.InitializeView();
        View.AddUserControl(_navigationPresenter.View);

        _navigationPresenter.ContextMenu.HomeClicked += OnHomeClicked;
        _navigationPresenter.ContextMenu.LibraryClicked += OnLibraryClicked;
        _navigationPresenter.ContextMenu.SettingsClicked += OnSettingsClicked;
    }

    private void OnSettingsClicked(object? sender, EventArgs e)
    {
        _logger.LogInformation("Settings Button Clicked.");
    }

    private void OnLibraryClicked(object? sender, EventArgs e)
    {
        _logger.LogInformation("Library Button Clicked.");
    }

    private void OnHomeClicked(object? sender, EventArgs e)
    {
        _logger.LogInformation("Home Button Clicked.");
    }

    protected override void OnViewResized(object? sender, EventArgs e)
    {
        var form = sender as Form;

        // Check Application Options
        if (_applicationOptions.ShouldMinimizeToSystemTray)
        {
            // Check if the form is minimized
            if (form?.WindowState == FormWindowState.Minimized)
            {
                // Hide the form and show a balloon tip
                form.Hide();

                _taskbarContextMenu.ShowBalloonTip(
                    100,
                    "Application Minimized",
                    "Your app is now minimized to the tray.",
                    (int)ToolTipIcon.Info
                );

                return;
            }
        }
    }
}
