using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Cube : IDrawable
{
        private readonly Texture _texture = new("Resources/wood.png");
    private readonly IndexBufferObject _indexBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shader;
    private readonly Transform _transform;
    private readonly Mesh _mesh;

    public Cube(Transform transform)
    {
        _transform = transform;
        _mesh = Primitives.Cube(0.5f);
        _indexBufferObject = new IndexBufferObject(_mesh.Indices);
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(_mesh.VerticesData), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        });

        _shader = new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        });
    }

    public void Init()
    {
        _texture.Load();
        _shader.Init();
        _vertexArrayObject.Init();
        _indexBufferObject.Init();
    }
    
    public void Draw(in Matrix4 projectionViewMatrix)
    {
        _texture.Use();
        _shader.Bridge.SetMatrix4("transform", projectionViewMatrix * _transform.ModelMatrix);
        _vertexArrayObject.Bind();
        _shader.Use();
        GL.DrawElements(PrimitiveType.Triangles, _mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}