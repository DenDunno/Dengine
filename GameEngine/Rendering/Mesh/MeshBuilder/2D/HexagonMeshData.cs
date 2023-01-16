using OpenTK.Mathematics;

public class HexagonMeshData : IMeshDataSource
{
    private readonly float _size;

    public HexagonMeshData(float size)
    {
        _size = size;
    }
    
    public MeshData GetMeshData()
    {
        (Vector3[] positions, Vector3[] normals) = EvaluateTriangle(_size);
        
        return new MeshData()
        {
            Positions = positions,
            Normals = normals,
            Indices = new uint[]
            {
                0, 1, 2,
                2, 0, 5,
                5, 2, 3,
                3, 4, 5
            }
        };
    }

    private (Vector3[], Vector3[]) EvaluateTriangle(float size)
    {
        Vector3[] positions = 
        {
            new(-size / 2f, size * MathF.Sqrt(3) / 2f, 0),
            new(-size, 0, 0),
            new(-size / 2f, -size * MathF.Sqrt(3) / 2f, 0),
            new(size / 2f, -size * MathF.Sqrt(3) / 2f, 0),
            new(size, 0, 0),
            new(size / 2f, size * MathF.Sqrt(3) / 2f, 0),
        };

        Vector3[] normals = 
        {
            Algorithms.GetNormal(positions[1] - positions[0]),
            Algorithms.GetNormal(positions[2] - positions[1]),
            Algorithms.GetNormal(positions[0] - positions[2]),
            Algorithms.GetNormal(positions[0] - positions[2]),
            Algorithms.GetNormal(positions[0] - positions[2]),
            Algorithms.GetNormal(positions[0] - positions[2]),
        };

        return (positions, normals);
    }
}