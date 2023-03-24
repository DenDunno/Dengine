using ImGuiNET;

public class ControlPanel : Panel
{
    public readonly PlayButton PlayButton = new();
    public readonly StopButton StopButton = new();
    private static bool _isFullscreen = true;
    
    public ControlPanel() : base("Control panel")
    {
    }

    public static bool IsFullscreen => _isFullscreen;
    
    protected override void OnPanelDraw()
    {
        PlayButton.Draw();
        StopButton.Draw();
        ImGui.Checkbox("Gizmo", ref Gizmo.Instance.Enabled);
        ImGui.Checkbox("Is fullscreen", ref _isFullscreen);
    }
}