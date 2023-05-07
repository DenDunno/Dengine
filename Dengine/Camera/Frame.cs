using OpenTK.Graphics.OpenGL;

public class Frame
{
    private readonly IReadOnlyList<GameObject> _gameObjects;
    private readonly RenderSettings _settings;
    private readonly FrustumCulling _culling;

    public Frame(IReadOnlyList<GameObject> gameObjects, RenderSettings settings, FrustumCulling culling)
    {
        _gameObjects = gameObjects;
        _settings = settings;
        _culling = culling;
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
            if (_culling.ContainsSphere(gameObject.Data.Transform.Position, 1))
            {
                gameObject.Draw();
            }
        }
    }
}