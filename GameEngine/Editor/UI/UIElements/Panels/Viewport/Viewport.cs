using System.Numerics;

public class Viewport
{
    private static Vector2 _viewportPanelSize;

    public static float AspectRatio
    {
        get
        {
            if (PlayMode.IsActive && ControlPanel.IsFullscreen)
            {
                return (float)Window.WindowSize.X / Window.WindowSize.Y;
            }

            return _viewportPanelSize.X / _viewportPanelSize.Y;
        }
    }

    public static void Set(Vector2 size)
    {
        _viewportPanelSize = size;
    }
}