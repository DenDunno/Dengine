using OpenTK.Graphics.OpenGL;

public class Shader : GLObject
{
    private readonly string _filename;

    public Shader(string filename, ShaderType type) : base(GL.CreateShader(type))
    {
        _filename = filename;
    }

    public void Load()
    {
        Read();
        Compile();
        CheckErrors();
    }

    private void Read()
    {
        using StreamReader streamReader = new(_filename);
        
        GL.ShaderSource(Id, streamReader.ReadToEnd());
    }

    private void Compile()
    {
        GL.CompileShader(Id);
    }

    private void CheckErrors()
    {
        GL.GetShader(Id, ShaderParameter.CompileStatus, out int status);
        
        if (status == 0)
            throw new Exception($"Error compiling shader: {GL.GetShaderInfoLog(Id)}");
    }
}