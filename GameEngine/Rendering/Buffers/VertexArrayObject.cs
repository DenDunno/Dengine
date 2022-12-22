using OpenTK.Graphics.OpenGL;

public class VertexArrayObject
{
    private readonly VertexAttributeGroup _vertexAttributeGroup;
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly IndexBufferObject _indexBufferObject;
    private readonly int _id;

    public VertexArrayObject(RenderData renderData)
    {
        _vertexBufferObject = new VertexBufferObject(renderData.Mesh.GetVerticesData(), renderData.BufferUsageHint);
        _indexBufferObject = new IndexBufferObject(renderData.Mesh.Data.Indices, renderData.BufferUsageHint);
        _vertexAttributeGroup = renderData.Mesh.AttributeGroup;
        _id = GL.GenVertexArray();
    }

    public void Init()
    {
        Bind();
        _indexBufferObject.Init();
        _vertexBufferObject.Init();
        _vertexAttributeGroup.Enable();
    }
    
    public void Bind()
    {
        GL.BindVertexArray(_id);
    }
}