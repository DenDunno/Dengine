
public class UpdateCycle
{
    private readonly Window _window;
    private readonly World _world;
    
    public UpdateCycle(Window window, World world)
    {
        _window = window;
        _world = world;
    }

    public void Initialize()
    {
        _world.Initialize();
    }

    public void Run()
    {
        _window.Run(_world);
    }
}