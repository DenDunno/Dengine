
public class UpdateCycle : IUpdatable
{
    private readonly World _world;
    private readonly Triangle _triangle = new();

    public UpdateCycle(World world)
    {
        _world = world;
        _triangle.Init();
    }

    public void Update(float deltaTime)
    {
        _world.Update(deltaTime);
        _world.Draw();
        _triangle.Draw();
    }
}