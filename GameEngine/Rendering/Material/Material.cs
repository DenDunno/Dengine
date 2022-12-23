using OpenTK.Graphics.OpenGL;

public abstract class Material 
{
    public readonly ShaderBridge Bridge;
    private readonly Shader[] _shaders;
    private readonly int _id;
    private bool _wasInited = false;
    
    protected Material(string vertexPath, string fragmentPath)
    {
        _shaders = new Shader[]
        {
            new(vertexPath, ShaderType.VertexShader),
            new(fragmentPath, ShaderType.FragmentShader),
        };
        _id = GL.CreateProgram();
        Bridge = new ShaderBridge(_id);
    }

    public void Init()
    {
        if (_wasInited == false) // shared material
        {
            _wasInited = true;
            foreach (Shader shader in _shaders)
            {
                shader.Load();
                GL.AttachShader(_id, shader.Address);
            }
        
            GL.LinkProgram(_id);
            Bridge.LoadUniforms();
            OnInit();
        }
    }

    public void Use()
    {
        OnUse();
        GL.UseProgram(_id);
    }

    protected virtual void OnInit() { }

    protected virtual void OnUse() { }
}