
public class ShaderProgramWithTexture : ShaderProgram
{
    private readonly TextureBase _texture;

    public ShaderProgramWithTexture(TextureBase texture, string vertexShaderPath, string fragmentShaderPath) 
        : base(vertexShaderPath, fragmentShaderPath)
    {
        _texture = texture;
    }

    protected override void OnInit()
    {
        _texture.Load();
    }

    protected override void OnUse()
    {
        _texture.Use();
    }
}