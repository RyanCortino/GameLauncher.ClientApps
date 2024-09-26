namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views
{
    public interface IView
    {
        event EventHandler? OnViewLoaded;

        void CloseView();

        void InitializeView();
    }
}
