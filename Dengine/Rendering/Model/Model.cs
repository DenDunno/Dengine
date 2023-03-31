
public class Model : IDrawable
{
    [EditorField] public readonly RenderData Data;
    private readonly VertexArrayObject _vertexArrayObject;

    public Model(RenderData data)
    {
        Data = data;
        _vertexArrayObject = new VertexArrayObject(data);
        data.DrawCommand.SetMesh(data.Mesh);
    }

    public void Initialize()
    {
        Data.Material.Initialize();
        _vertexArrayObject.Initialize();
        Data.Material.Bridge.BindUniformBlock("MyUniformBlock", 0);
    }

    public void Draw()
    {
        if (Data.Visible)
        {
            Data.Material.Bridge.SetMatrix4("model", Data.Transform.ModelMatrix);
            _vertexArrayObject.Bind();
            Data.Material.Use();
            Data.DrawCommand.Execute();
        }
    }

    public void Dispose()
    {
        _vertexArrayObject.Dispose();
        Data.Material.Dispose();
    }
}