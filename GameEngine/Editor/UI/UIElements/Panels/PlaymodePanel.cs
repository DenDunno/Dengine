using ImGuiNET;

public class PlaymodePanel : Panel
{
    private readonly PlayButton _playButton = new();
    private readonly StopButton _stopButton = new();
    
    public PlaymodePanel() : base("Playmode panel", ImGuiWindowFlags.NoTitleBar)
    {
    }

    protected override void OnPanelDraw()
    {
        _playButton.Draw();
        _stopButton.Draw();
    }
}