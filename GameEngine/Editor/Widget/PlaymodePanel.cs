using ImGuiNET;

public class PlaymodePanel : WidgetBase
{
    private readonly PlayButton _playButton = new();
    private readonly StopButton _stopButton = new();
    
    public PlaymodePanel() : base("Playmode panel", ImGuiWindowFlags.NoTitleBar)
    {
    }

    protected override void OnDraw()
    {
        _playButton.Draw();
        _stopButton.Draw();
    }
}