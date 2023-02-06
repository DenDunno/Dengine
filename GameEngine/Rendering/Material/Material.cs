using OpenTK.Graphics.OpenGL;

public class Material : ShaderProgram
{
    protected Material(string vertexPath, string fragmentPath) : 
        base(new Shader[]
        {
            new(vertexPath, ShaderType.VertexShader), 
            new(fragmentPath, ShaderType.FragmentShader)
        })
    {
    }
}