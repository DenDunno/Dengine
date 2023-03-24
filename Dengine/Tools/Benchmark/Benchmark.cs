
public class Benchmark 
{
    private readonly Dictionary<string, MeanValue> _stats = new();

    public void AddDelta(string profilingName, float elapsedMilliseconds)
    {
        _stats.TryAdd(profilingName, new MeanValue());
        _stats[profilingName].AddDelta(elapsedMilliseconds);
    }

    public BenchmarkResult[] GetData()
    {
        BenchmarkResult[] result = new BenchmarkResult[_stats.Count];
        
        int i = 0;
        
        foreach (KeyValuePair<string,MeanValue> meanStat in _stats)
        {
            result[i] = new BenchmarkResult(meanStat.Key, meanStat.Value.Value);
            meanStat.Value.Reset();
            ++i;
        }

        return result;
    }
}