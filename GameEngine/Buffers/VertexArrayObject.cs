using OpenTK.Graphics.OpenGL;

public class VertexArrayObject
{
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly AttributePointer _vertexPointer;
    private readonly int _id;

    public VertexArrayObject(VertexBufferObject vertexBufferObject)
    {
        _vertexPointer = new AttributePointer(0);
        _vertexBufferObject = vertexBufferObject;
        _id = GL.GenVertexArray();
    }

    public void Init()
    {
        Bind();
        _vertexBufferObject.Bind();
        _vertexBufferObject.SendData();
        _vertexPointer.Enable();
    }
    
    public void Bind()
    {
        GL.BindVertexArray(_id);
    }
}