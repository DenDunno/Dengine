
public class CubeMeshData : IMeshDataSource
{
    private readonly float _size;

    public CubeMeshData(float size)
    {
        _size = size;
    }
    
    MeshData IMeshDataSource.GetMeshData()
    {
        return null;
    }
}