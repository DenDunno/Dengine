
public class Engine
{
    private readonly Window _window;
    private readonly World _world;
    private readonly UI _ui;

    public Engine(Window window, World world, UI ui)
    {
        _window = window;
        _world = world;
        _ui = ui;
    }

    public void Initialize()
    {
        Initialize(_world);
        Initialize(_ui as IEngineComponent);
        Initialize(_ui);
    }

    private void Initialize(IEngineComponent engineComponent)
    {
        _window.Load += engineComponent.Initialize;
        _window.UpdateFrame += engineComponent.Update;
        _window.RenderFrame += engineComponent.Draw;
    }
    
    private void Initialize(UI ui)
    {
        _window.MouseWheel += ui.OnMouseWheel;
        _window.Resize += ui.OnWindowResize;
    }

    public void Run()
    {
        _window.Run();
    }
}