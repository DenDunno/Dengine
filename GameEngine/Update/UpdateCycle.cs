
public class UpdateCycle
{
    private readonly Window _window;
    private readonly World _world;
    private readonly PhysicsSimulation _physicsSimulation;
    private const float _fixedTimeStep = 1 / 60f;
    
    public UpdateCycle(Window window, World world, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _window = window;
        _world = world;
        _physicsSimulation = new PhysicsSimulation(_fixedTimeStep, rigidbodies);
    }

    public void Initialize()
    {
        _world.Initialize();
    }

    public void Run()
    {
        _physicsSimulation.Run();
        _window.Run(_world);
    }
}