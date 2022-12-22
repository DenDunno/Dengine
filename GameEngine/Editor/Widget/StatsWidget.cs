using System.Numerics;
using ConsoleTables;
using ImGuiNET;

public class StatsWidget : Widget
{
    private readonly float _coolDown = 0.5f;
    private readonly Vector4 _statsColor = new(0, 1, 0, 1);
    private readonly Timer _timer = new();
    private readonly FPSCounter _fpsCounter = new();
    private BenchmarkResult[] _results = Array.Empty<BenchmarkResult>();
    private float _clock;

    public StatsWidget(Window window) : base("Stats", window)
    {
    }

    protected override Vector2 Size => new(100, 100);
    protected override Vector2 Position => Vector2.Zero;
    
    public override void Update(float deltaTime)
    {
        _timer.Update(deltaTime);
        _fpsCounter.Update(deltaTime);
        
        if (Timer.Time >= _coolDown + _clock)
        {
            _clock = Timer.Time;
            _results = Benchmark.Instance.GetData();
            _fpsCounter.UpdateValue();
        }
    }

    protected override void OnDraw()
    {
        if (_results.Length != 0)
        {
            DrawStats();   
        }
    }

    private void DrawStats()
    {
        ImGui.PushStyleColor(ImGuiCol.Text, _statsColor);

        ConsoleTable consoleTable = new();
        consoleTable.AddColumn(new[] {string.Empty, "Time mls", string.Empty});

        foreach (BenchmarkResult result in _results)
        {
            int percentage = (int)(result.Value / _results[0].Value * 100);
            consoleTable.AddRow(result.Name, Math.Round(result.Value, 2), $"{percentage}%%");
        }

        ImGui.Text(consoleTable.ToMinimalString());
        ImGui.Text($"FPS = {_fpsCounter.Value}");
        ImGui.PopStyleColor();
    }
}