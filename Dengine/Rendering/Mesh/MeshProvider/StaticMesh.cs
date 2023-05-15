
public class StaticMesh : IMeshProvider
{
    private readonly MeshBinding _meshBinding;

    public StaticMesh(Mesh mesh)
    {
        _meshBinding = new MeshBinding(mesh);
    }

    public Mesh Mesh => _meshBinding.Mesh;

    public void Bind()
    { 
        _meshBinding.Bind();
        _meshBinding.TryBufferData();
    }

    public void Dispose()
    {
        _meshBinding.Dispose();
    }
}