using OpenTK.Graphics.OpenGL;

public class Triangle : IDrawable
{
    private readonly ElementBufferObject _elementBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shader;
    private readonly float[] _verticesData = 
    {
        0.5f,  0.5f, 0.0f,  
        0.5f, -0.5f, 0.0f,  
        -0.5f, -0.5f, 0.0f,  
        -0.5f,  0.5f, 0.0f
    };
    private readonly uint[] _indices = 
    {  
        0, 1, 3,
        1, 2, 3 
    };

    public Triangle()
    {
        _elementBufferObject = new ElementBufferObject(_indices);
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(_verticesData), new[]
        {
            new AttributePointer(0, 3)
        });

        _shader = new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        });
    }

    public void Init()
    {
        _vertexArrayObject.Init();
        _shader.Init();
        _elementBufferObject.Bind();
        _elementBufferObject.SendData();
    }

    public void Draw()
    {
        _shader.Use();
        _vertexArrayObject.Bind();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}