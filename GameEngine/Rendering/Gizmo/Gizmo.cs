using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

// Debug rendering tool
[HideInInspector]
public class Gizmo : Singlton<Gizmo>, IModel
{
    private readonly List<GizmoDrawable> _drawables = new();

    public void DrawPoint(Vector3 point, Color color)
    {
        _drawables.Add(new GizmoPoint(point, color));
    }
    
    public void DrawLine(Vector3 first, Vector3 second, Color color)
    {
        _drawables.Add(new GizmoLine(first, second, color));
    }

    public void DrawVector(Vector3 first, Vector3 second, Color color)
    {
        _drawables.Add(new GizmoVector(first, second, color));
    }

    public void DrawPath(List<Vector2i> path, Color color, float z = 0)
    {
        _drawables.Add(new GizmoPath(path, color, z));
    }
    
    public void DrawPlane(Vector3 centre, Vector3 normal, Color color)
    {
        _drawables.Add(new GizmoPlane(centre, normal, color));
    }

    void IModel.Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        GL.UseProgram(0);
        
        foreach (GizmoDrawable gizmoDrawable in _drawables)
        {
            gizmoDrawable.Draw();
        }

        _drawables.Clear();
    }

    public void Dispose()
    {
    }
}