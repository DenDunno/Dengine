
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

                if (objectA.Collider.CheckCollision(objectB.Collider))
                {
                    HandleCollision(objectA, objectB);
                }
            }
        }
    }

    private void HandleCollision(Rigidbody objectA, Rigidbody objectB)
    {
        objectA.TriggerStay?.Invoke();
        objectB.TriggerStay?.Invoke();
    }
}