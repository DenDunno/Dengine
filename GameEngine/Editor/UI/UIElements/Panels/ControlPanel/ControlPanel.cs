using ImGuiNET;

public class ControlPanel : Panel
{
    public readonly PlayButton PlayButton = new();
    public readonly StopButton StopButton = new();
    
    public ControlPanel() : base("Control panel")
    {
    }

    protected override void OnPanelDraw()
    {
        PlayButton.Draw();
        StopButton.Draw();
        ImGui.Checkbox("Gizmo", ref Gizmo.Instance.Enabled);
    }
}