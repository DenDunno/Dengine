
public readonly struct Log
{
    public readonly string Text;
    public readonly string Time;

    public Log(string text)
    {
        Text = text;
        Time = DateTime.Now.ToString("H:mm:ss");
    }
}