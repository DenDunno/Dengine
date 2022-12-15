using OpenTK.Mathematics;

public class Model : IModel
{
    private readonly IndexBufferObject _indexBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly Material _material;
    private readonly Transform _transform;
    private readonly GLRenderer _glRenderer;
    
    public Model(RenderData renderData)
    {
        VertexBufferObject vertexBufferObject = new(renderData.Mesh.GetVerticesData(), renderData.BufferUsageHint);
        _indexBufferObject = new IndexBufferObject(renderData.Mesh.Data.Indices, renderData.BufferUsageHint);
        _vertexArrayObject = new VertexArrayObject(vertexBufferObject, renderData.Mesh.AttributeGroup);
        _material = renderData.Material;
        _transform = renderData.Transform;
        _glRenderer = new GLRenderer(renderData.Mesh.Data.Indices.Length);
    }

    void IModel.Initialize()
    {
        _material.Init();
        _vertexArrayObject.Init();
        _indexBufferObject.Init();
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