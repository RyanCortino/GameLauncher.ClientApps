namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface ILinkedLabelBuilder<TBuilder> : ILabelBuilder<TBuilder>
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder SetLinkArea(int start, int length);
    TBuilder SetLinkBehavior(int linkBehavior);
    TBuilder SetLinkColor(string color);
}
