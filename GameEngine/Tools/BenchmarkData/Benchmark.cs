using System.Diagnostics;

public class Benchmark : Singlton<Benchmark>
{
    private readonly Stopwatch _stopwatch = new();
    private readonly FPSCounter _fpsCounter = new();
    private BenchmarkStats _stats;

    public void AddUpdateTime(Action update) => MeasureFunctionTime(ref _stats.Update, update);

    public void AddRenderTime(Action render) => MeasureFunctionTime(ref _stats.Render, render);

    public void AddSwapBufferTime(Action swapBuffer) => MeasureFunctionTime(ref _stats.SwapBuffer, swapBuffer);

    public BenchmarkViewData GetData()
    {
        return new BenchmarkViewData()
        {
            FPS = _fpsCounter.GetValue(),
            Render = MathF.Round(_stats.Render.Value, 2),
            Update = MathF.Round(_stats.Update.Value, 2),
            SwapBuffer = MathF.Round(_stats.SwapBuffer.Value, 2),
        };
    }

    public void Update(float deltaTime)
    {
        _fpsCounter.Update(deltaTime);
    }
    
    private void MeasureFunctionTime(ref BenchmarkMeanStat benchmarkMeanStat, Action actionToMeasure)
    {
        _stopwatch.Reset();
        _stopwatch.Start();
        actionToMeasure();
        _stopwatch.Stop();
        
        benchmarkMeanStat.AddDelta(_stopwatch.Elapsed.Milliseconds);
    }
}