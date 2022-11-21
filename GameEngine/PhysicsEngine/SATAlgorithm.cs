using OpenTK.Mathematics;

public class SATAlgorithm
{
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        IReadOnlyList<Vector3> worldPositionsA = objectA.MeshWorldView.Positions;
        IReadOnlyList<Vector3> worldPositionsB = objectB.MeshWorldView.Positions;
        IReadOnlyList<Vector3> normalsA = objectA.MeshWorldView.Normals;
        IReadOnlyList<Vector3> normalsB = objectB.MeshWorldView.Normals;
        
        return CheckSeparatingAxis(worldPositionsA, worldPositionsB, normalsA) && 
               CheckSeparatingAxis(worldPositionsA, worldPositionsB, normalsB);
    }

    private bool CheckSeparatingAxis(IReadOnlyList<Vector3> worldPositionsA, IReadOnlyList<Vector3> worldPositionsB, IReadOnlyList<Vector3> normalsA)
    {
        return false;
    }
}