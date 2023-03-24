using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class GizmoPlane : GizmoDrawable
{
    private readonly Vector3 _centre;
    private readonly Vector3 _normal;
    private const float _planeSize = 0.5f;
        
    public GizmoPlane(Vector3 centre, Vector3 normal, Color color) : base(PrimitiveType.Quads, color)
    {
        _centre = centre;
        _normal = normal;
    }

    protected override void OnDraw()
    {
        (Vector3 firstAxis, Vector3 secondAxis) = Algorithms.CreateOrthonormalBasis(_normal);

        GL.Vertex3(_centre + (firstAxis + secondAxis) * _planeSize);
        GL.Vertex3(_centre + (firstAxis - secondAxis) * _planeSize);
        GL.Vertex3(_centre - (firstAxis + secondAxis) * _planeSize);
        GL.Vertex3(_centre - (firstAxis - secondAxis) * _planeSize);
    }
}