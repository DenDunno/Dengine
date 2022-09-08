using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Model : IModel
{
    private readonly IndexBufferObject _indexBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shader;
    private readonly Transform _transform;
    private readonly GLRenderer _glRenderer;
    
    public Model(RenderData renderData, BufferUsageHint bufferUsageHint)
    {
        _indexBufferObject = new IndexBufferObject(renderData.Mesh.Indices, bufferUsageHint);
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(renderData.Mesh.VerticesData, bufferUsageHint), renderData.AttributePointers);
        _shader = renderData.ShaderProgram;
        _transform = renderData.Transform;
        _glRenderer = new GLRenderer(renderData.Mesh.Indices.Length);
    }

    void IInitializable.Initialize()
    {
        _shader.Init();
        _vertexArrayObject.Init();
        _indexBufferObject.Init();
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _shader.Bridge.SetMatrix4("model", _transform.ModelMatrix);
        _shader.Bridge.SetMatrix4("view", viewMatrix);
        _shader.Bridge.SetMatrix4("projection", projectionMatrix);
        _vertexArrayObject.Bind();
        _shader.Use();
        _glRenderer.Draw();
    }
}