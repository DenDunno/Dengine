
public class LitMaterial : Material
{
    [EditorField] private readonly LitMaterialData _data;

    public LitMaterial(LitMaterialData data) : base("Shaders/vert.glsl", "Shaders/lit.glsl")
    {
        _data = data;
    }

    protected override void OnInit()
    {
        if (_data.Texture == null)
        {
            Bridge.SetFloat("hasTexture", 0);
        }
        
        _data.Texture?.Load();
    }

    protected override void OnUse()
    {
        _data.Texture?.Use();
        Bridge.SetColor("baseColor", _data.Color);
    }
}