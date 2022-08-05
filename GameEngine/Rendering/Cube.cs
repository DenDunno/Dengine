using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Cube : IDrawable
{
    private readonly Texture _texture = new("Resources/wood.png");
    private readonly IndexBufferObject _indexBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shader;
    private readonly Transform _transform = new();
    private readonly Mesh _mesh;

    public Cube()
    {
        _mesh = Primitives.Cube();
        _indexBufferObject = new IndexBufferObject(_mesh.Indices);
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(_mesh.VerticesData), new[]
        {
            new AttributePointer(0, 3, 5, 0),
            new AttributePointer(1, 2, 5, 3)
        });

        _shader = new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        });
    }

    public void Init()
    {
        _shader.Init();
        _texture.Load();
        _vertexArrayObject.Init();
        _indexBufferObject.Init();
    }
    
    public void Draw(in Matrix4 viewMatrix)
    {
        //_transform.Rotate(0, 0, 0.01f);
        _shader.Bridge.SetMatrix4("transform", viewMatrix * _transform.ModelMatrix);
        
        _vertexArrayObject.Bind();
        _texture.Use();
        _shader.Use();
        GL.DrawElements(PrimitiveType.Triangles, _mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}