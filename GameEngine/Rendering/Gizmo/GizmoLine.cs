using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class GizmoLine : GizmoDrawable
{
    private readonly Vector3 _first;
    private readonly Vector3 _second;

    public GizmoLine(Vector3 first, Vector3 second, Color color) : base(PrimitiveType.Lines, color)
    {
        _first = first;
        _second = second;
    }

    public Vector3 First => _first;
    public Vector3 Second => _second;
    
    protected override void OnDraw()
    {
        GL.Vertex3(_first);
        GL.Vertex3(_second);
    }

    protected override void OnPreDraw()
    {
        GL.LineWidth(5);
    }
}