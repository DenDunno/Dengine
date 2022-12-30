using ImGuiNET;

public class DockSpace : IWidget
{
    public void Draw()
    {
        ImGui.DockSpaceOverViewport();
    }
}