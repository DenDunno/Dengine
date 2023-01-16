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
    
    public MeshData GetMeshData()
    {
        return new MeshData()
        {
            Positions = new[]
            {
                // front
                new Vector3(_size, _size, -_size) + _offset,
                new Vector3(_size, -_size, -_size) + _offset,
                new Vector3(-_size, -_size, -_size) + _offset,
                new Vector3(-_size, _size, -_size) + _offset,

                //back
                new Vector3(_size, _size, _size) + _offset,
                new Vector3(_size, -_size, _size) + _offset,
                new Vector3(-_size, -_size, _size) + _offset,
                new Vector3(-_size, _size, _size) + _offset,
            
                //left
                new Vector3(-_size, _size, -_size) + _offset,
                new Vector3(-_size, -_size, -_size) + _offset,
                new Vector3(-_size, -_size, _size) + _offset,
                new Vector3(-_size, _size, _size) + _offset,
            
                //right
                new Vector3(_size, _size, -_size) + _offset,
                new Vector3(_size, -_size, -_size) + _offset,
                new Vector3(_size, -_size, _size) + _offset,
                new Vector3(_size, _size, _size) + _offset,
            
                //up
                new Vector3(_size, _size, _size) + _offset,
                new Vector3(_size, _size, -_size) + _offset,
                new Vector3(-_size, _size, -_size) + _offset,
                new Vector3(-_size, _size, _size) + _offset,
            
                //down
                new Vector3(_size, -_size, _size) + _offset,
                new Vector3(_size, -_size, -_size) + _offset,
                new Vector3(-_size, -_size, -_size) + _offset,
                new Vector3(-_size, -_size, _size) + _offset,
            },
            TextureCoordinates = new Vector2[]
            {
                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),
            },
            Normals = new Vector3[]
            {
                new(0, 0, -1),
                new(0, 0, -1),
                new(0, 0, -1),
                new(0, 0, -1),

                new(0, 0, 1),
                new(0, 0, 1),
                new(0, 0, 1),
                new(0, 0, 1),

                new(-1, 0, 0),
                new(-1, 0, 0),
                new(-1, 0, 0),
                new(-1, 0, 0),

                new(1, 0, 0),
                new(1, 0, 0),
                new(1, 0, 0),
                new(1, 0, 0),

                new(0, 1, 0),
                new(0, 1, 0),
                new(0, 1, 0),
                new(0, 1, 0),

                new(0, -1, 0),
                new(0, -1, 0),
                new(0, -1, 0),
                new(0, -1, 0),
            },
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