namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views
{
    public interface IView
    {
        event EventHandler? OnViewShown;

        void CloseView();

        void InitializeView();
    }
}
