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
        ImGui.SetWindowPos(Vector2.Zero, ImGuiCond.Always);
        ImGui.SetWindowSize(ImGui.GetIO().DisplaySize);
        ImGui.DockSpace(ImGui.GetID("Main"));
    }

    public override void AfterDraw()
    {
        ImGui.PopStyleVar();
    }
}