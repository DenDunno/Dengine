
public class MaterialWithTexture : Material
{
    private readonly TextureBase _texture;

    public MaterialWithTexture(TextureBase texture, string vertexShaderPath, string fragmentShaderPath) 
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