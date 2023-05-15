using OpenTK.Graphics.OpenGL;

public class ShaderProgram : GLObject, IDisposable
{
    public readonly ShaderBridge Bridge;
    private readonly Shader[] _shaders;
    private bool _wasInited;

    protected ShaderProgram(Shader[] shaders) : base(GL.CreateProgram())
    {
        _shaders = shaders;
        Bridge = new ShaderBridge(Id);
    }

    public void Initialize()
    {
        if (_wasInited == false) // shared material
        {
            _wasInited = true;
            LoadShaders();
            OnInit();
        }
    }

    public void Use()
    {
        GL.UseProgram(Id);
        OnUse();
    }

    private void LoadShaders()
    {
        foreach (Shader shader in _shaders)
        {
            shader.Load();
            GL.AttachShader(Id, shader.Id);
        }
            
        GL.LinkProgram(Id);
            
        foreach (Shader shader in _shaders)
        {
            GL.DetachShader(Id, shader.Id);
            GL.DeleteShader(shader.Id);
        }
    }

    public void Dispose()
    {
        OnDispose();
        GL.DeleteProgram(Id);
    }
    
    protected virtual void OnInit() { }

    protected virtual void OnUse() { }
    
    protected virtual void OnDispose() { }
}