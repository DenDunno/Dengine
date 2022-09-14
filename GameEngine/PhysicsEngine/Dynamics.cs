using OpenTK.Mathematics;

public class Dynamics 
{
    private readonly IEnumerable<Rigidbody> _rigidbodies;
    private readonly float _deltaTime;
    private const float _g = 9.81f;
    
    public Dynamics(IEnumerable<Rigidbody> rigidbodies, float deltaTime)
    {
        _rigidbodies = rigidbodies;
        _deltaTime = deltaTime;
    }

    public void ApplyGravity()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.Velocity += -Vector3.UnitY * _deltaTime;
            rigidbody.Transform.Move(rigidbody.Velocity * _deltaTime);
        }
    }
}