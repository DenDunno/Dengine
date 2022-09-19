using OpenTK.Mathematics;

public class CollisionResolution 
{
    private readonly Rigidbody[] _rigidbodies;

    public CollisionResolution(Rigidbody[] rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    public void Resolve()
    {
        for (int i = 0; i < _rigidbodies.Length; ++i)
        {
            for (int j = i + 1; j < _rigidbodies.Length; ++j)
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
    }

    private void TryShift(Rigidbody rigidbody, Vector3 delta)
    {
        if (rigidbody.IsStatic == false)
        {
            rigidbody.Transform.Position += delta;
        }
    }
}