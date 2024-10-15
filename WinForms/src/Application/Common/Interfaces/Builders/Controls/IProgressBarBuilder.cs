namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IProgressBarBuilder<TBuilder> : IBaseControlBuilder<TBuilder>
    where TBuilder : IBaseControlBuilder<TBuilder>
{
    TBuilder SetValue(int currentValue);

    TBuilder SetHeight(int height);

    TBuilder SetMinimum(int min);

    TBuilder SetMaximum(int max);

    TBuilder SetStep(int step);

    TBuilder UseMargueeStyle(int? marqueeAnimationSpeed = null);
}
