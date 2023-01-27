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
    
    public Mesh Build()
    {
        throw new NotImplementedException();
    }
}