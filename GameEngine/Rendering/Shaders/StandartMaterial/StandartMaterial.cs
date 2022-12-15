
public class StandartMaterial : Material
{
    private readonly StandartMaterialData _data;

    public StandartMaterial(string vertexShaderPath, string fragmentShaderPath, StandartMaterialData data)
        : base(vertexShaderPath, fragmentShaderPath)
    {
        _data = data;
    }

    protected override void OnInit()
    {
        _data.Texture?.Load();
    }

    protected override void OnUse()
    {
        _data.Texture?.Use();
    }
}