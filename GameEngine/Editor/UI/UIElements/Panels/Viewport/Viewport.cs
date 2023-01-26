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
                return (float)WindowSettings.Width /WindowSettings.Height;
            }

            return _viewportPanelSize.X / _viewportPanelSize.Y;
        }
    }

    public static void Set(Vector2 size)
    {
        _viewportPanelSize = size;
    }
}