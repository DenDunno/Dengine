using OpenTK.Windowing.Desktop;

public class WindowSettings
{
    public readonly GameWindowSettings GameWindowSettings;
    public readonly NativeWindowSettings NativeWindowSettings;

    public WindowSettings(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
    {
        GameWindowSettings = gameWindowSettings;
        NativeWindowSettings = nativeWindowSettings;
    }
}