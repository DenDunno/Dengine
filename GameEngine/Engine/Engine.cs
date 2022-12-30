
public class Engine
{
    private readonly Window _window;
    private readonly World _world;
    private readonly Editor _editor;

    public Engine(Window window, World world, Editor editor)
    {
        _window = window;
        _world = world;
        _editor = editor;
    }

    public void Initialize()
    {
        Initialize(_world);
        Initialize(_editor);
    }

    private void Initialize(IEngineComponent engineComponent)
    {
        _window.Load += engineComponent.Initialize;
        _window.UpdateFrame += engineComponent.Update;
        _window.RenderFrame += engineComponent.Draw;
    }

    public void Run()
    {
        _window.Run();
    }
}