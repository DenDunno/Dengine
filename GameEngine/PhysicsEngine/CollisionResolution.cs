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

                if (CheckCollision(objectA, objectB))
                {
                    objectA.ColorShaderProgram.SetRedColor();
                    objectB.ColorShaderProgram.SetRedColor();   
                }
            }
        }
    }

    private bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] worldPositionsA = objectA.MeshWorldView.Positions;
        Vector3[] worldPositionsB = objectB.MeshWorldView.Positions;
        
        return CheckSeparatingAxis(worldPositionsA, worldPositionsB) && CheckSeparatingAxis(worldPositionsB, worldPositionsA);
    }

    private bool CheckSeparatingAxis(Vector3[] worldPositionsA, Vector3[] worldPositionsB)
    {
        var separation = float.MinValue;
        
        for (int i = 0; i < worldPositionsA.Length; ++i)
        {
            Vector3 normalA = GetNormal(i, worldPositionsA);
            Vector3 vertexA = worldPositionsA[i];
            var minStep = float.MaxValue;
            
            foreach (Vector3 vertexB in worldPositionsB)
            {
                minStep = MathF.Min(minStep, Vector3.Dot(vertexA - vertexB, normalA));
            }
            
            separation = MathF.Max(separation, minStep);
        }
        
        return separation <= 0;
    }

    private Vector3 GetNormal(int firstIndex, Vector3[] worldPositions)
    {
        int secondIndex = firstIndex + 1;

        if (firstIndex == worldPositions.Length - 1)
            secondIndex = 0;

        return Algorithms.GetNormal(worldPositions[firstIndex], worldPositions[secondIndex]);
    }

    
}