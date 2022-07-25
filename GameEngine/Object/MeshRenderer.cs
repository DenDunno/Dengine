using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class MeshRenderer : IDrawable
{
    private readonly Transform _transform;
    private readonly Mesh _mesh;

    public MeshRenderer(Transform transform, Mesh mesh)
    {
        _transform = transform;
        _mesh = mesh;
    }
    
    void IDrawable.Draw()
    {
        GL.Enable(EnableCap.Blend);
        GL.Color4(Color.Crimson);
        GL.Begin(PrimitiveType.Polygon);

        foreach (Vector3 point in _mesh.Points)
        {
            GL.Vertex3(point);
        }
        
        GL.End();
        GL.Disable(EnableCap.Blend);
    }
}