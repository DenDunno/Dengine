using OpenTK.Graphics.OpenGL;

public class ShaderProgram 
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
        OnInit();
    }

    public void Use()
    {
        OnUse();
        GL.UseProgram(_id);
    }

    protected virtual void OnInit() { }

    protected virtual void OnUse() { }
}