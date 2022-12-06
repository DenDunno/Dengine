
public class PhysicsSimulation : IUpdatable, IInitializable
{
    private readonly CollisionResolution _collisionResolution;
    private readonly Dynamics _dynamics;
    private readonly IReadOnlyList<Rigidbody> _rigidbodies;

    public PhysicsSimulation(float fixedDeltaTime, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _collisionResolution = new CollisionResolution(rigidbodies);
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsStatic == false), fixedDeltaTime);
        _rigidbodies = rigidbodies;
    }

    public void Initialize()
    {
        _rigidbodies.ForEach(rigidbody => rigidbody.Init());
    }

    public void Update(float deltaTime)
    {
        _dynamics.Apply();
        _collisionResolution.Resolve();
    }
}