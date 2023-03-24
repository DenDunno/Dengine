using OpenTK.Mathematics;

public class CubeMeshData : IMeshDataSource
{
    private readonly Vector3 _offset;
    private readonly float _size;

    public CubeMeshData(float size) : this(size, Vector3.Zero)
    {
    }

    public CubeMeshData(float size, Vector3 offset)
    {
        _offset = offset;
        _size = size;
    }
    
    private List<VertexAttribute> VerticesData => new()
    {
        new VertexAttribute("Position", 0, 3, new[]
        {
            // front
            _size + _offset.X, _size + _offset.Y, -_size + _offset.Z,
            _size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, _size + _offset.Y, -_size + _offset.Z,

            //back
            _size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            _size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
            -_size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            
            //left
            -_size + _offset.X, _size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
            -_size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            
            //right
            _size + _offset.X, _size + _offset.Y, -_size + _offset.Z,
            _size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            _size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
            _size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            
            //up
            _size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            _size + _offset.X, _size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, _size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, _size + _offset.Y, _size + _offset.Z,
            
            //down
            _size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
            _size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, -_size + _offset.Z,
            -_size + _offset.X, -_size + _offset.Y, _size + _offset.Z,
        }),
            
        new VertexAttribute("Normals", 1, 3, new float[]
        {
            0, 0, -1,
            0, 0, -1,
            0, 0, -1,
            0, 0, -1,

            0, 0, 1,
            0, 0, 1,
            0, 0, 1,
            0, 0, 1,

            -1, 0, 0,
            -1, 0, 0,
            -1, 0, 0,
            -1, 0, 0,

            1, 0, 0,
            1, 0, 0,
            1, 0, 0,
            1, 0, 0,

            0, 1, 0,
            0, 1, 0,
            0, 1, 0,
            0, 1, 0,

            0, -1, 0,
            0, -1, 0,
            0, -1, 0,
            0, -1, 0,
        }),
            
        new VertexAttribute("TexCoord", 2, 2, new float[]
        {
            1, 1,
            1, 0,
            0, 0,
            0, 1,
            
            1, 1,
            1, 0,
            0, 0,
            0, 1,
            
            1, 1,
            1, 0,
            0, 0,
            0, 1,
            
            1, 1,
            1, 0,
            0, 0,
            0, 1,
            
            1, 1,
            1, 0,
            0, 0,
            0, 1,
            
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

                4, 5, 7,
                5, 6, 7,

                8, 9, 11,
                9, 10, 11,

                12, 13, 15,
                13, 14, 15,

                16, 17, 19,
                17, 18, 19,

                20, 21, 23,
                21, 22, 23
            }
        };
    }
}