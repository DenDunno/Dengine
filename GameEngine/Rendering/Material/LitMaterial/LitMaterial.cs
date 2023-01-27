
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
        Bridge.SetValue("hasTexture", hasTexture);

        Data.Base?.Use();
        Bridge.SetValue("baseColor", Data.Color);
    }
}