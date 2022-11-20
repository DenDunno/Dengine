
public class CollisionResolution 
{
    private readonly ICollisionDetection _collisionDetection;
    private readonly IReadOnlyList<Rigidbody> _rigidbodies;

    public CollisionResolution(ICollisionDetection collisionDetection, IReadOnlyList<Rigidbody> rigidbodies)
    {
        _collisionDetection = collisionDetection;
        _rigidbodies = rigidbodies;
    }

    public void Resolve()
    {
        Clear();
        ResolveCollisions();
    }

    private void Clear()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.ShaderProgram.SetNormalColor();
        }
    }

    private void ResolveCollisions()
    {
        for (int i = 0; i < _rigidbodies.Count; ++i)
        {
            for (int j = i + 1; j < _rigidbodies.Count; ++j)
            {
                Rigidbody objectA = _rigidbodies[i];
                Rigidbody objectB = _rigidbodies[j];

                if (_collisionDetection.CheckCollision(objectA, objectB))
                {
                    objectA.ShaderProgram.SetCollisionColor();
                    objectB.ShaderProgram.SetCollisionColor();
                }
            }
        }
    }
}