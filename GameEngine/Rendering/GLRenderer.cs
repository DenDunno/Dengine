using OpenTK.Graphics.OpenGL4;

public class GLRenderer
{
    private readonly int _indicesLength;

    public GLRenderer(int indicesLength)
    {
        _indicesLength = indicesLength;
    }

    public void Draw()
    {
        GL.DrawElements(PrimitiveType.Triangles, _indicesLength, DrawElementsType.UnsignedInt, 0);
        Stats.Instance.DrawCalls++;
    }
}