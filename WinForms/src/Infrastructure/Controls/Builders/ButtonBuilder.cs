using GameLauncher.ClientApps.Winforms.Application.Common.Enums;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

internal class ButtonBuilder : ControlBuilder, IButtonBuilder
{
    private Button? Button => _control as Button;

    public ButtonBuilder()
        : base(new Button()) { }

    public IButtonBuilder BuildAutoSize(bool useAutoSize = true)
    {
        Button!.AutoSize = useAutoSize;

        return this;
    }

    public IButtonBuilder BuildFlatStyle(int value)
    {
        Button!.FlatStyle = (FlatStyle)value;
        return this;
    }

    public IButtonBuilder BuildImageAlign(int value)
    {
        Button!.ImageAlign = (ContentAlignment)value;
        return this;
    }

    public IButtonBuilder BuildTextImageRelation(int value)
    {
        Button!.TextImageRelation = (TextImageRelation)value;
        return this;
    }

    public IButtonBuilder BuildDialogResult(int value)
    {
        Button!.DialogResult = (DialogResult)value;
        return this;
    }

    public IButtonBuilder BuildMaximumSize(Size size)
    {
        Button!.MaximumSize = size;
        return this;
    }

    public IButtonBuilder BuildMinimumSize(Size size)
    {
        Button!.MinimumSize = size;
        return this;
    }

    public IButtonBuilder BuildCursorBehaviour(CursorTypes cursorType)
    {
        Button!.Cursor = cursorType switch
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
