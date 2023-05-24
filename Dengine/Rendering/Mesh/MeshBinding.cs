using OpenTK.Graphics.OpenGL;

public class MeshBinding : IDisposable
{
    public readonly Mesh Mesh;
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly IndexBufferObject _indexBufferObject;

    public MeshBinding(Mesh mesh)
    {
        Mesh = mesh;
        _vertexBufferObject = new VertexBufferObject(mesh.GetRawData(), BufferUsageHint.StaticDraw);
        _indexBufferObject = new IndexBufferObject(mesh.Indices, BufferUsageHint.StaticDraw);
    }

    public void Bind()
    {
        _indexBufferObject.Bind();
        _vertexBufferObject.Bind();
        Mesh.AttributeGroup.Enable();
    }

    public void BufferData()
    {
        _indexBufferObject.BufferData();
        _vertexBufferObject.BufferData();
    }

    public void Dispose()
    {
        _vertexBufferObject.Dispose();
        _indexBufferObject.Dispose();
        Mesh.AttributeGroup.Disable();
    }
}