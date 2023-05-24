
public class Model : IDrawable
{
    [EditorField] public readonly RenderData Data;
    private readonly Transform _transform;
    
    public Model(RenderData data)
    {
        Data = data;
        _transform = data.Transform;
    }

    public void Initialize()
    {
        Data.Material.Initialize();
        Data.Material.Bridge.BindUniformBlock("CameraData", 0);
        Data.VertexArrayObject.Initialize();
    }

    public void Draw()
    {
        if (Data.Visible)
        {
            Data.Material.Bridge.SetMatrix4("model", _transform.ModelMatrix);
            Data.VertexArrayObject.Bind();
            Data.Material.Use();
            Data.DrawCommand.Execute();
        }
    }

    public void Dispose()
    {
        Data.VertexArrayObject.Dispose();
        Data.Material.Dispose();
    }
}