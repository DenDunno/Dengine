using OpenTK.Mathematics;

public class BoundingBox : CollisionMesh
{
    private Vector3 _localMin;
    private Vector3 _localMax;

    public BoundingBox(Mesh mesh, Transform transform) : base(mesh, transform)
    {
    }

    public Vector3 Min => Algorithms.MultiplyPointWithMatrix4(Transform.ModelMatrix, _localMin);
    public Vector3 Max => Algorithms.MultiplyPointWithMatrix4(Transform.ModelMatrix, _localMax);
    
    protected override Vector3[] CalculateMesh()
    {
        FindMinMax();
        return GetBoxVertices();
    }

    private void FindMinMax()
    {
        foreach (Vector3 position in Mesh.Data.Positions)
        {
            _localMin = Algorithms.Min(position, _localMin);
            _localMax = Algorithms.Max(position, _localMax);
        }
    }

    private Vector3[] GetBoxVertices()
    {
        Vector3[] boxVertices = new Vector3[8]; 
        float halfWidth = (_localMax.X - _localMin.X) / 2f;
        float halfHeight = (_localMax.Y - _localMin.Y) / 2f;
        float halfDepth = (_localMax.Z - _localMin.Z) / 2f;

        for (int i = -1, index = 0; i < 2; i += 2)
        {
            for (int j = -1; j < 2; j += 2)
            {
                for (int k = -1; k < 2; k += 2)
                {
                    boxVertices[index] = new Vector3(halfWidth * i, halfHeight * j, halfDepth * k);
                    ++index;
                }
            }
        }

        return boxVertices;
    }
}