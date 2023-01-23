using System.Numerics;

public readonly struct Log
{
    public readonly string Text;
    public readonly string Time;
    public readonly Vector4 Color;
    
    public Log(string text) : this(text, Vector4.One * 255) 
    {
    }
    
    public Log(string text, Vector4 color)
    {
        Text = text;
        Time = DateTime.Now.ToString("H:mm:ss");
        Color = color / 255;
    }
}