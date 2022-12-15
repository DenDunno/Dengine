
public class LitMaterial : Material
{
    [EditorField] private readonly LitMaterialData _data = new();

    public LitMaterial(string vertexPath, string fragmentPath) : base(vertexPath, fragmentPath)
    {
    }
    
    public LitMaterial(string vertexPath, string fragmentPath, LitMaterialData data) : base(vertexPath, fragmentPath)
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