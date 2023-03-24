using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class GizmoVector : GizmoLine
{
    public GizmoVector(Vector3 first, Vector3 second, Color color) : base(first, second, color)
    {
    }

    protected override void OnPreDraw()
    {
        GL.PushAttrib(AttribMask.EnableBit);
        GL.LineStipple(1, 30);
        GL.Enable(EnableCap.LineStipple);
    }

    protected override void OnPostDraw()
    {
        GL.PopAttrib();
        DrawArrowSide(-0.2f);
        DrawArrowSide(0.2f);
    }

    private void DrawArrowSide(float arrowAngle)
    {
        Vector4 direction = new Vector4(First - Second, 0).Normalized();
        Vector3 normal = Algorithms.GetNormal(direction.Xyz);
        Vector4 arrowSideDirection = -(direction + new Vector4(normal, 0) * arrowAngle);
        Vector3 first = First + direction.Xyz * 0.2f;
        Vector3 second = first + arrowSideDirection.Xyz * 0.2f;

        GL.LineWidth(3);
        GL.Begin(PrimitiveType.Lines);
        GL.Vertex3(first);
        GL.Vertex3(second);
        GL.End();
    }
}