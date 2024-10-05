using GameLauncher.ClientApps.Winforms.Application.Common.Interfaces.Controls;

namespace GameLauncher.ClientApps.Winforms.Infrastructure.Controls.Builders;

internal class LabelBuilder : ControlBuilder, ILabelBuilder
{
    private Label? Label => _control as Label;

    public LabelBuilder()
        : base(new Label()) { }

    public ILabelBuilder BuildAutoSize(bool useAutoSize = true)
    {
        Label!.AutoSize = useAutoSize;
        return this;
    }

    public ILabelBuilder BuildTextAlign(int value)
    {
        Label!.TextAlign = (ContentAlignment)value;
        return this;
    }

    public ILabelBuilder BuildMaximumSize(Size size)
    {
        Label!.MaximumSize = size;
        return this;
    }

    public ILabelBuilder BuildMinimumSize(Size size)
    {
        Label!.MinimumSize = size;
        return this;
    }
}
