using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class ProgressBarBuilder
    : BaseControlBuilder<ProgressBar, ProgressBarBuilder>,
        IProgressBarBuilder<ProgressBarBuilder>
{
    public ProgressBarBuilder SetMaximum(int max)
    {
        _control.Maximum = max;
        return this;
    }

    public ProgressBarBuilder SetHeight(int height)
    {
        _control.Height = height;
        return this;
    }

    public ProgressBarBuilder SetMinimum(int min)
    {
        _control.Minimum = min;
        return this;
    }

    public ProgressBarBuilder SetStep(int step)
    {
        _control.Step = step;
        return this;
    }

    public ProgressBarBuilder SetValue(int currentValue)
    {
        _control.Value = currentValue;
        return this;
    }

    public ProgressBarBuilder UseMargueeStyle(int? marqueeAnimationSpeed = null)
    {
        _control.Style = ProgressBarStyle.Marquee;

        if (marqueeAnimationSpeed is not null)
            _control.MarqueeAnimationSpeed = (int)marqueeAnimationSpeed;

        return this;
    }
}
