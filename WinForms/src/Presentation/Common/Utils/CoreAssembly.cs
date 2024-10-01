using System.Reflection;

namespace GameLauncher.ClientApps.Winforms.Presentation.Common.Utils;

public static class CoreAssembly
{
    public static readonly Assembly Reference = typeof(CoreAssembly).Assembly;
    public static readonly Version Version = Reference.GetName().Version!;
    public static readonly string? Name = typeof(CoreAssembly).Assembly.GetName().Name;
}
