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
        Vector3[] positions = EvaluateTriangle();
        
        List<VertexAttribute> data = new()
        {
            new VertexAttribute("Position", 0, 3, new[]
            {
                positions[0].X, positions[0].Y, positions[0].Z,
                positions[1].X, positions[1].Y, positions[1].Z,
                positions[2].X, positions[2].Y, positions[2].Z,
            })
        };

        return new Mesh(data)
        {
            Indices = new uint[] {0, 1, 2}
        };
    }

    private Vector3[] EvaluateTriangle()
    {
        return new Vector3[]  
        {
            new(-_size / 2f, -_size * MathF.Sqrt(3) / 6, 0.0f),
            new(0, _size * MathF.Sqrt(3) / 3, 0.0f),
            new(_size / 2f, -_size * MathF.Sqrt(3) / 6, 0.0f),
        };
    }
}