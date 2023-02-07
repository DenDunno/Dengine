using OpenTK.Graphics.OpenGL4;

public class GLRenderer
{
    private readonly int _indicesLength;
    private readonly int _verticesCount;

    public GLRenderer(Mesh mesh)
    {
        _indicesLength = mesh.Indices.Length;
        _verticesCount = mesh.VerticesCount;
    }

    public void Draw()
    {
        //GL.DrawElements(PrimitiveType.Triangles, _indicesLength, DrawElementsType.UnsignedInt, 0);
        GL.DrawElementsInstanced(PrimitiveType.Triangles, _indicesLength, DrawElementsType.UnsignedInt, 0, 5);
        Stats.Instance.AddDrawCallStats(_verticesCount, _indicesLength / 3);
    }
}