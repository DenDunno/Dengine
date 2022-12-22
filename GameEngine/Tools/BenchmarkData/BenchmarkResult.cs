
public readonly struct BenchmarkResult
{
    public readonly string Name;
    public readonly double Value;

    public BenchmarkResult(string name, double value)
    {
        Name = name;
        Value = value;
    }
}