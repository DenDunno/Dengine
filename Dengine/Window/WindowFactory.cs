using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class WindowFactory
{
    private readonly NativeWindowSettings _nativeWindowSettings = new()
    {
        Size = new Vector2i(1536, 864),
        Location = new Vector2i(1536/8, 864/8),
        Title = "Dengine",
        API = ContextAPI.OpenGL,
        Profile = ContextProfile.Compatability,
    };

    public Window Create()
    {
        Window window = new(_nativeWindowSettings);
        window.VSync = VSyncMode.Off;

        return window;
    }
}