
public class Dynamics : IPhysicsSimulationComponent
{
    private readonly IEnumerable<Rigidbody> _rigidbodies;

    public Dynamics(IEnumerable<Rigidbody> rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    void IPhysicsSimulationComponent.Run()
    {
    }
}