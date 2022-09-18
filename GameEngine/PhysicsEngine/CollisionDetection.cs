
public class CollisionDetection 
{
    private readonly Rigidbody[] _rigidbodies;

    public CollisionDetection(Rigidbody[] rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    public void CheckCollision()
    {
        for (int i = 0; i < _rigidbodies.Length; ++i)
        {
            for (int j = i + 1; j < _rigidbodies.Length; ++j)
            {
                if (_rigidbodies[i].BoxCollider.CheckCollision(_rigidbodies[j].BoxCollider))
                {
                    Console.WriteLine($"Collision {Timer.Time}");
                }
            }
        }
    }
}