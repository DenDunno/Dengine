using System.Drawing;
using OpenTK.Mathematics;

public class ParticleSystemData
{
    public AnimationCurve<float> Size { get; init; } = new(1);
    public AnimationCurve<Color> Color { get; init; } = new(System.Drawing.Color.White);
    public AnimationCurve<Vector3> Rotation { get; init; } = new(Vector3.Zero);
    public float LifeTime = 5f;
}