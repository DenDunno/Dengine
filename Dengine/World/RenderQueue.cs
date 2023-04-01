
public class RenderQueue
{
    private readonly Framebuffer _framebuffer = new();
    private readonly Camera _camera;
    private readonly Frame _frame;
    
    public RenderQueue(List<GameObject> gameObjects)
    {
        _camera = gameObjects.Find<Camera>();
        _frame = new Frame(gameObjects, _camera.Settings);
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
        _camera.UpdateViewProjectionMatrices();
        _frame.Reset();
        _frame.DrawObjects();
    }
}