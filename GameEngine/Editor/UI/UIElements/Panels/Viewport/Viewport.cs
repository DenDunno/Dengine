using System.Numerics;

public class Viewport
{
    public static float Width { get; private set; }
    public static float Height { get; private set; }

    public static float AspectRatio => Width / Height;
    
    public static void Set(Vector2 size)
    {
        Width = size.X;
        Height = size.Y;
    }
}