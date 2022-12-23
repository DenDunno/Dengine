using System.Numerics;
using ConsoleTables;
using ImGuiNET;

public class StatsWidget : Widget
{
    private readonly Vector4 _statsColor = new(0, 1, 0, 1);
    private readonly Stats _stats;
    
    public StatsWidget() : base("Stats")
    {
        _stats = Stats.Instance;
    }

    protected override void OnDraw()
    {
        ImGui.SetWindowPos(Vector2.Zero);
        ImGui.SetWindowSize(new Vector2(425, 375));
        
        ImGui.PushStyleColor(ImGuiCol.Text, _statsColor);
        
        ImGui.Text(GetBenchmarkTable());
        ImGui.Text($"FPS = {_stats.FPS}");
        ImGui.Text($"Draw calls = {_stats.DrawCalls}");
        ImGui.Text($"Tris = {_stats.Tris}");
        ImGui.Text($"Vertices = {_stats.Vertices}");
        
        ImGui.PopStyleColor();
    }


    private string GetBenchmarkTable()
    {
        ConsoleTable consoleTable = new(string.Empty, "Time mls", string.Empty);

        foreach (BenchmarkResult result in _stats.BenchmarkResults)
        {
            int percentage = (int)(result.Value / _stats.FrameTime * 100);
            consoleTable.AddRow(result.Name, Math.Round(result.Value, 2), $"{percentage}%%");
        }

        return consoleTable.ToMinimalString();
    }
}