using System.Reflection;

namespace GameLauncher.ClientApps.Winforms.Presentation.Services;

public static class CoreAssembly
{
    public static readonly Assembly Reference = typeof(CoreAssembly).Assembly;
    public static readonly Version Version = Reference.GetName().Version!;
}
