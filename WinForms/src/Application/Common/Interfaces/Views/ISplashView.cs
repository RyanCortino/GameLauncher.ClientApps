namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Views;

public interface ISplashView : IView, IProgress<string>
{
    string AssemblyVersion { get; }
}
