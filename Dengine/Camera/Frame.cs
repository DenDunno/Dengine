using OpenTK.Graphics.OpenGL;

public class Frame
{
    private readonly RenderSettings _settings;
    private readonly List<GameObject> _gameObjects;

    public Frame(List<GameObject> gameObjects, RenderSettings settings)
    {
        _gameObjects = gameObjects;
        _settings = settings;
    }

    public void Reset()
    {
        GL.ClearColor(_settings.ClearColor);
        GL.Viewport(0, 0, WindowSettings.Width, WindowSettings.Height);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.Blend);
    }

    public void DrawObjects()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.Draw();
        }
    }
}