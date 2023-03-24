using ImGuiNET;

public class DockSpace : UIElement
{
    protected override void OnDraw()
    {
        ImGui.DockSpaceOverViewport();
    }
}