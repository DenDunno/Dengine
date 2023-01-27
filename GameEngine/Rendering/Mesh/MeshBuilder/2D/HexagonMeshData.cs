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
        (Vector3[] positions, Vector3[] normals) = EvaluateTriangle();
        
        List<VertexAttribute> data = new()
        {
            new VertexAttribute("Position", 0, 3, new[]
            {
                positions[0].X, positions[0].Y, positions[0].Z,
                positions[1].X, positions[1].Y, positions[1].Z,
                positions[2].X, positions[2].Y, positions[2].Z,
                positions[3].X, positions[3].Y, positions[3].Z,
                positions[4].X, positions[4].Y, positions[4].Z,
                positions[5].X, positions[5].Y, positions[5].Z,
            }),
            
            new VertexAttribute("Normals", 1, 3, new[]
            {
                normals[0].X, normals[0].Y, normals[0].Z,
                normals[1].X, normals[1].Y, normals[1].Z,
                normals[2].X, normals[2].Y, normals[2].Z,
                normals[3].X, normals[3].Y, normals[3].Z,
                normals[4].X, normals[4].Y, normals[4].Z,
                normals[5].X, normals[5].Y, normals[5].Z,
            }),
        };

        return new Mesh(data)
        {
            Indices = new uint[]
            {
                0, 1, 2,
                2, 0, 5,
                5, 2, 3,
                3, 4, 5
            }
        };
    }

    private (Vector3[], Vector3[]) EvaluateTriangle()
    {
        Vector3[] positions = 
        {
            new(-_size / 2f, _size * MathF.Sqrt(3) / 2f, 0),
            new(-_size, 0, 0),
            new(-_size / 2f, -_size * MathF.Sqrt(3) / 2f, 0),
            new(_size / 2f, -_size * MathF.Sqrt(3) / 2f, 0),
            new(_size, 0, 0),
            new(_size / 2f, _size * MathF.Sqrt(3) / 2f, 0),
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