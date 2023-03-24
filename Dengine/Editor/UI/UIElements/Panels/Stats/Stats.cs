using OpenTK.Graphics.OpenGL;

public class Stats : Singlton<Stats>
{
    public readonly BenchmarkTable Table = new();
    private readonly FPSCounter _fpsCounter = new();
    private readonly float _coolDown = 0.5f;
    private float _clock;

    public string BenchmarkResults => Table.Value;
    public int DrawCalls { get; private set; }
    public int Vertices { get; private set; }
    public int Tris { get; private set; }
    public int FPS => _fpsCounter.Value;
    public string Renderer => GL.GetString(StringName.Renderer);

    public void AddDrawCallStats(int vertices, int tris)
    {
        SetDrawCallStats(DrawCalls + 1, Tris + tris, Vertices + vertices);
    }
    
    public void Reset()
    {
        SetDrawCallStats(0, 0, 0);
    }

    public void Update(float deltaTime)
    {
        _fpsCounter.Update(deltaTime);
        
        if (Clock.Time >= _coolDown + _clock)
        {
            _clock = Clock.Time;
            float frameTime = 1f / FPS * 1000;
            Table.UpdateValue(frameTime);
            _fpsCounter.UpdateValue();
        }
    }

    private void SetDrawCallStats(int drawCalls, int tris, int vertices)
    {
        DrawCalls = drawCalls;
        Vertices = vertices;
        Tris = tris;
    }
}