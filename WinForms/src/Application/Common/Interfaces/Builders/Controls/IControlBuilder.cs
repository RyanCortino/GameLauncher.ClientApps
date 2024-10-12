using System.Drawing;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

public interface IControlBuilder : IBuilder
{
    // Common Text-Related Properties
    public IControlBuilder BuildText(string text);

    public IControlBuilder BuildFont(Font? font);

    public IControlBuilder BuildForeColor(Color color);

    public IControlBuilder BuildBackColor(Color color);

    // Common Layout Properties
    public IControlBuilder BuildSize(Size size);

    public IControlBuilder BuildLocation(Point point);

    public IControlBuilder BuildPadding(int all);

    public IControlBuilder BuildMargin(int all);

    public IControlBuilder BuildPadding(int left, int top, int right, int bottom);

    public IControlBuilder BuildMargin(int left, int top, int right, int bottom);

    public IControlBuilder BuildDockStyle(int value);

    public IControlBuilder BuildAnchorStyles(int value);

    // Common Appearance Properties


    public IControlBuilder BuildBackgroundImage(Image image);

    public IControlBuilder BuildBackgroundImageLayout(int value);

    // Common Behavior Properties
    public IControlBuilder BuildEnabledBehaviour(bool isEnabled);

    public IControlBuilder BuildVisibleBehaviour(bool isVisible);

    public IControlBuilder BuildTabIndexBehaviour(int tabIndex);

    // Common Events

    public IControlBuilder BuildClickEventHandler();

    public IControlBuilder BuildMouseEnterEventHandler();

    public IControlBuilder BuildMouseExitEventHandler();

    public IControlBuilder BuildKeyUpEventHandler();

    public IControlBuilder BuildKeyDownEventHandler();
}
