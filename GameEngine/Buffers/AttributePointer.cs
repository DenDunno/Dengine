using OpenTK.Graphics.OpenGL;

public class AttributePointer
{
    private readonly int _index;
    private readonly int _size;
    private readonly int _stride;
    private readonly int _offset;

    public AttributePointer(int index, int size, int stride, int offset)
    {
        _index = index;
        _size = size;
        _stride = stride;
        _offset = offset;
    }

    public void Enable()
    {
        GL.VertexAttribPointer(_index, _size, VertexAttribPointerType.Float, false, _stride * sizeof(float), _offset * sizeof(float));
        GL.EnableVertexAttribArray(_index);
    }
}