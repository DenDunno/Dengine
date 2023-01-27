using OpenTK.Mathematics;

public class HexagonMeshData : IMeshDataSource
{
    private readonly float _size;

    public HexagonMeshData(float size)
    {
        _size = size;
    }
    
    public Mesh Build()
    {
        throw new NotImplementedException();
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