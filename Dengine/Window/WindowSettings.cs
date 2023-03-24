using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public static class WindowSettings
{
    private static Window _window = null!;

    public static Vector2i Size => _window.Size;
    public static MouseState Mouse => _window.MouseState;
    public static KeyboardState Keyboard => _window.KeyboardState;
    public static int Width => Size.X;
    public static int Height => Size.Y;
    
    public static void Setup(Window window)
    {
        _window = window;
    }
}