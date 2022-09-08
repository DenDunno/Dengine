using OpenTK.Mathematics;

public class Dynamics 
{
    private readonly IEnumerable<Rigidbody> _rigidbodies;
    private const float _g = 9.81f;
    
    public Dynamics(IEnumerable<Rigidbody> rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    public void ApplyGravity()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.Velocity += -Vector3.UnitY * Timer.FixedDeltaTime;
            rigidbody.Transform.Move(rigidbody.Velocity * Timer.FixedDeltaTime);
        }
    }
}