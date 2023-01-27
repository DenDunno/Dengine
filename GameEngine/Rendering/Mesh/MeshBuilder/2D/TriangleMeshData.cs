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
        (Vector3[] positions, Vector3[] normals) = EvaluateTriangle();
        
        List<VertexAttribute> data = new()
        {
            new VertexAttribute("Position", 0, 3, new[]
            {
                positions[0].X, positions[0].Y, positions[0].Z,
                positions[1].X, positions[1].Y, positions[1].Z,
                positions[2].X, positions[2].Y, positions[2].Z,
            }),
            
            new VertexAttribute("Normals", 1, 3, new[]
            {
                normals[0].X, normals[0].Y, normals[0].Z,
                normals[1].X, normals[1].Y, normals[1].Z,
                normals[2].X, normals[2].Y, normals[2].Z,
            }),
            
            new VertexAttribute("TexCoord", 2, 2, new[]
            {
                0.0f, 0.0f,
                0.5f, 1.0f,
                1.0f, 0.0f,
            }),
        };

        return new Mesh(data)
        {
            Indices = new uint[] {0, 1, 2}
        };
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