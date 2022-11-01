using OpenTK.Mathematics;

public class LightningShaderProgram : ShaderProgram
{
    private readonly LightData _data;
    private readonly Camera _camera;
    private Vector3 _color = Vector3.One;
    
    public LightningShaderProgram(LightData data, Camera camera, string vertexShaderPath, string fragmentShaderPath) 
        : base(vertexShaderPath, fragmentShaderPath)
    {
        _data = data;
        _camera = camera;
    }

    public void SetColor(Vector3 color)
    {
        _color = color;
    }
    
    protected override void OnInit()
    {
        Bridge.SetVector3("lightPosition", _data.LightPosition);
        _data.Texture.Load();
    }

    protected override void OnUse()
    {
        _data.Texture.Use();
        Bridge.SetVector3("lightColor", _color);
        Bridge.SetVector3("viewPosition", _camera.Position);
    }
}