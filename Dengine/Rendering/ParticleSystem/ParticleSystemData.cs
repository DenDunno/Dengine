using System.Drawing;
using OpenTK.Mathematics;

public class ParticleSystemData
{
    public float[] Size = { 1 };
    public Color[] Color = { System.Drawing.Color.White };
    public Vector3 Rotation;
    public int ParticlesPerSecond { get; init; } = 100;
    public float LifeTime { get; init; } = 1f;
    public int Pool { get; init; } = 100_000;
    public float Speed { get; init; } = 4f;
    public IMeshDataSource MeshDataSource { get; init; } = new QuadMeshData(1f);
}