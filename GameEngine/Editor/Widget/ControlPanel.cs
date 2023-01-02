
public class ControlPanel : WidgetBase
{
    public readonly PlayButton PlayButton = new();
    public readonly StopButton StopButton = new();

    public ControlPanel() : base("Control panel")
    {
    }

    protected override void OnDraw()
    {
        PlayButton.Draw();
        StopButton.Draw();
    }
}