using System.Numerics;
using ImGuiNET;

public class Stats : Widget
{
    private readonly float _coolDown = 0.5f;
    private readonly Timer _timer = new();
    private BenchmarkViewData _viewData;
    private float _clock;

    public Stats(Window window) : base("Stats", window)
    {
    }

    protected override Vector2 Size => new(100, 100);
    protected override Vector2 Position => Vector2.Zero;
    
    public override void Update(float deltaTime)
    {
        _timer.Update(deltaTime);
        Benchmark.Instance.Update(deltaTime);

        TryUpdateStats();
    }

    private void TryUpdateStats()
    {
        if (Timer.Time >= _coolDown + _clock)
        {
            _clock = Timer.Time;
            _viewData = Benchmark.Instance.GetData();
        }
    }
    
    protected override void OnDraw()
    {
        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0, 1, 0, 1));
        
        ImGui.Text($"FPS = {_viewData.FPS}");
        ImGui.Text($"Render mls = {_viewData.Render}");
        ImGui.Text($"Update mls = {_viewData.Update}");
        ImGui.Text($"Swap buffer mls = {_viewData.SwapBuffer}");
        
        ImGui.PopStyleColor();
    }
}