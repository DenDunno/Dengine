using OpenTK.Mathematics;

public class Dynamics 
{
    private readonly IEnumerable<Rigidbody> _rigidbodies;
    private readonly Vector3 _gravity = new(0, -9.81f, 0);
    private readonly float _fixedDeltaTime;

    public Dynamics(IEnumerable<Rigidbody> rigidbodies, float fixedDeltaTime)
    {
        _rigidbodies = rigidbodies;
        _fixedDeltaTime = fixedDeltaTime;
    }

    public void Apply()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            if (rigidbody.IsDynamic)
            {
                rigidbody.Force = rigidbody.Mass * _gravity;
            }

            rigidbody.Velocity += rigidbody.Force / rigidbody.Mass * _fixedDeltaTime;
            rigidbody.Transform.Move(rigidbody.Velocity * _fixedDeltaTime);
            
            rigidbody.Force = Vector3.Zero;
        }
    }
}