
[HideInInspector]
public class Stats : Singlton<Stats>, IGameComponent
{
    public readonly Benchmark Benchmark = new();
    public int DrawCalls;
    public int Vertices;
    public int Tris;

    private readonly FPSCounter _fpsCounter = new();
    private readonly float _coolDown = 0.5f;
    private float _clock;

    public BenchmarkResult[] BenchmarkResults { get; private set; } = Array.Empty<BenchmarkResult>();
    public double FrameTime => BenchmarkResults[0].Value;
    public int FPS => _fpsCounter.Value;

    public void Update(float deltaTime)
    {
        _fpsCounter.Update(deltaTime);
        
        if (Timer.Time >= _coolDown + _clock)
        {
            _clock = Timer.Time;
            BenchmarkResults = Benchmark.GetData();
            _fpsCounter.UpdateValue();
        }
    }

    public void Reset()
    {
        DrawCalls = 0;
        Tris = 0;
        Vertices = 0;
    }
}