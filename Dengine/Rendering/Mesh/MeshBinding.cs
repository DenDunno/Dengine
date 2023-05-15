using OpenTK.Graphics.OpenGL;

public class MeshBinding : IDisposable
{
    public readonly Mesh Mesh;
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly IndexBufferObject _indexBufferObject;
    private bool _dataWasBuffered;
    
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
    }

    public void TryBufferData()
    {
        if (_dataWasBuffered == false)
        {
            _dataWasBuffered = true;
            BufferData();
        }
    }

    public void BufferData()
    {
        _indexBufferObject.BufferData();
        _vertexBufferObject.BufferData();
        Mesh.AttributeGroup.Enable();
    }

    public void Dispose()
    {
        _vertexBufferObject.Dispose();
        _indexBufferObject.Dispose();
        Mesh.AttributeGroup.Disable();
    }
}