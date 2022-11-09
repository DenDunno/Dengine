
public class MeshBuilder
{
    private readonly IMeshDataSource _meshDataSource;

    public MeshBuilder(IMeshDataSource meshDataSource)
    {
        _meshDataSource = meshDataSource;
    }

    public Mesh Build()
    {
        MeshData meshData = _meshDataSource.Get();
        Mesh mesh = new(meshData, null);
        mesh.Init();

        return mesh;
    }
}