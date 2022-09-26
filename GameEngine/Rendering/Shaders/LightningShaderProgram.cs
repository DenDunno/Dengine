using OpenTK.Mathematics;

public class LightningShaderProgram : ShaderProgram
{
    private readonly LightData _data;
    private readonly Camera _camera;

    public LightningShaderProgram(LightData data, Camera camera, string vertexShaderPath, string fragmentShaderPath) 
        : base(vertexShaderPath, fragmentShaderPath)
    {
        _data = data;
        _camera = camera;
    }

    protected override void OnInit()
    {
        Bridge.SetVector3("lightPosition", _data.Position);
        Bridge.SetVector3("lightColor", Vector3.One);
        _data.Texture.Load();
    }

    protected override void OnUse()
    {
        _data.Texture.Use();
        Bridge.SetVector3("viewPosition", _camera.Position);
    }
}