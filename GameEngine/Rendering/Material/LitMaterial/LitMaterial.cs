
public class LitMaterial : Material
{
    [EditorField] private readonly LitMaterialData _data;

    public LitMaterial(LitMaterialData data) : base(Paths.GetShader("vert"), Paths.GetShader("lit"))
    {
        _data = data;
    }

    protected override void OnInit()
    {
        if (_data.Texture == null)
        {
            Bridge.SetInt("hasTexture", 0);
        }
        
        _data.Texture?.Load();
    }

    protected override void OnUse()
    {
        _data.Texture?.Use();
        Bridge.SetColor("baseColor", _data.Color);
    }
}