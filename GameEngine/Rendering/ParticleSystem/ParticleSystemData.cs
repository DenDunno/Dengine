using System.Drawing;
using OpenTK.Mathematics;

public class ParticleSystemData
{
    public AnimationCurve<float> Size { get; init; } = new(1);
    public AnimationCurve<Color> Color { get; init; } = new(System.Drawing.Color.White);
    public AnimationCurve<Vector3> Rotation { get; init; } = new(Vector3.Zero);
    public int ParticlesPerSecond { get; init; } = 100;
    public float LifeTime { get; init; } = 1f;
    public int Pool { get; init; } = 100_000;
    public float Speed { get; init; } = 4f;
    public IMeshDataSource MeshDataSource { get; init; } = new QuadMeshData(1f);
}