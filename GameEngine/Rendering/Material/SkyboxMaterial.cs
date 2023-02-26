
public class SkyboxMaterial : Material
{
    private readonly Cubemap _texture;

    public SkyboxMaterial(Cubemap texture) : base(Paths.GetShader("skyboxVert"), Paths.GetShader("skyboxFrag"))
    {
        _texture = texture;
    }

    protected override void OnInit()
    {
        _texture.Load();
    }

    protected override void OnUse()
    {
        _texture.Bind();
    }
}