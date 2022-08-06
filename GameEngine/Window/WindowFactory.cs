using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class WindowFactory
{
    private readonly GameWindowSettings _gameWindowSettings;
    private readonly NativeWindowSettings _nativeWindowSettings;

    public WindowFactory()
    {
        _gameWindowSettings = new GameWindowSettings();
        _nativeWindowSettings = new NativeWindowSettings()
        {
            Size = new Vector2i(1536, 864),
            Location = new Vector2i(1536/8, 864/8),
            Title = "Game engine",
            WindowBorder = WindowBorder.Hidden,
            Flags = ContextFlags.Default,
            Profile = ContextProfile.Compatability,
            API = ContextAPI.OpenGL,
        };
    }
    
    public Window Create()
    {
        var windowSettings = new WindowSettings(_gameWindowSettings, _nativeWindowSettings);
        var window = new Window(windowSettings);
        
        window.CursorState = CursorState.Hidden;
        window.VSync = VSyncMode.On;

        return window;
    }
}