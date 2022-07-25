
public class Object : IDrawable
{
    public readonly Transform Transform;
    private readonly IDrawable _meshRenderer;

    public Object(Mesh mesh) : this(new Transform(), mesh)
    {
    }

    private Object(Transform transform, Mesh mesh)
    {
        Transform = transform;
        _meshRenderer = new MeshRenderer(transform, mesh);
    }

    public void Draw()
    {
        _meshRenderer.Draw();
    }
}