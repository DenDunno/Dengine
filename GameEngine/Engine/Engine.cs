
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
        Initialize(_ui);
    }

    private void Initialize(World world)
    {
        _window.Load += world.Initialize;
        _window.UpdateFrame += world.Update;
        _window.RenderFrame += world.Draw;
    }
    
    private void Initialize(UI ui)
    {
        _window.MouseWheel += ui.OnMouseWheel;
        _window.UpdateFrame += ui.Update;
        _window.RenderFrame += ui.Draw;
    }

    public void Run()
    {
        _window.Run();
    }
}