
public abstract class GLDrawCommand
{
    private IMeshProvider _meshProvider = null!;

    protected int Indices => _meshProvider.Mesh.Indices.Length;
    protected int VerticesCount => _meshProvider.Mesh.VerticesCount;
    protected int Tris => _meshProvider.Mesh.Indices.Length / 3;

    public void SetMeshProvider(IMeshProvider meshProvider)
    {
        _meshProvider = meshProvider;
    }

    public abstract void Execute();
}