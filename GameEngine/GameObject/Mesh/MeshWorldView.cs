using GameEngine.Extensions;
using OpenTK.Mathematics;

public class MeshWorldView
{
    private readonly Transform _transform;
    private readonly Vector3[] _worldNormals;
    private readonly Vector3[] _worldPositions;
    private readonly Vector3[] _localNormals;
    private readonly Vector3[] _localPositions;

    public MeshWorldView(Transform transform, Mesh mesh)
    {
        _transform = transform;
        _localPositions = CalculatePositions(mesh);
        _localNormals = CalculateNormals(mesh);
        _worldPositions = new Vector3[_localPositions.Length];
        _worldNormals = new Vector3[_localNormals.Length];
    }

    public IReadOnlyList<Vector3> Positions 
    {
        get
        {
            Matrix4 modelMatrix = _transform.ModelMatrix;
            return Algorithms.MultiplyPointsWithMatrix4(ref modelMatrix, _localPositions, _worldPositions);
        }
    }

    public IReadOnlyList<Vector3> Normals
    {
        get
        {
            Matrix4 modelMatrix = _transform.ModelMatrix;
            return Algorithms.MultiplyDirectionsWithMatrix4(ref modelMatrix, _localNormals, _worldNormals);
        }
    }

    private Vector3[] CalculatePositions(Mesh mesh)
    {
        return mesh.Data.Positions.Distinct().ToArray();
    }

    private Vector3[] CalculateNormals(Mesh mesh)
    {
        List<Vector3> normals = new();
        
        CalculatePolygonNormals(normals, mesh);
        CalculateEdgeNormals(normals);
        
        return normals.ToArray();
    }

    private void CalculatePolygonNormals(List<Vector3> normals, Mesh mesh)
    {
        List<Vector3> lookUp = new();
        
        foreach (Vector3 normal in mesh.Data.Normals!)
        {
            if (lookUp.Contains(normal) == false && DoNoExistCollinear(normal, normals))
            {
                lookUp.Add(normal);
                normals.Add(normal);
            }
        }
    }

    private void CalculateEdgeNormals(List<Vector3> normals)
    {
        int count = normals.Count;
        for (int i = 0; i < count; ++i)
        {
            for (int j = i + 1; j < count; ++j)
            {
                Vector3 edgeNormal = (normals[i] + normals[j]).Normalized();
                normals.Add(edgeNormal);
            }
        }
    }

    private bool DoNoExistCollinear(Vector3 normal, IReadOnlyList<Vector3> normals)
    {
        bool collinearNotFound = true;

        for (int i = 0; i < normals.Count && collinearNotFound; ++i)
        {
            if (normal.IsCollinear(normals[i]))
            {
                collinearNotFound = false;
            }
        }

        return collinearNotFound;
    }
}