using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class GizmoPoint : GizmoDrawable
{
    private readonly Vector3 _position;

    public GizmoPoint(Vector3 position, Color color) : base(PrimitiveType.Points, color)
    {
        _position = position;
    }

    protected override void OnDraw()
    {
        GL.Vertex3(_position);
    }

    protected override void OnPreDraw()
    {
        GL.PointSize(8);
    }
}