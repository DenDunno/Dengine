using OpenTK.Mathematics;

public class Mesh
{
    public float[] VerticesData { get; init; } = Array.Empty<float>();
    public uint[] Indices { get; init; } = Array.Empty<uint>();
    public Vector3[] LocalVertexPositions = Array.Empty<Vector3>();
}