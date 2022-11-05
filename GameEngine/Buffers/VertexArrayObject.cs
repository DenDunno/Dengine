using OpenTK.Graphics.OpenGL;

public class VertexArrayObject
{
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly VertexAttributeGroup _vertexAttributeGroup;
    private readonly int _id;

    public VertexArrayObject(VertexBufferObject vertexBufferObject, VertexAttributeGroup vertexAttributeGroup)
    {
        _vertexBufferObject = vertexBufferObject;
        _vertexAttributeGroup = vertexAttributeGroup;
        _id = GL.GenVertexArray();
    }

    public void Init()
    {
        Bind();
        _vertexBufferObject.Init();
        _vertexAttributeGroup.Enable();
    }
    
    public void Bind()
    {
        GL.BindVertexArray(_id);
    }
}