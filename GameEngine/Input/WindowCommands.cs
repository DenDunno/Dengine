using OpenTK.Graphics.OpenGL;

public class WindowCommands
{
    private readonly Window _window;

    public WindowCommands(Window window)
    {
        _window = window;
    }

    public void EnableWireframeMode()
    {
        _window.SetPolygonMode(PolygonMode.Line);
    }

    public void EnableShadedMode()
    {
        _window.SetPolygonMode(PolygonMode.Fill);
    }
}