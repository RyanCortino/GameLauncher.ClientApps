namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms
{
    public interface IFormView : IView
    {
        event EventHandler? OnViewShown;
        event EventHandler? OnViewResized;

        void CloseView();
    }
}
