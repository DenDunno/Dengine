
public class PhysicsSimulation
{
    private readonly CollisionResolution _collisionResolution;
    private readonly Dynamics _dynamics;
    private readonly float _fixedDeltaTime;

    public PhysicsSimulation(float fixedDeltaTime, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _collisionResolution = new CollisionResolution(rigidbodies);
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsStatic == false), fixedDeltaTime);
        _fixedDeltaTime = fixedDeltaTime;
    }
    
    public void Run()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                _dynamics.Apply();
                _collisionResolution.Resolve();

                await Task.Delay(TimeSpan.FromSeconds(_fixedDeltaTime));
            }
        });
    }
}