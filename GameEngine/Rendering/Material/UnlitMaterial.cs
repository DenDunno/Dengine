using System.Drawing;

public class UnlitMaterial : Material
{
    [EditorField] private readonly Color _color = Color.White;

    public UnlitMaterial(string vertexPath, string fragmentPath) : base(vertexPath, fragmentPath)
    {
    }

    protected override void OnUse()
    {
        Bridge.SetColor("color", _color);
    }
}