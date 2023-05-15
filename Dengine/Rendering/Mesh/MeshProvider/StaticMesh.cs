using OpenTK.Graphics.OpenGL;

public class StaticMesh : IMeshProvider
{
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly IndexBufferObject _indexBufferObject;
    private bool _wasDataBuffered;

    public StaticMesh(Mesh mesh)
    {
        Mesh = mesh;
        _vertexBufferObject = new VertexBufferObject(mesh.GetRawData(), BufferUsageHint.StaticDraw);
        _indexBufferObject = new IndexBufferObject(mesh.Indices, BufferUsageHint.StaticDraw);
    }

    public Mesh Mesh { get; }

    public void Bind()
    { 
        if (_wasDataBuffered == false)
        {
            _wasDataBuffered = true;
            _indexBufferObject.Bind();
            _vertexBufferObject.Bind();
            _indexBufferObject.BufferData();
            _vertexBufferObject.BufferData();
            Mesh.AttributeGroup.Enable();
        }
    }

    public void Dispose()
    {
        _vertexBufferObject.Dispose();
        _indexBufferObject.Dispose();
        Mesh.AttributeGroup.Disable();
    }
}