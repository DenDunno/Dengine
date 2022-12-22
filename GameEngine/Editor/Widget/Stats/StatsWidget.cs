﻿using System.Numerics;
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
        ImGui.PushStyleColor(ImGuiCol.Text, _statsColor);
        
        ImGui.Text(GetBenchmarkTable());
        ImGui.Text($"FPS = {_stats.FPS}");
        ImGui.Text($"Draw calls = {_stats.DrawCalls}");
        
        ImGui.PopStyleColor();
    }

    private string GetBenchmarkTable()
    {
        ConsoleTable consoleTable = new();
        consoleTable.AddColumn(new[] {string.Empty, "Time mls", string.Empty});

        foreach (BenchmarkResult result in _stats.BenchmarkResults)
        {
            int percentage = (int)(result.Value / _stats.FrameTime * 100);
            consoleTable.AddRow(result.Name, Math.Round(result.Value, 2), $"{percentage}%%");
        }

        return consoleTable.ToMinimalString();
    }
}