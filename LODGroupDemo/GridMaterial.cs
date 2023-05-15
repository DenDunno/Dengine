using System.Drawing;
using OpenTK.Mathematics;

public class GridMaterial : Material
{
    [EditorField] private readonly Vector2 _value = new(43.650f, 0.35f);
    [EditorField] private readonly ColorVector4 _quadColor = new(Color.FromArgb(255, 26, 97, 0));
    [EditorField] private readonly ColorVector4 _voidColor = new(Color.FromArgb(255, 76, 61, 0));
    
    public GridMaterial() : base(Paths.GetShader("vert"), Paths.GetShader("grid"))
    {
    }

    protected override void OnUse()
    {
        Bridge.SetVector2("gridValue", _value);
        Bridge.SetVector4("quadColor", _quadColor.Value.ToOpenTk());
        Bridge.SetVector4("voidColor", _voidColor.Value.ToOpenTk());
    }
}