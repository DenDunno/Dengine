using OpenTK.Graphics.OpenGL;

public class Triangle : IDrawable
{
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shaderProgram;

    private readonly float[] _vertices = 
    {
        -0.5f, -0.5f, 0.0f, 
         0.5f, -0.5f, 0.0f, 
         0.0f,  0.5f, 0.0f,
    };

    public Triangle()
    {
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(_vertices, BufferUsageHint.StaticDraw));
        _shaderProgram = new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        });
    }

    public void Init()
    {
        _vertexArrayObject.Init();
        _shaderProgram.Link();
    }

    public void Draw()
    {
        _shaderProgram.Use();
        _vertexArrayObject.Bind();
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }
}