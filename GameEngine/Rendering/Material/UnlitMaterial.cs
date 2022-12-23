using System.Drawing;

public class UnlitMaterial : Material
{
    [EditorField] private readonly Color _color = Color.White;

    public UnlitMaterial() : base(Paths.GetShader("vert"), Paths.GetShader("unlit"))
    {
    }

    protected override void OnUse()
    {
        Bridge.SetColor("baseColor", _color);
    }
}