using OpenTK.Mathematics;

public class Model : IModel
{
    [EditorField] private readonly Material _material;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly GLRenderer _glRenderer;
    private readonly Transform _transform;

    public Model(RenderData renderData)
    {
        _vertexArrayObject = new VertexArrayObject(renderData);
        _glRenderer = new GLRenderer(renderData.Mesh.Data);
        _transform = renderData.Transform;
        _material = renderData.Material;
    }

    public void Initialize()
    {
        _material.Init();
        _vertexArrayObject.Init();
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _material.Bridge.SetMatrix4("model", _transform.ModelMatrix);
        _material.Bridge.SetMatrix4("view", viewMatrix);
        _material.Bridge.SetMatrix4("projection", projectionMatrix);
        _vertexArrayObject.Bind();
        _material.Use();
        _glRenderer.Draw();
    }
}