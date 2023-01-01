
public class ControlPanel : WidgetBase
{
    private readonly PlayButton _playButton = new();
    private readonly StopButton _stopButton = new();
    
    public ControlPanel() : base("Control panel")
    {
    }

    protected override void OnDraw()
    {
        _playButton.Draw();
        _stopButton.Draw();
    }
}