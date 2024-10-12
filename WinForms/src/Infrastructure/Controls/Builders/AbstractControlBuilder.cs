using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public abstract class AbstractControlBuilder : IControlBuilder
{
    protected Control _control = new();

    public abstract void Reset();

    public abstract IControlBuilder BuildAnchorStyles(int value);

    public abstract IControlBuilder BuildBackColor(Color color);

    public abstract IControlBuilder BuildBackgroundImageLayout(int value);

    public abstract IControlBuilder BuildDockStyle(int value);

    public abstract IControlBuilder BuildFont(Font? font);

    public abstract IControlBuilder BuildForeColor(Color color);

    public abstract IControlBuilder BuildBackgroundImage(Image image);

    public abstract IControlBuilder BuildLocation(Point point);

    public abstract IControlBuilder BuildText(string text);

    public abstract IControlBuilder BuildSize(Size size);

    public abstract IControlBuilder BuildPadding(int all);

    public abstract IControlBuilder BuildMargin(int all);

    public abstract IControlBuilder BuildPadding(int left, int top, int right, int bottom);

    public abstract IControlBuilder BuildMargin(int left, int top, int right, int bottom);

    public abstract IControlBuilder BuildEnabledBehaviour(bool isEnabled);

    public abstract IControlBuilder BuildVisibleBehaviour(bool isVisible);

    public abstract IControlBuilder BuildTabIndexBehaviour(int tabIndex);

    public abstract IControlBuilder BuildClickEventHandler();

    public abstract IControlBuilder BuildMouseEnterEventHandler();

    public abstract IControlBuilder BuildMouseExitEventHandler();

    public abstract IControlBuilder BuildKeyUpEventHandler();

    public abstract IControlBuilder BuildKeyDownEventHandler();
}
