using OpenTK.Graphics.OpenGL;

public class Shader
{
    private readonly string _filename;
    private readonly ShaderType _type;

    public Shader(string filename, ShaderType type)
    {
        _filename = filename;
        _type = type;
    }
    
    public int Address { get; private set; }

    public void Load()
    {
        Create();
        Read();
        Compile();
        CheckErrors();
    }

    private void Create()
    {
        Address = GL.CreateShader(_type);
    }

    private void Read()
    {
        using var streamReader = new StreamReader(_filename);
        
        GL.ShaderSource(Address, streamReader.ReadToEnd());
    }

    private void Compile()
    {
        GL.CompileShader(Address);
    }

    private void CheckErrors()
    {
        GL.GetShader(Address, ShaderParameter.CompileStatus, out int status);
        
        if (status == 0)
            throw new Exception($"Error compiling shader: {GL.GetShaderInfoLog(Address)}");
    }
}