using OpenTK.Graphics.OpenGL;

public class Shader
{
    private readonly ShaderProgram _shaderProgram;
    private readonly string _filename;
    private readonly ShaderType _type;

    public Shader(ShaderProgram shaderProgram, string filename, ShaderType type)
    {
        _shaderProgram = shaderProgram;
        _filename = filename;
        _type = type;
    }
    
    public int Address { get; private set; }

    public void Load()
    {
        Address = GL.CreateShader(_type);
        
        using (var streamReader = new StreamReader(_filename))
        {
            GL.ShaderSource(Address, streamReader.ReadToEnd());
        }
        
        GL.CompileShader(Address);
        GL.AttachShader(_shaderProgram.Id, Address);
        Console.WriteLine(GL.GetShaderInfoLog(Address));
    }
}