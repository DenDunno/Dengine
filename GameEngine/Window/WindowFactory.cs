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
            Size = new Vector2i(1200, 800),
            Location = new Vector2i(350, 150),
            Title = "Game engine",
            WindowBorder = WindowBorder.Fixed,
            Flags = ContextFlags.Default,
            Profile = ContextProfile.Compatability,
            API = ContextAPI.OpenGL
        };
    }
    
    public Window Create()
    {
        var windowSettings = new WindowSettings(_gameWindowSettings, _nativeWindowSettings);
        var window = new Window(windowSettings);
        window.VSync = VSyncMode.On;

        return window;
    }
}