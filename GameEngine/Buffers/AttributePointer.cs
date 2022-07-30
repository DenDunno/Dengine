using OpenTK.Graphics.OpenGL;

public class AttributePointer
{
    private readonly int _index;
    private readonly int _size;

    public AttributePointer(int index, int size)
    {
        _index = index;
        _size = size;
    }

    public void Enable()
    {
        GL.VertexAttribPointer(_index, _size, VertexAttribPointerType.Float, false, _size * sizeof(float), 0);
        GL.EnableVertexAttribArray(_index);
    }
}