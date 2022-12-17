
public class SkyboxMaterial : Material
{
    private readonly Cubemap _texture;

    public SkyboxMaterial(Cubemap texture) : base("Shaders/skyboxVert.glsl", "Shaders/skyboxFrag.glsl")
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