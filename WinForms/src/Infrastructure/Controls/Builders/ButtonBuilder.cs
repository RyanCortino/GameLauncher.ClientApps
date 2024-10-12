using GameLauncher.ClientApps.Winforms.Application.Common.Enums;
using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Builders.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

public class ButtonBuilder : AbstractControlBuilder, IButtonBuilder
{
    private new Button _control = new();

    public Button GetResult => _control;

    public void PerformClick()
    {
        throw new NotImplementedException();
    }

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

    public IButtonBuilder BuildBorder(Color color, int size)
    {
        _control.FlatStyle = FlatStyle.Flat;
        _control.FlatAppearance.BorderColor = color;
        _control.FlatAppearance.BorderSize = size;

        return this;
    }

    public override void Reset() => _control = new Button();

    public override IButtonBuilder BuildAnchorStyles(int value)
    {
        _control.Anchor = (AnchorStyles)value;
        return this;
    }

    public override IButtonBuilder BuildBackColor(Color color)
    {
        _control.BackColor = color;
        return this;
    }

    public override IButtonBuilder BuildBackgroundImageLayout(int value)
    {
        _control.BackgroundImageLayout = (ImageLayout)value;
        return this;
    }

    public override IButtonBuilder BuildDockStyle(int value)
    {
        _control.Dock = (DockStyle)value;
        return this;
    }

    public override IButtonBuilder BuildFont(Font? font)
    {
        _control.Font = font ?? default;
        return this;
    }

    public override IButtonBuilder BuildForeColor(Color color)
    {
        _control.ForeColor = color;
        return this;
    }

    public override IButtonBuilder BuildBackgroundImage(Image image)
    {
        _control.BackgroundImage = image;
        return this;
    }

    public override IButtonBuilder BuildLocation(Point point)
    {
        _control.Location = point;
        return this;
    }

    public override IButtonBuilder BuildText(string text)
    {
        _control.Text = text;
        return this;
    }

    public override IButtonBuilder BuildSize(Size size)
    {
        _control.Size = size;
        return this;
    }

    public override IButtonBuilder BuildPadding(int all)
    {
        _control.Padding = new Padding(all);
        return this;
    }

    public override IButtonBuilder BuildPadding(int left, int top, int right, int bottom)
    {
        _control.Padding = new Padding(left, top, right, bottom);
        return this;
    }

    public override IButtonBuilder BuildMargin(int all)
    {
        _control.Margin = new Padding(all);
        return this;
    }

    public override IButtonBuilder BuildMargin(int left, int top, int right, int bottom)
    {
        _control.Margin = new Padding(left, top, right, bottom);
        return this;
    }

    public override IButtonBuilder BuildEnabledBehaviour(bool isEnabled)
    {
        _control.Enabled = isEnabled;
        return this;
    }

    public override IButtonBuilder BuildVisibleBehaviour(bool isVisible)
    {
        _control.Visible = isVisible;
        return this;
    }

    public override IButtonBuilder BuildTabIndexBehaviour(int tabIndex)
    {
        _control.TabIndex = tabIndex;
        return this;
    }

    public override IButtonBuilder BuildClickEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IButtonBuilder BuildMouseEnterEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IButtonBuilder BuildMouseExitEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IButtonBuilder BuildKeyUpEventHandler()
    {
        throw new NotImplementedException();
    }

    public override IButtonBuilder BuildKeyDownEventHandler()
    {
        throw new NotImplementedException();
    }
}
