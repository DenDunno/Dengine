
public class NormalsViewer : TogglingComponent
{
    private readonly List<MeshWorldView> _meshs = new();

    public void Add(Transform transform, Mesh mesh)
    {
        MeshWorldView meshWorldView = new(transform, mesh);
        Add(meshWorldView);
    }

    public void Add(MeshWorldView meshWorldView)
    {
        _meshs.Add(meshWorldView);
    }

    protected override void OnUpdate(float deltaTime)
    {
    }
}