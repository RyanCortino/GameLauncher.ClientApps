using System.Drawing;
using GameLauncher.ClientApps.Winforms.Application.Common.Enums;

namespace GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

public interface IButtonBuilder : IControlBuilder
{
    public IButtonBuilder BuildFlatStyle(int value);

    public IButtonBuilder BuildImageAlign(int value);

    public IButtonBuilder BuildTextImageRelation(int value);

    public IButtonBuilder BuildDialogResult(int value);

    public IButtonBuilder BuildAutoSize(bool useAutoSize = true);

    public IButtonBuilder BuildMaximumSize(Size size);

    public IButtonBuilder BuildMinimumSize(Size size);

    public IButtonBuilder BuildCursorBehaviour(CursorTypes cursorType);

    void PerformClick();
}
