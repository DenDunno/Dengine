using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class RenderQueue
{
    private readonly Framebuffer _framebuffer = new();
    private readonly List<GameObject> _gameObjects;
    private readonly Camera _camera;

    public RenderQueue(List<GameObject> gameObjects)
    {
        _gameObjects = gameObjects;
        _camera = gameObjects.Find<Camera>();
    }

    public void Initialize()
    {
        _framebuffer.Initialize();
    }

    public void ResizeFrameBuffer(int width, int height)
    {
        _framebuffer.Resize(width, height);
    }

    public void Draw()
    {
        _framebuffer.Bind();
        ResetFrame();
        DrawObjects();
    }

    private void ResetFrame()
    {
        GL.ClearColor(_camera.Settings.ClearColor);
        GL.Viewport(0, 0, WindowSettings.Width, WindowSettings.Height);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.Blend);
    }

    private void DrawObjects()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.Draw();
        }
    }
}