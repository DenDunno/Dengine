
public struct BenchmarkViewData
{
    public readonly int FPS { get; init; }
    public readonly float Render { get; init; }
    public readonly float Update { get; init; }
    public readonly float SwapBuffer { get; init; }
}