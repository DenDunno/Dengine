using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class WindowFactory
{
    private readonly NativeWindowSettings _nativeWindowSettings = new()
    {
        Size = new Vector2i(1536, 864),
        Location = new Vector2i(1536/8, 864/8),
        Title = "Game engine",
        WindowBorder = WindowBorder.Hidden,
        Flags = ContextFlags.Default,
        Profile = ContextProfile.Compatability,
        API = ContextAPI.OpenGL,
    };

    public Window Create()
    {
        var window = new Window(_nativeWindowSettings);
        
        window.CursorState = CursorState.Grabbed;
        window.VSync = VSyncMode.On;

        return window;
    }
}