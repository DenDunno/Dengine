
public class PhysicsSimulation : IUpdatable
{
    private readonly CollisionResolution _collisionResolution;
    private readonly Dynamics _dynamics;
    private readonly float _fixedDeltaTime;
    private float _clock;

    public PhysicsSimulation(float fixedDeltaTime, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _collisionResolution = new CollisionResolution(rigidbodies);
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsStatic == false), fixedDeltaTime);
        _fixedDeltaTime = fixedDeltaTime;
    }

    public void Update(float deltaTime)
    {
        _dynamics.Apply();
        _collisionResolution.Resolve();
    }
}