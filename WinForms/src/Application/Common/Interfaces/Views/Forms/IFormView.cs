namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views.Forms
{
    public interface IFormView : IView
    {
        event EventHandler? ViewShown;
        event EventHandler? ViewResized;
        event EventHandler? ViewLoaded;

        void CloseView();
    }
}
