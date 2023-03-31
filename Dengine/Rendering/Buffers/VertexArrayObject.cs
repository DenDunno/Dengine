using OpenTK.Graphics.OpenGL;

public class VertexArrayObject : GLObject, IDisposable
{
    private readonly VertexAttributeGroup _vertexAttributeGroup;
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly IndexBufferObject _indexBufferObject;

    public VertexArrayObject(RenderData renderData) : base(GL.GenVertexArray())
    {
        _vertexBufferObject = new VertexBufferObject(renderData.Mesh.GetRawData(), renderData.VertexBufferUsage);
        _indexBufferObject = new IndexBufferObject(renderData.Mesh.Indices, renderData.IndexBufferUsage);
        _vertexAttributeGroup = renderData.Mesh.AttributeGroup;
    }

    public void Initialize()
    {
        Bind();
        _indexBufferObject.SendAndRelease();
        _vertexBufferObject.SendAndRelease();
        _vertexAttributeGroup.Enable();
    }
    
    public void Bind()
    {
        GL.BindVertexArray(Id);
    }

    public void Dispose()
    {
        _vertexBufferObject.Dispose();
        _indexBufferObject.Dispose();
        _vertexAttributeGroup.Disable();
        GL.DeleteVertexArray(Id);
    }
}