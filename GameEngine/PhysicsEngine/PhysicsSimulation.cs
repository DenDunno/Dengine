
public class PhysicsSimulation : IGameComponent
{
    private readonly CollisionResolution _collisionResolution;
    private readonly Dynamics _dynamics;

    public PhysicsSimulation(float fixedDeltaTime, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _collisionResolution = new CollisionResolution(rigidbodies);
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsStatic == false), fixedDeltaTime);
    }

    public void Update(float deltaTime)
    {
        _dynamics.Apply();
        _collisionResolution.Resolve();
    }
}