using System.Reflection;

public class MethodTimeLogger
{
    public static void Log(MethodBase methodBase, TimeSpan timeSpan, string message)
    {
        Stats.Instance.Reset();
        Stats.Instance.Benchmark.AddDelta(message, timeSpan.Milliseconds);
    }
}