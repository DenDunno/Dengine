using OpenTK.Graphics.OpenGL;

public class AttributePointer
{
    private readonly int _index;

    public AttributePointer(int index)
    {
        _index = index;
    }

    public void Enable()
    {
        GL.VertexAttribPointer(_index, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(_index);
    }
}