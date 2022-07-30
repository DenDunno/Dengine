using OpenTK.Graphics.OpenGL;

public class VertexArrayObject
{
    private readonly VertexBufferObject _vertexBufferObject;
    private readonly AttributePointer[] _attributePointers;
    private readonly int _id;

    public VertexArrayObject(VertexBufferObject vertexBufferObject, AttributePointer[] attributePointers)
    {
        _vertexBufferObject = vertexBufferObject;
        _attributePointers = attributePointers;
        _id = GL.GenVertexArray();
    }

    public void Init()
    {
        Bind();
        _vertexBufferObject.Bind();
        _vertexBufferObject.SendData();
        _attributePointers.ForEach(pointer => pointer.Enable());
    }
    
    public void Bind()
    {
        GL.BindVertexArray(_id);
    }
}