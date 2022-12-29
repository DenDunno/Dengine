using OpenTK.Graphics.OpenGL;

public abstract class Material : GLObject
{
    public readonly ShaderBridge Bridge;
    private readonly Shader[] _shaders;
    private bool _wasInited;
    
    protected Material(string vertexPath, string fragmentPath) : base(GL.CreateProgram())
    {
        _shaders = new Shader[]
        {
            new(vertexPath, ShaderType.VertexShader),
            new(fragmentPath, ShaderType.FragmentShader),
        };
        
        Bridge = new ShaderBridge(Id);
    }

    public void Init()
    {
        if (_wasInited == false) // shared material
        {
            _wasInited = true;
            foreach (Shader shader in _shaders)
            {
                shader.Load();
                GL.AttachShader(Id, shader.Address);
            }
        
            GL.LinkProgram(Id);
            Bridge.LoadUniforms();
            OnInit();
        }
    }

    public void Use()
    {
        OnUse();
        GL.UseProgram(Id);
    }

    protected virtual void OnInit() { }

    protected virtual void OnUse() { }
}