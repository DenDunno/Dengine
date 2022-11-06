using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

// Debugging rendering tool
public class Gizmo : IModel
{
    public static Gizmo Instance;
    private readonly List<GizmoDrawable> _drawables = new();
    private bool _rendering = true;

    public void Initialize()
    {
        Instance = this;
    }

    public void Enable()
    {
        _rendering = true;
    }
    
    public void Disable()
    {
        _rendering = false;
    }

    public void DrawLine(Vector3 first, Vector3 second, Color color)
    {
        _drawables.Add(new GizmoLine(first, second, color));
    }

    public void DrawArrow(Vector3 first, Vector3 second, Color color)
    {
        _drawables.Add(new ArrowGizmo(first, second, color));
    }

    public void DrawPlane(Vector3 centre, Vector3 normal, Color color)
    {
        _drawables.Add(new GizmoPlane(centre, normal, color));
    }

    void IModel.Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        if (_rendering == false)
            return;
        
        GL.UseProgram(0);
        
        foreach (GizmoDrawable gizmoDrawable in _drawables)
        {
            gizmoDrawable.Draw();
        }

        _drawables.Clear();
    }
}