namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views
{
    public interface IView
    {
        event EventHandler? OnViewShown;
        event EventHandler? OnViewResized;

        void CloseView();

        void InitializeView();
    }
}
