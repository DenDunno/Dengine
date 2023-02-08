using ConsoleTables;

public class BenchmarkTable
{
    private readonly Benchmark _benchmark = new();
    private readonly ConsoleTable _table = new();
    private readonly string[] _columns = { string.Empty, "Time mls", string.Empty };

    public string Value { get; private set; } = string.Empty;
    
    public void UpdateValue(float frameTime)
    {
        _table.Columns.Clear();
        _table.Rows.Clear();
        _table.AddColumn(_columns);

        AddRow("Frame", frameTime, frameTime);
        double other = frameTime;
        
        foreach (BenchmarkResult result in _benchmark.GetData())
        {
            AddRow(result.Name, result.Value, frameTime);
            other -= result.Value;
        }
        
        AddRow("Other", other, frameTime);

        Value = _table.ToMinimalString();
    }

    public void AddDelta(string profilingName, float delta)
    {
        _benchmark.AddDelta(profilingName, delta);
    }

    private void AddRow(string name, double time, float frameTime)
    {
        int percentage = (int)(time / frameTime * 100);
        
        _table.AddRow($"{name}\t", Math.Round(time, 2), $"{percentage}%%");
    }
}