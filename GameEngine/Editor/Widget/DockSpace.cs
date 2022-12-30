using System.Numerics;
using ImGuiNET;

public class DockSpace : Widget
{
    public DockSpace() : base("Main", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBackground | 
                                      ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | 
                                      ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar |
                                      ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus | 
                                      ImGuiWindowFlags.NoDocking)
    {
    }

    public override void PreDraw()
    {
        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, Vector2.Zero);
    }

    protected override void OnDraw()
    {
        
        ImGui.DockSpace(ImGui.GetID("Dock"), Vector2.Zero);
    }

    public override void AfterDraw()
    {
        ImGui.PopStyleVar();
    }
}