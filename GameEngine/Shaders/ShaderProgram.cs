using OpenTK.Graphics.OpenGL;

public class ShaderProgram : IDisposable
{
    public readonly ShaderBridge Bridge;
    private readonly Shader[] _shaders;
    private readonly int _id;
    
    public ShaderProgram(Shader[] shaders)
    {
        _shaders = shaders;
        _id = GL.CreateProgram();
        Bridge = new ShaderBridge(_id);
    }

    public void Init()
    {
        foreach (Shader shader in _shaders)
        {
            shader.Load();
            GL.AttachShader(_id, shader.Address);
        }
        
        GL.LinkProgram(_id);
        Bridge.LoadUniforms();
    }

    public void Use()
    {
        GL.UseProgram(_id);
    }

    public void Dispose()
    {
        foreach (Shader shader in _shaders)
        {
            GL.DetachShader(_id, shader.Address);
            GL.DeleteShader(shader.Address);
        }
        
        GL.DeleteProgram(_id);
    }
}