
public class LitMaterial : Material
{
    [EditorField] public readonly LitMaterialData Data;

    public LitMaterial(LitMaterialData data) : base(Paths.GetShader("vert"), Paths.GetShader("lit"))
    {
        Data = data;
    }

    protected override void OnInit()
    {
        Data.Base?.Load();
    }

    protected override void OnUse()
    {
        int hasTexture = Convert.ToInt32(Data.Base != null);
        Bridge.SetInt("hasTexture", hasTexture);

        Data.Base?.Bind();
        Bridge.SetColor("baseColor", Data.Color);
    }
}