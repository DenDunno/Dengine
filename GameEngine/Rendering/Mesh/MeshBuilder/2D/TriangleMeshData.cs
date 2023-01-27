using OpenTK.Mathematics;

public class TriangleMeshData : IMeshDataSource
{
    private readonly float _size;

    public TriangleMeshData(float size)
    {
        _size = size;
    }
    
    public Mesh Build()
    {
        throw new NotImplementedException();
    }

    private (Vector3[], Vector3[]) EvaluateTriangle()
    {
        Vector3[] positions = 
        {
            new(-_size / 2f, -_size * MathF.Sqrt(3) / 6, 0.0f),
            new(0, _size * MathF.Sqrt(3) / 3, 0.0f),
            new(_size / 2f, -_size * MathF.Sqrt(3) / 6, 0.0f),
        };

        Vector3[] normals = 
        {
            Algorithms.GetNormal(positions[1] - positions[0]),
            Algorithms.GetNormal(positions[2] - positions[1]),
            Algorithms.GetNormal(positions[0] - positions[2]),
        };

        return (positions, normals);
    }
}