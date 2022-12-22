using System.Diagnostics;

public class Benchmark : Singlton<Benchmark>
{
    private readonly Dictionary<string, BenchmarkMeanStat> _stats = new();
    private readonly Dictionary<string, Stopwatch> _stopwatches = new();

    public void Start(string profilingName)
    {
        _stats.TryAdd(profilingName, new BenchmarkMeanStat(profilingName));
        _stopwatches.TryAdd(profilingName, new Stopwatch());
        
        _stopwatches[profilingName].Reset();
        _stopwatches[profilingName].Start();
    }

    public void Stop(string profilingName)
    {
        _stats[profilingName].AddDelta(_stopwatches[profilingName].ElapsedMilliseconds);
        _stopwatches[profilingName].Stop();
    }

    public BenchmarkResult[] GetData()
    {
        BenchmarkResult[] result = new BenchmarkResult[_stats.Count];

        int i = 0;
        foreach (BenchmarkMeanStat meanStat in _stats.Values)
        {
            result[i] = new BenchmarkResult(meanStat.Name, meanStat.Value);
            meanStat.Reset();
            ++i;
        }

        return result;
    }
}