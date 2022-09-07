
public class PhysicsSimulation
{
    private readonly int _deltaTimeMilliseconds;
    private readonly List<IPhysicsSimulationComponent> _components;

    public PhysicsSimulation(float deltaTime, List<Rigidbody> rigidbodies)
    {
        _deltaTimeMilliseconds = TimeSpan.FromSeconds(deltaTime).Milliseconds;
        _components = new List<IPhysicsSimulationComponent>()
        {
            new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsDynamic)),
        };
    }
    
    public async void Run()
    {
        while (true)
        {
            Console.WriteLine(DateTime.Now.Second);
            
            foreach (IPhysicsSimulationComponent physicsEngineComponent in _components)
            {
                physicsEngineComponent.Run();
            }
            
            await Task.Delay(TimeSpan.FromSeconds(0.02f));
        }
    }
}