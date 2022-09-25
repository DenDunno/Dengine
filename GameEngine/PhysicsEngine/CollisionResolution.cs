using OpenTK.Mathematics;

public class CollisionResolution 
{
    private readonly IReadOnlyList<Rigidbody> _rigidbodies;

    public CollisionResolution(IReadOnlyList<Rigidbody> rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    public void Resolve()
    {
        for (int i = 0; i < _rigidbodies.Count; ++i)
        {
            for (int j = i + 1; j < _rigidbodies.Count; ++j)
            {
                Rigidbody objectA = _rigidbodies[i];
                Rigidbody objectB = _rigidbodies[j];
                
                if (objectA.SphereCollider.CheckCollision(objectB.SphereCollider))
                {
                    Resolve(objectA, objectB);
                }
            }
        }
    }

    private void Resolve(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3 direction = objectA.Transform.Position - objectB.Transform.Position;
        Vector3 impulseDirection = direction.Normalized();
        float delta = objectA.SphereCollider.Radius + objectB.SphereCollider.Radius - direction.Length;
                    
        TryShift(objectA,  delta * impulseDirection);
        TryShift(objectB, -delta * impulseDirection);
        TryRecalculateVelocities(objectA, objectB, direction);
    }

    private void TryRecalculateVelocities(Rigidbody objectA, Rigidbody objectB, Vector3 direction)
    {
        if (objectA.Velocity != Vector3.Zero || objectB.Velocity != Vector3.Zero)
        {
            float velocityObjectA = objectA.Velocity.Length;
            float velocityObjectB = objectB.Velocity.Length;

            float newVelocityB = (2 * objectA.Mass * velocityObjectA + velocityObjectB * (objectB.Mass - objectA.Mass)) /
                                 (objectA.Mass + objectB.Mass);
            float newVelocityA = newVelocityB + velocityObjectB - velocityObjectA;

            objectA.Velocity = objectA.Velocity.Normalized() * newVelocityA;
            objectB.Velocity = -direction.Normalized() * newVelocityB;
            
            Console.WriteLine(objectA.Velocity);
            Console.WriteLine(objectB.Velocity);
        }
    }
    
    private void TryShift(Rigidbody rigidbody, Vector3 delta)
    {
        if (rigidbody.IsStatic == false)
        {
            rigidbody.Transform.Position += delta;
        }
    }
}