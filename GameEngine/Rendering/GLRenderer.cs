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
        Benchmark.Instance.DrawCalls++;
        GL.DrawElements(PrimitiveType.Triangles, _indicesLength, DrawElementsType.UnsignedInt, 0);
    }
}