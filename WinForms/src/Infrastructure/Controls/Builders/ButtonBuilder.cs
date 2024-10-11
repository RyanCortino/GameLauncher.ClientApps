using GameLauncher.ClientApps.Winforms.Application.Common.Enums;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class ButtonBuilder : AbstractControlBuilder, IButtonBuilder
{
    private new Button _control = new();

    public Button GetResult => _control;

    public override void Reset() => _control = new Button();

    public IButtonBuilder BuildAutoSize(bool useAutoSize = true)
    {
        _control.AutoSize = useAutoSize;

        return this;
    }

    public IButtonBuilder BuildFlatStyle(int value)
    {
        _control.FlatStyle = (FlatStyle)value;
        return this;
    }

    public IButtonBuilder BuildImageAlign(int value)
    {
        _control.ImageAlign = (ContentAlignment)value;
        return this;
    }

    public IButtonBuilder BuildTextImageRelation(int value)
    {
        _control.TextImageRelation = (TextImageRelation)value;
        return this;
    }

    public IButtonBuilder BuildDialogResult(int value)
    {
        _control.DialogResult = (DialogResult)value;
        return this;
    }

    public IButtonBuilder BuildMaximumSize(Size size)
    {
        _control.MaximumSize = size;
        return this;
    }

    public IButtonBuilder BuildMinimumSize(Size size)
    {
        _control.MinimumSize = size;
        return this;
    }

    public IButtonBuilder BuildCursorBehaviour(CursorTypes cursorType)
    {
        _control.Cursor = cursorType switch
        {
            CursorTypes.AppStarting => Cursors.AppStarting,
            CursorTypes.Arrow => Cursors.Arrow,
            CursorTypes.Cross => Cursors.Cross,
            CursorTypes.Hand => Cursors.Hand,
            CursorTypes.Help => Cursors.Help,
            CursorTypes.IBeam => Cursors.IBeam,
            CursorTypes.No => Cursors.No,
            CursorTypes.SizeAll => Cursors.SizeAll,
            CursorTypes.SizeNorthEastSouthWest => Cursors.SizeNESW,
            CursorTypes.SizeWestEast => Cursors.SizeWE,
            CursorTypes.UpArrow => Cursors.UpArrow,
            CursorTypes.Wait => Cursors.WaitCursor,
            _ => Cursors.Default,
        };

        return this;
    }

    public void PerformClick()
    {
        throw new NotImplementedException();
    }
}
