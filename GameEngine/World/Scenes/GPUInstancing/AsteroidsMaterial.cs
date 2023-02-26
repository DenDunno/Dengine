using System.Drawing;

public class AsteroidsMaterial : Material
{
    [EditorField] private readonly LitMaterialData _data;

    public AsteroidsMaterial(LitMaterialData data) : base(Paths.GetShader("Asteroids/vert"), Paths.GetShader("lit"))
    {
        _data = data;
    }

    protected override void OnInit()
    {
        _data.Base?.Load();
        Bridge.SetFloat("ambientValue", 1f);
        Bridge.SetInt("hasTexture", 1);
        Bridge.SetColor("lightColor", Color.White);
        Bridge.SetColor("baseColor", _data.Color);
    }

    protected override void OnUse()
    {
        _data.Base?.Use();
    }
}