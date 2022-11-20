using OpenTK.Mathematics;

public class QuadMeshData : IMeshDataSource
{
    private readonly float _size;

    public QuadMeshData(float size)
    {
        _size = size;
    }
    
    MeshData IMeshDataSource.GetMeshData()
    {
        return new MeshData()
        {
            Positions = new Vector3[]
            {
                new(_size, _size, 0.0f),
                new(_size, -_size, 0.0f),
                new(-_size, -_size, 0.0f),
                new(-_size, _size, 0.0f),
            },
            Normals = new Vector3[]
            {
                new(0, 0, -1.0f),
                new(0, 0, -1.0f),
                new(0, 0, -1.0f),
                new(0, 0, -1.0f),
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