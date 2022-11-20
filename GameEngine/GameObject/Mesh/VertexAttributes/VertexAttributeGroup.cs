using OpenTK.Graphics.OpenGL;

public class VertexAttributeGroup
{
    private readonly IEnumerable<VertexAttribute> _vertexAttributes;
    private readonly int _stride;

    public VertexAttributeGroup(IEnumerable<VertexAttribute> vertexAttributes, int stride)
    {
        _vertexAttributes = vertexAttributes;
        _stride = stride;
    }

    public void Enable()
    {
        foreach (VertexAttribute attribute in _vertexAttributes)
        {
            GL.VertexAttribPointer(attribute.Index, attribute.Size, VertexAttribPointerType.Float, false, _stride * sizeof(float), attribute.Offset * sizeof(float));
            GL.EnableVertexAttribArray(attribute.Index);
        }
    }
}