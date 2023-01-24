using System.Numerics;

public class Viewport
{
    public static Vector2 Size { get; private set; }
    public static Vector2 Position { get; private set; }
    
    public static float AspectRatio => Size.X / Size.Y;
    public static float Width => Size.X;
    public static float Height => Size.Y;
    
    public static void Set(Vector2 size, Vector2 position)
    {
        Size = size;
        Position = position;
    }
}