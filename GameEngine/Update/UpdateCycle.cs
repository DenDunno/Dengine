
public class UpdateCycle : IUpdatable
{
    private readonly World _world;
    private readonly Rectangle _rectangle = new();
    
    public UpdateCycle(World world)
    {
        _world = world;
        _rectangle.Init();
    }

    public void Update(float deltaTime)
    {
        _world.Update(deltaTime);
        _world.Draw();
        _rectangle.Draw();
    }
}