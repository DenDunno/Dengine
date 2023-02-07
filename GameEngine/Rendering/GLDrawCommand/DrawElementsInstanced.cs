using OpenTK.Graphics.OpenGL;

public class DrawElementsInstanced : GLDrawCommand
{
    private readonly int _count;

    public DrawElementsInstanced(int count)
    {
        _count = count;
    }

    public override void Execute()
    {
        GL.DrawElementsInstanced(PrimitiveType.Triangles, Indices, DrawElementsType.UnsignedInt, 0, _count);
        Stats.Instance.AddDrawCallStats(VerticesCount * _count, Tris * _count);
    }
}