
public class CollisionResolution 
{
    private readonly IReadOnlyList<Rigidbody> _rigidbodies;
    private readonly SATAlgorithm _satAlgorithm = new();

    public CollisionResolution(IReadOnlyList<Rigidbody> rigidbodies)
    {
        _rigidbodies = rigidbodies;
    }

    public void Resolve()
    {
        Clear();
        CheckCollisions();
    }

    private void Clear()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.ColorShaderProgram.SetWhiteColor();
        }
    }

    private void CheckCollisions()
    {
        for (int i = 0; i < _rigidbodies.Count; ++i)
        {
            for (int j = i + 1; j < _rigidbodies.Count; ++j)
            {
                Rigidbody objectA = _rigidbodies[i];
                Rigidbody objectB = _rigidbodies[j];

                if (_satAlgorithm.CheckCollision(objectA, objectB))
                {
                    objectA.ColorShaderProgram.SetRedColor();
                    objectB.ColorShaderProgram.SetRedColor();   
                }
            }
        }
    }
}