using OpenTK.Mathematics;

public class CubeMeshData : IMeshDataSource
{
    private readonly float _size;

    public CubeMeshData(float size)
    {
        _size = size;
    }
    
    MeshData IMeshDataSource.GetMeshData()
    {
        return new MeshData()
        {
            Positions = new Vector3[]
            {
                // front
                new(_size, _size, -_size),
                new(_size, -_size, -_size),
                new(-_size, -_size, -_size),
                new(-_size, _size, -_size),

                //back
                new(_size, _size, _size),
                new(_size, -_size, _size),
                new(-_size, -_size, _size),
                new(-_size, _size, _size),
            
                //left
                new(-_size, _size, -_size),
                new(-_size, -_size, -_size),
                new(-_size, -_size, _size),
                new(-_size, _size, _size),
            
                //right
                new(_size, _size, -_size),
                new(_size, -_size, -_size),
                new(_size, -_size, _size),
                new(_size, _size, _size),
            
                //up
                new(_size, _size, _size),
                new(_size, _size, -_size),
                new(-_size, _size, -_size),
                new(-_size, _size, _size),
            
                //down
                new(_size, -_size, _size),
                new(_size, -_size, -_size),
                new(-_size, -_size, -_size),
                new(-_size, -_size, _size),
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