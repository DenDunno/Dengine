using OpenTK.Graphics.OpenGL4;

public class GLRenderer
{
    private readonly int _indicesLength;
    private readonly int _verticesLength;

    public GLRenderer(MeshData meshData)
    {
        _indicesLength = meshData.Indices.Length;
        _verticesLength = meshData.Positions.Length;
    }

    public void Draw()
    {
        GL.DrawElements(PrimitiveType.Triangles, _indicesLength, DrawElementsType.UnsignedInt, 0);
        Stats.Instance.DrawCalls++;
        Stats.Instance.Tris += _indicesLength / 3;
        Stats.Instance.Vertices += _verticesLength;
    }
}