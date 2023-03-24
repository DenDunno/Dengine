using OpenTK.Mathematics;

public class QuadMeshData : IMeshDataSource
{
    private readonly Vector3 _offset;
    private readonly float _size;

    public QuadMeshData(float size) : this(size, Vector3.Zero)
    {
    }

    public QuadMeshData(float size, Vector3 offset)
    {
        _offset = offset;
        _size = size / 2f;
    }

    private List<VertexAttribute> VerticesData => new()
    {
        new VertexAttribute("Position", 0, 3, new[]
        {
            _size + _offset.X, _size + _offset.Y, _offset.Z,
            _size + _offset.X, -_size + _offset.Y, _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, _offset.Z,
            -_size + _offset.X, _size + _offset.Y, _offset.Z,
        }),
            
        new VertexAttribute("Normals", 1, 3, new float[]
        {
            1,  0, 0,
            0, -1, 0,
            -1, 0, 0,
            0,  1, 0,
        }),
            
        new VertexAttribute("TexCoord", 2, 2, new float[]
        {
            1, 1,
            1, 0,
            0, 0,
            0, 1,
        }),
    };
    
    public Mesh Build()
    {
        return new Mesh(VerticesData)
        {
            Indices = new uint[]
            {
                0, 1, 3,
                1, 2, 3,
            }, 
        };
    }
}