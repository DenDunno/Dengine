
public readonly struct Log
{
    public readonly string Text;
    public readonly DateTime Time;

    public Log(string text)
    {
        Text = text;
        Time = DateTime.Now;
    }
}