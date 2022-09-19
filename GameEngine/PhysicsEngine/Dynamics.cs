using OpenTK.Mathematics;

public class Dynamics 
{
    private readonly IEnumerable<Rigidbody> _rigidbodies;
    private readonly Vector3 _gravity = new(0, -9.81f, 0);
    private readonly float _deltaTime;

    public Dynamics(IEnumerable<Rigidbody> rigidbodies, float deltaTime)
    {
        _rigidbodies = rigidbodies;
        _deltaTime = deltaTime;
    }

    public void ApplyGravity()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.Velocity += _gravity * rigidbody.Mass * _deltaTime;
            rigidbody.Transform.Move(rigidbody.Velocity * _deltaTime);
        }
    }
}