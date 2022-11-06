using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

// Debugging rendering tool
public class Gizmo : IModel
{
    public static Gizmo Instance;
    private readonly List<GizmoDrawable> _drawables = new();
    
    public Gizmo()
    {
        Instance = this;
    }

    public void DrawLine(Vector3 first, Vector3 second, Color color = new())
    {
        _drawables.Add(new GizmoLine(first, second, color));
    }

    public void DrawArrow(Vector3 first, Vector3 second, Color color = new())
    {
        _drawables.Add(new ArrowGizmo(first, second, color));
    }

    public void Initialize()
    {
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
}