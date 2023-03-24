using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class GizmoPath : GizmoDrawable
{
    private readonly List<Vector2i> _path;
    private readonly float _z;

    public GizmoPath(List<Vector2i> path, Color color, float z) : base(PrimitiveType.Lines, color)
    {
        _path = path;
        _z = z;
    }

    protected override void OnPreDraw()
    {
        GL.LineWidth(5);
    }

    protected override void OnDraw()
    {
        for (int i = 0; i < _path.Count - 1; ++i)
        {
            Vector2i from = _path[i];
            Vector2i to = _path[i + 1];
            
            GL.Vertex3(from.X, from.Y, _z);
            GL.Vertex3(to.X, to.Y, _z);
        }
    }
}