using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ModelRenderer : IDrawable
{
    private readonly Model _model;
    private readonly Transform _transform;

    public ModelRenderer(Model model, Transform transform)
    {
        _model = model;
        _transform = transform;
    }

    void IDrawable.Draw()
    {
        GL.Enable(EnableCap.Blend);
        GL.Begin(PrimitiveType.Polygon);

        foreach (Vector3 point in _model.Mesh.Points)
        {
            GL.Color3(1.0, 0, 0);
            GL.Vertex3(_transform.LocalToWorldPoint(point));
        }
        
        GL.End();
        GL.Disable(EnableCap.Blend);
    }
}