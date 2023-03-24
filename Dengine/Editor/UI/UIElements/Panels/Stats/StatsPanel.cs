using System.Numerics;
using ImGuiNET;

public class StatsPanel : Panel
{
    private readonly Vector4 _statsColor = new(0, 1, 0, 1);
    private readonly Stats _stats;
    
    public StatsPanel() : base("Stats", ImGuiWindowFlags.AlwaysAutoResize)
    {
        Enabled = false;
        _stats = Stats.Instance;
    }

    public override void Update(float deltaTime)
    {
        _stats.Update(deltaTime);
    }

    protected override void OnPanelDraw()
    {
        ImGui.PushStyleColor(ImGuiCol.Text, _statsColor);
        
        ImGui.Text(_stats.BenchmarkResults);
        ImGui.Spacing();
        ImGui.Text($"FPS = {_stats.FPS}");
        ImGui.Text($"Draw calls = {_stats.DrawCalls}");
        ImGui.Text($"Tris = {_stats.Tris}");
        ImGui.Text($"Vertices = {_stats.Vertices}");
        ImGui.Spacing();
        ImGui.Text(_stats.Renderer);

        ImGui.PopStyleColor();
    }
}