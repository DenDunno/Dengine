using System.Reflection;

public class MethodTimeLogger
{
    public static void Log(MethodBase methodBase, TimeSpan timeSpan, string message)
    {
        Stats.Instance.Table.AddDelta(message, timeSpan.Milliseconds);
    }
}