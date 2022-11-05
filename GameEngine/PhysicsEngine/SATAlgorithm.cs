using OpenTK.Mathematics;

public class SATAlgorithm
{
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] worldPositionsA = objectA.MeshWorldView.Positions;
        Vector3[] worldPositionsB = objectB.MeshWorldView.Positions;
        Vector3[] normalsA = objectA.MeshWorldView.Normals;
        Vector3[] normalsB = objectB.MeshWorldView.Normals;

        return CheckSeparatingAxis(worldPositionsA, normalsA, worldPositionsB) && 
               CheckSeparatingAxis(worldPositionsB, normalsB, worldPositionsA);
    }

    private bool CheckSeparatingAxis(Vector3[] worldPositionsA, Vector3[] normalsA, Vector3[] worldPositionsB)
    {
        float separation = float.MinValue;
        
        for (int i = 0; i < worldPositionsA.Length && separation <= 0; ++i)
        {
            Vector3 normalA = normalsA[i];
            Vector3 vertexA = worldPositionsA[i];

            (Vector3 minVertexB, float minSeparation) = FindMinSeparation(vertexA, normalA, worldPositionsB);
            separation = MathF.Max(separation, minSeparation);

            if (separation >= 0)
            {
                DrawSeparatingAxis(vertexA, normalA, minVertexB);
            }
        }
        
        return separation <= 0;
    }

    private (Vector3, float) FindMinSeparation(Vector3 vertexA, Vector3 normalA, Vector3[] worldPositionsB)
    {
        float minSeparation = float.MaxValue;
        Vector3 minVertexB = Vector3.Zero;
            
        foreach (Vector3 vertexB in worldPositionsB)
        {
            float dot = Vector3.Dot(vertexB - vertexA, normalA);
                
            if (dot < minSeparation)
            {
                minVertexB = vertexB;
                minSeparation = dot;
            }
        }

        return (minVertexB, minSeparation);
    }

    private void DrawSeparatingAxis(Vector3 vertexA, Vector3 normalA, Vector3 vertexB)
    {
        Vector3 lineDirection = Algorithms.GetNormal(normalA);
        Vector3 lineCentre = (vertexA + vertexB) / 2;
        Vector3 firstPoint = lineCentre + lineDirection;
        Vector3 secondPoint = lineCentre - lineDirection;
        
        Gizmo.Instance.AddLineToDraw(new List<Vector2>
        {
            firstPoint.Xy,
            secondPoint.Xy,
        });
    }
}