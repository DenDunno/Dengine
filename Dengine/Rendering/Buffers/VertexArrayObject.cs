using OpenTK.Graphics.OpenGL;

public class VertexArrayObject : GLObject, IDisposable
{
    private readonly IMeshProvider _meshProvider;

    public VertexArrayObject(IMeshProvider meshProvider) : base(GL.GenVertexArray())
    {
        _meshProvider = meshProvider;
    }

    public void Initialize()
    {
        GL.BindVertexArray(Id);
        _meshProvider.Initialize();
    }

    public void Bind()
    {
        GL.BindVertexArray(Id);
        _meshProvider.Bind();
    }

    public void Dispose()
    {
        _meshProvider.Dispose();
        GL.DeleteVertexArray(Id);
    }
}