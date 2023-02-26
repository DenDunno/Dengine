using OpenTK.Mathematics;

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
        _vertexArrayObject.Init();
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        if (Data.Visible)
        {
            Data.Material.Bridge.SetMatrix4("model", Data.Transform.ModelMatrix);
            Data.Material.Bridge.SetMatrix4("view", viewMatrix);
            Data.Material.Bridge.SetMatrix4("projection", projectionMatrix);
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