using OpenTK.Graphics.OpenGL;

public class DrawElements : GLDrawCommand
{
    public override void Execute()
    {
        GL.DrawElements(PrimitiveType.Triangles, Indices, DrawElementsType.UnsignedInt, 0); 
        Stats.Instance.AddDrawCallStats(VerticesCount, Tris);
    }
}