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
        var separation = float.MinValue;
        
        for (int i = 0; i < worldPositionsA.Length; ++i)
        {
            Vector3 normalA = normalsA[i];
            Vector3 vertexA = worldPositionsA[i];
            var minStep = float.MaxValue;
            
            foreach (Vector3 vertexB in worldPositionsB)
            {
                minStep = MathF.Min(minStep, Vector3.Dot(vertexB - vertexA, normalA));
            }
            
            separation = MathF.Max(separation, minStep);
        }
        
        return separation <= 0;
    }
}