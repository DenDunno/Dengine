using System.Drawing;
using OpenTK.Graphics.OpenGL;

public abstract class GizmoDrawable
{
    private readonly PrimitiveType _primitiveType;
    private readonly Color _color;

    protected GizmoDrawable(PrimitiveType primitiveType, Color color)
    {
        _primitiveType = primitiveType;
        _color = color;
    }

    public void Draw()
    {
        GL.Color3(_color);
        OnPreDraw();
        
        GL.Begin(_primitiveType);
        OnDraw();
        GL.End();
        
        OnPostDraw();
    }

    protected abstract void OnDraw();

    protected virtual void OnPreDraw() {}
    
    protected virtual void OnPostDraw() {}
}