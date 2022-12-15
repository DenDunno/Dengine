
public class SkyboxMaterial : Material
{
    private readonly Cubemap _texture;

    public SkyboxMaterial(Cubemap texture, string vertexPath, string fragmentPath) 
        : base(vertexPath, fragmentPath)
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