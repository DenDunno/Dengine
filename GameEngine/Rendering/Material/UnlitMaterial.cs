using System.Drawing;

public class UnlitMaterial : Material
{
    [EditorField] private readonly Color _color = Color.White;

    public UnlitMaterial() : base("Shaders/vert.glsl", "Shaders/unlit.glsl")
    {
    }

    protected override void OnUse()
    {
        Bridge.SetColor("color", _color);
    }
}