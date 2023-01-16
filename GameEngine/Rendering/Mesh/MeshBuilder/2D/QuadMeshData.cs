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

    public MeshData GetMeshData()
    {
        return new MeshData()
        {
            Positions = new[]
            {
                new Vector3(_size, _size, 0.0f) + _offset,
                new Vector3(_size, -_size, 0.0f) + _offset,
                new Vector3(-_size, -_size, 0.0f) + _offset,
                new Vector3(-_size, _size, 0.0f) + _offset,
            },
            Normals = new Vector3[]
            {
                new(1, 0, 0),
                new(0, -1, 0),
                new(-1, 0, 0),
                new(0, 1, 0),
            },
            TextureCoordinates = new Vector2[]
            {
                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),
            },
            Indices = new uint[]
            {
                0, 1, 3,
                1, 2, 3,
            }
        };
    }
}