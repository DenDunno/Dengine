using System.Drawing;
using OpenTK.Mathematics;

public class GridMaterial : Material
{
    [EditorField] private readonly Vector2 _value = new(28.250f, 0.4f);
    [EditorField] private readonly ColorVector4 _quadColor = new(Color.MediumPurple);
    [EditorField] private readonly ColorVector4 _voidColor = new(Color.Black);
    
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