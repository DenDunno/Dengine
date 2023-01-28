using System.Numerics;
using ConsoleTables;
using ImGuiNET;

public class StatsPanel : Panel
{
    private readonly Vector4 _statsColor = new(0, 1, 0, 1);
    private readonly Stats _stats;
    
    public StatsPanel() : base("Stats", ImGuiWindowFlags.NoResize)
    {
        Enabled = false;
        _stats = Stats.Instance;
    }

    public override void Update(float deltaTime)
    {
        Stats.Instance.Update(deltaTime);
    }

    protected override void OnPanelDraw()
    {
        ImGui.SetWindowSize(new Vector2(300, 375));
        
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
        ConsoleTable table = new(string.Empty, "Time mls", string.Empty);

        AddRow(table, "Frame", _stats.FrameTime);

        foreach (BenchmarkResult result in _stats.BenchmarkResults)
        {
            AddRow(table, result.Name, result.Value);
        }

        return table.ToMinimalString();
    }

    private void AddRow(ConsoleTable table, string name, double time)
    {
        int percentage = (int)(time / _stats.FrameTime * 100);
        
        table.AddRow($"{name}\t", Math.Round(time, 2), $"{percentage}%%");
    }
}