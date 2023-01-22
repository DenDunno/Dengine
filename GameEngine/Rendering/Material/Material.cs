using OpenTK.Graphics.OpenGL;

public class Material : GLObject, IDisposable
{
    public readonly ShaderBridge Bridge;
    private readonly Shader[] _shaders;
    private bool _wasInited;
    
    public Material(string vertexPath, string fragmentPath) : base(GL.CreateProgram())
    {
        _shaders = new Shader[]
        {
            new(vertexPath, ShaderType.VertexShader),
            new(fragmentPath, ShaderType.FragmentShader),
        };
        
        Bridge = new ShaderBridge(Id);
    }

    public void Initialize()
    {
        if (_wasInited == false) // shared material
        {
            _wasInited = true;
            
            LoadShaders();
            Bridge.LoadUniforms();
            OnInit();
        }
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

    public void Use()
    {
        OnUse();
        GL.UseProgram(Id);
    }

    protected virtual void OnInit() { }

    protected virtual void OnUse() { }

    public virtual void Dispose() { }
}