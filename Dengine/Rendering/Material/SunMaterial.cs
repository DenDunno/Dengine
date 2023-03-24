using System.Drawing;

public class SunMaterial : Material
{
    private readonly float _intensity = 2;
    private readonly int _resolution = 40;
    private readonly Color _colorMin = Color.FromArgb(255, 255, 60, 7);
    private readonly Color _colorMax = Color.Yellow;

    public SunMaterial() : base(Paths.GetShader("vert"), Paths.GetShader("sun"))
    {
    }

    protected override void OnInit()
    {
        Bridge.SetFloat("intensity", _intensity);
        Bridge.SetFloat("resolution", _resolution);
        Bridge.SetColor("colorMin", _colorMin);
        Bridge.SetColor("colorMax", _colorMax);
    }
}