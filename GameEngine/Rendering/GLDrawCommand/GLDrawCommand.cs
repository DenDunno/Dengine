
public abstract class GLDrawCommand
{
    protected int Indices { get; private set; }
    protected int VerticesCount { get; private set; }
    protected int Tris { get; private set; }

    public void SetMesh(Mesh mesh)
    {
        Tris = mesh.Indices.Length / 3;
        Indices = mesh.Indices.Length;
        VerticesCount = mesh.VerticesCount;
    }

    public abstract void Execute();
}